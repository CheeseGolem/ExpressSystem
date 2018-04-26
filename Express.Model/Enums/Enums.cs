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
        [EnumDescription("已超时")]
        TimeOut = 2
    }

    /// <summary>
    /// 快递类型
    /// </summary>
    public enum ExpressType
    {
        /// <summary>
        /// 普通件
        /// </summary>
        [EnumDescription("普通件")]
        Ordinary = 1,
        /// <summary>
        /// 贵重件
        /// </summary>
        [EnumDescription("贵重件")]
        Precious = 2,
        /// <summary>
        /// 大体积
        /// </summary>
        [EnumDescription("大体积")]
        Large = 3,
    }

    /// <summary>
    /// 回复状态
    /// </summary>
    public enum CommentStatus
    {
        /// <summary>
        /// 未回复
        /// </summary>
        [EnumDescription("未回复")]
        Unanswered = 0,
        /// <summary>
        /// 已回复
        /// </summary>
        [EnumDescription("已回复")]
        Replied = 1,
    }

    /// <summary>
    /// 寄件状态
    /// </summary>
    public enum SendStatus
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
        /// 已发送
        /// </summary>
        [EnumDescription("已发送")]
        Sent = 2,
    }
}
