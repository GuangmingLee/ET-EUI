namespace ET
{
    [FriendClassAttribute(typeof(ET.RoleInfo))]
    public static class RoleInfoSystem
    {
        public static void FromMessage(this RoleInfo self, RoleInfoProto roleInfoProto)
        {
            self.Id = roleInfoProto.Id;
            self.Name = roleInfoProto.Name;
            self.State = roleInfoProto.State;
<<<<<<< HEAD
            self.AccountId = roleInfoProto.AccountId;
            self.CreateTime = roleInfoProto.CreateTime;
            self.ServerId = roleInfoProto.ServerId;
            self.LastLoginTime = roleInfoProto.LastLoginTime;
=======
            self.CreateTime = roleInfoProto.CreateTime;
            self.LastLoginTime = roleInfoProto.LastLoginTime;
            self.AccountId = roleInfoProto.AccountId;
            self.ServerId = roleInfoProto.ServerId;
>>>>>>> main
        }

        public static RoleInfoProto ToMessage(this RoleInfo self)
        {
            return new RoleInfoProto()
            {
                Id = self.Id,
                Name = self.Name,
                State = self.State,
<<<<<<< HEAD
                AccountId = self.AccountId,
                CreateTime = self.CreateTime,
                ServerId = self.ServerId,
                LastLoginTime = self.LastLoginTime,
=======
                CreateTime = self.CreateTime,
                LastLoginTime = self.LastLoginTime,
                AccountId = self.AccountId,
                ServerId = self.ServerId
>>>>>>> main
            };
        }
    }
}