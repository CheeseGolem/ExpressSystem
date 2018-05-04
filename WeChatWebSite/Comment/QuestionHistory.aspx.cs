using Express.BLL;
using Express.Model;
using Express.WeiXin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeChatWebSite.Comment
{
    public partial class QuestionHistory : System.Web.UI.Page
    {
        Ep_QuestionBLL bllQ = new Ep_QuestionBLL();
        Ep_AnswerBLL bllA = new Ep_AnswerBLL();        

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
            List<Ep_Question> list = bllQ.GetModelList(" openid='" + WeiXinConfigBase.OpenId + "'");//读取所有的快递数据

            //可以赋值为 DataSet 、 DataTable 、 List<T>
            rptQuestion.DataSource = list;//设置数据源
            rptQuestion.DataBind();//绑定数据
        }
    }
}