using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Express.OPPortal.UserInfo
{
    using Express.Common;
    using Express.BLL;
    using Express.Model;
    public partial class Edit : PageBase
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定用户类型
                BindUserType();
                //绑定用户状态
                BindUserStatus();

                //判断新建页或编辑页
                string strId = Request.QueryString["id"];
                if (!string.IsNullOrWhiteSpace(strId) && strId.IsNumber())
                {
                    BindData(Convert.ToInt32(strId));
                }              
            }
        }

        /// <summary>
        /// 绑定用户类型下拉框
        /// </summary>
        private void BindUserType()
        {
            ddlUserType.Items.Add(new ListItem("系统管理员", "1"));
            ddlUserType.Items.Add(new ListItem("网站管理员", "2"));
            //设置默认选中项
            ddlUserType.SelectedValue = "2";
        }

        /// <summary>
        /// 绑定用户状态单选框列表
        /// </summary>
        private void BindUserStatus()
        {
            rblStatus.RepeatDirection = RepeatDirection.Horizontal;
            rblStatus.Items.Add(new ListItem("禁用", "0"));
            rblStatus.Items.Add(new ListItem("启用", "1"));
            //设置默认选中项
            rblStatus.SelectedValue = "1";
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="userId">用户编号</param>
        private void BindData(int userId)
        {
            //1.0 从数据库读取数据
            UserInfoBLL bllUserInfo = new UserInfoBLL();
            UserInfo model = bllUserInfo.GetModel(userId);
            //2.0 将数据设置到控件上
            //非空验证
            if (model == null)
            {
                return;
            }

            txtUserId.Value = model.UserId.ToString(); //在前端保留UserId
            txtUsername.Text = model.Username;

            txtPassword.Attributes["value"] = "******";
            //密码的默认值

            txtRealName.Text = model.RealName;
            txtPhone.Text = model.Phone;
            ddlUserType.SelectedValue = model.UserType.ToString();
            rblStatus.SelectedValue = model.Status.ToString();
        }
    }
}