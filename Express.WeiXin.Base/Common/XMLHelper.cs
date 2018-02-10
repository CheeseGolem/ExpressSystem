using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Express.WeiXin.Base.Common
{
    public class XMLHelper
    {
        #region 反序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
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
            catch (Exception e)
            {

                return null;
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            try
            {
                //序列化对象
                xml.Serialize(Stream, obj);
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        #endregion


        #region WebServiceXML
        #region 获取XML
        /// <summary>
        /// 获取XML
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetXML(object obj)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            //去除xml声明
            settings.OmitXmlDeclaration = true;
            settings.Encoding = Encoding.Default;
            settings.Indent = true;
            MemoryStream mem = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(mem, settings))
            {
                //去除默认命名空间xmlns:xsd和xmlns:xsi
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlSerializer formatter = new XmlSerializer(obj.GetType());
                formatter.Serialize(writer, obj, ns);
                string xml = Encoding.Default.GetString(mem.ToArray());
                return xml = xml.Replace(obj.GetType().Name, "HisTrans");//将类名转成HisTrans根节点

            }
        }
        #endregion


        #region 转换成类
        public static object GetClass(Type t, string xml)
        {
            try
            {
                xml = xml.Replace("HisTrans", t.Name);
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(t);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {

                return null;

            }
           
        }
        #endregion
        #endregion
        #region 获取某个节点的值

        /// <summary>
        /// 获取rootName节点树下的ElementName的值
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="rootName"></param>
        /// <param name="ElementName"></param>
        /// <returns></returns>
        public static string GetELementValue(string xml, string rootName,string ElementName) {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            XmlNodeList nodeList = xmlDocument.SelectSingleNode(rootName).ChildNodes;
            foreach (XmlNode item in nodeList)
            {
                if (item.Name.Equals(ElementName))
                {
                    return item.InnerText;
                }
            }

            return null; 
        }

        public static string GetELementValue(XmlDocument xmlDocument, string rootName, string ElementName)
        {
             
          
            XmlNodeList nodeList = xmlDocument.SelectSingleNode(rootName).ChildNodes;
            foreach (XmlNode item in nodeList)
            {
                if (item.Name.Equals(ElementName))
                {
                    return item.InnerText;
                }
            }

            return null;
        }
        #endregion

    }
}
