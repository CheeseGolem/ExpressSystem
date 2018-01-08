using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.Common
{
    using System.Reflection;

    public static class EnumHelper
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="enum">枚举字段</param>
        /// <returns>描述</returns>
        public static string GetDescription(this Enum @enum)
        {
            Type type = @enum.GetType();//获取枚举的元数据
            FieldInfo fi = type.GetField(@enum.ToString());//根据字段名找到指定的字段

            object[] objs = fi.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);//获取该字段上的EnumDescriptionAttribute特性
            if (objs == null || objs.Length <= 0)//该字段上没有标记EnumDescriptionAttribute特性
            {
                return string.Empty;
            }

            string result = string.Empty;
            EnumDescriptionAttribute[] attrs = objs as EnumDescriptionAttribute[];//强制转换
            foreach (EnumDescriptionAttribute attr in attrs)
            {
                result += attr.Desc + " | ";//字符串拼接
            }

            return result.TrimEnd(' ', '|', ' ');//去除末尾的" | "
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="value">枚举字段值</param>
        /// <returns>描述</returns>
        public static string GetDescription<TEnum>(this int value)
        //where TEnum : System.Enum//泛型约束
        {
            Type type = typeof(TEnum);
            if (!type.IsEnum)
            {
                throw new ArgumentException("TEnum不是枚举类型");
            }

            //Enum.Parse() 根据枚举字段的值转换为指定的枚举字段
            //CountryEnum @enum = (CountryEnum)Enum.Parse(typeof(CountryEnum), value.ToString());        
            TEnum @enum = (TEnum)Enum.Parse(typeof(TEnum), value.ToString());

            return GetDescription(@enum as Enum);


            //object obj=枚举

            //    obj  as 枚举
        }


    }
}
