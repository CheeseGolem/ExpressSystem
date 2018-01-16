using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Express.OPPortal
{
    using System.Text.RegularExpressions;
    using Express.Common;
    using Express.Model;

    public partial class AdminPage : System.Web.UI.MasterPage
    {
        protected string realName = string.Empty;
        protected string module = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //当前用户
            Ep_Admin currentUser = Session[Key.CURRENT_USER] as Ep_Admin;
            realName = currentUser.RealName;            

            //获取当前的请求链接
            string url = Request.RawUrl;//地址栏url
            Regex reg = new Regex(@"^/(\w+)/\w+.aspx");
            Match m = reg.Match(url);
            //Groups[0]为全部分组
            module = m.Groups[1].Value;//第一个分组的数据
        }
    }
}