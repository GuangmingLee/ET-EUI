using ET;

namespace ET
{
    public class AccountInfoComponentDestroySystem: DestroySystem<AccountInfoComponent>
    {
        public override void Destroy(AccountInfoComponent self)
        {
            self.token = null;
            self.accountId = 0;
            self.realmAddress = null;
            self.realmKey = null;
        }
    }

    public static class AccountInfoComponentSystem
    {
    }
}