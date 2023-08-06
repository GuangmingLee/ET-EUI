using System;

namespace ET
{
    [MessageHandler]
    [FriendClassAttribute(typeof(ET.TokenComponent))]
    [FriendClassAttribute(typeof(ET.ServerInfosComponent))]
    [FriendClassAttribute(typeof(ET.ServerInfoManagerComponent))]
    public class C2A_GetServerInfosHandler : AMRpcHandler<C2A_GetServerInfos, A2C_GetServerInfos>
    {
        protected override async ETTask Run(Session session, C2A_GetServerInfos request, A2C_GetServerInfos response, Action reply)
        {
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

            await ETTask.CompletedTask;
        }
    }
}