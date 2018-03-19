using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeChatWebSite
{
    using Express.Common;
    using Express.WeiXin;
    using WeiXin.Base.Impl;

    public partial class UserBind : BasePage
    {
        static string openid = "";
        AccountBind _AccountBind = new AccountBind();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session[WeiXinConfigBase.OpenidKey] != null)
            {
                openid = HttpContext.Current.Session[WeiXinConfigBase.OpenidKey].ToString();
            }            
        }        
    }
}