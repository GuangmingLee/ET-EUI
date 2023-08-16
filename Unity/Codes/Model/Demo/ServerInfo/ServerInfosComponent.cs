using System.Collections.Generic;

namespace ET
{
<<<<<<< HEAD
    [ChildType]
    [ComponentOf(typeof (Scene))]
    public class ServerInfosComponent: Entity, IAwake, IDestroy
    {
        public List<ServerInfo> ServerInfoList = new List<ServerInfo>();
        public int CurrentServerId;
=======
    [ComponentOf(typeof (Scene))]
    [ChildType()]
    public class ServerInfosComponent: Entity, IAwake, IDestroy
    {
        public List<ServerInfo> serverInfoList = new List<ServerInfo>();
        public int CurrentServerId = 0;
>>>>>>> main
    }
}