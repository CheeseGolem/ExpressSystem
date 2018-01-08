using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Express.OPPortal.UserInfo
{
    using Express.BLL;
    using Express.Model;
    using Express.Common;
    using System.Text;
    public partial class List : PageBase
    {
        UserInfoBLL bllUserInfo = new UserInfoBLL();
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
            List<UserInfo> list = bllUserInfo.GetModelList("");//读取所有的用户数据

            //可以赋值为 DataSet 、 DataTable 、 List<T>
            repUserInfoList.DataSource = list;//设置数据源
            repUserInfoList.DataBind();//绑定数据
        }

        protected void repUserInfoList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)//AlternatingItem 间隔行
            {
                //在当前行中查询指定控件
                Label lblStatus = e.Item.FindControl("lblStatus") as Label;
                //获取控件中的文本
                string strUserStatus = lblStatus.Text;//用户状态值
                //转换枚举
                UserStatus enumUserStatus = (UserStatus)Enum.Parse(typeof(UserStatus), strUserStatus);
                //获取枚举描述
                strUserStatus = Convert.ToInt32(strUserStatus).GetDescription<UserStatus>();
                //将Label控件的文本重新赋值
                lblStatus.Text = strUserStatus;
                //根据用户状态设置前景色
                switch (enumUserStatus)
                {
                    case UserStatus.Disable:
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        break;
                    case UserStatus.Enable:
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        break;
                    default:
                        break;
                }
            }
        }

        protected void repUserInfoList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Del":
                    int userId = Convert.ToInt32(e.CommandArgument);
                    DeleteUserInfo(userId);
                    break;
                default:
                    break;
            }
        }

        private void DeleteUserInfo(int userId)
        {
            if (bllUserInfo.Delete(userId))
            {
                ScriptHelper.AlertRefresh("删除成功");
            }
            else
            {
                ScriptHelper.Alert("删除失败");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strUserId = txtUserId.Text.Trim();
            string strUsername = txtUsername.Text.Trim();
            string strUserType = ddlUserType.SelectedValue;
            string strBeginDate = txtBeginDate.Value;
            string strEndDate = txtEndDate.Value;

            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (!string.IsNullOrWhiteSpace(strUserId) && strUserId.IsNumber())
            {
                sb.Append(" and UserId= " + strUserId);
            }
            if (!string.IsNullOrWhiteSpace(strUsername))
            {
                sb.Append(" and Username like '%" + strUsername + "%'");
            }
            if (Convert.ToInt32(strUserType) != -1)
            {
                sb.Append(" and UserType=" + strUserType);
            }
            if (!string.IsNullOrWhiteSpace(strBeginDate))
            {
                sb.Append(" and CreateDate>='" + strBeginDate + "'");
            }
            if (!string.IsNullOrWhiteSpace(strEndDate))
            {
                sb.Append(" and CreateDate<='" + strEndDate + "'");
            }

            //条件查询，重新绑定数据
            List<UserInfo> list = bllUserInfo.GetModelList(sb.ToString());
            repUserInfoList.DataSource = list;
            repUserInfoList.DataBind();
        }
    }
}