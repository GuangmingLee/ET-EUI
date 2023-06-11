namespace ET
{
    public enum RoleInfoState
    {
        Normal = 0,
        Freeze,
    }
    
    public class RoleInfo: Entity, IAwake
    {
        public string Name;
        public int State;
        public long AccountId;
        public long CreateTime;
        public int ServerId;
        public long LastLoginTime;
    }
}