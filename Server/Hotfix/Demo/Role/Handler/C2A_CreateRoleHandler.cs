using System;
<<<<<<< HEAD

namespace ET
{
=======
using System.Collections.Generic;

namespace ET
{
    [FriendClassAttribute(typeof (ET.TokenComponent))]
>>>>>>> main
    [FriendClassAttribute(typeof (ET.RoleInfo))]
    public class C2A_CreateRoleHandler: AMRpcHandler<C2A_CreateRole, A2C_CreateRole>
    {
        protected override async ETTask Run(Session session, C2A_CreateRole request, A2C_CreateRole response, Action reply)
        {
<<<<<<< HEAD
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
                session.Disconnect().Coroutine();
                return;
            }

            string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);

            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                Log.Debug($"现在的Token为{request.Token}");
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_RoleNameIsNull;
                reply();
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRole, request.AccountId))
                {
                    var roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                            .Query<RoleInfo>(d => d.Name == request.Name && d.ServerId == request.ServerId);
                    if (roleInfos != null && roleInfos.Count > 0)
                    {
                        response.Error = ErrorCode.ERR_RoleNameSame;
                        reply();
                        return;
                    }

                    RoleInfo newRoleInfo = session.AddChildWithId<RoleInfo>(IdGenerater.Instance.GenerateUnitId(request.ServerId));
                    newRoleInfo.Name = request.Name;
                    newRoleInfo.State = (int)RoleInfoState.Normal;
                    newRoleInfo.ServerId = request.ServerId;
                    newRoleInfo.AccountId = request.AccountId;
                    newRoleInfo.CreateTime = TimeHelper.ServerNow();
                    newRoleInfo.LastLoginTime = 0;

                    await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<RoleInfo>(newRoleInfo);
                    response.RoleInfo = newRoleInfo.ToMessage();
                    reply();

                    newRoleInfo?.Dispose();
                }
=======
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

                if (string.IsNullOrEmpty(request.Name))
                {
                    response.Error = ErrorCode.ERR_ErrorToken;
                    reply();
                    return;
                }

                using (session.AddComponent<SessionLockingComponent>())
                {
                    using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRoleLock, request.AccountId))
                    {
                        var roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                                .Query<RoleInfo>(d =>
                                        d.Name == request.Name && d.ServerId == request.ServerId);

                        if (roleInfos != null && roleInfos.Count > 0) //当前的accountid没有角色，可以创建
                        {
                            response.Error = ErrorCode.ERR_ERRRoleHasContain;
                            reply();
                            return;
                        }

                        RoleInfo newRoleInfo = session.AddChildWithId<RoleInfo>(IdGenerater.Instance.GenerateUnitId(request.ServerId));
                        newRoleInfo.Name = request.Name;
                        newRoleInfo.ServerId = request.ServerId;
                        newRoleInfo.LastLoginTime = 0;
                        newRoleInfo.CreateTime = TimeHelper.ServerNow();
                        newRoleInfo.AccountId = request.AccountId;
                        newRoleInfo.State = (int)RoleState.Normal;
                        await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<RoleInfo>(newRoleInfo);
                        response.RoleInfo = newRoleInfo.ToMessage();
                        reply();
                        newRoleInfo?.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
>>>>>>> main
            }
        }
    }
}