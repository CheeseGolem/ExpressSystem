using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.WeiXin.Base.Common
{

    /// <summary>
    /// 微信基本缓存业务代码
    /// </summary>
    public class WeiXinCacheHelper
    {
        #region 通用
        /// <summary>
        /// 用于唯一锁
        /// </summary>
        public static object obj = new object();


        /// <summary>
        /// 通用缓存方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dal"></param>
        /// <param name="msg"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        //protected static T CommonCache<T>(string key, Func<T> dal, Msg msg, TimeSpan sp) where T : class, new()
        //{

        //    Type t = typeof(T);
        //    try
        //    {
        //        T ds = CacheHelper.Get<T>(key);
        //        if (null == ds)
        //        {
        //            //避免缓存刷新时重新赋值需要先锁定
        //            lock (obj)
        //            {
        //                ds = dal();
        //                CacheHelper.Add(key, ds, sp);

        //            }
        //        }

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        msg.Result = false;
        //        msg.AddMsg("获取" + t.FullName + "缓存数据异常" + ex.Message);
        //        Express.Enterprise.Logging.LogHelper.Write(msg);
        //        return default(T);
        //    }

        //}

        /// <summary>
        /// 先移除缓存，然后再调用属性就可以刷新了
        /// </summary>
        /// <param name="key"></param>
        //public static void RefreshCache(string key)
        //{

        //    CacheHelper.Remove(key);
        //}
        #endregion

    }
}
