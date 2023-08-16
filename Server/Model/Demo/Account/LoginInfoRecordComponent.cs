using System.Collections.Generic;

namespace ET
{
<<<<<<< HEAD
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(Session))]
    public class LoginInfoRecordComponent : Entity,IAwake,IDestroy
    {
        public Dictionary<long, int> AccountLoginInfoDict = new Dictionary<long, int>();
=======
    [ComponentOf(typeof (Scene))]
    public class LoginInfoRecordComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<long, int> AccountInfoRecordDict = new Dictionary<long, int>();
>>>>>>> main
    }
}