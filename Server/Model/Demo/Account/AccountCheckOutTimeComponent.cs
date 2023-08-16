namespace ET
{
    [ComponentOf(typeof(Session))]
<<<<<<< HEAD
    public class AccountCheckOutTimeComponent : Entity, IAwake<long>, IDestroy
    {
        public long Timer = 0;

        public long AccountId = 0;
        
=======
    public class AccountCheckOutTimeComponent: Entity, IAwake<long>, IDestroy
    {
        public long Timer = 0;
        public long AccountId = 0;
>>>>>>> main
    }
}