<<<<<<< HEAD
﻿using System;

namespace ET
=======
﻿namespace ET
>>>>>>> main
{
    public class RoleInfosComponentDestroySystem: DestroySystem<RoleInfosComponent>
    {
        public override void Destroy(RoleInfosComponent self)
        {
<<<<<<< HEAD
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
=======
            foreach (var roleInfo in self.RoleInfos)
            {
                roleInfo?.Dispose();
            }
            self.RoleInfos.Clear();
        }
    }
>>>>>>> main
}