using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.OrganizationFormReviewer data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class OrganizationFormReviewer : EntityBase
    {
        private OrganizationFormReviewerSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public OrganizationFormReviewerSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new OrganizationFormReviewerSearch();
                }

                return _searchProperties;
            }
        }

        private OrganizationFormReviewerExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public OrganizationFormReviewerExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new OrganizationFormReviewerExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _organizationFormReviewerID;

        /// <summary>
        /// A property representation of the OrganizationFormReviewerID field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationFormReviewerID
        {
            get { return _organizationFormReviewerID; }
            set { _organizationFormReviewerID = value; }
        }

        private Nullable<Int32> _organizationFormRoutingID;

        /// <summary>
        /// A property representation of the OrganizationFormRoutingID field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationFormRoutingID
        {
            get { return _organizationFormRoutingID; }
            set { _organizationFormRoutingID = value; }
        }

        private Nullable<Byte> _reviewOrder;

        /// <summary>
        /// A property representation of the ReviewOrder field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0)]
        public Nullable<Byte> ReviewOrder
        {
            get { return _reviewOrder; }
            set { _reviewOrder = value; }
        }

        private Nullable<Int32> _reviewerGroupID;

        /// <summary>
        /// A property representation of the ReviewerGroupID field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewerGroupID
        {
            get { return _reviewerGroupID; }
            set { _reviewerGroupID = value; }
        }

        private Nullable<Int32> _reviewRoleID;

        /// <summary>
        /// A property representation of the ReviewRoleID field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewRoleID
        {
            get { return _reviewRoleID; }
            set { _reviewRoleID = value; }
        }

    }

    [Serializable]
    public class OrganizationFormReviewerSearch : EntitySearchBase
    {
        internal OrganizationFormReviewerSearch() { }

        private Nullable<Int32> _organizationFormRoutingIDMinRange;

        /// <summary>
        /// A search property representation of the OrganizationFormRoutingIDMinRange field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationFormRoutingIDMinRange
        {
            get { return _organizationFormRoutingIDMinRange; }
            set { _organizationFormRoutingIDMinRange = value; }
        }

        private Nullable<Int32> _organizationFormRoutingIDMaxRange;

        /// <summary>
        /// A search property representation of the OrganizationFormRoutingIDMaxRange field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationFormRoutingIDMaxRange
        {
            get { return _organizationFormRoutingIDMaxRange; }
            set { _organizationFormRoutingIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _organizationFormRoutingIDIsIn;

        /// <summary>
        /// A search property representation of the OrganizationFormRoutingIDIsIn field for a record in the dbo.OrganizationFormReviewer data table. 
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

        private Nullable<Byte> _reviewOrderMinRange;

        /// <summary>
        /// A search property representation of the ReviewOrderMinRange field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> ReviewOrderMinRange
        {
            get { return _reviewOrderMinRange; }
            set { _reviewOrderMinRange = value; }
        }

        private Nullable<Byte> _reviewOrderMaxRange;

        /// <summary>
        /// A search property representation of the ReviewOrderMaxRange field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> ReviewOrderMaxRange
        {
            get { return _reviewOrderMaxRange; }
            set { _reviewOrderMaxRange = value; }
        }

        private IList<Nullable<Byte>> _reviewOrderIsIn;

        /// <summary>
        /// A search property representation of the ReviewOrderIsIn field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Byte>> ReviewOrderIsIn
        {
            get
            {
                if (_reviewOrderIsIn == null)
                {
                    _reviewOrderIsIn = new List<Nullable<Byte>>();
                }
                return _reviewOrderIsIn;
            }
            set { _reviewOrderIsIn = value; }
        }

        private Nullable<Int32> _reviewerGroupIDMinRange;

        /// <summary>
        /// A search property representation of the ReviewerGroupIDMinRange field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewerGroupIDMinRange
        {
            get { return _reviewerGroupIDMinRange; }
            set { _reviewerGroupIDMinRange = value; }
        }

        private Nullable<Int32> _reviewerGroupIDMaxRange;

        /// <summary>
        /// A search property representation of the ReviewerGroupIDMaxRange field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewerGroupIDMaxRange
        {
            get { return _reviewerGroupIDMaxRange; }
            set { _reviewerGroupIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _reviewerGroupIDIsIn;

        /// <summary>
        /// A search property representation of the ReviewerGroupIDIsIn field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> ReviewerGroupIDIsIn
        {
            get
            {
                if (_reviewerGroupIDIsIn == null)
                {
                    _reviewerGroupIDIsIn = new List<Nullable<Int32>>();
                }
                return _reviewerGroupIDIsIn;
            }
            set { _reviewerGroupIDIsIn = value; }
        }

        private Nullable<Int32> _reviewRoleIDMinRange;

        /// <summary>
        /// A search property representation of the ReviewRoleIDMinRange field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewRoleIDMinRange
        {
            get { return _reviewRoleIDMinRange; }
            set { _reviewRoleIDMinRange = value; }
        }

        private Nullable<Int32> _reviewRoleIDMaxRange;

        /// <summary>
        /// A search property representation of the ReviewRoleIDMaxRange field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewRoleIDMaxRange
        {
            get { return _reviewRoleIDMaxRange; }
            set { _reviewRoleIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _reviewRoleIDIsIn;

        /// <summary>
        /// A search property representation of the ReviewRoleIDIsIn field for a record in the dbo.OrganizationFormReviewer data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> ReviewRoleIDIsIn
        {
            get
            {
                if (_reviewRoleIDIsIn == null)
                {
                    _reviewRoleIDIsIn = new List<Nullable<Int32>>();
                }
                return _reviewRoleIDIsIn;
            }
            set { _reviewRoleIDIsIn = value; }
        }

    }

    [Serializable]
    public partial class OrganizationFormReviewerExtended : EntityExtendedBase
    {
        internal OrganizationFormReviewerExtended() { }
    }
}