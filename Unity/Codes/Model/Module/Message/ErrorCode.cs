namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误

        // 110000以下的错误请看ErrorCore.cs

        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常
        public const int ERR_NetWorkError            = 200002; //网络错误
        public const int ERR_LoginInfoError          = 200003; //登录信息错误
        public const int ERR_AccountNameFormError    = 200004; //登录账号格式错误
        public const int ERR_PasswordFormError       = 200005; //登陆密码格式错误
        public const int ERR_AccountInBlackListError = 200006; //账号处于黑名单中
        public const int ERR_LoginPasswordError      = 200007; //登录密码错误
        public const int ERR_RequestRepeatedly       = 200008; //反复多次请求
        public const int ERR_TokenError              = 200009; //Token错误
       
        
        public const int ERR_RoleNameIsNull          = 200010; //角色名为空
        public const int ERR_RoleNameSame            = 200011; //角色同名
        public const int ERR_RoleNotExist = 200012;//游戏角色不存在
    }
}