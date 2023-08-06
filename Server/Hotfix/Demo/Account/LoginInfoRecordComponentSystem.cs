namespace ET
{
    public class LoginInfoRecordComponentDestorySystem: DestroySystem<LoginInfoRecordComponent>
    {
        public override void Destroy(LoginInfoRecordComponent self)
        {
            self.AccountInfoRecordDict.Clear();
        }
    }

    [FriendClassAttribute(typeof (ET.LoginInfoRecordComponent))]
    public static class LoginInfoRecordComponentSystem
    {
        public static void Add(this LoginInfoRecordComponent self, long key, int value)
        {
            if (self.AccountInfoRecordDict.ContainsKey(key))
            {
                self.AccountInfoRecordDict[key] = value;
                return;
            }

            self.AccountInfoRecordDict.Add(key, value);
        }

        public static void Remove(this LoginInfoRecordComponent self, long key)
        {
            if (self.AccountInfoRecordDict.ContainsKey(key))
            {
                self.AccountInfoRecordDict.Remove(key);
            }
        }

        public static int Get(this LoginInfoRecordComponent self, long key)
        {
            if (self.AccountInfoRecordDict.TryGetValue(key, out int value))
            {
                return value;
            }

            return -1;
        }

        public static bool isExits(this LoginInfoRecordComponent self, long key)
        {
            return self.AccountInfoRecordDict.ContainsKey(key);
        }
    }
}