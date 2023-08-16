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
<<<<<<< HEAD
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
=======

        public const int ERR_LoginInfoError = 200003; //登录信息错误
        public const int ERR_LoginAccountNameError = 200004; //用户名不合规
        public const int ERR_LoginPasswordError = 200005; //密码错误
        public const int ERR_BlackList = 200006; //黑名单中
        public const int ERR_RequestRepeatedly = 200007; //重复创建
        public const int ERR_ErrorType = 200008; //类型错误
        public const int ERR_ErrorToken = 200009; //Token类型错误

        public const int ERR_ERRNameIsNullOrEmpty = 200010; //名字为空
        public const int ERR_ERRRoleHasContain = 200011; //角色存在
        public const int ERR_ERRRoleIsNull = 200012; //角色不存在

        public const int ERR_RequestSceneTypeError = 200013; //访问的类型错误
        public const int ERR_NetWorkError = 200014; //网络错误

        public const int ERR_OtherAccountLogin = 200015; //其他账号在登录
>>>>>>> main
    }
}