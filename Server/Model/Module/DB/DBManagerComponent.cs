namespace ET
{
<<<<<<< HEAD
    [ComponentOf(typeof (Scene))]
    [ChildType(typeof (DBComponent))]
=======
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(DBComponent))]
>>>>>>> main
    public class DBManagerComponent: Entity, IAwake, IDestroy
    {
        public static DBManagerComponent Instance;

        public DBComponent[] DBComponents = new DBComponent[IdGenerater.MaxZone];
    }
}