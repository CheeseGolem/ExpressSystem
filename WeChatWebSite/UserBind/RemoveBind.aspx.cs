using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Express.BLL;
using Express.Common;
using Express.Model;
using Express.WeiXin;
using WeChatWebSite;
using WeiXin.Base.Impl;

public partial class Express_RemoveBind : BasePage
{
    Ep_UserBLL bllUser = new Ep_UserBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Express_RemoveBind));
    }

    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public Msg RemoveBindByOpenId()
    {
        string openId = "";
        Msg msg = new Msg();
        msg.Result = false;
        try
        {
            openId = Context.Session[WeiXinConfigBase.OpenidKey].ToString();
            int userId = AccountBind.GetUserIdByOpenId(openId);
            msg.Result = bllUser.Delete(userId);
            Context.Session.Remove(WeiXinConfigBase.OpenId);
        }
        catch (Exception e)
        {
            msg.AddMsg(e.Message.ToString());            
        }
        return msg;
    }
}
