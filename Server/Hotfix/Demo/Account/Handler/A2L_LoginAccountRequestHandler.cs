using System;

namespace ET
{
    [ActorMessageHandler]
    public class A2L_LoginAccountRequestHandler: AMActorRpcHandler<Scene, A2L_LoginAccountRequest, L2A_LoginAccountResponse>
    {
        protected override async ETTask Run(Scene scene, A2L_LoginAccountRequest request, L2A_LoginAccountResponse response, Action reply)
        {
<<<<<<< HEAD
            long accountId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock, accountId.GetHashCode()))
            {
                if (!scene.GetComponent<LoginInfoRecordComponent>().IsExist(accountId))
=======
            long accountid = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock, accountid.GetHashCode()))
            {
                if (!scene.GetComponent<LoginInfoRecordComponent>().isExits(accountid))
>>>>>>> main
                {
                    reply();
                    return;
                }

<<<<<<< HEAD
                int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountId);

                StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(zone, accountId);

                var g2LDisconnectGateUnit =
                        (G2L_DisconnectGateUnit)await MessageHelper.CallActor(gateConfig.InstanceId,
                            new L2G_DisconnectGateUnit() { AccountId = accountId });
=======
                int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountid);
                StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(zone, accountid);

                var g2LDisconnectGateUnit =
                        (G2L_DisconnectGateUnit)await MessageHelper.CallActor(gateConfig.InstanceId,
                            new L2G_DisconnectGateUnit() { AccountId = accountid });
>>>>>>> main
                response.Error = g2LDisconnectGateUnit.Error;
                reply();
            }
        }
    }
}