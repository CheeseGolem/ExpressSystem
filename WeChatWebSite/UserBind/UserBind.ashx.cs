using Express.Common;
using Express.WeiXin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatWebSite.A
{
    using Senparc.Weixin;
    using Senparc.Weixin.MP.AdvancedAPIs;
    using WeiXin.Base.Impl;
    /// <summary>
    /// UserBind 的摘要说明
    /// </summary>
    public class UserBind : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        AccountBind _AccountBind = new AccountBind();

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Request.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            string method = context.Request.Params["getmethod"];
            this.GetType().GetMethod(method).Invoke(this, new object[] { context });            
        }

        public Msg CreateOpenid(HttpContext context)
        {
            Msg msg = new Msg();
            try
            {
                string code = context.Request.QueryString["code"];
                code = HttpContext.Current.Session[WeiXinConfigBase.Code].ToString();                
                msg.Result = false;

                if (string.IsNullOrWhiteSpace(code))
                {
                    msg.AddMsg("code为空，您拒绝了授权,请从微信客户端打开本程序");
                    msg.MsgObjectContent = -40001;
                    return msg;
                }
                //通过，用code换取access_token
                var result = OAuthApi.GetAccessToken(WeiXinConfigBase.AppID, WeiXinConfigBase.AppSecret, code);
                if (result.errcode != ReturnCode.请求成功)
                {
                    msg.AddMsg("错误：" + result.errmsg);
                    msg.MsgObjectContent = -40002;
                    return msg;
                }
                else
                {
                    HttpContext.Current.Session[WeiXinConfigBase.OpenidKey] = result.openid;
                    HttpContext.Current.Session[WeiXinConfigBase.OAuthAccessTokenKey] = result.access_token;
                    HttpContext.Current.Session[WeiXinConfigBase.OAuthAccessTokenRefreshKey] = result.refresh_token;
                    msg.Result = true;
                    //AccountHelper.RefreshAccount(result.openid);
                }

            }
            catch (Exception e)
            {
                msg.AddMsg("错误：" + e.Message + ",请从微信客户端打开本程序");
                msg.MsgObjectContent = -40003;
            }
            return msg;
        }

        public void GetUser(HttpContext context)
        {
            CreateOpenid(context);

            Msg msg = new Msg();
            msg.Result = false;

            string bindname = context.Request["bindname"] != null ? context.Request["bindname"].ToString() : "";
            string vcode = context.Request["vcode"] != null ? context.Request["vcode"].ToString() : "";
            string phone = context.Request["phone"] != null ? context.Request["phone"].ToString() : "";
            //string openid = HttpContext.Current.Session[WeiXinConfigBase.OpenidKey].ToString();
            string openid = WeiXinConfigBase.OpenId;

            //if (context.Session[WeiXinConfigBase.VcodeKey] == null || !UserSmsServices.isSmsTimeEffective(openid, bindhaoma, phone, 5))//验证码有效期内没给用户发送成功的验码
            if (false)
            {//vcode的session没有了
                msg.AddMsg("验证码已失效");
            }
            else
            {
                //验证码不匹配
                //if (vcode != context.Session[WeiXinConfigBase.VcodeKey].ToString())
                if (vcode != "1234")
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
    }
}