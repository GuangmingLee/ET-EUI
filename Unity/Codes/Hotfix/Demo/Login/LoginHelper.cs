using System;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof (AccountInfoComponent))]
    [FriendClassAttribute(typeof (ET.ServerInfosComponent))]
    [FriendClassAttribute(typeof (ET.RoleInfosComponent))]
    [FriendClassAttribute(typeof (ET.RoleInfo))]
    public static class LoginHelper
    {
        //登录
        public static async ETTask<int> Login(Scene zoneScene, string address, string account, string password)
        {
            A2C_LoginAccount a2CLoginAccount = null;
            Session accountSession = null;
            try
            {
                accountSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                password = MD5Helper.StringMD5(password);
                a2CLoginAccount = (A2C_LoginAccount)await accountSession.Call(new C2A_LoginAccount() { AccountName = account, Password = password });
            }
            catch (Exception e)
            {
                accountSession?.Dispose();
                Log.Error(e.ToString());
                return a2CLoginAccount.Error;
            }

            if (a2CLoginAccount.Error != ErrorCode.ERR_Success)
            {
                accountSession?.Dispose();
                return a2CLoginAccount.Error;
            }

            zoneScene.AddComponent<SessionComponent>().Session = accountSession;
            zoneScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();

            zoneScene.GetComponent<AccountInfoComponent>().accountId = a2CLoginAccount.AccountId;
            zoneScene.GetComponent<AccountInfoComponent>().token = a2CLoginAccount.Token;
            return ErrorCode.ERR_Success;
        }

        //获取服务器信息
        public static async ETTask<int> GetServerInfos(Scene zoneScene)
        {
            A2C_GetServerInfos a2CGetServerInfos = null;
            try
            {
                string Token = zoneScene.GetComponent<AccountInfoComponent>().token;
                long AccountId = zoneScene.GetComponent<AccountInfoComponent>().accountId;
                a2CGetServerInfos = (A2C_GetServerInfos)await zoneScene.GetComponent<SessionComponent>().Session
                        .Call(new C2A_GetServerInfos() { Token = Token, AccountId = AccountId });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return a2CGetServerInfos.Error;
            }

            if (a2CGetServerInfos.Error != ErrorCode.ERR_Success)
            {
                return a2CGetServerInfos.Error;
            }

            //将消息协议转化为信息数据，存放在组件信息里面
            foreach (var serverInfoProto in a2CGetServerInfos.ServerInfoList)
            {
                ServerInfo serverInfo = zoneScene.GetComponent<ServerInfosComponent>().AddChild<ServerInfo>();
                serverInfo.FromMessage(serverInfoProto);
                zoneScene.GetComponent<ServerInfosComponent>().serverInfoList.Add(serverInfo);
            }

            return ErrorCode.ERR_Success;
        }

        //创建角色
        public static async ETTask<int> CreateRole(Scene zoneScene, string name)
        {
            A2C_CreateRole a2CCreateRole = null;

            try
            {
                a2CCreateRole = (A2C_CreateRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_CreateRole()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().accountId,
                    Name = name,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_LoginInfoError;
            }

            if (a2CCreateRole.Error != ErrorCode.ERR_Success)
            {
                return a2CCreateRole.Error;
            }

            RoleInfo roleInfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
            roleInfo.FromMessage(a2CCreateRole.RoleInfo);

            zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Add(roleInfo);

            return ErrorCode.ERR_Success;
        }

        //获取角色
        public static async ETTask<int> GetRoles(Scene zoneScene)
        {
            A2C_GetRoles a2CGetRole = null;

            try
            {
                a2CGetRole = (A2C_GetRoles)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRoles()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().accountId,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_LoginInfoError;
            }

            if (a2CGetRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2CGetRole.Error.ToString());
                return a2CGetRole.Error;
            }

            zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Clear();
            foreach (var roleInfo in a2CGetRole.RoleInfo)
            {
                RoleInfo newroleInfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
                newroleInfo.FromMessage(roleInfo);
                zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Add(newroleInfo);
            }

            return ErrorCode.ERR_Success;
        }

        //删除角色
        public static async ETTask<int> DeleteRole(Scene zoneScene, long roleInfoId)
        {
            A2C_DeleteRole a2CDeleteRole = null;
            try
            {
                a2CDeleteRole = (A2C_DeleteRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_DeleteRole()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().accountId,
                    RoleInfoId = zoneScene.GetComponent<RoleInfosComponent>().CurrentRoleId,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });

                if (a2CDeleteRole.Error != ErrorCode.ERR_Success)
                {
                    return a2CDeleteRole.Error;
                }

                int roleinfoIndex = zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.FindIndex((info) =>
                {
                    return info.Id == a2CDeleteRole.DeletedRoleInfoId;
                });
                zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.RemoveAt(roleinfoIndex);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRealmKey(Scene zoneScene)
        {
            A2C_GetRealmKey a2CGetRealmKey = null;
            try
            {
                a2CGetRealmKey = (A2C_GetRealmKey)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRealmKey()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().accountId,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });

                if (a2CGetRealmKey.Error != ErrorCode.ERR_Success)
                {
                    return a2CGetRealmKey.Error;
                }

                zoneScene.GetComponent<AccountInfoComponent>().realmKey = a2CGetRealmKey.RealmKey;
                zoneScene.GetComponent<AccountInfoComponent>().realmAddress = a2CGetRealmKey.RealmAddress;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> EnterGame(Scene zoneScene)
        {
            string realmAddress = zoneScene.GetComponent<AccountInfoComponent>().realmAddress;
            Session session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(realmAddress));
            R2C_LoginRealm r2CLoginRealm = null;
            try
            {
                r2CLoginRealm = (R2C_LoginRealm)await session.Call(new C2R_LoginRealm()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().accountId,
                    RealmTokenKey = zoneScene.GetComponent<AccountInfoComponent>().realmKey,
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                session?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            session?.Dispose(); //不管成功与否，都要关闭这个session
            if (r2CLoginRealm.Error != ErrorCode.ERR_Success)
            {
                return r2CLoginRealm.Error;
            }

            Log.Warning($"GateAddress : {r2CLoginRealm.GateAddress}");

            Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2CLoginRealm.GateAddress));
            gateSession.AddComponent<PingComponent>();
            zoneScene.GetComponent<SessionComponent>().Session = gateSession;

            //开始连接Gate

            long currentRoleId = zoneScene.GetComponent<RoleInfosComponent>().CurrentRoleId;
            G2C_LoginGameGate g2CLoginGameGate;

            try
            {
                long accountId = zoneScene.GetComponent<AccountInfoComponent>().accountId;
                g2CLoginGameGate = (G2C_LoginGameGate)await gateSession.Call(new C2G_LoginGameGate()
                {
                    Key = r2CLoginRealm.GateSessionKey,
                    RoleId = currentRoleId,
                    Account = zoneScene.GetComponent<AccountInfoComponent>().accountId,
                });
            }
            catch (Exception e)
            {
                Log.Error(e);
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2CLoginGameGate.Error != ErrorCode.ERR_Success)
            {
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return g2CLoginGameGate.Error;
            }

            Log.Debug("gate登录成功");
            return ErrorCode.ERR_Success;
        }
    }
}