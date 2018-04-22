using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatWebSite
{
    using Express.Common;
    using Express.WeiXin;
    using Senparc.Weixin;
    using Senparc.Weixin.MP.AdvancedAPIs;
    using System.Configuration;
    using WeiXin.Base.Impl;

    public class BasePage: System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);//保留父类的操作         

            CreateOpenid();
        }

        public void CreateOpenid()
        {
            string code = Context.Request.QueryString["code"];
            HttpContext.Current.Session[WeiXinConfigBase.Code] = code;
            IsLogined();
        }

        /// <summary>
        /// 判断用户是否登录        
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public bool IsLogined()
        {
            if (ConfigurationManager.AppSettings["WinXinDeBug"] == "true")
            {
                WXDebugerUserInit();
                return true;
            }
            else
            {
                return HttpContext.Current != null && HttpContext.Current.Session[WeiXinConfigBase.OpenidKey] != null;
            }
        }


        /// <summary>
        /// 虚拟调试
        /// 不需要在微信中集成调试
        /// 也不需要添加到微信开发工具中调试
        /// </summary>
        public static void WXDebugerUserInit()
        {
            if (System.Web.HttpContext.Current.Session[WeiXinConfigBase.OpenidKey] == null
                   || string.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session[WeiXinConfigBase.OpenidKey].ToString()))
            {
                var DeBugOpenid = ConfigurationManager.AppSettings["wx_debugOpenid"];
                System.Web.HttpContext.Current.Session[WeiXinConfigBase.OpenidKey] = DeBugOpenid;
                RefreshAccount(DeBugOpenid);
            }
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        /// <param name="openid"></param>
        public static void RefreshAccount(string openid)
        {
            //AccountBind _WeixinOAuth = new AccountBind();
            //var accounts = _WeixinOAuth.UserBinding(openid, "");
            //HttpContext.Current.Session[WeiXinConfigBase.AccountEntityKey] = accounts;
        }
    }
}