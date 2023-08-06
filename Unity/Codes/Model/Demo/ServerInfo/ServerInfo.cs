namespace ET
{
    public enum ServerStatus
    {
        Normal = 0,
        Stop = 1,
    }
    [ChildType()]
    public class ServerInfo: Entity, IAwake, IDestroy
    {
        public string serverName { get; set; }
        public int ServerStatus { get; set; }
    }
}