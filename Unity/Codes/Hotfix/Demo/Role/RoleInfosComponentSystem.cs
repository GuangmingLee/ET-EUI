using System;

namespace ET
{
    public class RoleInfosComponentDestroySystem: DestroySystem<RoleInfosComponent>
    {
        public override void Destroy(RoleInfosComponent self)
        {
            foreach (var roleinfo in self.RoleInfos)
            {
                roleinfo?.Dispose();
            }

            self.RoleInfos.Clear();
            self.CurrentRoleId = 0;
        }
    }

    public static class RoleInfosComponentSystem
    {
    }
}