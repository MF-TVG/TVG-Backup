using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.FormData data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class FormData : EntityBase
    {
        private FormDataSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public FormDataSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new FormDataSearch();
                }

                return _searchProperties;
            }
        }

        private FormDataExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public FormDataExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new FormDataExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _formDataID;

        /// <summary>
        /// A property representation of the FormDataID field for a record in the dbo.FormData data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> FormDataID
        {
            get { return _formDataID; }
            set { _formDataID = value; }
        }

        private Nullable<Int32> _formID;

        /// <summary>
        /// A property representation of the FormID field for a record in the dbo.FormData data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormID
        {
            get { return _formID; }
            set { _formID = value; }
        }

        private String _formDataXML;

        /// <summary>
        /// A property representation of the FormDataXML field for a record in the dbo.FormData data table. 
        /// </summary>
        [EntityProperty()]
        public String FormDataXML
        {
            get { return _formDataXML; }
            set { _formDataXML = value; }
        }

    }

    [Serializable]
    public class FormDataSearch : EntitySearchBase
    {
        internal FormDataSearch() { }

        private Nullable<Int32> _formIDMinRange;

        /// <summary>
        /// A search property representation of the FormIDMinRange field for a record in the dbo.FormData data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormIDMinRange
        {
            get { return _formIDMinRange; }
            set { _formIDMinRange = value; }
        }

        private Nullable<Int32> _formIDMaxRange;

        /// <summary>
        /// A search property representation of the FormIDMaxRange field for a record in the dbo.FormData data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormIDMaxRange
        {
            get { return _formIDMaxRange; }
            set { _formIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formIDIsIn;

        /// <summary>
        /// A search property representation of the FormIDIsIn field for a record in the dbo.FormData data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> FormIDIsIn
        {
            get
            {
                if (_formIDIsIn == null)
                {
                    _formIDIsIn = new List<Nullable<Int32>>();
                }
                return _formIDIsIn;
            }
            set { _formIDIsIn = value; }
        }

        private String _formDataXMLContains;

        /// <summary>
        /// A search property representation of the FormDataXMLContains field for a record in the dbo.FormData data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String FormDataXMLContains
        {
            get { return _formDataXMLContains; }
            set { _formDataXMLContains = value; }
        }

        private IList<String> _formDataXMLIsIn;

        /// <summary>
        /// A search property representation of the FormDataXMLIsIn field for a record in the dbo.FormData data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> FormDataXMLIsIn
        {
            get
            {
                if (_formDataXMLIsIn == null)
                {
                    _formDataXMLIsIn = new List<String>();
                }
                return _formDataXMLIsIn;
            }
            set { _formDataXMLIsIn = value; }
        }

    }

    [Serializable]
    public partial class FormDataExtended : EntityExtendedBase
    {
        internal FormDataExtended() { }
    }
}