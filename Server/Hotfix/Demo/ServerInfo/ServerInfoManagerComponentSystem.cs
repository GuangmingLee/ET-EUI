﻿namespace ET
{
    public class ServerInfoManagerComponentAwake: AwakeSystem<ServerInfoManagerComponent>
    {
        public override void Awake(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

    public class ServerInfoManagerComponentDestroy: DestroySystem<ServerInfoManagerComponent>
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
                Log.Error("serverInfo count is zero");
                self.ServerInfos.Clear();
                var serverInfoConfigs = ServerInfoConfigCategory.Instance.GetAll();

                foreach (var info in serverInfoConfigs.Values)
                {
                    ServerInfo newServerInfo = self.AddChildWithId<ServerInfo>(info.Id);
                    newServerInfo.ServerName = info.ServerName;
                    newServerInfo.Status = (int)ServerStatus.Normal;
                    self.ServerInfos.Add(newServerInfo);
                    await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(newServerInfo);
                }

                return;
            }

            self.ServerInfos.Clear();

            foreach (var serverInfo in serverInfoList)
            {
                self.AddChild(serverInfo);
                self.ServerInfos.Add(serverInfo);
            }

            await ETTask.CompletedTask;
        }
    }
}