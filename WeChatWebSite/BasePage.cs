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
        }
    }
}