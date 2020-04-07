using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

#region - 版权信息
/************************************************
*公司：楠迪科技 
*作者: Benn.zhu
*创建时间 2019/7/17 8:49:09
*版本: 0.0.1
*描述:
*
*更新历史:
*
***********************************************/
#endregion
namespace CommLib.Common
{
    public enum SerializationType
    {
        Xml,
        Json,
        DataContract,
        Binary
    }
    public class HttpHelper
    {
        public static int Timeout = 5000;
        public static T HttpPost<T>(string uri, object data, SerializationType serializationType)
        {
            string responseText = HttpPost(uri, data, serializationType);

            T t = default(T);
            if (serializationType == SerializationType.Xml)
            {

                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                StringReader sWriter = new StringReader(responseText);
                t = (T)xmlSerializer.Deserialize(sWriter);
            }
            else if (serializationType == SerializationType.Json)
            {
                t = (T)JsonConvert.DeserializeObject<T>(responseText);
            }
            return t;
        }

        public static string HttpPost(string uri, object data, SerializationType serializationType)
        {
            string res = "";
            using (var client = new HttpClient())
            {
                string dataStr = string.Empty;
                client.Timeout = TimeSpan.FromMilliseconds(Timeout);
                if (data is string)
                {
                    dataStr = (string)data;
                }
                else
                {
                    if (serializationType == SerializationType.Xml)
                    {
                        System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(data.GetType());
                        StringWriter sWriter = new StringWriter();
                        xmlSerializer.Serialize(sWriter, data);
                        dataStr = sWriter.ToString();

                    }
                    else if (serializationType == SerializationType.Json)
                    {
                        dataStr = JsonConvert.SerializeObject(data);
                    }
                }
                HttpContent content = new StringContent(dataStr);
                if (serializationType == SerializationType.Xml)
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/xml");

                }
                else if (serializationType == SerializationType.Json)
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                }
                try
                {
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        res = response.Content.ReadAsStringAsync().Result;
                    }

                }
                catch (Exception)
                {
                    throw;
                }

            }
            return res;

        }




        public static T HttpGet<T>(string uri, SerializationType serializationType)
        {
            string responseText = HttpGet(uri);

            T t = default(T);
            if (serializationType == SerializationType.Xml)
            {
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                StringReader sWriter = new StringReader(responseText);
                t = (T)xmlSerializer.Deserialize(sWriter);
            }
            else if (serializationType == SerializationType.Json)
            {
                t = (T)JsonConvert.DeserializeObject<T>(responseText);
            }
            return t;
        }

        public static string HttpGet(string uri)
        {
            StringBuilder respBody = new StringBuilder();
            HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
            request.Method = "GET";

            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            request.Timeout = Timeout;

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                byte[] buffer = new byte[8192];
                Stream stream;
                stream = response.GetResponseStream();
                int count = 0;

                do
                {
                    count = stream.Read(buffer, 0, buffer.Length);
                    if (count != 0)
                        respBody.Append(Encoding.UTF8.GetString(buffer, 0, count));
                } while (count > 0);

                string responseText = respBody.ToString();
                return responseText;
            }
            catch (Exception)
            {
                throw;
            }
            return "";


        }


    }
}
