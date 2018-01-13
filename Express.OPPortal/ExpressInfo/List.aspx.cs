using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Express.OPPortal.ExpressInfo
{
    using Express.BLL;
    using Express.Model;
    public partial class List : PageBase
    {
        ExpressBLL bllExpress = new ExpressBLL();
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
            List<Express> list = bllExpress.GetModelList("");//读取所有的用户数据

            //可以赋值为 DataSet 、 DataTable 、 List<T>
            repExpressList.DataSource = list;//设置数据源
            repExpressList.DataBind();//绑定数据
        }

        protected void repExpressList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)//AlternatingItem 间隔行
            //{
            //    //在当前行中查询指定控件
            //    Label lblStatus = e.Item.FindControl("lblStatus") as Label;
            //    //获取控件中的文本
            //    string strUserStatus = lblStatus.Text;//用户状态值
            //    //转换枚举
            //    UserStatus enumUserStatus = (UserStatus)Enum.Parse(typeof(UserStatus), strUserStatus);
            //    //获取枚举描述
            //    strUserStatus = Convert.ToInt32(strUserStatus).GetDescription<UserStatus>();
            //    //将Label控件的文本重新赋值
            //    lblStatus.Text = strUserStatus;
            //    //根据用户状态设置前景色
            //    switch (enumUserStatus)
            //    {
            //        case UserStatus.Disable:
            //            lblStatus.ForeColor = System.Drawing.Color.Red;
            //            break;
            //        case UserStatus.Enable:
            //            lblStatus.ForeColor = System.Drawing.Color.Green;
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        protected void repExpressList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}