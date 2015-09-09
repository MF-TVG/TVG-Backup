using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    public class LookupEntityList<T> : List<T> where T : LookupEntityBase, new()
    {
        private List<T> _values;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public List<T> Values
        {
            get
            {
                if (_values == null)
                {
                    _values = new List<T>();
                }

                return _values;
            }
            set
            {
                _values = value;
            }
        }

        public LookupEntityList()
        {

        }

        public LookupEntityList(String xml)
        {
            LoadFromXml(xml);
        }

        public void LoadFromXml(String xml)
        {
            try
            {
                if (!String.IsNullOrEmpty(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    StringReader stringReader = new StringReader(xml);

                    XmlReader xmlReader = XmlReader.Create(stringReader);

                    List<T> data = serializer.Deserialize(xmlReader) as List<T>;

                    xmlReader.Close();
                    stringReader.Close();

                    this.Values = data;
                }
            }
            catch (Exception)
            {

            }
        }

        public String SaveToXml()
        {
            XmlSerializer serializer = new XmlSerializer(this.Values.GetType());

            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = false });

            serializer.Serialize(xmlWriter, this.Values);

            xmlWriter.Close();
            stringWriter.Close();

            return stringWriter.ToString();
        }
    }
}
