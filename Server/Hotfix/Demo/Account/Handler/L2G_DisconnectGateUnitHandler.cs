﻿using System;

namespace ET
{
    [ActorMessageHandler]
    public class L2G_DisconnectGateUnitHandler: AMActorRpcHandler<Scene, L2G_DisconnectGateUnit, G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene scene, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response, Action reply)
        {
            long accountid = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, accountid.GetHashCode()))
            {
                PlayerComponent playerComponent = scene.GetComponent<PlayerComponent>();
                Player player = playerComponent.Get(accountid);

                if (player == null)
                {
                    reply();
                    return;
                }

                scene.GetComponent<GateSessionKeyComponent>().Remove(accountid);
                Session gateSession = Game.EventSystem.Get(player.SessionInstanceId) as Session;
                if (gateSession != null && !gateSession.IsDisposed)
                {
                    gateSession.Send(new A2C_DisConnect() { Error = ErrorCode.ERR_OtherAccountLogin });
                    gateSession?.Disconnect().Coroutine();
                }

                player.SessionInstanceId = 0;
                player.AddComponent<PlayerOfflineOutTimeComponent>();
            }

            reply();
        }
    }
}