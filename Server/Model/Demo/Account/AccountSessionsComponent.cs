using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(Session))]
    public class AccountSessionsComponent : Entity,IAwake,IDestroy
    {
        public Dictionary<long, long> AccountSessionDicitionary = new Dictionary<long, long>();
    }
}