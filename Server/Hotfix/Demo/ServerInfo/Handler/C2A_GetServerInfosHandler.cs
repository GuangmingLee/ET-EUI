using System;

namespace ET
{
<<<<<<< HEAD
=======
    [MessageHandler]
    [FriendClassAttribute(typeof(ET.TokenComponent))]
    [FriendClassAttribute(typeof(ET.ServerInfosComponent))]
>>>>>>> main
    [FriendClassAttribute(typeof(ET.ServerInfoManagerComponent))]
    public class C2A_GetServerInfosHandler : AMRpcHandler<C2A_GetServerInfos, A2C_GetServerInfos>
    {
        protected override async ETTask Run(Session session, C2A_GetServerInfos request, A2C_GetServerInfos response, Action reply)
        {
<<<<<<< HEAD
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            foreach (var serverInfo in session.DomainScene().GetComponent<ServerInfoManagerComponent>().ServerInfos)
            {
                response.ServerInfoList.Add(serverInfo.ToMessage());
            }
            reply();
=======
            try
            {
                if (session.DomainScene().SceneType != SceneType.Account)
                {
                    Log.Error($"请求的Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                    return;
                }

                string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);

                if (token == null || token != request.Token)
                {
                    response.Error = ErrorCode.ERR_ErrorToken;
                    reply();
                    session?.Disconnect().Coroutine();
                    return;
                }

                foreach (var serverInfo in session.DomainScene().GetComponent<ServerInfoManagerComponent>().ServerInfos)
                {
                    response.ServerInfoList.Add(serverInfo.ToMessage());
                }

                reply();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return;
            }

>>>>>>> main
            await ETTask.CompletedTask;
        }
    }
}