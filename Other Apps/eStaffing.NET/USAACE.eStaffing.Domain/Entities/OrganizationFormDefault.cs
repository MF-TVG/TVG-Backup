using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.OrganizationFormDefault data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class OrganizationFormDefault : EntityBase
    {
        private OrganizationFormDefaultSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public OrganizationFormDefaultSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new OrganizationFormDefaultSearch();
                }

                return _searchProperties;
            }
        }

        private OrganizationFormDefaultExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public OrganizationFormDefaultExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new OrganizationFormDefaultExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _organizationFormDefaultID;

        /// <summary>
        /// A property representation of the OrganizationFormDefaultID field for a record in the dbo.OrganizationFormDefault data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationFormDefaultID
        {
            get { return _organizationFormDefaultID; }
            set { _organizationFormDefaultID = value; }
        }

        private Nullable<Int32> _organizationGroupID;

        /// <summary>
        /// A property representation of the OrganizationGroupID field for a record in the dbo.OrganizationFormDefault data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationGroupID
        {
            get { return _organizationGroupID; }
            set { _organizationGroupID = value; }
        }

        private Nullable<Int32> _formTypeID;

        /// <summary>
        /// A property representation of the FormTypeID field for a record in the dbo.OrganizationFormDefault data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormTypeID
        {
            get { return _formTypeID; }
            set { _formTypeID = value; }
        }

        private String _formDataXML;

        /// <summary>
        /// A property representation of the FormDataXML field for a record in the dbo.OrganizationFormDefault data table. 
        /// </summary>
        [EntityProperty()]
        public String FormDataXML
        {
            get { return _formDataXML; }
            set { _formDataXML = value; }
        }

    }

    [Serializable]
    public class OrganizationFormDefaultSearch : EntitySearchBase
    {
        internal OrganizationFormDefaultSearch() { }

        private Nullable<Int32> _organizationGroupIDMinRange;

        /// <summary>
        /// A search property representation of the OrganizationGroupIDMinRange field for a record in the dbo.OrganizationFormDefault data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationGroupIDMinRange
        {
            get { return _organizationGroupIDMinRange; }
            set { _organizationGroupIDMinRange = value; }
        }

        private Nullable<Int32> _organizationGroupIDMaxRange;

        /// <summary>
        /// A search property representation of the OrganizationGroupIDMaxRange field for a record in the dbo.OrganizationFormDefault data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationGroupIDMaxRange
        {
            get { return _organizationGroupIDMaxRange; }
            set { _organizationGroupIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _organizationGroupIDIsIn;

        /// <summary>
        /// A search property representation of the OrganizationGroupIDIsIn field for a record in the dbo.OrganizationFormDefault data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> OrganizationGroupIDIsIn
        {
            get
            {
                if (_organizationGroupIDIsIn == null)
                {
                    _organizationGroupIDIsIn = new List<Nullable<Int32>>();
                }
                return _organizationGroupIDIsIn;
            }
            set { _organizationGroupIDIsIn = value; }
        }

        private Nullable<Int32> _formTypeIDMinRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMinRange field for a record in the dbo.OrganizationFormDefault data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMinRange
        {
            get { return _formTypeIDMinRange; }
            set { _formTypeIDMinRange = value; }
        }

        private Nullable<Int32> _formTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMaxRange field for a record in the dbo.OrganizationFormDefault data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMaxRange
        {
            get { return _formTypeIDMaxRange; }
            set { _formTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formTypeIDIsIn;

        /// <summary>
        /// A search property representation of the FormTypeIDIsIn field for a record in the dbo.OrganizationFormDefault data table. 
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

        private String _formDataXMLContains;

        /// <summary>
        /// A search property representation of the FormDataXMLContains field for a record in the dbo.OrganizationFormDefault data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String FormDataXMLContains
        {
            get { return _formDataXMLContains; }
            set { _formDataXMLContains = value; }
        }

        private IList<String> _formDataXMLIsIn;

        /// <summary>
        /// A search property representation of the FormDataXMLIsIn field for a record in the dbo.OrganizationFormDefault data table. 
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
    public partial class OrganizationFormDefaultExtended : EntityExtendedBase
    {
        internal OrganizationFormDefaultExtended() { }
    }
}