using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.OrganizationFormRouting data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class OrganizationFormRouting : EntityBase
    {
        private OrganizationFormRoutingSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public OrganizationFormRoutingSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new OrganizationFormRoutingSearch();
                }

                return _searchProperties;
            }
        }

        private OrganizationFormRoutingExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public OrganizationFormRoutingExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new OrganizationFormRoutingExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _organizationFormRoutingID;

        /// <summary>
        /// A property representation of the OrganizationFormRoutingID field for a record in the dbo.OrganizationFormRouting data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationFormRoutingID
        {
            get { return _organizationFormRoutingID; }
            set { _organizationFormRoutingID = value; }
        }

        private Nullable<Int32> _organizationID;

        /// <summary>
        /// A property representation of the OrganizationID field for a record in the dbo.OrganizationFormRouting data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value; }
        }

        private Nullable<Int32> _formTypeID;

        /// <summary>
        /// A property representation of the FormTypeID field for a record in the dbo.OrganizationFormRouting data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormTypeID
        {
            get { return _formTypeID; }
            set { _formTypeID = value; }
        }

        private String _routingName;

        /// <summary>
        /// A property representation of the RoutingName field for a record in the dbo.OrganizationFormRouting data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String RoutingName
        {
            get { return _routingName; }
            set { _routingName = value; }
        }

    }

    [Serializable]
    public class OrganizationFormRoutingSearch : EntitySearchBase
    {
        internal OrganizationFormRoutingSearch() { }

        private Nullable<Int32> _organizationIDMinRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMinRange field for a record in the dbo.OrganizationFormRouting data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMinRange
        {
            get { return _organizationIDMinRange; }
            set { _organizationIDMinRange = value; }
        }

        private Nullable<Int32> _organizationIDMaxRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMaxRange field for a record in the dbo.OrganizationFormRouting data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMaxRange
        {
            get { return _organizationIDMaxRange; }
            set { _organizationIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _organizationIDIsIn;

        /// <summary>
        /// A search property representation of the OrganizationIDIsIn field for a record in the dbo.OrganizationFormRouting data table. 
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

        private Nullable<Int32> _formTypeIDMinRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMinRange field for a record in the dbo.OrganizationFormRouting data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMinRange
        {
            get { return _formTypeIDMinRange; }
            set { _formTypeIDMinRange = value; }
        }

        private Nullable<Int32> _formTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMaxRange field for a record in the dbo.OrganizationFormRouting data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMaxRange
        {
            get { return _formTypeIDMaxRange; }
            set { _formTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formTypeIDIsIn;

        /// <summary>
        /// A search property representation of the FormTypeIDIsIn field for a record in the dbo.OrganizationFormRouting data table. 
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

        private String _routingNameContains;

        /// <summary>
        /// A search property representation of the RoutingNameContains field for a record in the dbo.OrganizationFormRouting data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String RoutingNameContains
        {
            get { return _routingNameContains; }
            set { _routingNameContains = value; }
        }

        private IList<String> _routingNameIsIn;

        /// <summary>
        /// A search property representation of the RoutingNameIsIn field for a record in the dbo.OrganizationFormRouting data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> RoutingNameIsIn
        {
            get
            {
                if (_routingNameIsIn == null)
                {
                    _routingNameIsIn = new List<String>();
                }
                return _routingNameIsIn;
            }
            set { _routingNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class OrganizationFormRoutingExtended : EntityExtendedBase
    {
        internal OrganizationFormRoutingExtended() { }
    }
}