using Express.WeiXin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeChatWebSite.Comment
{
    public partial class Comment : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                ValidateOpenId();
            }
            
            
        }
        public void ValidateOpenId()
        {
            string openId = "";
            try
            {                
                openId = Context.Session[WeiXinConfigBase.OpenidKey].ToString();
            }
            catch (Exception)
            {
                Context.Response.Redirect("/UserBind/UserBind.aspx");
                throw;
            }
        }
    }
}