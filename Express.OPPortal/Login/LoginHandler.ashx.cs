using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.OPPortal.Ajax
{
    using Express.Common;
    using Express.BLL;
    using Express.Model;
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler,System.Web.SessionState.IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //1.0 接收参数
            string strUsername = context.Request.Form["Username"];
            string strPassword = context.Request.Form["Password"];
            string strCaptcha = context.Request.Form["Captcha"];
            string strIsAutoLogin = context.Request.Form["IsAutoLogin"];        
            //2.0 非空验证
            string msg = string.Empty;
            if (!CheckParameter(strUsername,strPassword,strCaptcha,out msg))
            {
                AjaxHelper.WriteErrorJson(msg);
            }         
            //3.0 验证验证码
            string sessionCaptcha = context.Session[Key.CAPTCHA].ToString();
            if (sessionCaptcha.ToLower()!=strCaptcha.ToLower())
            {
                AjaxHelper.WriteErrorJson("验证码不匹配");
            }
            Ep_AdminBLL bllAdmin = new Ep_AdminBLL();
            //4.0 账户是否存在
            Ep_Admin model = bllAdmin.GetModelByUsername(strUsername);
            if (model == null)
            {
                AjaxHelper.WriteErrorJson("用户名不存在");
            }
            //5.0 账户是否被禁用
            if (model.Status == (int)UserStatus.Disable)
            {
                AjaxHelper.WriteErrorJson("此用户已被禁用");
            }
            //6.0 密码是否正确
            if (model.Password!=strPassword)
            {
                AjaxHelper.WriteErrorJson("用户名或密码错误");
            }
            //密码验证3次 计数保存在Session中
            //7.0 如果密码正确，登录成功，保存用户信息到Session
            context.Session[Key.CURRENT_USER] = model;        
            //8.0是否自动登录，生成cookie
            if (!string.IsNullOrWhiteSpace(strIsAutoLogin) && strIsAutoLogin.ToLower() == "true")
            {
                GenerateCookie(model);
            }
            AjaxHelper.WriteSuccessJson();
        }

        /// <summary>
        /// 生成Cookie
        /// </summary>
        /// <param name="model"></param>
        private void GenerateCookie(Ep_Admin model)
        {
            HttpCookie hcUserId = new HttpCookie(Key.USER_ID);
            hcUserId.Value = CryptoHelper.TripleDES_Encrypt(model.UserId.ToString(), Key.COOKIE_KEY);//3DES加密
            hcUserId.Expires = DateTime.Now.AddDays(1);

            HttpContext.Current.Response.Cookies.Add(hcUserId);
        }

        /// <summary>
        /// 验证请求参数
        /// </summary>
        /// <param name="strUsername"></param>
        /// <param name="strPassword"></param>
        /// <param name="strCaptcha"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool CheckParameter(string strUsername,string strPassword,string strCaptcha,out string msg)
        {
            bool flag = true;
            msg = string.Empty;

            if (string.IsNullOrWhiteSpace(strUsername))
            {
                msg = "请输入用户名";
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(strPassword))
            {
                msg = "请输入密码";
                flag = false;
            }
            if (string.IsNullOrWhiteSpace(strCaptcha))
            {
                msg = "请输入验证码";
                flag = false;
            }
            return flag;
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