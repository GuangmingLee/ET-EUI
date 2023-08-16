using System.Collections.Generic;

namespace ET
{
<<<<<<< HEAD
    [ChildType]
    [ComponentOf(typeof (Scene))]
=======
    [ComponentOf(typeof (Scene))]
    [ChildType()]
>>>>>>> main
    public class RoleInfosComponent: Entity, IAwake, IDestroy
    {
        public List<RoleInfo> RoleInfos = new List<RoleInfo>();
        public long CurrentRoleId = 0;
    }
}