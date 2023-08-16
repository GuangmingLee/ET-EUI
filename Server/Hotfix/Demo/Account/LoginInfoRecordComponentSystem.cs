namespace ET
{
<<<<<<< HEAD
    public class LoginInfoRecordComponentDestroySystem: DestroySystem<LoginInfoRecordComponent>
    {
        public override void Destroy(LoginInfoRecordComponent self)
        {
            self.AccountLoginInfoDict.Clear();
=======
    public class LoginInfoRecordComponentDestorySystem: DestroySystem<LoginInfoRecordComponent>
    {
        public override void Destroy(LoginInfoRecordComponent self)
        {
            self.AccountInfoRecordDict.Clear();
>>>>>>> main
        }
    }

    [FriendClassAttribute(typeof (ET.LoginInfoRecordComponent))]
    public static class LoginInfoRecordComponentSystem
    {
        public static void Add(this LoginInfoRecordComponent self, long key, int value)
        {
<<<<<<< HEAD
            if (self.AccountLoginInfoDict.ContainsKey(key))
            {
                self.AccountLoginInfoDict[key] = value;
                return;
            }

            self.AccountLoginInfoDict.Add(key, value);
=======
            if (self.AccountInfoRecordDict.ContainsKey(key))
            {
                self.AccountInfoRecordDict[key] = value;
                return;
            }

            self.AccountInfoRecordDict.Add(key, value);
>>>>>>> main
        }

        public static void Remove(this LoginInfoRecordComponent self, long key)
        {
<<<<<<< HEAD
            if (self.AccountLoginInfoDict.ContainsKey(key))
            {
                self.AccountLoginInfoDict.Remove(key);
=======
            if (self.AccountInfoRecordDict.ContainsKey(key))
            {
                self.AccountInfoRecordDict.Remove(key);
>>>>>>> main
            }
        }

        public static int Get(this LoginInfoRecordComponent self, long key)
        {
<<<<<<< HEAD
            if (!self.AccountLoginInfoDict.TryGetValue(key, out int value))
            {
                return -1;
            }

            return value;
        }

        public static bool IsExist(this LoginInfoRecordComponent self, long key)
        {
            return self.AccountLoginInfoDict.ContainsKey(key);
=======
            if (self.AccountInfoRecordDict.TryGetValue(key, out int value))
            {
                return value;
            }

            return -1;
        }

        public static bool isExits(this LoginInfoRecordComponent self, long key)
        {
            return self.AccountInfoRecordDict.ContainsKey(key);
>>>>>>> main
        }
    }
}