using System;

namespace ET
{
    public class R2G_GetLoginGateKeyHandler: AMActorRpcHandler<Scene, R2G_GetLoginGateKey, G2R_GetLoginGateKey>
    {
        protected override async ETTask Run(Scene scene, R2G_GetLoginGateKey request, G2R_GetLoginGateKey response, Action reply)
        {
            if (SceneType.Gate != scene.SceneType)
            {
                Log.Error($"类型错误：{scene.SceneType}");
                return;
            }

            string key = RandomHelper.RandInt64().ToString() + TimeHelper.ServerNow().ToString();
            scene.GetComponent<GateSessionKeyComponent>().Remove(request.AccountId);
            scene.GetComponent<GateSessionKeyComponent>().Add(request.AccountId, key);
            response.GateSessionKey = key;
            reply();
            await ETTask.CompletedTask;
        }
    }
}