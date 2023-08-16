<<<<<<< HEAD
﻿namespace ET
{
    public class AccountInfoComponentDestroySystem: DestroySystem<AccountInfoComponent>
    {

        public override void Destroy(AccountInfoComponent self)
        {
            self.Token = null;
            self.AccountId = 0;
=======
﻿using ET;

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
>>>>>>> main
        }
    }

    public static class AccountInfoComponentSystem
    {
<<<<<<< HEAD
            
=======
>>>>>>> main
    }
}