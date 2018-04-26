using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Express.WeiXin
{
    public class WeiXinConfigBase
    {


        #region 基本配置

        public static string Code = "_Code";
        /// <summary>
        /// 存放openidKey
        /// </summary>
        public static string OpenidKey = "_Openid";

        /// <summary>
        /// 存放OAuthAccessTokenKey
        /// </summary>
        public static string OAuthAccessTokenKey = "_OAuthAccessToken";

        /// <summary>
        /// 存放OAuthAccessTokenRefreshKey
        /// </summary>
        public static string OAuthAccessTokenRefreshKey = "_OAuthAccessTokenRefreshKey";


        /// <summary>
        /// 存放openid绑定的用户列表
        /// </summary>
        public static string AccountEntityKey = "_Accounts";

        /// <summary>
        /// 消息重复发送次数
        /// </summary>
        public static string SendTimes = ConfigurationManager.AppSettings["SendTimes"];
        /// <summary>
        /// 存放根据openid获取的用户绑定信息
        /// </summary>
        public static string PubUserBind = "_PubUserBind";

        #endregion

        #region 微信配置
        /// <summary>
        /// 微信AppID
        /// </summary>
        public static string AppID = ConfigurationManager.AppSettings["AppID"];
        /// <summary>
        /// 微信AppSecret
        /// </summary>
        public static string AppSecret = ConfigurationManager.AppSettings["AppSecret"];
        /// <summary>
        /// 微信自定义Token
        /// </summary>
        public static string Token = ConfigurationManager.AppSettings["Token"];
        /// <summary>
        /// 
        /// </summary>
        public static string OpenId = ConfigurationManager.AppSettings["wx_debugOpenid"];
        /// <summary>
        /// 消息加解密密钥(没有设置)
        /// </summary>
        public static string EncodingAESKey = ConfigurationManager.AppSettings["EncodingAESKey"];

        /// <summary>
        /// 回调域名
        /// </summary>
        public static string AppDomain = ConfigurationManager.AppSettings["AppDomain"];

        /// <summary>
        /// 授权ReturnUrl
        /// </summary>
        public static string OAuthRetrunUrl = ConfigurationManager.AppSettings["OAuthRetrunUrl"];

        #endregion



    }
}