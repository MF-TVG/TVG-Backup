using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace USAACE.eStaffing.Domain.FormEntities
{
    [Serializable]
    public abstract class FormEntityBase
    {
        public static T LoadFromXml<T>(String xml) where T : FormEntityBase, new()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                StringReader stringReader = new StringReader(xml);

                XmlReader xmlReader = XmlReader.Create(stringReader);

                T data = serializer.Deserialize(xmlReader) as T;

                xmlReader.Close();
                stringReader.Close();

                return data;
            }
            catch (Exception)
            {
                return new T();
            }
        }

        public String SaveToXml()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());

            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = false });

            serializer.Serialize(xmlWriter, this);

            xmlWriter.Close();
            stringWriter.Close();

            return stringWriter.ToString();
        }
    }
}
