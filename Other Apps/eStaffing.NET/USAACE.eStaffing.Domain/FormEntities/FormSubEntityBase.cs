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
    public abstract class FormSubEntityBase
    {        
        private Int32 _listIndex = 0;

        [XmlIgnore]
        public Int32 ListIndex
        {
            get { return _listIndex; }
            set { _listIndex = value; }
        }
    }
}
