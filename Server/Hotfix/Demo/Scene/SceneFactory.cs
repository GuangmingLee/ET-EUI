using System.Net;

namespace ET
{
    public static class SceneFactory
    {
        public static async ETTask<Scene> Create(Entity parent, string name, SceneType sceneType)
        {
            long instanceId = IdGenerater.Instance.GenerateInstanceId();
            return await Create(parent, instanceId, instanceId, parent.DomainZone(), name, sceneType);
        }

        public static async ETTask<Scene> Create(Entity parent, long id, long instanceId, int zone, string name, SceneType sceneType,
        StartSceneConfig startSceneConfig = null)
        {
            await ETTask.CompletedTask;
            Scene scene = EntitySceneFactory.CreateScene(id, instanceId, zone, sceneType, name, parent);

            scene.AddComponent<MailBoxComponent, MailboxType>(MailboxType.UnOrderMessageDispatcher);

            switch (scene.SceneType)
            {
                case SceneType.Realm:
                    scene.AddComponent<NetKcpComponent, IPEndPoint, int>(startSceneConfig.OuterIPPort,
                        SessionStreamDispatcherType.SessionStreamDispatcherServerOuter);
<<<<<<< HEAD
=======
                    scene.AddComponent<TokenComponent>();
>>>>>>> main
                    break;
                case SceneType.Gate:
                    scene.AddComponent<NetKcpComponent, IPEndPoint, int>(startSceneConfig.OuterIPPort,
                        SessionStreamDispatcherType.SessionStreamDispatcherServerOuter);
                    scene.AddComponent<PlayerComponent>();
                    scene.AddComponent<GateSessionKeyComponent>();
                    break;
                case SceneType.Map:
                    scene.AddComponent<UnitComponent>();
                    scene.AddComponent<AOIManagerComponent>();
                    break;
                case SceneType.Location:
                    scene.AddComponent<LocationComponent>();
                    break;
                case SceneType.Account:
                    scene.AddComponent<NetKcpComponent, IPEndPoint, int>(startSceneConfig.OuterIPPort,
                        SessionStreamDispatcherType.SessionStreamDispatcherServerOuter);
<<<<<<< HEAD
                    scene.AddComponent<TokenComponent>();
                    scene.AddComponent<AccountSessionsComponent>();
                    scene.AddComponent<ServerInfoManagerComponent>();
=======
                    scene.AddComponent<TokenComponent>(); //添加token组件
                    scene.AddComponent<AccountSessionsComponent>(); //添加账户连接组件
                    scene.AddComponent<ServerInfosComponent>(); //添加服务器列表信息组件
                    scene.AddComponent<ServerInfoManagerComponent>(); //
>>>>>>> main
                    break;
                case SceneType.LoginCenter:
                    scene.AddComponent<LoginInfoRecordComponent>();
                    break;
<<<<<<< HEAD
                
=======
>>>>>>> main
            }

            return scene;
        }
    }
}