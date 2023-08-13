namespace ET
{
    public static class DisconnectHelper
    {
        public static async ETTask Disconnect(this Session self)
        {
            if (self == null && self.IsDisposed)
            {
                return;
            }

            long instanceId = self.InstanceId;
            await TimerComponent.Instance.WaitAsync(1000);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.Dispose();
        }

        public static async ETTask KickPlayer(Player player)
        {
            if (player == null || player.IsDisposed)
            {
                return;
            }

            long instanceid = player.InstanceId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, player.Account.GetHashCode()))
            {
                if (player.IsDisposed || instanceid != player.InstanceId)
                {
                    return;
                }

                switch (player.playerState)
                {
                    case PlayerState.Disconnect:
                        break;
                    case PlayerState.Gate:
                        break;
                    case PlayerState.Game:
                        //TODO 通知游戏逻辑服下线逻辑，并将数据存入数据库
                        break;
                }

                player.playerState = (int)PlayerState.Disconnect;
                player.DomainScene().GetComponent<PlayerComponent>()?.Remove(player.Account);
                player?.Dispose();
                await TimerComponent.Instance.WaitAsync(300);
            }
        }
    }
}