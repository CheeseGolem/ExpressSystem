using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Express.OPPortal.Comment
{
    using Express.Model;
    using Express.BLL;
    using Express.Common;

    public partial class List : PageBase
    {
        Ep_QuestionBLL bllQuestion = new Ep_QuestionBLL();
        Ep_AnswerBLL bllAns = new Ep_AnswerBLL();

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
            List<Ep_Question> list = bllQuestion.GetModelList("");//读取所有的用户数据

            //可以赋值为 DataSet 、 DataTable 、 List<T>
            repQuestionList.DataSource = list;//设置数据源
            repQuestionList.DataBind();//绑定数据
        }

        protected void repQuestionList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)//AlternatingItem 间隔行
            {
                //在当前行中查询指定控件
                Label lblId = e.Item.FindControl("lblId") as Label;
                Label lblStatus = e.Item.FindControl("lblStatus") as Label;

                //if (hasAns)
                //{
                //    lblStatus.Text = 
                //}
                if (lblId != null)
                {
                    bool hasAns = bllAns.HasAnswerByQId(Convert.ToInt32(lblId.Text));
                    //获取控件中的文本
                    string strCommentStatus = Convert.ToInt32(hasAns).ToString();//用户状态值
                                                              //转换枚举
                    CommentStatus enumCommentStatus = (CommentStatus)Enum.Parse(typeof(CommentStatus), strCommentStatus);
                    //获取枚举描述
                    strCommentStatus = Convert.ToInt32(strCommentStatus).GetDescription<CommentStatus>();
                    //将Label控件的文本重新赋值
                    lblStatus.Text = strCommentStatus;

                    //根据状态设置前景色
                    switch (enumCommentStatus)
                    {
                        case CommentStatus.Unanswered:
                            lblStatus.ForeColor = System.Drawing.Color.Red;
                            break;
                        case CommentStatus.Replied:
                            lblStatus.ForeColor = System.Drawing.Color.Green;
                            break;
                        default:
                            break;
                    }
                }                
            }
        }

        protected void repQuestionList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}