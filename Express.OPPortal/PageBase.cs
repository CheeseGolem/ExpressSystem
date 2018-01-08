using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.OPPortal
{
    using Express.BLL;
    using Express.Common;

    public class PageBase : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);//保留父类的操作

            //验证Session
            if (Session[Key.CURRENT_USER] == null)
            {
                //验证Cookie
                CheckCookie();
            }
        }

        private void RedirectLoginPage()
        {
            //提示重新登录
            Response.Write("<script>alert('您还未登录');window.location.href='/Login.aspx';</script>");
            Response.End();
        }

        private void CheckCookie()
        {
            //获取Cookie
            HttpCookie hcUserId = Request.Cookies[Key.USER_ID];
            //过期判断
            if (hcUserId == null)
            {
                RedirectLoginPage();
            }
            //非空判断
            string strUserId = hcUserId.Value;
            if (string.IsNullOrWhiteSpace(strUserId))
            {
                RedirectLoginPage();
            }

            //3DES解密
            strUserId = CryptoHelper.TripleDES_Decrypt(strUserId, Key.COOKIE_KEY);

            //验证UserId格式
            if (string.IsNullOrWhiteSpace(strUserId) || !strUserId.IsNumber())
            {
                RedirectLoginPage();
            }

            //通过验证，根据UserId从数据库获取用户信息
            UserInfoBLL bllUserInfo = new UserInfoBLL();
            Express.Model.UserInfo model = bllUserInfo.GetModel(Convert.ToInt32(strUserId));
            if (model == null)
            {
                RedirectLoginPage();
            }

            //保存Session
            Session[Key.CURRENT_USER] = model;
        }
    }
}