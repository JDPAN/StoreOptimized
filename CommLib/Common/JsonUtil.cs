using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

#region - 版权信息
/************************************************
*公司：楠迪科技 
*作者: Benn.zhu
*创建时间 2019/7/23 15:22:18
*版本: 0.0.1
*描述:
*
*更新历史:
*
***********************************************/
#endregion
namespace CommLib.Common
{
    public class JsonUtil
    {
        public static T Deserialize<T>(string xml)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(xml); ;

            }
            catch (Exception)
            {
            }
            return default(T);
        }

        public static string Serializer(object obj)
        {
            try
            {
                Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
                timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                string str = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None, timeConverter);
                return str;
            }
            catch (Exception)
            {

            }
            return null;

        }
    }

    public static class JsonHelper
    {
        static JsonHelper()
        {
            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                setting.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";


                //空值处理
                setting.NullValueHandling = NullValueHandling.Ignore;

                //高级用法九中的Bool类型转换 设置
                //setting.Converters.Add(new BoolConvert("是,否"));

                if (setting.Converters.FirstOrDefault(p => p.GetType() == typeof(JsonCustomDoubleConvert)) == null)
                {
                    setting.Converters.Add(new JsonCustomDoubleConvert());
                }

                return setting;
            });
        }

        public static String ToJsonStr<T>(this T obj) where T : class
        {
            if (obj == null)
                return string.Empty;
            return JsonConvert.SerializeObject(obj, Formatting.Indented);

        }
        public static T ToInstance<T>(this String jsonStr) where T : class
        {
            if (string.IsNullOrEmpty(jsonStr))
                return null;
            try
            {
                var instance = JsonConvert.DeserializeObject<T>(jsonStr);

                return instance;
            }
            catch
            {
                return null;
            }

        }
    }

    /// <summary>
    /// 自定义数值类型序列化转换器(默认保留3位)
    /// </summary>
    public class JsonCustomDoubleConvert : JsonConverter<double>
    {
        /// <summary>
        /// 序列化后保留小数位数
        /// </summary>
        public virtual int Digits { get; private set; }

        /// <summary>
        /// .ctor
        /// </summary>
        public JsonCustomDoubleConvert()
        {
            this.Digits = 3;
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="digits">序列化后保留小数位数</param>
        public JsonCustomDoubleConvert(int digits)
        {
            this.Digits = digits;
        }

        /// <summary>
        /// 重载是否可写
        /// </summary>
        public override bool CanWrite { get { return true; } }

        /// <summary>
        /// 重载创建方法
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public double Create(Type objectType)
        {
            return 0.0;
        }



        public override void WriteJson(JsonWriter writer, double value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                var formatter = ((double)value).ToString("N" + Digits.ToString());
                writer.WriteValue(formatter);
            }
        }

        public override double ReadJson(JsonReader reader, Type objectType, double existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader != null)
            {
                if (reader.ValueType == typeof(double))
                {
                    return (double)reader.Value;
                }else if(reader.ValueType == typeof(string))
                {
                    double value = 0;
                    double.TryParse((string)reader.Value, out value);
                    return value;
                }
            }

            return 0.0;


        }
    }

    /// <summary>
    /// 自定义数值类型序列化转换器(无小数位)
    /// </summary>
    public class JsonCustomDoubleWith0DigitsConvert : JsonCustomDoubleConvert
    {
        public override int Digits
        {
            get { return 0; }
        }
    }

    /// <summary>
    /// 自定义数值类型序列化转换器(保留1位)
    /// </summary>
    public class JsonCustomDoubleWith1DigitsConvert : JsonCustomDoubleConvert
    {
        public override int Digits
        {
            get { return 1; }
        }
    }

    /// <summary>
    /// 自定义数值类型序列化转换器(保留2位)
    /// </summary>
    public class JsonCustomDoubleWith2DigitsConvert : JsonCustomDoubleConvert
    {
        public override int Digits
        {
            get { return 2; }
        }
    }

    /// <summary>
    /// 自定义数值类型序列化转换器(保留3位)
    /// </summary>
    public class JsonCustomDoubleWith3DigitsConvert : JsonCustomDoubleConvert
    {
        public override int Digits
        {
            get { return 3; }
        }
    }

    /// <summary>
    /// 自定义数值类型序列化转换器(保留4位)
    /// </summary>
    public class JsonCustomDoubleWith4DigitsConvert : JsonCustomDoubleConvert
    {
        public override int Digits
        {
            get { return 4; }
        }
    }

    /// <summary>
    /// 自定义数值类型序列化转换器(保留5位)
    /// </summary>
    public class JsonCustomDoubleWith5DigitsConvert : JsonCustomDoubleConvert
    {
        public override int Digits
        {
            get { return 5; }
        }
    }
}
