namespace ET
{
    public class AccountSessionsComponentDestroySystem: DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessionDicitionary.Clear();
        }
    }

    [FriendClass(typeof(AccountSessionsComponent))]
    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSessionDicitionary.TryGetValue(accountId, out long instanceId))
            {
                return 0;
            }

            return instanceId;
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long sessionInstanceId)
        {
            if (self.AccountSessionDicitionary.ContainsKey(accountId))
            {
                self.AccountSessionDicitionary[accountId] = sessionInstanceId;
                return;
            }

            self.AccountSessionDicitionary.Add(accountId, sessionInstanceId);
        }

        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if (self.AccountSessionDicitionary.ContainsKey(accountId))
            {
                self.AccountSessionDicitionary.Remove(accountId);
            }
        }
    }
}