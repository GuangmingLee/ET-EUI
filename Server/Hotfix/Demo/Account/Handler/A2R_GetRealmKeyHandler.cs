using System;

namespace ET
{
    [ActorMessageHandler]
    [FriendClassAttribute(typeof (ET.TokenComponent))]
    public class A2R_GetRealmKeyHandler: AMActorRpcHandler<Scene, A2R_GetRealmKey, R2A_GetRealmKey>
    {
        protected override async ETTask Run(Scene scene, A2R_GetRealmKey request, R2A_GetRealmKey response, Action reply)
        {
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccountLock, request.AccountId))
            {
                if (scene.SceneType != SceneType.Realm)
                {
                    Log.Error($"当前类型错误{scene.SceneType}");
                    response.Error = ErrorCode.ERR_RequestSceneTypeError;
                    reply();
                    return;
                }
            }

            string key = TimeHelper.ServerNow().ToString() + RandomHelper.RandInt64().ToString();
            scene.GetComponent<TokenComponent>().Remove(request.AccountId);
            scene.GetComponent<TokenComponent>().Add(request.AccountId, key);
            response.RealmKey = key;
            reply();
        }
    }
}