namespace ET
{
    public class ServerInfosComponentDestroySystem: DestroySystem<ServerInfosComponent>
    {
        public override void Destroy(ServerInfosComponent self)
        {
            foreach (var serverInfo in self.serverInfoList)
            {
                serverInfo?.Dispose();
            }

            self.serverInfoList.Clear();
        }
    }
    [FriendClassAttribute(typeof(ET.ServerInfosComponent))]
    public static class ServerInfosComponentSystem
    {
        public static void Add(ServerInfosComponent self, ServerInfo serverInfo)
        {
            self.serverInfoList.Add(serverInfo);
        }
    }
}