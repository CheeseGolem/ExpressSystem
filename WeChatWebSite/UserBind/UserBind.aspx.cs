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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Msg msg = new Msg();
            msg.Result = false;

            //if (context.Session[WeiXinConfigBase.VcodeKey] == null || !UserSmsServices.isSmsTimeEffective(openid, bindhaoma, phone, 5))//验证码有效期内没给用户发送成功的验码
            if (false)
            {//vcode的session没有了
                msg.AddMsg("验证码已失效");
            }
            else
            {
                //验证码不匹配
                //if (vcode != context.Session[WeiXinConfigBase.VcodeKey].ToString())
                if (vcode.Value != "1234")
                {
                    msg.AddMsg("验证码不正确");
                }
                else
                {
                    if (!_AccountBind.isBanding(openid))//先判断是否绑定
                    {
                        msg.Result = false;
                        msg.AddMsg("已经绑定该账号了！");
                    }
                    else
                    {
                        //msg = WeiXin.ART.Impl.UserService.CheckHisTel(bindhaoma, bindname, bindsex, idcardno, phone);
                        msg = _AccountBind.UserBinding(tb_name.Value, phone.Value, openid);
                        if (msg.Result)
                        {
                            //AccountHelper.RefreshAccount(context.Session[WeiXinConfigBase.OpenidKey].ToString());//刷先用户缓存
                        }
                    }
                }

            }
            msg.MsgObjectContent = msg.ToString();
            if (msg.Result)
            {
                AjaxHelper.WriteSuccessJson("成功");
            }            
        }
    }
}