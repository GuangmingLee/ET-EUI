using System;

namespace ET
{
    [ActorMessageHandler]
    public class L2G_DisconnectGateUnitHandler: AMActorRpcHandler<Scene, L2G_DisconnectGateUnit, G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene scene, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response, Action reply)
        {

                long accountid = request.AccountId;
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.GateLoginLock, accountid.GetHashCode()))
                {
                    PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
                    Player gateUnit = playerComponent.Get(accountid);

                    if (gateUnit == null)
                    {
                        reply();
                        return;
                    }

                    playerComponent.Remove(accountid);
                    gateUnit.Dispose();
                }

                reply();
        }
    }
}