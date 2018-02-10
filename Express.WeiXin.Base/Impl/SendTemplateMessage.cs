using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HongYang.WeiXin.Base.Impl
{
    using Express.BLL;
    using Express.Common;
    using Express.Model;
    using Express.WeiXin;
    using Senparc.Weixin.Entities;
    using Senparc.Weixin.MP.AdvancedAPIs;
    using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
    using Senparc.Weixin.MP.Containers;

    public class SendTemplateMessage
    {
        public Msg SendTemplateMessageAnswer(string openId, string url, int qId)
        {            
            Msg msg = new Msg();
            //Ep_Question question = new Ep_Question();
            //Ep_Answer answer = new Ep_Answer();
            Ep_QuestionBLL bllQue = new Ep_QuestionBLL();
            Ep_AnswerBLL bllAns = new Ep_AnswerBLL();

            string appId = WeiXinConfigBase.AppID;
            string templateId = "VQMSnKrUcxziaA9tY3zqJlI5WJLeYuSq2sg4zEqxKI8";
            string templateName = "评价回复";
            string msgQContent = bllQue.GetModel(qId).QContent;
            string msgAContent = bllAns.GetModelList(" qid='" + qId + "' ")[0].AContent;

            var testData = new //TestTemplateData()
            {
                first = new TemplateDataItem(templateName),
                keyword1 = new TemplateDataItem(msgQContent),
                keyword2 = new TemplateDataItem(msgAContent),
                remark = new TemplateDataItem(DateTime.Now.ToString())
            };

            //var result = 
            WxJsonResult result = new WxJsonResult();
            msg.Result = true;
            try
            {
                result = TemplateApi.SendTemplateMessage(appId, openId, templateId, url, testData);
            }
            catch (Exception ex)
            {
                msg.Result = false;
                msg.AddMsg(ex.Message);
                return msg;
            }
            return msg;
        }

        public Msg SendTemplateMessageExpress(string openId, string url, int id)
        {
            Msg msg = new Msg();
            Ep_ExpressBLL bllExpress = new Ep_ExpressBLL();

            string appId = WeiXinConfigBase.AppID;
            string templateId = "eD5PjZMSSC9MpPiFhk8n6LEA5aPwBeASdh7GzSXj58c";
            string templateName = "快递到站提醒";
            string expressId = bllExpress.GetModel(id).ExpressId;
            string expressAddress = "XX小区XX超市";
            string code = "";

            var testData = new //TestTemplateData()
            {
                first = new TemplateDataItem(templateName),
                keyword1 = new TemplateDataItem(expressId),
                keyword2 = new TemplateDataItem(expressAddress),
                keyword3 = new TemplateDataItem(code),
                remark = new TemplateDataItem(DateTime.Now.ToString())
            };

            //var result = 
            WxJsonResult result = new WxJsonResult();
            msg.Result = true;
            try
            {
                result = TemplateApi.SendTemplateMessage(appId, openId, templateId, url, testData);
            }
            catch (Exception ex)
            {
                msg.Result = false;
                msg.AddMsg(ex.Message);
                return msg;
            }
            return msg;
        }
    }
}
