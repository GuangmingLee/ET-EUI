<<<<<<< HEAD
using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(Session))]
    public class AccountSessionsComponent : Entity,IAwake,IDestroy
    {
        public Dictionary<long, long> AccountSessionDicitionary = new Dictionary<long, long>();
=======
﻿using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof (Scene))]
    public class AccountSessionsComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<long, long> AccountSessionDictionary = new Dictionary<long, long>();
>>>>>>> main
    }
}