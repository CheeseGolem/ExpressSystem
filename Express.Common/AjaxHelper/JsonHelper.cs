using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Common
{
    using Newtonsoft.Json;
    public class JsonHelper
    {        
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>JSON字符串</returns>
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns>指定数据类型的对象</returns>
        public static T Deserialize<T>(string json)
            where T : class,new()
        {
            object obj = JsonConvert.DeserializeObject(json,typeof(T));
            return obj as T;
        }
    }
}
