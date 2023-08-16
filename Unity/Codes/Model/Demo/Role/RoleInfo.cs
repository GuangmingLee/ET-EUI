namespace ET
{
<<<<<<< HEAD
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
=======
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
>>>>>>> main
    }
}