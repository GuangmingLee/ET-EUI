namespace ET
{
<<<<<<< HEAD
    public static class ServerInfoSystem
    {
        public static void FromMessage(this ServerInfo self, ServerInfoProto serverInfoProto)
        {
            self.Id = serverInfoProto.Id;
            self.Status = serverInfoProto.Status;
            self.ServerName = serverInfoProto.ServerName;
=======
    [FriendClassAttribute(typeof(ET.ServerInfo))]
    public static class ServerInfoSystem
    {
        public static void FromMessage(this ServerInfo self, ServerInfoProto proto)
        {
            self.serverName = proto.ServerName;
            self.ServerStatus = proto.Status;
            self.Id = proto.Id;
>>>>>>> main
        }

        public static ServerInfoProto ToMessage(this ServerInfo self)
        {
<<<<<<< HEAD
            return new ServerInfoProto() { Id = (int)self.Id, ServerName = self.ServerName, Status = self.Status };
=======
            return new ServerInfoProto() { Id = (int)self.Id, ServerName = self.serverName, Status = self.ServerStatus };
>>>>>>> main
        }
    }
}