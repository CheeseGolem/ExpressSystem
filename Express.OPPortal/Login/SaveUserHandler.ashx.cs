using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.OPPortal.Ajax
{
    using Express.OPPortal;
    using Express.BLL;
    using Express.Model;
    using Express.Common;
    /// <summary>
    /// SaveUserHandler 的摘要说明
    /// </summary>
    public class SaveUserHandler : BaseHandler
    {       
        public override void SubProcessRequest()
        {
            AdminBLL bllAdmin = new AdminBLL();
            //1.0 接收数据
            string strUserId = Context.Request.Form["UserId"];
            string strUsername = Context.Request.Form["Username"];
            string strPassword = Context.Request.Form["Password"];
            string strRealName = Context.Request.Form["RealName"];
            string strPhone = Context.Request.Form["Phone"];
            string strUserType = Context.Request.Form["UserType"];
            string strStatus = Context.Request.Form["Status"];
            
            //非空判断
            Admin model = new Admin();
            model.UserId = !string.IsNullOrWhiteSpace(strUserId) ? Convert.ToInt32(strUserId) : 0;
            model.Username = !string.IsNullOrWhiteSpace(strUsername) ? strUsername : "";
            model.Password=!string.IsNullOrWhiteSpace(strUsername)?strPassword.ToUpper():"";//统一大写
            model.RealName = !string.IsNullOrWhiteSpace(strUsername) ? strRealName : "";
            model.Phone = !string.IsNullOrWhiteSpace(strUsername) ? strPhone : "";
            model.UserType = !string.IsNullOrWhiteSpace(strUsername) ? Convert.ToInt32(strUserType) : 2;
            model.Status = !string.IsNullOrWhiteSpace(strUsername) ? Convert.ToInt32(strStatus) : 1;

            //2.0判断用户名是否存在
            if (bllAdmin.isExistsUsername(model.Username, model.UserId))
            {
                AjaxHelper.WriteErrorJson("该用户已存在");
            }

            //3.0 更新数据

            if (bllAdmin.AddOrUpdate(model))//新增
            {
                AjaxHelper.WriteSuccessJson();
            }
            else//修改
            {
                AjaxHelper.WriteErrorJson("保存失败");
            }
        }
    }
}