using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Model
{
    using Express.Common;
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

    public enum CategoryType
    {
        /// <summary>
        /// 链接
        /// </summary>
        [EnumDescription("链接")]
        Link = 1,
        /// <summary>
        /// 内容页
        /// </summary>
        [EnumDescription("内容页")]
        ContentPage = 2,
        /// <summary>
        /// 新闻列表
        /// </summary>
        [EnumDescription("新闻列表")]
        NewsList = 3,
        /// <summary>
        /// 产品列表
        /// </summary>
        [EnumDescription("产品列表")]
        ProductList = 4,
    }

    public enum NewsType
    {
        /// <summary>
        /// 公司新闻
        /// </summary>
        [EnumDescription("公司新闻")]
        CompanyNews = 9,
        /// <summary>
        /// 行业新闻
        /// </summary>
        [EnumDescription("行业新闻")]
        IndustryNews = 10,
        /// <summary>
        /// 下载中心
        /// </summary>
        [EnumDescription("下载中心")]
        DownloadCenter = 24,
    }

    public enum ProductType
    {
        /// <summary>
        /// 数码播放器
        /// </summary>
        [EnumDescription("数码播放器")]
        Player=12,
        /// <summary>
        /// MP3
        /// </summary>
        [EnumDescription("MP3")]
        Mp3 = 13,
        /// <summary>
        /// MP4
        /// </summary>
        [EnumDescription("MP4")]
        Mp4=14,
        /// <summary>
        /// GPS
        /// </summary>
        [EnumDescription("GPS")]
        GPS=15
    }
}
