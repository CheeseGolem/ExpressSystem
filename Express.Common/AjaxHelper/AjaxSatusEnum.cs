using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Common
{
    /// <summary>
    /// AJAX状态枚举
    /// </summary>
    public enum AjaxSatusEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 未登录
        /// </summary>
        NoLogin = 1,
        /// <summary>
        /// 错误
        /// </summary>
        Error = -1,
    }
}
