using MongoDB.Driver.Core.Servers;

namespace ET
{
    public class ServerInfoManagerComponentAwakeSystem: AwakeSystem<ServerInfoManagerComponent>
    {
        public override void Awake(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

    public class ServerInfoManagerComponentDestroySystem: DestroySystem<ServerInfoManagerComponent>
    {
        public override void Destroy(ServerInfoManagerComponent self)
        {
            foreach (var serverinfo in self.ServerInfos)
            {
                serverinfo?.Dispose();
            }

            self.ServerInfos.Clear();
        }
    }

    public class ServerInfoManagerComponentLoadSystem: LoadSystem<ServerInfoManagerComponent>
    {
        public override void Load(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

    [FriendClassAttribute(typeof (ET.ServerInfoManagerComponent))]
    public static class ServerInfoManagerComponentSystem
    {
        public static async ETTask Awake(this ServerInfoManagerComponent self)
        {
            var serverInfoList = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<ServerInfo>(d => true);
            if (serverInfoList == null || serverInfoList.Count <= 0)
            {
                Log.Error("serverInfo is null");
                self.ServerInfos.Clear();

                var serverInfoConfig = ServerInfoConfigCategory.Instance.GetAll();

                foreach (var info in serverInfoConfig.Values)
                {
                    ServerInfo newServerInfo = self.AddChildWithId<ServerInfo>(info.Id);
                    newServerInfo.ServerStatus = (int)ServerStatus.Normal;
                    newServerInfo.serverName = info.ServerName;
                    self.ServerInfos.Add(newServerInfo);
                    await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(newServerInfo);
                }

                return;
            }

            self.ServerInfos.Clear();
            foreach (var serverinfo in serverInfoList)
            {
                self.AddChild(serverinfo);
                self.ServerInfos.Add(serverinfo);
            }

            await ETTask.CompletedTask;
        }
    }
}