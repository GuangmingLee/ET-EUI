namespace ET
{
    public enum AccountType
    {
        General =0,
        BlackList =1
    }
    [ChildType()]
    public class Account: Entity, IAwake
    {
        public string AccountName;
        public string Password;
        public int AccountType;
        public long CreateTime;
    }
}