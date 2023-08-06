namespace ET
{
    [FriendClassAttribute(typeof(ET.ServerInfo))]
    public static class ServerInfoSystem
    {
        public static void FromMessage(this ServerInfo self, ServerInfoProto proto)
        {
            self.serverName = proto.ServerName;
            self.ServerStatus = proto.Status;
            self.Id = proto.Id;
        }

        public static ServerInfoProto ToMessage(this ServerInfo self)
        {
            return new ServerInfoProto() { Id = (int)self.Id, ServerName = self.serverName, Status = self.ServerStatus };
        }
    }
}