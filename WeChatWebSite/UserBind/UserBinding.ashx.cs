using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatWebSite.UserBind
{
    using Express.Common;
    using Express.WeiXin;
    using WeiXin.Base.Impl;
    /// <summary>
    /// UserBinding 的摘要说明
    /// </summary>
    public class UserBinding : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        AccountBind _AccountBind = new AccountBind();

        public void ProcessRequest(HttpContext context)
        {
            context.Request.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            string method = context.Request.Params["getmethod"];
            this.GetType().GetMethod(method).Invoke(this, new object[] { context });
        }

        public void GetUser(HttpContext context)
        {
            Msg msg = new Msg();
            msg.Result = false;

            string bindname = context.Request["bindname"] != null ? context.Request["bindname"].ToString() : "";
            string vcode = context.Request["vcode"] != null ? context.Request["vcode"].ToString() : "";
            string phone = context.Request["phone"] != null ? context.Request["phone"].ToString() : "";
            //string openid = HttpContext.Current.Session[WeiXinConfigBase.OpenidKey].ToString();
            string openid = WeiXinConfigBase.OpenId;

            if (context.Session[WeiXinConfigBase.VcodeKey] == null)//验证码有效期内没给用户发送成功的验码                
            {
                //vcode的session没有了
                msg.AddMsg("验证码已失效");
            }
            else
            {
                //验证码不匹配
                if (vcode != context.Session[WeiXinConfigBase.VcodeKey].ToString())
                {
                    msg.AddMsg("验证码不正确");
                }
                else
                {
                    if (_AccountBind.isBanding(openid))//先判断是否绑定
                    {
                        msg.Result = false;
                        msg.AddMsg("已经绑定该账号了！");
                    }
                    else
                    {
                        //msg = WeiXin.ART.Impl.UserService.CheckHisTel(bindhaoma, bindname, bindsex, idcardno, phone);
                        msg = _AccountBind.UserBinding(bindname, phone, openid);

                        if (msg.Result)
                        {
                            //AccountHelper.RefreshAccount(context.Session[WeiXinConfigBase.OpenidKey].ToString());//刷先用户缓存
                        }
                    }
                }
            }
            msg.MsgObjectContent = msg.ToString();
            context.Response.Write(JsonHelper.Serialize(msg));
        }

        public void SendPhoneMsg(HttpContext context)
        {
            HttpContext.Current.Session[WeiXinConfigBase.VcodeKey] = "123456";
            context.Response.Write("");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}