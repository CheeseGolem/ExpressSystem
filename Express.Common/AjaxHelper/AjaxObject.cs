using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Common
{
    /// <summary>
    /// Ajax对象
    /// </summary>
    public class AjaxObject
    {
        /// <summary>
        /// 构造函数 初始化属性
        /// </summary>
        public AjaxObject()
        {
            
            this.Status = 0;
            this.Msg = string.Empty;
            this.Data = null;
        }
        /// <summary>
        /// 状态 0表示成功 1表示还未登录 其他表示其他错误
        /// </summary>
        public AjaxSatusEnum Status { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 附加数据
        /// </summary>
        public object Data { get; set; }
    }
}
