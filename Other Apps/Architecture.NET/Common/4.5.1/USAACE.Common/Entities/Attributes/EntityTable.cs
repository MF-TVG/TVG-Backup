using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USAACE.Common.Entities.Attributes
{
    /// <summary>
    /// An attribute used to identify an entity as a table entity
    /// </summary>
    public class EntityTable : Attribute
    {
        private String _schema = null;

        /// <summary>
        /// The schema this table entity belongs to
        /// </summary>
        public String Schema
        {
            get { return _schema; }
            set { _schema = value; }
        }

        private Boolean _isView = false;

        /// <summary>
        /// The schema this table entity belongs to
        /// </summary>
        public Boolean IsView
        {
            get { return _isView; }
            set { _isView = value; }
        }
    }
}
