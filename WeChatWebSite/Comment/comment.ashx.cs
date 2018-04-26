using Express.BLL;
using Express.Common;
using Express.Model;
using Express.WeiXin;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatWebSite.Comment
{
    /// <summary>
    /// comment 的摘要说明
    /// </summary>
    public class comment : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        Ep_QuestionBLL bllQue = new Ep_QuestionBLL();

        public void ProcessRequest(HttpContext context)
        {
            context.Request.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            string method = context.Request.Params["getmethod"];
            this.GetType().GetMethod(method).Invoke(this, new object[] { context });
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void GetQuestion(HttpContext context)
        {
            CreateOpenid(context);

            Msg msg = new Msg();
            msg.Result = false;

            string content = context.Request["content"] != null ? context.Request["content"].ToString() : "";
            //string openid = HttpContext.Current.Session[WeiXinConfigBase.OpenidKey].ToString();
            string openid = WeiXinConfigBase.OpenId;

            Ep_Question model = new Ep_Question();
            model.Openid = openid;
            model.QContent = content;
            model.QTime = DateTime.Now;

            try
            {
                bllQue.Add(model);
                msg.Result = true;
            }
            catch (Exception ex)
            {
                msg.AddMsg(ex.Message);
            }
            msg.MsgObjectContent = msg.ToString();
            var s = JsonHelper.Serialize(msg);
            context.Response.Write(JsonHelper.Serialize(msg));
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
    }
}
