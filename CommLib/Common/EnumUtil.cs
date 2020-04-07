using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

#region - 版权信息
/************************************************
*公司：楠迪科技 
*作者: Benn.zhu
*创建时间 2019/6/3 19:19:04
*版本: 0.0.1
*描述:
* 枚举类工具
*更新历史:
*
***********************************************/
#endregion
namespace CommLib
{
    /// <summary>
    /// 枚举类型工具
    /// </summary>
    public static class EnumUtil
    {
        public static string GetDesByName<T>(this T enumItemName)
        {
            System.Reflection.FieldInfo fi = enumItemName.GetType().GetField(enumItemName.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return enumItemName.ToString();
            }
        }


        /// <summary>
                /// 获取枚举值的Description
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="value"></param>
                /// <returns></returns>
        public static string GetDescription<T>(this T value) where T : struct
        {
            string result = value.ToString();
            Type type = typeof(T);
            FieldInfo info = type.GetField(value.ToString());
            var attributes = info.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attributes != null && attributes.FirstOrDefault() != null)
            {
                result = (attributes.First() as DescriptionAttribute).Description;
            }

            return result;
        }

        /// <summary>
                /// 根据Description获取枚举值
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="value"></param>
                /// <returns></returns>
        public static T GetValueByDescription<T>(this string description) where T : struct
        {
            Type type = typeof(T);
            foreach (var field in type.GetFields())
            {
                if (field.Name == description)
                {
                    return (T)field.GetValue(null);
                }

                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attributes != null && attributes.FirstOrDefault() != null)
                {
                    if (attributes.First().Description == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }

            throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", description), "Description");
        }

        /// <summary>
                /// 获取string获取枚举值
                /// </summary>
                /// <typeparam name="T"></typeparam>
                /// <param name="value"></param>
                /// <returns></returns>
        public static T GetValue<T>(this string value) where T : struct
        {
            T result;
            try
            {
                result = (T)Enum.Parse(typeof(T), value, true);
                return result;
            }
            catch
            {
                throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", value), "Value");
            }


        }
    }
}
