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
    using HongYang.WeiXin.Base.Impl;

    public partial class Edit : PageBase
    {
        Ep_QuestionBLL bllQue = new Ep_QuestionBLL();
        Ep_AnswerBLL bllAns = new Ep_AnswerBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

            int qId = Convert.ToInt32(Request.QueryString["id"]);
            BindData(qId);
        }

        public void BindData(int qId)
        {
            Ep_Answer answer = new Ep_Answer();

            lblQuestion.Text = bllQue.GetModel(qId).QContent;

            string strWhere = " qid='" + qId + "' ";
            rptAnswer.DataSource = bllAns.GetModelList(strWhere);
            rptAnswer.DataBind();
        }

        protected void rptAnswer_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptAnswer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int aId;
            switch (e.CommandName)
            {
                case "Del":
                    aId = Convert.ToInt32(e.CommandArgument);
                    DeleteAnswer(aId);
                    break;
                case "Send":
                    aId = Convert.ToInt32(e.CommandArgument);
                    SendTempMsg(aId);
                    break;
                default:
                    break;
            }
        }

        private void DeleteAnswer(int aId)
        {
            if (bllAns.Delete(aId))
            {
                ScriptHelper.AlertRefresh("删除成功");
            }
            else
            {
                ScriptHelper.Alert("删除失败");
            }
        }

        private void SendTempMsg(int aId)
        {
            Msg msg = new Msg();

            int qId = bllAns.GetModel(aId).QId;
            string openId = bllQue.GetModel(qId).Openid;


            string baseUrl = AppDomain.CurrentDomain.BaseDirectory;
            string url = baseUrl + "ART/Consultation/AnswerDetail?qid=" + qId;
            SendTemplateMessage bllWx = new SendTemplateMessage();
            msg = bllWx.SendTemplateMessageAnswer(openId, url, qId);
            if (msg.Result)
            {
                ScriptHelper.Alert("发送成功");
            }
            else
            {
                ScriptHelper.Alert("发送失败" + msg.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (rfvAnswer.IsValid)
            {
                Ep_Answer answer = new Ep_Answer();
                if (hidAnsId.Value != null && hidAnsId.Value != "")
                {
                    //编辑
                    int aId = Convert.ToInt32(hidAnsId.Value);

                    answer = bllAns.GetModel(aId);
                    try
                    {
                        answer.AContent = txtAnswer.Value;
                        answer.ATime = DateTime.Now;
                        bllAns.Update(answer);
                    }
                    catch (Exception ex)
                    {
                        ScriptHelper.AlertRefresh(ex.Message);
                        throw;
                    }
                    ScriptHelper.AlertRedirect("更新成功", "/Comment/Edit.aspx?id=" + answer.QId);

                }
                else
                {
                    //新增
                    answer.QId = Convert.ToInt32(Request.QueryString["id"]);
                    answer.AContent = txtAnswer.Value;
                    answer.ATime = DateTime.Now;
                    try
                    {
                        bllAns.Add(answer);
                    }
                    catch (Exception ex)
                    {
                        ScriptHelper.AlertRefresh(ex.Message);
                        throw;
                    }
                    ScriptHelper.AlertRedirect("回复成功", "/Comment/Edit.aspx?id=" + answer.QId);
                }
            }            
        }
    }
}