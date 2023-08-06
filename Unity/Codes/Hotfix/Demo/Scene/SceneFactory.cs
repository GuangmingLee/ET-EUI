namespace ET
{
    public static class SceneFactory
    {
        public static Scene CreateZoneScene(int zone, string name, Entity parent)
        {
            Scene zoneScene = EntitySceneFactory.CreateScene(Game.IdGenerater.GenerateInstanceId(), zone, SceneType.Zone, name, parent);
            zoneScene.AddComponent<ZoneSceneFlagComponent>();
            zoneScene.AddComponent<NetKcpComponent, int>(SessionStreamDispatcherType.SessionStreamDispatcherClientOuter);
            zoneScene.AddComponent<CurrentScenesComponent>();
            zoneScene.AddComponent<ObjectWait>();
            zoneScene.AddComponent<PlayerComponent>();
            zoneScene.AddComponent<AccountInfoComponent>(); //添加的用户信息组件
            zoneScene.AddComponent<ServerInfosComponent>(); //添加的服务器信息组件
            zoneScene.AddComponent<RoleInfosComponent>(); //添加角色信息组件

            Game.EventSystem.Publish(new EventType.AfterCreateZoneScene() { ZoneScene = zoneScene });
            return zoneScene;
        }

        public static Scene CreateCurrentScene(long id, int zone, string name, CurrentScenesComponent currentScenesComponent)
        {
            Scene currentScene = EntitySceneFactory.CreateScene(id, IdGenerater.Instance.GenerateInstanceId(), zone, SceneType.Current, name,
                currentScenesComponent);
            currentScenesComponent.Scene = currentScene;

            Game.EventSystem.Publish(new EventType.AfterCreateCurrentScene() { CurrentScene = currentScene });
            return currentScene;
        }
    }
}