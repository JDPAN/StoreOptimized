using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

#region - 版权信息
/************************************************
*公司：楠迪科技 
*作者: Benn.zhu
*创建时间 2019/6/2 16:23:39
*版本: 0.0.1
*描述:
*
*更新历史:
*
***********************************************/
#endregion
namespace CommLib
{
    public class XmlSerializeUtil
    {

        #region 逆序列化


        /// <summary>
        /// 逆序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        public static object Deserialize(Type type, Stream stream)
        {
            try
            {
                XmlSerializer xmldes = new XmlSerializer(type);
                return xmldes.Deserialize(stream);
            }
            catch (Exception)
            {
            }
            return null;
        }
        #endregion

        #region 序列化
        public static string Serializer(Type type, object obj)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                XmlSerializer xml = new XmlSerializer(type);
                xml.Serialize(stream, obj);
                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);
                string str = sr.ReadToEnd();
                sr.Dispose();
                stream.Dispose();
                return str;
            }
            catch (Exception)
            {

            }
            return null;

        }

        #endregion

    }
}
