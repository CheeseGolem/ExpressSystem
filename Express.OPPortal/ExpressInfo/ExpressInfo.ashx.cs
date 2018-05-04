using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Express.OPPortal.ExpressInfo
{
    using Express.BLL;
    using Express.Common;
    using Express.Model;
    /// <summary>
    /// ExpressInfo 的摘要说明
    /// </summary>
    public class ExpressInfo : IHttpHandler
    {
        

        public void ProcessRequest(HttpContext context)
        {
            context.Request.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            string method = context.Request.Params["getmethod"];
            this.GetType().GetMethod(method).Invoke(this, new object[] { context });
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void GetPhone(HttpContext context)
        {
            string strECode = context.Request["ecode"];
            string sqlWhere = " ExpressCode='" + strECode + "'";

            VirtualExpressBLL bllVE = new VirtualExpressBLL();
            VirtualExpress entityVE = new VirtualExpress();
            entityVE = bllVE.GetModelList(sqlWhere).ToList()[0];

            context.Response.Write(JsonHelper.Serialize(entityVE));
        }

        public void GetUser(HttpContext context)
        {
            string strPhone = context.Request["phone"];
            string sqlWhere = "phone='" + strPhone + "'";

            Ep_UserBLL bllUser = new Ep_UserBLL();
            List<Ep_User> list = new List<Ep_User>();
            list = bllUser.GetModelList(sqlWhere).ToList();

            context.Response.Write(JsonHelper.Serialize(list));            
        }
    }
}