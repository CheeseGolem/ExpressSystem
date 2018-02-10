using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Express.OPPortal
{
    using Express.BLL;
    using Express.Model;

    public partial class List : PageBase
    {
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
            List<Ep_User> list = bllUser.GetModelList("");//读取所有的用户数据

            //可以赋值为 DataSet 、 DataTable 、 List<T>
            repUserList.DataSource = list;//设置数据源
            repUserList.DataBind();//绑定数据
        }

        protected void repUserList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void repUserList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}