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

    public partial class MyExpress : System.Web.UI.Page
    {
        Ep_ExpressBLL bllExpress = new Ep_ExpressBLL();

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
            List<Ep_Express> list = bllExpress.GetModelList("");//读取所有的快递数据

            //可以赋值为 DataSet 、 DataTable 、 List<T>
            rptExpress.DataSource = list;//设置数据源
            rptExpress.DataBind();//绑定数据
        }
    }
}