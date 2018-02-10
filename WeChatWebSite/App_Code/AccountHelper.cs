using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WeChatWebSite
{
    using Express.Model;
    using Express.WeiXin;

    /// <summary>
    /// 用于微信与业务系统绑定使用
    /// </summary>
    public class AccountHelper
    {
        //public static string GetSessionOpenID()
        //{
        //    return System.Web.HttpContext.Current.Session[WeiXinConfigBase.OpenidKey].ToString();
        //}
        #region 与绑定相关数据
        /// <summary>
        /// 刷新缓存
        /// </summary>
        /// <param name="openid"></param>
        //public static void RefreshAccount(string openid)
        //{
        //    HISAccountBind _WeixinOAuth = new HISAccountBind();
        //    var accounts = _WeixinOAuth.UserBindings(openid, "");
        //    HttpContext.Current.Session[WeiXinConfigBase.AccountEntityKey] = accounts;
        //}

        ///// <summary>
        ///// 获取绑定的账户
        ///// </summary>
        ///// <returns></returns>
        //public static List<Ep_User> GetAllAccount()
        //{
        //    if (HttpContext.Current.Session[WeiXinConfigBase.AccountEntityKey] == null)
        //    {
        //        RefreshAccount(GetSessionOpenID());
        //    }
        //    return HttpContext.Current.Session[WeiXinConfigBase.AccountEntityKey] as List<Ep_User>;
        //}

        ///// <summary>
        ///// 判断传入病人ID，是否数据该openid
        ///// 避免数据被泄露
        ///// </summary>
        ///// <param name="accountid"></param>
        ///// <returns></returns>
        //public static bool IsValiteAccount(string accountid)
        //{
        //    return GetAllAccount().FindAll(p => p.Brid == accountid).Count > 0;
        //}

        ///// <summary>
        ///// 获取账户
        ///// </summary>
        ///// <param name="accountid"></param>
        ///// <returns></returns>
        //public static Ep_User GetAccount(string accountid)
        //{
        //    return GetAllAccount().Find(p => p.Brid == accountid);
        //}

        ///// <summary>
        ///// 获取门诊账户
        ///// </summary>
        ///// <returns></returns>
        //public static List<Ep_User> GetMenzhenAccount()
        //{
        //    return GetAllAccount().FindAll(p => p.Bind_type == 1);
        //}
        ///// <summary>
        ///// 获取住院账户
        ///// </summary>
        ///// <returns></returns>
        //public static List<Ep_User> GetZhuyuanAccount()
        //{
        //    return GetAllAccount().FindAll(p => p.Bind_type == 2);
        //}

        ///// <summary>0
        ///// 获取ART账户
        ///// </summary>
        ///// <returns></returns>
        //public static List<Ep_User> GetARTAccount()
        //{
        //    return GetAllAccount().FindAll(p => p.Bind_type == 0);
        //}


        ///// <summary>
        ///// 虚拟调试
        ///// 不需要在微信中集成调试
        ///// 也不需要添加到微信开发工具中调试
        ///// </summary>
        //public static void WXDebugerUserInit()
        //{
        //    if (System.Web.HttpContext.Current.Session[WeiXinConfigBase.OpenidKey] == null
        //           || string.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session[WeiXinConfigBase.OpenidKey].ToString()))
        //    {
        //        var DeBugOpenid = ConfigurationManager.AppSettings["wx_debugOpenid"];
        //        System.Web.HttpContext.Current.Session[WeiXinConfigBase.OpenidKey] = DeBugOpenid;
        //        RefreshAccount(DeBugOpenid);
        //    }
        //}
        #endregion

        //#region 与选择用户相关的
        //private static string __temp_data_key = "__choose_account_key";
        //private static string __temp_data_session_key = "__choose_account_session_key";

        ///// <summary>
        ///// 获取通过选择页面
        ///// 选择的用户信息
        ///// 如果不是从userlist页面回发
        ///// 则会为空
        ///// </summary>
        ///// <returns></returns>
        //public static Ep_User GetChooseViewAccount(ControllerBase controller)
        //{
        //    return controller.TempData[__temp_data_key] as Ep_User;
        //}

        ///// <summary>
        /////  获取选中的账户信息存在session中                
        ///// </summary>
        ///// <returns></returns>
        //public static Ep_User GetChooseAccount(ControllerBase controller)
        //{
        //    return controller.ControllerContext.HttpContext.Session[__temp_data_session_key] as Ep_User;
        //}

        ///// <summary>
        ///// 设置用户选择信息
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public static void SetChooseAccount(ControllerBase controller, Ep_User account)
        //{
        //    if (controller.TempData.ContainsKey(__temp_data_key))
        //    {
        //        //这个是一次性存储，Request结束就释放
        //        controller.TempData[__temp_data_key] = account;            
        //    }
        //    else
        //    {
        //        controller.TempData.Add(__temp_data_key, account);
        //    }
        //    //这个是存在session用于action中用来判断
        //    controller.ControllerContext.HttpContext.Session[__temp_data_session_key] = account;
        //}


        //#endregion
    }
}