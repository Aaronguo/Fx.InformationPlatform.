using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Fx.Infrastructure.Data
{
    public class SerializeHelper
    {
        /// <summary>
        /// 序列化成xml字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>序列化后的字符串</returns>
        public static string Serialize(object obj)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                System.Xml.XmlTextWriter xtw = new System.Xml.XmlTextWriter(ms, System.Text.Encoding.UTF8);
                xtw.Formatting = System.Xml.Formatting.Indented;
                xs.Serialize(xtw, obj);
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(ms))
                {
                    string str = sr.ReadToEnd();
                    xtw.Close();
                    ms.Close();
                    return str;
                }
            }
        }


        /// <summary>
        /// 反序列化方法
        /// </summary>     
        /// <param name="xml">xml字符串</param>   
        /// <param name="type">反序列化对象的类型</param>   
        /// <returns>反序列化后的对象</returns>
        public static object Desrialize(string xml, Type type)
        {
            object obj = null;
            XmlSerializer xs = new XmlSerializer(type);
            TextReader tr;
            if (!File.Exists(xml))
            {
                tr = new StringReader(xml);
            }
            else
            {
                tr = new StreamReader(xml);
            }
            using (tr)
            {
                obj = xs.Deserialize(tr);
            }
            return obj;
        }
    }
}
