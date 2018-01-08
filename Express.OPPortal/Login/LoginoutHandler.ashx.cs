using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.OPPortal
{
    using Express.Common;
    /// <summary>
    /// LoginoutHandler 的摘要说明
    /// </summary>
    public class LoginoutHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Session[Key.CURRENT_USER] == null)
            {
                context.Response.Redirect("/Login.aspx");
            }

            //1.0 清空Session
            context.Session.Clear();//从Session池中清空所有的键值对

            //2.0 清空Cookie
            HttpCookie hcUserId = context.Request.Cookies[Key.USER_ID];

            if (hcUserId != null)
            {
                hcUserId.Expires = DateTime.Now.AddDays(-1);//设置过期时间
                context.Request.Cookies.Add(hcUserId);//添加至响应报文
            }           
            

            //3.0 跳转到登录界面
            context.Response.Redirect("/Login.aspx");
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