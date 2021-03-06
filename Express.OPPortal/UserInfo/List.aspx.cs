﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Express.OPPortal
{
    using Express.BLL;
    using Express.Model;
    using System.Text;

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strUsername = txtUsername.Text.Trim();
            string strNickName = txtNickName.Text.Trim();
            string strPhone = txtPhone.Text.Trim();
            string strBeginDate = txtBeginDate.Value;
            string strEndDate = txtEndDate.Value;

            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            if (!string.IsNullOrWhiteSpace(strUsername))
            {
                sb.Append(" and Name like '%" + strUsername + "%'");
            }
            if (!string.IsNullOrWhiteSpace(strNickName))
            {
                sb.Append(" and NickName like '%" + strNickName + "%'");
            }
            if (!string.IsNullOrWhiteSpace(strPhone))
            {
                sb.Append(" and Phone like '%" + strPhone + "%'");
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
            List<Ep_User> list = bllUser.GetModelList(sb.ToString());
            repUserList.DataSource = list;
            repUserList.DataBind();
        }

        protected void repUserList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void repUserList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}