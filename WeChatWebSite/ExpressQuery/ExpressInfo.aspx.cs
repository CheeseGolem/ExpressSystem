using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Express.BLL;
using Express.Model;

namespace WeChatWebSite.ExpressQuery
{
    public partial class ExpressInfo : BasePage
    {
        VirtualExpressBLL bllVE = new VirtualExpressBLL();

        string expressCode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            expressCode = Context.Request.QueryString["ECode"].ToString();

            if (!IsPostBack)
            {
                ExpressDetail(expressCode);
            }
        }

        private void ExpressDetail(string eCode)
        {
            VirtualExpress entityVE = new VirtualExpress();
            List<EInfo> listEInfo = new List<EInfo>();
            List<VirtualExpress> listVE = new List<VirtualExpress>();
            listVE = bllVE.GetModelList(" ExpressCode='" + eCode + "' ");
            
            if (listVE.Count > 0)
            {
                entityVE = bllVE.GetModelList(" ExpressCode='" + eCode + "' ")[0];

                lblSendName.InnerText = entityVE.SendName;
                lblSendPhone.InnerText = entityVE.SendPhone;
                lblReceiveName.InnerText = entityVE.ReceivedName;
                lblReceivePhone.InnerText = entityVE.ReceivedPhone;

                string[] arrInfo = entityVE.Info.Split('|');
                foreach (var item in arrInfo)
                {
                    if (item.IndexOf('+') > 0)
                    {
                        EInfo eInfo = new EInfo();
                        string[] arr = item.Split('+');
                        eInfo.Time = arr[0].Replace(" ", "<br />");
                        eInfo.Info = arr[1];
                        listEInfo.Add(eInfo);
                    }
                }                
            }
            else
            {
                EInfo eInfo = new EInfo();
                eInfo.Info = "暂无物流信息";
                listEInfo.Add(eInfo);
            }
            rptAnswer.DataSource = listEInfo;
            rptAnswer.DataBind();
        }
    }

    public class EInfo
    {
        public string Time { get; set; }
        public string Info { get; set; }
    }
}