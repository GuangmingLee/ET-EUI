﻿using System;

namespace ET
{
    [FriendClassAttribute(typeof (ET.TokenComponent))]
    [FriendClassAttribute(typeof (ET.RoleInfo))]
    public class C2A_DeleteRoleHandler: AMRpcHandler<C2A_DeleteRole, A2C_DeleteRole>
    {
        protected override async ETTask Run(Session session, C2A_DeleteRole request, A2C_DeleteRole response, Action reply)
        {
            try
            {
                if (session.DomainScene().SceneType != SceneType.Account)
                {
                    Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                    session.Dispose();
                    return;
                }

                if (session.GetComponent<SessionLockingComponent>() != null)
                {
                    response.Error = ErrorCode.ERR_RequestRepeatedly;
                    reply();
                    session?.Disconnect().Coroutine();
                    return;
                }

                var token = session.DomainScene().GetComponent<TokenComponent>().TokenDictionary[request.AccountId];
                if (token == null || token != request.Token)
                {
                    response.Error = ErrorCode.ERR_ErrorToken;
                    reply();
                    session?.Disconnect().Coroutine();
                }

                using (session.AddComponent<SessionLockingComponent>())
                {
                    using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRoleLock, request.AccountId))
                    {
                        var roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                                .Query<RoleInfo>(d =>
                                        d.Id == request.RoleInfoId && d.ServerId == request.ServerId &&
                                        d.State == (int)RoleState.Normal);
                        if (roleInfos == null || roleInfos.Count <= 0)
                        {
                            response.Error = ErrorCode.ERR_ERRRoleIsNull;
                            reply();
                            return;
                        }

                        roleInfos[0].State = (int)RoleState.Freeze;
                        session.AddChild(roleInfos[0]);
                        await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<RoleInfo>(roleInfos[0]);
                        response.DeletedRoleInfoId = roleInfos[0].Id;
                        reply();
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}