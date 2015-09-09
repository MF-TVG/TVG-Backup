using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.OrganizationForwarding data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class OrganizationForwarding : EntityBase
    {
        private OrganizationForwardingSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public OrganizationForwardingSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new OrganizationForwardingSearch();
                }

                return _searchProperties;
            }
        }

        private OrganizationForwardingExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public OrganizationForwardingExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new OrganizationForwardingExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _organizationForwardingID;

        /// <summary>
        /// A property representation of the OrganizationForwardingID field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationForwardingID
        {
            get { return _organizationForwardingID; }
            set { _organizationForwardingID = value; }
        }

        private Nullable<Int32> _receiveOrganizationID;

        /// <summary>
        /// A property representation of the ReceiveOrganizationID field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ReceiveOrganizationID
        {
            get { return _receiveOrganizationID; }
            set { _receiveOrganizationID = value; }
        }

        private Nullable<Int32> _forwardOrganizationID;

        /// <summary>
        /// A property representation of the ForwardOrganizationID field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ForwardOrganizationID
        {
            get { return _forwardOrganizationID; }
            set { _forwardOrganizationID = value; }
        }

        private Nullable<Int32> _organizationFormRoutingID;

        /// <summary>
        /// A property representation of the OrganizationFormRoutingID field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationFormRoutingID
        {
            get { return _organizationFormRoutingID; }
            set { _organizationFormRoutingID = value; }
        }

        private Nullable<Int32> _formTypeID;

        /// <summary>
        /// A property representation of the FormTypeID field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormTypeID
        {
            get { return _formTypeID; }
            set { _formTypeID = value; }
        }

    }

    [Serializable]
    public class OrganizationForwardingSearch : EntitySearchBase
    {
        internal OrganizationForwardingSearch() { }

        private Nullable<Int32> _receiveOrganizationIDMinRange;

        /// <summary>
        /// A search property representation of the ReceiveOrganizationIDMinRange field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReceiveOrganizationIDMinRange
        {
            get { return _receiveOrganizationIDMinRange; }
            set { _receiveOrganizationIDMinRange = value; }
        }

        private Nullable<Int32> _receiveOrganizationIDMaxRange;

        /// <summary>
        /// A search property representation of the ReceiveOrganizationIDMaxRange field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReceiveOrganizationIDMaxRange
        {
            get { return _receiveOrganizationIDMaxRange; }
            set { _receiveOrganizationIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _receiveOrganizationIDIsIn;

        /// <summary>
        /// A search property representation of the ReceiveOrganizationIDIsIn field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> ReceiveOrganizationIDIsIn
        {
            get
            {
                if (_receiveOrganizationIDIsIn == null)
                {
                    _receiveOrganizationIDIsIn = new List<Nullable<Int32>>();
                }
                return _receiveOrganizationIDIsIn;
            }
            set { _receiveOrganizationIDIsIn = value; }
        }

        private Nullable<Int32> _forwardOrganizationIDMinRange;

        /// <summary>
        /// A search property representation of the ForwardOrganizationIDMinRange field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ForwardOrganizationIDMinRange
        {
            get { return _forwardOrganizationIDMinRange; }
            set { _forwardOrganizationIDMinRange = value; }
        }

        private Nullable<Int32> _forwardOrganizationIDMaxRange;

        /// <summary>
        /// A search property representation of the ForwardOrganizationIDMaxRange field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ForwardOrganizationIDMaxRange
        {
            get { return _forwardOrganizationIDMaxRange; }
            set { _forwardOrganizationIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _forwardOrganizationIDIsIn;

        /// <summary>
        /// A search property representation of the ForwardOrganizationIDIsIn field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> ForwardOrganizationIDIsIn
        {
            get
            {
                if (_forwardOrganizationIDIsIn == null)
                {
                    _forwardOrganizationIDIsIn = new List<Nullable<Int32>>();
                }
                return _forwardOrganizationIDIsIn;
            }
            set { _forwardOrganizationIDIsIn = value; }
        }

        private Nullable<Int32> _organizationFormRoutingIDMinRange;

        /// <summary>
        /// A search property representation of the OrganizationFormRoutingIDMinRange field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationFormRoutingIDMinRange
        {
            get { return _organizationFormRoutingIDMinRange; }
            set { _organizationFormRoutingIDMinRange = value; }
        }

        private Nullable<Int32> _organizationFormRoutingIDMaxRange;

        /// <summary>
        /// A search property representation of the OrganizationFormRoutingIDMaxRange field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationFormRoutingIDMaxRange
        {
            get { return _organizationFormRoutingIDMaxRange; }
            set { _organizationFormRoutingIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _organizationFormRoutingIDIsIn;

        /// <summary>
        /// A search property representation of the OrganizationFormRoutingIDIsIn field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> OrganizationFormRoutingIDIsIn
        {
            get
            {
                if (_organizationFormRoutingIDIsIn == null)
                {
                    _organizationFormRoutingIDIsIn = new List<Nullable<Int32>>();
                }
                return _organizationFormRoutingIDIsIn;
            }
            set { _organizationFormRoutingIDIsIn = value; }
        }

        private Nullable<Int32> _formTypeIDMinRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMinRange field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMinRange
        {
            get { return _formTypeIDMinRange; }
            set { _formTypeIDMinRange = value; }
        }

        private Nullable<Int32> _formTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMaxRange field for a record in the dbo.OrganizationForwarding data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMaxRange
        {
            get { return _formTypeIDMaxRange; }
            set { _formTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formTypeIDIsIn;

        /// <summary>
        /// A search property representation of the FormTypeIDIsIn field for a record in the dbo.OrganizationForwarding data table. 
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

    }

    [Serializable]
    public partial class OrganizationForwardingExtended : EntityExtendedBase
    {
        internal OrganizationForwardingExtended() { }
    }
}