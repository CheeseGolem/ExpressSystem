using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Express.Common
{
    /// <summary>
    /// AJAX������
    /// </summary>
    public class AjaxHelper
    {
        /// <summary>
        /// ���JSON
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        private static void WriteJson(AjaxSatusEnum status, string msg = "", object data = null)
        {
            AjaxObject objAjax = new AjaxObject()
            {
                Status = status,
                Msg = msg,
                Data = data,
            };
            HttpContext.Current.Response.Write(JsonHelper.Serialize(objAjax));//������ת����JSON�ַ���
            HttpContext.Current.Response.End();//��������Ӧ�� ����Ĵ��벻�ᱻִ��
        }

        /// <summary>
        /// ����ɹ�JSON
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        public static void WriteSuccessJson(string msg = "", object data = null)
        {
            WriteJson(AjaxSatusEnum.Success, msg, data);
        }
        /// <summary>
        /// �������JSON
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        public static void WriteErrorJson(string msg, object data = null)
        {
            WriteJson(AjaxSatusEnum.Error, msg, data);
        }
        /// <summary>
        /// ���δ��¼JSON
        /// </summary>
        public static void WriteNoLoginJson()
        {
            WriteJson(AjaxSatusEnum.NoLogin, "����δ��¼", null);
        }
    }
}
