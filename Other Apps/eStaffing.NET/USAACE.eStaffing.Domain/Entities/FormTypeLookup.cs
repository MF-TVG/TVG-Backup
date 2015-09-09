using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.FormTypeLookup data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class FormTypeLookup : EntityBase
    {
        private FormTypeLookupSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public FormTypeLookupSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new FormTypeLookupSearch();
                }

                return _searchProperties;
            }
        }

        private FormTypeLookupExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public FormTypeLookupExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new FormTypeLookupExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _formTypeLookupID;

        /// <summary>
        /// A property representation of the FormTypeLookupID field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> FormTypeLookupID
        {
            get { return _formTypeLookupID; }
            set { _formTypeLookupID = value; }
        }

        private Nullable<Int32> _formTypeID;

        /// <summary>
        /// A property representation of the FormTypeID field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormTypeID
        {
            get { return _formTypeID; }
            set { _formTypeID = value; }
        }

        private Nullable<Int32> _organizationID;

        /// <summary>
        /// A property representation of the OrganizationID field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value; }
        }

        private String _lookupDataType;

        /// <summary>
        /// A property representation of the LookupDataType field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String LookupDataType
        {
            get { return _lookupDataType; }
            set { _lookupDataType = value; }
        }

        private String _lookupName;

        /// <summary>
        /// A property representation of the LookupName field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String LookupName
        {
            get { return _lookupName; }
            set { _lookupName = value; }
        }

        private String _lookupValuesXML;

        /// <summary>
        /// A property representation of the LookupValuesXML field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty()]
        public String LookupValuesXML
        {
            get { return _lookupValuesXML; }
            set { _lookupValuesXML = value; }
        }

    }

    [Serializable]
    public class FormTypeLookupSearch : EntitySearchBase
    {
        internal FormTypeLookupSearch() { }

        private Nullable<Int32> _formTypeIDMinRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMinRange field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMinRange
        {
            get { return _formTypeIDMinRange; }
            set { _formTypeIDMinRange = value; }
        }

        private Nullable<Int32> _formTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMaxRange field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMaxRange
        {
            get { return _formTypeIDMaxRange; }
            set { _formTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formTypeIDIsIn;

        /// <summary>
        /// A search property representation of the FormTypeIDIsIn field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> FormTypeIDIsIn
        {
            get
            {
                if (_formTypeIDIsIn == null)
                {
                    _formTypeIDIsIn = new List<Nullable<Int32>>();
                }
                return _formTypeIDIsIn;
            }
            set { _formTypeIDIsIn = value; }
        }

        private Nullable<Int32> _organizationIDMinRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMinRange field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMinRange
        {
            get { return _organizationIDMinRange; }
            set { _organizationIDMinRange = value; }
        }

        private Nullable<Int32> _organizationIDMaxRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMaxRange field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMaxRange
        {
            get { return _organizationIDMaxRange; }
            set { _organizationIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _organizationIDIsIn;

        /// <summary>
        /// A search property representation of the OrganizationIDIsIn field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> OrganizationIDIsIn
        {
            get
            {
                if (_organizationIDIsIn == null)
                {
                    _organizationIDIsIn = new List<Nullable<Int32>>();
                }
                return _organizationIDIsIn;
            }
            set { _organizationIDIsIn = value; }
        }

        private String _lookupDataTypeContains;

        /// <summary>
        /// A search property representation of the LookupDataTypeContains field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String LookupDataTypeContains
        {
            get { return _lookupDataTypeContains; }
            set { _lookupDataTypeContains = value; }
        }

        private IList<String> _lookupDataTypeIsIn;

        /// <summary>
        /// A search property representation of the LookupDataTypeIsIn field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> LookupDataTypeIsIn
        {
            get
            {
                if (_lookupDataTypeIsIn == null)
                {
                    _lookupDataTypeIsIn = new List<String>();
                }
                return _lookupDataTypeIsIn;
            }
            set { _lookupDataTypeIsIn = value; }
        }

        private String _lookupNameContains;

        /// <summary>
        /// A search property representation of the LookupNameContains field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String LookupNameContains
        {
            get { return _lookupNameContains; }
            set { _lookupNameContains = value; }
        }

        private IList<String> _lookupNameIsIn;

        /// <summary>
        /// A search property representation of the LookupNameIsIn field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> LookupNameIsIn
        {
            get
            {
                if (_lookupNameIsIn == null)
                {
                    _lookupNameIsIn = new List<String>();
                }
                return _lookupNameIsIn;
            }
            set { _lookupNameIsIn = value; }
        }

        private String _lookupValuesXMLContains;

        /// <summary>
        /// A search property representation of the LookupValuesXMLContains field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String LookupValuesXMLContains
        {
            get { return _lookupValuesXMLContains; }
            set { _lookupValuesXMLContains = value; }
        }

        private IList<String> _lookupValuesXMLIsIn;

        /// <summary>
        /// A search property representation of the LookupValuesXMLIsIn field for a record in the dbo.FormTypeLookup data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> LookupValuesXMLIsIn
        {
            get
            {
                if (_lookupValuesXMLIsIn == null)
                {
                    _lookupValuesXMLIsIn = new List<String>();
                }
                return _lookupValuesXMLIsIn;
            }
            set { _lookupValuesXMLIsIn = value; }
        }

    }

    [Serializable]
    public partial class FormTypeLookupExtended : EntityExtendedBase
    {
        internal FormTypeLookupExtended() { }
    }
}