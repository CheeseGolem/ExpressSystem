using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Common
{
    using System.Web;
    using System.Web.UI;
    public class ScriptHelper
    {
        /// <summary>
        /// 弹窗提示
        /// </summary>
        /// <param name="alert">弹窗提示</param>
        public static void Alert(string alert)
        {
            ExecuteScript("alert('" + alert + "');");
        }

        /// <summary>
        /// 弹窗提示后跳转
        /// </summary>
        /// <param name="alert">弹窗提示</param>
        /// <param name="url">跳转地址</param>
        public static void AlertRedirect(string alert, string url)
        {
            ExecuteScript("alert('" + alert + "');window.location.href='" + url + "'");
        }

        /// <summary>
        /// 弹窗提示后返回上一页
        /// </summary>
        /// <param name="alert"></param>
        public static void AlertGoback(string alert)
        {
            ExecuteScript("alert('" + alert + "');history.go(-1;)");
        }

        /// <summary>
        /// 弹窗提示后刷新当前页面
        /// </summary>
        /// <param name="alert"></param>
        public static void AlertRefresh(string alert)
        {
            ExecuteScript("alert('" + alert + "');window.location.href=window.location.href;");
        }

        /// <summary>
        /// 执行脚本
        /// </summary>
        /// <param name="script"></param>
        private static void ExecuteScript(string script)
        {

            //第一个参数 当前页面的Type
            //第二个参数 不重复的Key
            //第三个参数 脚本
            //第四个参数 true或false  <script>标签是否自动添加

            //是在</body>结束标签之前执行的
            //this.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('您还未登录');", true);

            //是在页面还未加载前，执行的（html元素还未加载、脚本、样式也还未加载）
            //this.ClientScript.RegisterClientScriptBlock()

            Page currentPage = HttpContext.Current.Handler as Page;
            if (currentPage != null)
            {
                currentPage.ClientScript.RegisterStartupScript(currentPage.GetType(), Guid.NewGuid().ToString(), script, true);
            }
            else
            {
                HttpContext.Current.Response.Write("<script>" + script + "</script>");
                HttpContext.Current.Response.End();
            }
        }
    }
}
