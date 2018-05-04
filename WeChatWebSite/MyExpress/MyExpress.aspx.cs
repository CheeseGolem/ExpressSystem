using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeChatWebSite.MyExpress
{
    using Express.Model;
    using Express.BLL;
    using Express.WeiXin;

    public partial class MyExpress : BasePage
    {
        Ep_ExpressBLL bllExpress = new Ep_ExpressBLL();
        Ep_UserBLL bllUser = new Ep_UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定数据
            if (!IsPostBack)//首次加载页面
            {
                BindData();
            }
        }

        private void BindData()
        {
            string openId = "";
            try
            {
                //Session.Remove(WeiXinConfigBase.OpenidKey);
                openId = Context.Session[WeiXinConfigBase.OpenidKey].ToString();
            }
            catch (Exception)
            {
                Context.Response.Redirect("/UserBind/UserBind.aspx");
                throw;
            }

            //int userId = bllUser.GetModelList(" openid='" + openId + "'")[0].UserId;
            string phone = bllUser.GetModelList(" openid='" + openId + "'")[0].Phone;
            List<Ep_Express> list = bllExpress.GetModelList(" ReceivePhone='" + phone + "'");//读取所有的快递数据
            if (list.Count == 0)
            {
                Ep_Express ep = new Ep_Express();
                ep.ExpressId = "没有快递信息";
                list.Add(ep);
            }
            //可以赋值为 DataSet 、 DataTable 、 List<T>
            rptExpress.DataSource = list;//设置数据源
            rptExpress.DataBind();//绑定数据
        }
    }
}