using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Express.BLL;
using Express.Common;
using Express.Model;

namespace Express.OPPortal.SendExpress
{
    public partial class List : PageBase
    {
        Ep_UserBLL bllUser = new Ep_UserBLL();
        Ep_ExpressBLL bllExpress = new Ep_ExpressBLL();
        Ep_SendExpressBLL bllSend = new Ep_SendExpressBLL();

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
            List<Ep_SendExpress> list = bllSend.GetModelList("");//读取所有的快递数据

            //可以赋值为 DataSet 、 DataTable 、 List<T>
            repExpressList.DataSource = list;//设置数据源
            repExpressList.DataBind();//绑定数据
        }

        protected void repExpressList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)//AlternatingItem 间隔行
            {
                //在当前行中查询指定控件
                Label lblStatus = e.Item.FindControl("lblStatus") as Label;
                //获取控件中的文本
                string strExpressStatus = lblStatus.Text;//用户状态值
                //转换枚举
                SendStatus enumExpressStatus = (SendStatus)Enum.Parse(typeof(SendStatus), strExpressStatus);
                //获取枚举描述
                strExpressStatus = Convert.ToInt32(strExpressStatus).GetDescription<SendStatus>();
                //将Label控件的文本重新赋值
                lblStatus.Text = strExpressStatus;
                //根据用户状态设置前景色
                switch (enumExpressStatus)
                {
                    case SendStatus.Received:
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        break;
                    case SendStatus.Sent:
                        lblStatus.ForeColor = System.Drawing.Color.Green;
                        break;
                    default:
                        break;
                }

                //在当前行中查询指定控件
                Label lblSendId = e.Item.FindControl("lblSendId") as Label;
                Label lblSendPhone = e.Item.FindControl("lblSendPhone") as Label;
                //获取控件中的文本
                int strUserId = Convert.ToInt32(lblSendId.Text);
                //将Label控件的文本重新赋值
                //if (!string.IsNullOrWhiteSpace(strUserId))
                //{
                Ep_User model = new Ep_User();
                model = bllUser.GetModel(strUserId);
                if (model != null)
                {
                    lblSendId.Text = model.Name.ToString();
                    lblSendPhone.Text = model.Phone.ToString();
                }
                else
                {
                    lblSendId.Text = "";
                }
            }
        }

        protected void repExpressList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int expressId = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Del":                    
                    DeleteExpress(expressId);
                    break;
                case "Print":
                    Print(expressId);
                    break;
                case "Send":
                    Send(expressId);
                    break;
                default:
                    break;
            }
        }

        private void DeleteExpress(int expressId)
        {
            if (bllSend.Delete(expressId))
            {
                ScriptHelper.AlertRefresh("删除成功");
            }
            else
            {
                ScriptHelper.Alert("删除失败");
            }
        }

        private void Print(int expressId)
        {
            Ep_SendExpress entitySend = new Ep_SendExpress();
            entitySend = bllSend.GetModel(expressId);
            entitySend.Status = 1;
            if (bllSend.Update(entitySend))
            {
                ScriptHelper.AlertRefresh("打印成功");
            }
            else
            {
                ScriptHelper.Alert("打印失败");
            }
        }

        private void Send(int expressId)
        {
            Ep_SendExpress entitySend = new Ep_SendExpress();
            entitySend = bllSend.GetModel(expressId);
            entitySend.Status = 2;
            if (bllSend.Update(entitySend))
            {
                ScriptHelper.AlertRefresh("发送成功");
            }
            else
            {
                ScriptHelper.Alert("发送失败");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strReName = txtReceiveName.Text.Trim();
            string strRePhone = txtReceivePhone.Text.Trim();
            string strEpStatus = ddlEpStatus.SelectedValue;
            string strBeginDate = txtBeginDate.Value;
            string strEndDate = txtEndDate.Value;

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1");
            if (!string.IsNullOrWhiteSpace(strReName) && strReName.IsNumber())
            {
                sb.Append(" and ReceiveName like '%" + strReName + "%'");
            }
            if (!string.IsNullOrWhiteSpace(strRePhone))
            {
                //需调整
                sb.Append(" and ReceivePhone like '%" + strRePhone + "%'");
            }
            if (Convert.ToInt32(strEpStatus) != -1)
            {
                sb.Append(" and Status=" + strEpStatus);
            }
            if (!string.IsNullOrWhiteSpace(strBeginDate))
            {
                sb.Append(" and CreateTime>='" + strBeginDate + "'");
            }
            if (!string.IsNullOrWhiteSpace(strEndDate))
            {
                sb.Append(" and CreateTime<='" + strEndDate + "'");
            }

            //条件查询，重新绑定数据
            List<Ep_SendExpress> list = bllSend.GetModelList(sb.ToString());
            repExpressList.DataSource = list;
            repExpressList.DataBind();
        }
    }
}