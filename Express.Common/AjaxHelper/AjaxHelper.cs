using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Express.Common
{
    /// <summary>
    /// AJAX帮助类
    /// </summary>
    public class AjaxHelper
    {
        /// <summary>
        /// 输出JSON
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
            HttpContext.Current.Response.Write(JsonHelper.Serialize(objAjax));//将对象转换成JSON字符串
            HttpContext.Current.Response.End();//【结束响应】 下面的代码不会被执行
        }

        /// <summary>
        /// 输出成功JSON
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        public static void WriteSuccessJson(string msg = "", object data = null)
        {
            WriteJson(AjaxSatusEnum.Success, msg, data);
        }
        /// <summary>
        /// 输出错误JSON
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        public static void WriteErrorJson(string msg, object data = null)
        {
            WriteJson(AjaxSatusEnum.Error, msg, data);
        }
        /// <summary>
        /// 输出未登录JSON
        /// </summary>
        public static void WriteNoLoginJson()
        {
            WriteJson(AjaxSatusEnum.NoLogin, "您还未登录", null);
        }
    }
}
