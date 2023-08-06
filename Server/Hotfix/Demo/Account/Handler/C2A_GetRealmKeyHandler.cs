using System;

namespace ET
{
    [FriendClassAttribute(typeof (ET.TokenComponent))]
    public class C2A_GetRealmKeyHandler: AMRpcHandler<C2A_GetRealmKey, A2C_GetRealmKey>
    {
        protected override async ETTask Run(Session session, C2A_GetRealmKey request, A2C_GetRealmKey response, Action reply)
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
                    using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccountLock, request.AccountId))
                    {
                        StartSceneConfig realmstartSceneConfig = RealmGateAddressHelper.GetGate(request.ServerId, request.AccountId);
                        R2A_GetRealmKey r2AGetRealmKey = (R2A_GetRealmKey)await MessageHelper.CallActor(realmstartSceneConfig.Id,
                            new A2R_GetRealmKey() { AccountId = request.AccountId, });
                        if (r2AGetRealmKey.Error != ErrorCode.ERR_Success)
                        {
                            response.Error = r2AGetRealmKey.Error;
                            reply();
                            session?.Disconnect().Coroutine();
                            return;
                        }

                        response.RealmKey = r2AGetRealmKey.RealmKey;
                        response.RealmAddress = realmstartSceneConfig.OuterIPPort.ToString();
                        reply();
                        session?.Disconnect().Coroutine();
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