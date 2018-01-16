using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Model
{
    using global::Express.Common;

    /// <summary>
    /// 用户状态枚举
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 禁用
        /// </summary>
        [EnumDescription("禁用")]
        Disable = 0,
        /// <summary>
        /// 启用
        /// </summary>
        [EnumDescription("启用")]
        Enable = 1,
    }

    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 系统管理员
        /// </summary>
        [EnumDescription("系统管理员")]
        Admin = 1,
        /// <summary>
        /// 网站管理员
        /// </summary>
        [EnumDescription("网站管理员")]
        WebSite = 2,
    }

    /// <summary>
    /// 不显示与显示
    /// </summary>
    public enum ShowOrHide
    {
        /// <summary>
        /// 不显示
        /// </summary>
        [EnumDescription("不显示")]
        Hide = 0,
        /// <summary>
        /// 显示
        /// </summary>
        [EnumDescription("显示")]
        Show = 1,
    }

    /// <summary>
    /// 快递状态
    /// </summary>
    public enum ExpressStatus
    {
        /// <summary>
        /// 未接收
        /// </summary>
        [EnumDescription("未接收")]
        Unclaimed = 0,
        /// <summary>
        /// 已接收
        /// </summary>
        [EnumDescription("已接收")]
        Received = 1,
        /// <summary>
        /// 超时
        /// </summary>
        [EnumDescription("超时")]
        TimeOut = 2
    }
}
