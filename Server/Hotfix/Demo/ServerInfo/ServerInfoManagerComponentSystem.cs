<<<<<<< HEAD
﻿namespace ET
{
    public class ServerInfoManagerComponentAwake: AwakeSystem<ServerInfoManagerComponent>
=======
﻿using MongoDB.Driver.Core.Servers;

namespace ET
{
    public class ServerInfoManagerComponentAwakeSystem: AwakeSystem<ServerInfoManagerComponent>
>>>>>>> main
    {
        public override void Awake(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

<<<<<<< HEAD
    public class ServerInfoManagerComponentDestroy: DestroySystem<ServerInfoManagerComponent>
=======
    public class ServerInfoManagerComponentDestroySystem: DestroySystem<ServerInfoManagerComponent>
>>>>>>> main
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
<<<<<<< HEAD

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
=======
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
>>>>>>> main
                    self.ServerInfos.Add(newServerInfo);
                    await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(newServerInfo);
                }

                return;
            }

            self.ServerInfos.Clear();
<<<<<<< HEAD

            foreach (var serverInfo in serverInfoList)
            {
                self.AddChild(serverInfo);
                self.ServerInfos.Add(serverInfo);
=======
            foreach (var serverinfo in serverInfoList)
            {
                self.AddChild(serverinfo);
                self.ServerInfos.Add(serverinfo);
>>>>>>> main
            }

            await ETTask.CompletedTask;
        }
    }
}