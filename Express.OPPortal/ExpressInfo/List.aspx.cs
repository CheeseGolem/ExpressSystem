using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Express.OPPortal.ExpressInfo
{
    using Express.BLL;
    using Express.Common;
    using Express.Model;
    using HongYang.WeiXin.Base.Impl;
    using System.Text;

    public partial class List : PageBase
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
            List<Ep_Express> list = bllExpress.GetModelList("");//读取所有的用户数据

            //可以赋值为 DataSet 、 DataTable 、 List<T>
            repExpressList.DataSource = list;//设置数据源
            repExpressList.DataBind();//绑定数据
        }

        protected void repExpressList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)//AlternatingItem 间隔行
            {
                LinkButton lbtnStatus = e.Item.FindControl("lbtnStatus") as LinkButton;
                //获取控件中的文本
                string strExpressStatus = lbtnStatus.Text;//用户状态值
                //转换枚举
                ExpressStatus enumExpressStatus = (ExpressStatus)Enum.Parse(typeof(ExpressStatus), strExpressStatus);
                //获取枚举描述
                strExpressStatus = Convert.ToInt32(strExpressStatus).GetDescription<ExpressStatus>();
                //将Label控件的文本重新赋值
                lbtnStatus.Text = strExpressStatus;
                //根据用户状态设置前景色
                switch (enumExpressStatus)
                {
                    case ExpressStatus.TimeOut:
                        lbtnStatus.ForeColor = System.Drawing.Color.Red;
                        break;
                    case ExpressStatus.Received:
                        lbtnStatus.ForeColor = System.Drawing.Color.Green;
                        break;
                    default:
                        break;
                }

                //在当前行中查询指定控件
                Label lblUserId = e.Item.FindControl("lblUserId") as Label;
                Label lblPhone = e.Item.FindControl("lblPhone") as Label;
                //获取控件中的文本
                int strUserId = Convert.ToInt32(lblUserId.Text);
                //将Label控件的文本重新赋值
                Ep_User model = new Ep_User();
                model = bllUser.GetModel(strUserId);
                if (model != null)
                {
                    lblUserId.Text = model.Name.ToString();
                    lblPhone.Text = model.Phone.ToString();
                }
                else
                {
                    lblUserId.Text = "";
                }
            }
        }

        protected void repExpressList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string[] comArg = e.CommandArgument.ToString().Split(',');
            int expressId = Convert.ToInt32(comArg[0]);
            switch (e.CommandName)
            {
                case "Del":
                    DeleteExpress(expressId);
                    break;
                case "Send":
                    SendTempMsg(expressId);
                    break;
                case "Change":
                    ChangeStatus(expressId, comArg[1]);
                    break;
                default:
                    break;
            }
        }

        private void DeleteExpress(int expressId)
        {
            if (bllExpress.Delete(expressId))
            {
                ScriptHelper.AlertRefresh("删除成功");
            }
            else
            {
                ScriptHelper.Alert("删除失败");
            }
        }

        private void SendTempMsg(int epId)
        {
            Msg msg = new Msg();
            Ep_Express entityEp = new Ep_Express();
            entityEp = bllExpress.GetModel(epId);
            string openId = bllUser.GetModel(entityEp.UserId).OpenId;

            string baseUrl = AppDomain.CurrentDomain.BaseDirectory;
            SendTemplateMessage bllWx = new SendTemplateMessage();
            msg = bllWx.SendTemplateMessageExpress(openId, entityEp.ExpressId, entityEp.GetCode);
            if (msg.Result)
            {
                ScriptHelper.Alert("消息发送成功");
            }
            else
            {
                ScriptHelper.Alert("消息发送失败" + msg.ToString() + "请重新发送");
            }
        }

        private void ChangeStatus(int id, string status)
        {
            Ep_Express entity = new Ep_Express();
            entity = bllExpress.GetModel(id);
            if (status == "0")
            {
                entity.Status = 1;
                entity.GetTime = DateTime.Now;
            }
            else if (status == "1")
            {
                entity.Status = 2;
            }
            else
            {
                entity.Status = 0;
            }
            if (bllExpress.Update(entity))
            {
                ScriptHelper.Refresh();
            }
            else
            {
                ScriptHelper.Alert("状态切换失败");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strEpId = txtExpressId.Text.Trim();
            string strUsername = txtUsername.Text.Trim();
            string strEpStatus = ddlEpStatus.SelectedValue;
            string strBeginDate = txtBeginDate.Value;
            string strEndDate = txtEndDate.Value;

            StringBuilder sb = new StringBuilder();
            sb.Append(" and 1=1");
            if (!string.IsNullOrWhiteSpace(strEpId) && strEpId.IsNumber())
            {
                sb.Append(" and ExpressId like '%" + strEpId + "%'");
            }
            if (!string.IsNullOrWhiteSpace(strUsername))
            {
                //需调整
                sb.Append(" and name like '%" + strUsername + "%'");
            }
            if (Convert.ToInt32(strEpStatus) != -1)
            {
                sb.Append(" and Status=" + strEpStatus);
            }
            if (!string.IsNullOrWhiteSpace(strBeginDate))
            {
                sb.Append(" and ArrivalTime>='" + strBeginDate + "'");
            }
            if (!string.IsNullOrWhiteSpace(strEndDate))
            {
                sb.Append(" and ArrivalTime<='" + strEndDate + "'");
            }

            //条件查询，重新绑定数据
            List<Ep_Express> list = bllExpress.GetModelListEpUser(sb.ToString());
            repExpressList.DataSource = list;
            repExpressList.DataBind();
        }
    }
}