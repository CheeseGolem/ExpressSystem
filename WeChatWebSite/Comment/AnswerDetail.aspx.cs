using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Express.BLL;
using Express.Model;
using Express.WeiXin;

namespace WeChatWebSite.Comment
{
    public partial class AnswerDetail : BasePage
    {
        Ep_QuestionBLL bllQ = new Ep_QuestionBLL();
        Ep_AnswerBLL bllA = new Ep_AnswerBLL();

        int qId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            qId = Convert.ToInt32(Context.Request.QueryString["qid"]);
            Ep_Question question = new Ep_Question();
            //绑定数据
            if (!IsPostBack)//首次加载页面
            {                
                question = bllQ.GetModel(qId);
                lblQContent.InnerText = question.QContent;
                lblATime.InnerText = question.QTime.ToShortDateString();

                BindData();
            }
        }

        private void BindData()
        {
            List<Ep_Answer> list = bllA.GetModelList(" qid=" + qId);//读取所有的快递数据

            //可以赋值为 DataSet 、 DataTable 、 List<T>
            rptAnswer.DataSource = list;//设置数据源
            rptAnswer.DataBind();//绑定数据
        }
    }
}