using System.Collections.Generic;

namespace ET
{
    [ChildType]
    [ComponentOf(typeof (Scene))]
    public class ServerInfosComponent: Entity, IAwake, IDestroy
    {
        public List<ServerInfo> ServerInfoList = new List<ServerInfo>();
        public long CurrentServerId = 0;
    }
}