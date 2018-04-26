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

    public partial class Edit : PageBase
    {
        Ep_ExpressBLL bllExpress = new Ep_ExpressBLL();
        Ep_UserBLL bllUser = new Ep_UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定快递状态
                BindExpressStatus();

                //判断新建页或编辑页
                int strId = Convert.ToInt32(Request.QueryString["id"]);
                //if (!string.IsNullOrWhiteSpace(strId))
                //{
                BindData(strId);
                //}
            }
        }

        /// <summary>
        /// 绑定用户类型下拉框
        /// </summary>
        private void BindExpressStatus()
        {
            ddlStatus.Items.Add(new ListItem("未领取", "0"));
            ddlStatus.Items.Add(new ListItem("已领取", "1"));
            ddlStatus.Items.Add(new ListItem("已超时", "2"));
            //设置默认选中项
            ddlStatus.SelectedValue = "0";
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="userId">用户编号</param>
        private void BindData(int id)
        {
            //1.0 从数据库读取数据
            Ep_ExpressBLL bllExpress = new Ep_ExpressBLL();
            Ep_Express model = bllExpress.GetModel(id);

            //2.0 将数据设置到控件上
            //非空验证
            if (model == null)
            {
                return;
            }

            txtExpressId.Text = model.ExpressId.ToString();
            txtRemark.Text = model.Remark.ToString();
            ddlStatus.SelectedValue = model.Status.ToString();

            Ep_UserBLL bllUser = new Ep_UserBLL();
            Ep_User modelUser = new Ep_User();
            //if (!string.IsNullOrWhiteSpace(model.UserId))
            //{
            modelUser = bllUser.GetModel(model.UserId);
            txtUserName.Text = modelUser.Name.ToString();
            txtPhone.Text = modelUser.Phone.ToString();
            //}                        

            ViewState["id"] = model.ID;//将原数据保存在隐藏域中
            //viewstate 只保存ID
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (rfvExpressId.IsValid && rfvPhone.IsValid)
            {
                Ep_Express model = new Ep_Express();
                model.ExpressId = txtExpressId.Text;
                if (hidUserId.Value != "")
                {
                    model.UserId = Convert.ToInt32(hidUserId.Value);
                }
                model.UserId = 0;
                model.Remark = txtRemark.Text;
                model.Status = Convert.ToInt32(ddlStatus.SelectedIndex);

                if (ViewState["id"] != null)//修改
                {
                    model.ID = Convert.ToInt32(ViewState["id"]);
                    string[] fields = { "Status", "Remark", "ArrivalTime" };
                    string sqlstr = " id=" + model.ID;
                    bllExpress.Update(model, fields, sqlstr);
                    ScriptHelper.AlertRedirect("更新成功", "/ExpressInfo/List.aspx");
                }
                else//新增
                {
                    //model.ID = Guid.NewGuid().ToString();
                    model.ArrivalTime = DateTime.Now;
                    Random random = new Random();
                    model.GetCode = random.Next(0, 999999).ToString("D6");
                    Ep_User modelUser = new Ep_User();
                    if (!bllUser.Exists(model.UserId))
                    {
                        try
                        {
                            //modelUser.UserId = Guid.NewGuid().ToString();                           
                            modelUser.Phone = txtPhone.Text;
                            bllUser.Add(modelUser);
                            model.UserId = bllUser.GetModelList("").Where(o => o.Phone == modelUser.Phone).ToList()[0].UserId;
                            //model.UserId = modelUser.UserId;
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }

                    bllExpress.Add(model);
                    SendTempMsg(model.UserId, model.ExpressId, model.GetCode);
                    ScriptHelper.AlertRedirect("快递添加成功", "/ExpressInfo/List.aspx");
                }
            }
        }

        private void SendTempMsg(int userId, string epId, string code)
        {
            Msg msg = new Msg();

            string openId = bllUser.GetModel(userId).OpenId;

            string baseUrl = AppDomain.CurrentDomain.BaseDirectory;
            SendTemplateMessage bllWx = new SendTemplateMessage();
            msg = bllWx.SendTemplateMessageExpress(openId, epId, code);
            if (msg.Result)
            {
                ScriptHelper.Alert("消息发送成功");
            }
            else
            {
                ScriptHelper.Alert("消息发送失败" + msg.ToString() + "请尝试手动发送");
            }
        }
    }
}