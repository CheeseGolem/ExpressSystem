using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.OPPortal
{
    using Express.BLL;
    using Express.Common;
    using Express.Model;
    public abstract class BaseHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            //验证登录
            CheckLogin();

            SubProcessRequest();//由子类重写
        }

        /// <summary>
        /// 验证登录
        /// </summary>
        private void CheckLogin()
        {
            //验证Session
            if (HttpContext.Current.Session[Key.CURRENT_USER] == null)
            {
                //验证Cookie
                CheckCookie();
            }
        }

        private void CheckCookie()
        {
            //获取Cookie
            HttpCookie hcUserId = new HttpCookie(Key.USER_ID);
            //过期判断
            if (hcUserId == null)
            {
                AjaxHelper.WriteNoLoginJson();
            }
            //非空判断
            string strUserId = hcUserId.Value;
            if (string.IsNullOrWhiteSpace(strUserId))
            {
                AjaxHelper.WriteNoLoginJson();
            }

            //3DES解密
            strUserId = CryptoHelper.TripleDES_Decrypt(strUserId, Key.COOKIE_KEY);

            //验证UserId格式
            if (string.IsNullOrWhiteSpace(strUserId) || !strUserId.IsNumber())
            {
                AjaxHelper.WriteNoLoginJson();
            }

            //通过验证，根据UserId从数据库获取用户信息
            UserInfoBLL bllUserInfo = new UserInfoBLL();
            Express.Model.UserInfo model = bllUserInfo.GetModel(Convert.ToInt32(strUserId));
            if (model == null)
            {
                AjaxHelper.WriteNoLoginJson();
            }

            //保存Session
            HttpContext.Current.Session[Key.CURRENT_USER] = model;
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
    }
}