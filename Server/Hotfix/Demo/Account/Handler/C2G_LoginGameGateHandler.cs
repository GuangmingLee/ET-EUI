﻿using System;

namespace ET
{
    [FriendClassAttribute(typeof (ET.SessionPlayerComponent))]
    public class C2G_LoginGameGateHandler: AMRpcHandler<C2G_LoginGameGate, G2C_LoginGameGate>
    {
        protected override async ETTask Run(Session session, C2G_LoginGameGate request, G2C_LoginGameGate response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Gate)
            {
                Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session?.Dispose();
                return;
            }

            session.RemoveComponent<SessionAcceptTimeoutComponent>();
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                return;
            }

            Scene scene = session.DomainScene();

            string tokenKey = scene.GetComponent<GateSessionKeyComponent>().Get(request.Account);
            if (tokenKey == null || tokenKey != request.Key)
            {
                response.Error = ErrorCode.ERR_ErrorToken;
                response.Message = "Gate Key验证失败";
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            scene.GetComponent<GateSessionKeyComponent>().Remove(request.Account);

            long instansceid = session.InstanceId;
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, request.Account.GetHashCode()))
                {
                    if (instansceid != session.InstanceId)
                    {
                        return;
                    }

                    StartSceneConfig loginCenterConfig = StartSceneConfigCategory.Instance.LoginCenterConfig;

                    L2G_AddLoginRecord l2GAddLoginRecord = (L2G_AddLoginRecord)await MessageHelper.CallActor(loginCenterConfig.InstanceId,
                        new G2L_AddLoginRecord() { AccountId = request.Account, ServerId = session.DomainScene().DomainZone(), });
                    if (l2GAddLoginRecord.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = l2GAddLoginRecord.Error;
                        reply();
                        session?.Disconnect().Coroutine();
                        return;
                    }

                    Player player = scene.GetComponent<PlayerComponent>().Get(request.Account);//唯一值

                    if (player == null)
                    {
                        player = scene.GetComponent<PlayerComponent>()
                                .AddChildWithId<Player, long, long>(request.RoleId, request.Account, request.RoleId);
                        player.playerState = PlayerState.Gate;
                        scene.GetComponent<PlayerComponent>().Add(player);
                        session.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);
                    }
                    else
                    {
                        player.RemoveComponent<PlayerOfflineOutTimeComponent>(); //断线逻辑处理
                    }

                    session.AddComponent<SessionPlayerComponent>().PlayerId = player.Id;
                    session.GetComponent<SessionPlayerComponent>().PlayerInstanceId = player.InstanceId;
                    session.GetComponent<SessionPlayerComponent>().AccountId = request.Account;
                    player.SessionInstanceId = session.InstanceId;
                }
            }

            await ETTask.CompletedTask;
        }
    }
}