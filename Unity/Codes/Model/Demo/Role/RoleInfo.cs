namespace ET
{
    public enum RoleState
    {
        Normal = 0,
        Freeze = 1
    }

    [ChildType()]
    [ComponentOf(typeof(Scene))]
    public class RoleInfo: Entity, IAwake
    {
        public string Name;
        public long AccountId;
        public long CreateTime;
        public long LastLoginTime;
        public int ServerId;
        public int State;
    }
}