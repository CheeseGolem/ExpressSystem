using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Express.OPPortal.LocationInfo
{
    using Express.BLL;
    using Express.Common;
    using Express.Model;
    public partial class List : PageBase
    {
        Ep_ShelfBLL bllShelf = new Ep_ShelfBLL();
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
            List<Ep_Shelf> list = bllShelf.GetModelList("").OrderBy(o => o.Shelf).ToList();//读取所有的用户数据

            //可以赋值为 DataSet 、 DataTable 、 List<T>
            repShelfList.DataSource = list;//设置数据源
            repShelfList.DataBind();//绑定数据
        }

        protected void repShelfList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)//AlternatingItem 间隔行
            {
                //在当前行中查询指定控件
                Label lblType = e.Item.FindControl("lblType") as Label;
                //获取控件中的文本
                string strExpressType = lblType.Text;//用户状态值
                //转换枚举
                ExpressType enumExpressType = (ExpressType)Enum.Parse(typeof(ExpressType), strExpressType);
                //获取枚举描述
                strExpressType = Convert.ToInt32(strExpressType).GetDescription<ExpressType>();
                //将Label控件的文本重新赋值
                lblType.Text = strExpressType;
            }
        }

        protected void repShelfList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Del":
                    int shelfId = Convert.ToInt32(e.CommandArgument);
                    DeleteShelf(shelfId);
                    break;
                default:
                    break;
            }
        }

        private void DeleteShelf(int sId)
        {
            if (bllShelf.Delete(sId))
            {
                ScriptHelper.AlertRefresh("删除成功");
            }
            else
            {
                ScriptHelper.Alert("删除失败");
            }
        }

    }
}