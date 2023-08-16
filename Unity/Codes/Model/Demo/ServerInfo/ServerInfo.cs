namespace ET
{
    public enum ServerStatus
    {
        Normal = 0,
<<<<<<< HEAD
        Stop = 1
    }

    public class ServerInfo: Entity, IAwake
    {
        public int Status { get; set; }
        public string ServerName { get; set; }
=======
        Stop = 1,
    }
    [ChildType()]
    public class ServerInfo: Entity, IAwake, IDestroy
    {
        public string serverName { get; set; }
        public int ServerStatus { get; set; }
>>>>>>> main
    }
}