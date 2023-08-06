using System;

namespace ET
{
    [FriendClassAttribute(typeof (ET.TokenComponent))]
    [FriendClassAttribute(typeof (ET.RoleInfo))]
    public class C2A_GetRoleHandler: AMRpcHandler<C2A_GetRoles, A2C_GetRoles>
    {
        protected override async ETTask Run(Session session, C2A_GetRoles request, A2C_GetRoles response, Action reply)
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

                using (session.GetComponent<SessionLockingComponent>())
                {
                    using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRoleLock, request.AccountId))
                    {
                        var roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                                .Query<RoleInfo>(d =>
                                        d.AccountId == request.AccountId && d.ServerId == request.ServerId && d.State == (int)RoleState.Normal);

                        if (roleInfos == null || roleInfos.Count == 0)
                        {
                            reply();
                            return;
                        }

                        response.RoleInfo.Clear();
                        foreach (var info in roleInfos)
                        {
                            response.RoleInfo.Add(info.ToMessage());
                            info?.Dispose();
                        }

                        roleInfos.Clear();
                        reply();
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return;
            }

            await ETTask.CompletedTask;
        }
    }
}