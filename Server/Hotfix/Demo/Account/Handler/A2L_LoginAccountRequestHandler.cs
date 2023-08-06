using System;

namespace ET
{
    [ActorMessageHandler]
    public class A2L_LoginAccountRequestHandler: AMActorRpcHandler<Scene, A2L_LoginAccountRequest, L2A_LoginAccountResponse>
    {
        protected override async ETTask Run(Scene scene, A2L_LoginAccountRequest request, L2A_LoginAccountResponse response, Action reply)
        {
            long accountid = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock, accountid.GetHashCode()))
            {
                if (!scene.GetComponent<LoginInfoRecordComponent>().isExits(accountid))
                {
                    reply();
                    return;
                }

                int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountid);
                StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(zone, accountid);

                var g2LDisconnectGateUnit =
                        (G2L_DisconnectGateUnit)await MessageHelper.CallActor(gateConfig.InstanceId,
                            new L2G_DisconnectGateUnit() { AccountId = accountid });
                response.Error = g2LDisconnectGateUnit.Error;
                reply();
            }
        }
    }
}