using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Reflection;

namespace HongYang.WeiXin.Base.Utility.Extensions
{
    public static class ObjectExtensions
    {
        #region 类型转换判断

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static bool IsNotNullAndHasValue<T>(this Nullable<T> value) where T : struct
        {
            return value != null && value.HasValue;
        }

        public static bool IsNullOrHasNoValue<T>(this Nullable<T> value) where T : struct
        {
            return value == null || !value.HasValue;
        }

        public static string IfNullOrWhiteSpace(this object source, string displayWhenNullOrEmpty)
        {
            return source.IsNull()
                ? displayWhenNullOrEmpty
                : source.ToString().IsNullOrWhiteSpace()
                    ? displayWhenNullOrEmpty
                    : source.ToString();
        }

        public static int AsInt(this object value)
        {
            return As<int>(value);
        }

        public static int AsInt(this object value, int defaultValue)
        {
            return As<int>(value, defaultValue);
        }

        public static float AsFloat(this object value)
        {
            return As<float>(value);
        }

        public static float AsFloat(this object value, float defaultValue)
        {
            return As<float>(value, defaultValue);
        }

        public static decimal AsDecimal(this object value)
        {
            return As<decimal>(value);
        }

        public static decimal AsDecimal(this object value, decimal defaultValue)
        {
            return As<decimal>(value, defaultValue);
        }

        public static double AsDouble(this object value)
        {
            return As<double>(value);
        }

        public static double AsDouble(this object value, double defaultValue)
        {
            return As<double>(value, defaultValue);
        }

        public static long AsLong(this object value)
        {
            return As<long>(value);
        }

        public static long AsDouble(this object value, long defaultValue)
        {
            return As<long>(value, defaultValue);
        }

        private static readonly string[] Booleans = new string[] { "true", "yes", "on", "1", "是", "确定" };

        public static bool AsBoolean(this object value)
        {
            return AsBoolean(value, default(bool));
        }


        public static bool AsBoolean(this object value, bool defaultValue)
        {
            string valueAsString = value.AsString();

            if (!String.IsNullOrEmpty(valueAsString))
            {
                return Booleans.Contains(valueAsString, StringComparer.OrdinalIgnoreCase);
            }

            return defaultValue;
        }

        public static string AsString(this object value)
        {
            return As<string>(value, String.Empty);
        }

        public static string AsString(this object value, string defaultValue)
        {
            return As<string>(value, defaultValue);
        }

        public static DateTime AsDateTime(this object value)
        {
            return As<DateTime>(value);
        }

        public static DateTime AsDateTime(this object value, DateTime defaultValue)
        {
            return As<DateTime>(value, defaultValue);
        }

        public static T As<T>(this object value)
        {
            return As<T>(value, default(T));
        }

        public static T As<T>(this object value, T defaultValue)
        {
            T convertedValue = defaultValue;

            if (value != null && value != DBNull.Value && value is IConvertible)
            {
                try
                {
                    convertedValue = (T)value;
                }
                catch
                {
                    try
                    {
                        convertedValue = (T)Convert.ChangeType(value, typeof(T));
                    }
                    catch
                    {
                    }
                }
            }

            return convertedValue;
        }

        #endregion

        #region 反射扩展

        /// <summary>
        /// 反射获取对象的所有属性
        /// </summary>
        public static object GetProperties(this object obj)
        {
            if (obj == null)
                return null;

            return obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }





        /// <summary>
        /// 如果不为空返回对象，否则返回obj2
        /// </summary>
        public static object DefaultIfNull(this object obj, object obj2)
        {
            return DefaultIf(obj, obj2, (o) => o != null);
        }

        /// <summary>
        /// 如果返回true返回对象，否则返回obj2参数
        /// </summary>
        public static object DefaultIf(this object obj, object obj2, Func<object, bool> predicate)
        {
            if (predicate(obj))
                return obj;
            else
                return obj2;
        }

        /// <summary>
        /// 反射获取对象所有的属性键值对
        /// </summary>
        public static IDictionary<string, object> ToDictionary(this object obj)
        {
            if (obj == null)
                return null;

            Dictionary<string, object> dic = new Dictionary<string, object>();
            var props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var val = prop.GetValue(obj);
                dic.Add(prop.Name, val);
            }

            return dic;
        }

        /// <summary>
        /// 反射获取对象所有的属性键值对
        /// </summary>
        public static NameValueCollection ToNameValueCollection(this object obj)
        {
            if (obj == null)
                return null;

            NameValueCollection dic = new NameValueCollection();
            var props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var val = prop.GetValue(obj);
                dic.Add(prop.Name, val == null ? string.Empty : val.ToString());
            }

            return dic;
        }


        /// <summary>
        /// 反射获取对象的某个属性值
        /// </summary>
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            if (obj == null)
                return null;

            int idx = propertyName.IndexOf('.');
            if (idx > 0)
            {
                string subObjPropName = propertyName.Substring(0, idx);
                object subObj = GetPropertyValue(obj, subObjPropName);
                string propName = propertyName.Substring(idx + 1);
                return GetPropertyValue(subObj, propName);
            }

            PropertyDescriptor descriptor = obj.GetType().GetPropertyDescriptor(propertyName, true);
            return descriptor.GetValue(obj);
        }

        /// <summary>
        /// 将对象的属性与属性值放置字典
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDictionaryPropertyValues(this object _object)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var item in _object.GetProperties() as System.Reflection.PropertyInfo[])
            {
                var Property = item.GetPropertyValue("Name").ToString();
                dictionary.Add(Property, _object.GetPropertyValue(Property) as string);
            }

            return dictionary;
        }
        #endregion
    }
}
