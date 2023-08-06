using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof (Scene))]
    [ChildType()]
    public class ServerInfosComponent: Entity, IAwake, IDestroy
    {
        public List<ServerInfo> serverInfoList = new List<ServerInfo>();
        public int CurrentServerId = 0;
    }
}