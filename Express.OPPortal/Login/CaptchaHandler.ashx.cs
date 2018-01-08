using Express.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Express.OPPortal.Captcha
{
    /// <summary>
    /// Captcha 的摘要说明
    /// </summary>
    public class CaptchaHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        //读写Session 必须要实现 System.Web.SessionState.IRequiresSessionState 接口
        //读Session   只需要实现 System.Web.SessionState.IReadOnlySessionState

        public void ProcessRequest(HttpContext context)
        {
            string captcha = string.Empty;
            context.Response.ContentType = "image/jpeg";

            using (Image img = new Bitmap(100, 30))
            {
                using (Graphics g = Graphics.FromImage(img))
                {
                    //背景色
                    g.Clear(Color.White);

                    //边框
                    g.DrawRectangle(Pens.Black, 0, 0, img.Width - 2, img.Height - 2);

                    //随机数
                    captcha = GenerateRandomNumber(4);
                    g.DrawString(captcha, new Font("宋体", 20, FontStyle.Bold | FontStyle.Italic), Brushes.Red, new PointF(15, 2));

                    //噪点
                    this.DrawLine(g, img.Width, img.Height, Pens.YellowGreen, 20);
                }

                context.Session[Key.CAPTCHA] = captcha;//保存随机数
                img.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        #region 画噪点
        /// <summary>
        /// 画噪点
        /// </summary>
        /// <param name="g">Graphics对象</param>
        /// <param name="imgWidth">验证码宽度</param>
        /// <param name="imgHeight">验证码高度</param>
        /// <param name="pen">线条颜色</param>
        /// <param name="lineCount">画多少条线</param>
        private void DrawLine(Graphics g, int imgWidth, int imgHeight, Pen pen, int lineCount)
        {
            Random r = new Random();

            for (int i = 0; i < lineCount; i++)
            {
                int x1 = r.Next(1, imgWidth - 2);
                int y1 = r.Next(1, imgHeight - 2);
                int x2 = r.Next(1, imgWidth - 2);
                int y2 = r.Next(1, imgHeight - 2);

                g.DrawLine(pen, new PointF(x1, y1), new PointF(x2, y2));
            }
        }
        #endregion

        #region 生成随机数
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="count">生成个数</param>
        /// <returns></returns>
        private string GenerateRandomNumber(int count)
        {
            string strAll = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ";//去除大写O
            string strNumber = string.Empty;
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                int index = random.Next(0, strAll.Length);
                strNumber += strAll.Substring(index, 1);
            }

            return strNumber;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}