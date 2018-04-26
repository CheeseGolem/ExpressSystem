using Express.WeiXin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Express.Model;
using Express.BLL;
using WeiXin.Base.Impl;

public partial class Express_SendExpress : System.Web.UI.Page
{
    Ep_SendExpressBLL bllSend = new Ep_SendExpressBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(Express_SendExpress));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="phone"></param>
    /// <param name="address"></param>
    /// <param name="isExp"></param>
    /// <returns></returns>
    [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.ReadWrite)]
    public bool AddExpress(string name, string phone, string address, int isExp)
    {
        Ep_SendExpress entitySend = new Ep_SendExpress();
        entitySend.ReceiveName = name;
        entitySend.ReceivePhone = phone;
        entitySend.ReceiveAddress = address;
        entitySend.SendUserId = AccountBind.GetUserIdByOpenId(WeiXinConfigBase.OpenId);
        entitySend.Status = 0;
        entitySend.IsExpensive = isExp;

        return bllSend.Add(entitySend) > 0;
    }
}
