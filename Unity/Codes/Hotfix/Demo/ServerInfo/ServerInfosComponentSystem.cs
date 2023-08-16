namespace ET
{
    public class ServerInfosComponentDestroySystem: DestroySystem<ServerInfosComponent>
    {
        public override void Destroy(ServerInfosComponent self)
        {
<<<<<<< HEAD
            foreach (var serverInfo in self.ServerInfoList)
=======
            foreach (var serverInfo in self.serverInfoList)
>>>>>>> main
            {
                serverInfo?.Dispose();
            }

<<<<<<< HEAD
            self.ServerInfoList.Clear();
            self.CurrentServerId = 0;
        }
    }

    [FriendClassAttribute(typeof (ET.ServerInfosComponent))]
    public static class ServerInfosComponentSystem
    {
        public static void Add(this ServerInfosComponent self, ServerInfo serverInfo)
        {
            self.ServerInfoList.Add(serverInfo);
            self.CurrentServerId = (int)serverInfo.Id;
=======
            self.serverInfoList.Clear();
        }
    }
    [FriendClassAttribute(typeof(ET.ServerInfosComponent))]
    public static class ServerInfosComponentSystem
    {
        public static void Add(ServerInfosComponent self, ServerInfo serverInfo)
        {
            self.serverInfoList.Add(serverInfo);
>>>>>>> main
        }
    }
}