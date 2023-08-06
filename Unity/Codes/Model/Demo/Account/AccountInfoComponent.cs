namespace ET
{
    [ComponentOf(typeof (Scene))]
    public class AccountInfoComponent: Entity, IAwake, IDestroy
    {
        public string token;
        public long accountId;
        public string realmKey;
        public string realmAddress;
    }
}