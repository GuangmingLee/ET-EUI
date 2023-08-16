<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> main
using System.Text.RegularExpressions;

namespace ET
{
<<<<<<< HEAD
    [FriendClass(typeof (Account))]
=======
    [MessageHandler]
    [FriendClassAttribute(typeof (ET.Account))]
>>>>>>> main
    public class C2A_LoginAccountHandler: AMRpcHandler<C2A_LoginAccount, A2C_LoginAccount>
    {
        protected override async ETTask Run(Session session, C2A_LoginAccount request, A2C_LoginAccount response, Action reply)
        {
<<<<<<< HEAD
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            session.RemoveComponent<SessionAcceptTimeoutComponent>();
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_LoginInfoError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            if (string.IsNullOrEmpty(request.AccountName) || string.IsNullOrEmpty(request.Password))
            {
                response.Error = ErrorCode.ERR_LoginInfoError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            if (!Regex.IsMatch(request.AccountName.Trim(), @"^(?=.*[0-9].*)(?=.*[A-Z].*)(?=.*[a-z].*).{6,15}$"))
            {
                response.Error = ErrorCode.ERR_AccountNameFormError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            if (!Regex.IsMatch(request.Password.Trim(), @"^[A-Za-z0-9]+$"))
            {
                response.Error = ErrorCode.ERR_PasswordFormError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            using (session.AddComponent<SessionLockingComponent>()) //异步判断
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountName.Trim().GetHashCode()))
                {
                    var accountInfoList = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                            .Query<Account>(d => d.AccountName.Equals(request.AccountName.Trim()));
                    Account account = null;
                    if (accountInfoList != null && accountInfoList.Count > 0)
                    {
                        account = accountInfoList[0];
                        session.AddChild(account);
                        if (account.AccountType == (int)AccountType.BlackList)
                        {
                            response.Error = ErrorCode.ERR_AccountInBlackListError;
                            reply();
                            session.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }

                        if (!account.Password.Equals(request.Password))
                        {
                            response.Error = ErrorCode.ERR_LoginPasswordError;
                            reply();
                            session.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }
                    }
                    else
                    {
                        account = session.AddChild<Account>();
                        account.AccountName = request.AccountName.Trim();
                        account.Password = request.Password.Trim();
                        account.CreatTime = TimeHelper.ServerNow();
                        account.AccountType = (int)AccountType.General;
                        await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<Account>(account);
                    }

                    StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "LoginCenter");
                    long loginCenterInstanceId = startSceneConfig.InstanceId;
                    var loginAccountRespone = (L2A_LoginAccountResponse)await ActorMessageSenderComponent.Instance.Call(loginCenterInstanceId,
                        new A2L_LoginAccountRequest() { AccountId = account.Id });

                    if (loginAccountRespone.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = loginAccountRespone.Error;
                        reply();
                        session.Disconnect().Coroutine();
                        account?.Dispose();
                        return;
                    }

                    long accountSessionInstanceId = session.DomainScene().GetComponent<AccountSessionsComponent>().Get(account.Id);
                    Session otherSession = Game.EventSystem.Get(accountSessionInstanceId) as Session;
                    otherSession?.Send(new A2C_Disconnect() { Error = 0 });
                    otherSession?.Disconnect().Coroutine();
                    session.DomainScene().GetComponent<AccountSessionsComponent>().Add(account.Id, session.InstanceId);
                    session.AddComponent<AccountCheckOutTimeComponent, long>(account.Id);

                    string Token = TimeHelper.ServerNow().ToString() + RandomHelper.RandomNumber(int.MinValue, int.MaxValue).ToString();
                    session.DomainScene().GetComponent<TokenComponent>().Remove(account.Id);
                    session.DomainScene().GetComponent<TokenComponent>().Add(account.Id, Token);
                    Log.Error("登录时的loken为：" + Token.ToString());
                    response.AccountId = account.Id;
                    response.Token = Token;

                    reply();
                    account?.Dispose();
                }
=======
            try
            {
                if (session.DomainScene().SceneType != SceneType.Account)
                {
                    Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                    session.Dispose();
                    return;
                }

                session.RemoveComponent<SessionAcceptTimeoutComponent>(); //必须移除，不然会阻塞进程
                if (session.GetComponent<SessionLockingComponent>() != null) //判断锁区域是否未被是否，影响进程
                {
                    response.Error = ErrorCode.ERR_RequestRepeatedly;
                    reply();
                    session.Disconnect().Coroutine();
                    return;
                }

                if (string.IsNullOrEmpty(request.AccountName) || string.IsNullOrEmpty(request.Password))
                {
                    response.Error = ErrorCode.ERR_LoginInfoError;
                    reply();
                    session.Disconnect().Coroutine();
                    return;
                }

                if (!Regex.IsMatch(request.AccountName.Trim(), @"^(?=.*[0-9].*)(?=.*[A-Z].*)(?=.*[a-z].*).{6,15}$"))
                {
                    response.Error = ErrorCode.ERR_LoginAccountNameError;
                    reply();
                    session.Disconnect().Coroutine();
                    return;
                }

                if (!Regex.IsMatch(request.AccountName.Trim(), @"^[A-Za-z0-9]+$"))
                {
                    response.Error = ErrorCode.ERR_LoginPasswordError;
                    reply();
                    session.Disconnect().Coroutine();
                    return;
                }

                using (session.AddComponent<SessionLockingComponent>()) //异步判断，增加锁组件
                {
                    using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccountLock, request.AccountName.Trim().GetHashCode()))
                    {
                        var accountInfoList = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                                .Query<Account>(d => d.AccountName.Equals(request.AccountName.Trim()));
                        Account account = null;
                        if (accountInfoList != null && accountInfoList.Count > 0)
                        {
                            account = accountInfoList[0];
                            session.AddChild(account);
                            if (account.AccountType == (int)AccountType.BlackList)
                            {
                                response.Error = ErrorCode.ERR_LoginInfoError;
                                reply();
                                session.Disconnect().Coroutine();
                                account?.Dispose();
                                return;
                            }

                            if (!account.Password.Equals(request.Password.Trim()))
                            {
                                response.Error = ErrorCode.ERR_LoginPasswordError;
                                reply();
                                session.Disconnect().Coroutine();
                                account?.Dispose();
                                return;
                            }
                        }
                        else
                        {
                            account = session.AddChild<Account>();
                            account.AccountName = request.AccountName.Trim();
                            account.Password = request.Password.Trim();
                            account.CreateTime = TimeHelper.ServerNow();
                            account.AccountType = (int)AccountType.General;
                            await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<Account>(account);
                        }

                        //从配置列表中获取到配置账号心中的数据
                        StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "LoginCenter");
                        long loginCenterInstanceId = startSceneConfig.InstanceId;
                        var l2ALoginAccountResponse = (L2A_LoginAccountResponse)await ActorMessageSenderComponent.Instance.Call(loginCenterInstanceId,
                            new A2L_LoginAccountRequest() { AccountId = account.Id });
                        if (l2ALoginAccountResponse.Error != ErrorCode.ERR_Success)
                        {
                            response.Error = l2ALoginAccountResponse.Error;
                            reply();
                            session?.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }

                        //顶号下线操作
                        long accountSessionInstanceId = session.DomainScene().GetComponent<AccountSessionsComponent>().Get(account.Id);
                        Session otherSession = Game.EventSystem.Get(accountSessionInstanceId) as Session;
                        otherSession?.Send(new A2C_DisConnect() { Error = 0 });
                        otherSession?.Disconnect().Coroutine();
                        session.DomainScene().GetComponent<AccountSessionsComponent>().Add(account.Id, session.InstanceId);
                        session.AddComponent<AccountCheckOutTimeComponent, long>(account.Id);

                        string token = TimeHelper.ServerNow().ToString() + RandomHelper.RandomNumber(int.MaxValue, int.MaxValue).ToString();
                        session.DomainScene().GetComponent<TokenComponent>().Remove(account.Id);
                        session.DomainScene().GetComponent<TokenComponent>().Add(account.Id, token);

                        response.AccountId = account.Id;
                        response.Token = token;
                        reply();
                        account?.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
>>>>>>> main
            }
        }
    }
}