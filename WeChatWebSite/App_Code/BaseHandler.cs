using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatWebSite
{
    using Express.Common;
    using Express.WeiXin;
    using Senparc.Weixin;
    using Senparc.Weixin.MP;
    using Senparc.Weixin.MP.AdvancedAPIs;

    public abstract class BaseHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public BaseHandler() {            
            //CreateOpenid();
            //SubProcessRequest();//由子类重写
        }

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
            
            CreateOpenid(context);
            SubProcessRequest();
        }

        public abstract void SubProcessRequest();
        /// <summary>
        /// 上下文对象
        /// </summary>
        public HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public Msg CreateOpenid(HttpContext context)
        {
            //string code = Context.Request.QueryString["code"];
            string code = HttpContext.Current.Session[WeiXinConfigBase.Code].ToString();
            Msg msg = new Msg();
            msg.Result = false;
            try
            {
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
    }     
}