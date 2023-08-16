using System;
<<<<<<< HEAD
=======
using System.Timers;
>>>>>>> main

namespace ET
{
    [Timer(TimerType.AccountSessionCheckOutTime)]
    public class AccountSessionCheckOutTimer: ATimer<AccountCheckOutTimeComponent>
    {
        public override void Run(AccountCheckOutTimeComponent self)
        {
            try
            {
                self.DeleteSession();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
<<<<<<< HEAD
                throw;
            }
        }
    }
    public class AccountCheckOutTimeComponentAwakeSystem : AwakeSystem<AccountCheckOutTimeComponent, long>
    {
        public override void Awake(AccountCheckOutTimeComponent self, long accountId)
        {
            self.AccountId = accountId;
            TimerComponent.Instance.Remove(ref self.Timer);
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 60000, TimerType.AccountSessionCheckOutTime, self);
        }
    }
    
    public class AccountCheckOutTimeComponentDestroySystem : DestroySystem<AccountCheckOutTimeComponent>
=======
            }
        }
    }

    public class AccountCheckOutTimeComponentDestroySystem: DestroySystem<AccountCheckOutTimeComponent>
>>>>>>> main
    {
        public override void Destroy(AccountCheckOutTimeComponent self)
        {
            self.AccountId = 0;
            self.Timer = 0;
        }
    }

<<<<<<< HEAD
    [FriendClass(typeof(AccountCheckOutTimeComponent))]
=======
    public class AccountCheckOutTimeComponentAwakeSystem: AwakeSystem<AccountCheckOutTimeComponent, long>
    {
        //刷新计时器，10分钟无响应，则清除连接
        public override void Awake(AccountCheckOutTimeComponent self, long accountId)
        {
            self.AccountId = accountId;
            TimerComponent.Instance.Remove(ref self.Timer);
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 6000000, TimerType.AccountSessionCheckOutTime, self);
        }
    }

    [FriendClassAttribute(typeof (ET.AccountCheckOutTimeComponent))]
>>>>>>> main
    public static class AccountCheckOutTimeComponentSystem
    {
        public static void DeleteSession(this AccountCheckOutTimeComponent self)
        {
            Session session = self.GetParent<Session>();
<<<<<<< HEAD

=======
>>>>>>> main
            long sessionInstanceId = session.DomainScene().GetComponent<AccountSessionsComponent>().Get(self.AccountId);
            if (session.InstanceId == sessionInstanceId)
            {
                session.DomainScene().GetComponent<AccountSessionsComponent>().Remove(self.AccountId);
            }
<<<<<<< HEAD
            session.Send(new A2C_Disconnect(){Error = 1});

=======

            session.Send(new A2C_DisConnect() { Error = 1 });
>>>>>>> main
            session.Disconnect().Coroutine();
        }
    }
}