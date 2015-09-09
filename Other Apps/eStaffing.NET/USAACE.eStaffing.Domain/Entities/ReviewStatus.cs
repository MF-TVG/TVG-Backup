using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.ReviewStatus data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class ReviewStatus : EntityBase
    {
        private ReviewStatusSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public ReviewStatusSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new ReviewStatusSearch();
                }

                return _searchProperties;
            }
        }

        private ReviewStatusExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public ReviewStatusExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new ReviewStatusExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _reviewStatusID;

        /// <summary>
        /// A property representation of the ReviewStatusID field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewStatusID
        {
            get { return _reviewStatusID; }
            set { _reviewStatusID = value; }
        }

        private Nullable<Int32> _formID;

        /// <summary>
        /// A property representation of the FormID field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormID
        {
            get { return _formID; }
            set { _formID = value; }
        }

        private Nullable<Boolean> _notified;

        /// <summary>
        /// A property representation of the Notified field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Notified
        {
            get { return _notified; }
            set { _notified = value; }
        }

        private Nullable<Int32> _reviewActionID;

        /// <summary>
        /// A property representation of the ReviewActionID field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewActionID
        {
            get { return _reviewActionID; }
            set { _reviewActionID = value; }
        }

        private Nullable<DateTime> _actionDate;

        /// <summary>
        /// A property representation of the ActionDate field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> ActionDate
        {
            get { return _actionDate; }
            set { _actionDate = value; }
        }

        private Nullable<Boolean> _autopen;

        /// <summary>
        /// A property representation of the Autopen field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Autopen
        {
            get { return _autopen; }
            set { _autopen = value; }
        }

        private String _comments;

        /// <summary>
        /// A property representation of the Comments field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty()]
        public String Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        private Nullable<Boolean> _signed;

        /// <summary>
        /// A property representation of the Signed field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Signed
        {
            get { return _signed; }
            set { _signed = value; }
        }

        private Nullable<Byte> _reviewOrder;

        /// <summary>
        /// A property representation of the ReviewOrder field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0)]
        public Nullable<Byte> ReviewOrder
        {
            get { return _reviewOrder; }
            set { _reviewOrder = value; }
        }

        private Nullable<Int32> _reviewerGroupID;

        /// <summary>
        /// A property representation of the ReviewerGroupID field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewerGroupID
        {
            get { return _reviewerGroupID; }
            set { _reviewerGroupID = value; }
        }

        private Nullable<Int32> _organizationID;

        /// <summary>
        /// A property representation of the OrganizationID field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value; }
        }

        private Nullable<Int32> _reviewRoleID;

        /// <summary>
        /// A property representation of the ReviewRoleID field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewRoleID
        {
            get { return _reviewRoleID; }
            set { _reviewRoleID = value; }
        }

        private Nullable<Boolean> _digitalSignature;

        /// <summary>
        /// A property representation of the DigitalSignature field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> DigitalSignature
        {
            get { return _digitalSignature; }
            set { _digitalSignature = value; }
        }

    }

    [Serializable]
    public class ReviewStatusSearch : EntitySearchBase
    {
        internal ReviewStatusSearch() { }

        private Nullable<Int32> _formIDMinRange;

        /// <summary>
        /// A search property representation of the FormIDMinRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormIDMinRange
        {
            get { return _formIDMinRange; }
            set { _formIDMinRange = value; }
        }

        private Nullable<Int32> _formIDMaxRange;

        /// <summary>
        /// A search property representation of the FormIDMaxRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormIDMaxRange
        {
            get { return _formIDMaxRange; }
            set { _formIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formIDIsIn;

        /// <summary>
        /// A search property representation of the FormIDIsIn field for a record in the dbo.ReviewStatus data table. 
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

        private Nullable<Int32> _reviewActionIDMinRange;

        /// <summary>
        /// A search property representation of the ReviewActionIDMinRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewActionIDMinRange
        {
            get { return _reviewActionIDMinRange; }
            set { _reviewActionIDMinRange = value; }
        }

        private Nullable<Int32> _reviewActionIDMaxRange;

        /// <summary>
        /// A search property representation of the ReviewActionIDMaxRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewActionIDMaxRange
        {
            get { return _reviewActionIDMaxRange; }
            set { _reviewActionIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _reviewActionIDIsIn;

        /// <summary>
        /// A search property representation of the ReviewActionIDIsIn field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> ReviewActionIDIsIn
        {
            get
            {
                if (_reviewActionIDIsIn == null)
                {
                    _reviewActionIDIsIn = new List<Nullable<Int32>>();
                }
                return _reviewActionIDIsIn;
            }
            set { _reviewActionIDIsIn = value; }
        }

        private Nullable<DateTime> _actionDateMinRange;

        /// <summary>
        /// A search property representation of the ActionDateMinRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> ActionDateMinRange
        {
            get { return _actionDateMinRange; }
            set { _actionDateMinRange = value; }
        }

        private Nullable<DateTime> _actionDateMaxRange;

        /// <summary>
        /// A search property representation of the ActionDateMaxRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> ActionDateMaxRange
        {
            get { return _actionDateMaxRange; }
            set { _actionDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _actionDateIsIn;

        /// <summary>
        /// A search property representation of the ActionDateIsIn field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> ActionDateIsIn
        {
            get
            {
                if (_actionDateIsIn == null)
                {
                    _actionDateIsIn = new List<Nullable<DateTime>>();
                }
                return _actionDateIsIn;
            }
            set { _actionDateIsIn = value; }
        }

        private String _commentsContains;

        /// <summary>
        /// A search property representation of the CommentsContains field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String CommentsContains
        {
            get { return _commentsContains; }
            set { _commentsContains = value; }
        }

        private IList<String> _commentsIsIn;

        /// <summary>
        /// A search property representation of the CommentsIsIn field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> CommentsIsIn
        {
            get
            {
                if (_commentsIsIn == null)
                {
                    _commentsIsIn = new List<String>();
                }
                return _commentsIsIn;
            }
            set { _commentsIsIn = value; }
        }

        private Nullable<Byte> _reviewOrderMinRange;

        /// <summary>
        /// A search property representation of the ReviewOrderMinRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> ReviewOrderMinRange
        {
            get { return _reviewOrderMinRange; }
            set { _reviewOrderMinRange = value; }
        }

        private Nullable<Byte> _reviewOrderMaxRange;

        /// <summary>
        /// A search property representation of the ReviewOrderMaxRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> ReviewOrderMaxRange
        {
            get { return _reviewOrderMaxRange; }
            set { _reviewOrderMaxRange = value; }
        }

        private IList<Nullable<Byte>> _reviewOrderIsIn;

        /// <summary>
        /// A search property representation of the ReviewOrderIsIn field for a record in the dbo.ReviewStatus data table. 
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
        /// A search property representation of the ReviewerGroupIDMinRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewerGroupIDMinRange
        {
            get { return _reviewerGroupIDMinRange; }
            set { _reviewerGroupIDMinRange = value; }
        }

        private Nullable<Int32> _reviewerGroupIDMaxRange;

        /// <summary>
        /// A search property representation of the ReviewerGroupIDMaxRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewerGroupIDMaxRange
        {
            get { return _reviewerGroupIDMaxRange; }
            set { _reviewerGroupIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _reviewerGroupIDIsIn;

        /// <summary>
        /// A search property representation of the ReviewerGroupIDIsIn field for a record in the dbo.ReviewStatus data table. 
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

        private Nullable<Int32> _organizationIDMinRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMinRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMinRange
        {
            get { return _organizationIDMinRange; }
            set { _organizationIDMinRange = value; }
        }

        private Nullable<Int32> _organizationIDMaxRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMaxRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMaxRange
        {
            get { return _organizationIDMaxRange; }
            set { _organizationIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _organizationIDIsIn;

        /// <summary>
        /// A search property representation of the OrganizationIDIsIn field for a record in the dbo.ReviewStatus data table. 
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

        private Nullable<Int32> _reviewRoleIDMinRange;

        /// <summary>
        /// A search property representation of the ReviewRoleIDMinRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewRoleIDMinRange
        {
            get { return _reviewRoleIDMinRange; }
            set { _reviewRoleIDMinRange = value; }
        }

        private Nullable<Int32> _reviewRoleIDMaxRange;

        /// <summary>
        /// A search property representation of the ReviewRoleIDMaxRange field for a record in the dbo.ReviewStatus data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ReviewRoleIDMaxRange
        {
            get { return _reviewRoleIDMaxRange; }
            set { _reviewRoleIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _reviewRoleIDIsIn;

        /// <summary>
        /// A search property representation of the ReviewRoleIDIsIn field for a record in the dbo.ReviewStatus data table. 
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
    public partial class ReviewStatusExtended : EntityExtendedBase
    {
        internal ReviewStatusExtended() { }
    }
}