using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.OrganizationFormType data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class OrganizationFormType : EntityBase
    {
        private OrganizationFormTypeSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public OrganizationFormTypeSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new OrganizationFormTypeSearch();
                }

                return _searchProperties;
            }
        }

        private OrganizationFormTypeExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public OrganizationFormTypeExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new OrganizationFormTypeExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _organizationFormTypeID;

        /// <summary>
        /// A property representation of the OrganizationFormTypeID field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationFormTypeID
        {
            get { return _organizationFormTypeID; }
            set { _organizationFormTypeID = value; }
        }

        private Nullable<Int32> _formTypeID;

        /// <summary>
        /// A property representation of the FormTypeID field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormTypeID
        {
            get { return _formTypeID; }
            set { _formTypeID = value; }
        }

        private Nullable<Int32> _organizationID;

        /// <summary>
        /// A property representation of the OrganizationID field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value; }
        }

        private String _notifyReviewSubject;

        /// <summary>
        /// A property representation of the NotifyReviewSubject field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Size = 200)]
        public String NotifyReviewSubject
        {
            get { return _notifyReviewSubject; }
            set { _notifyReviewSubject = value; }
        }

        private String _notifyReviewMessage;

        /// <summary>
        /// A property representation of the NotifyReviewMessage field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty()]
        public String NotifyReviewMessage
        {
            get { return _notifyReviewMessage; }
            set { _notifyReviewMessage = value; }
        }

        private String _notifyRejectSubject;

        /// <summary>
        /// A property representation of the NotifyRejectSubject field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Size = 200)]
        public String NotifyRejectSubject
        {
            get { return _notifyRejectSubject; }
            set { _notifyRejectSubject = value; }
        }

        private String _notifyRejectMessage;

        /// <summary>
        /// A property representation of the NotifyRejectMessage field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty()]
        public String NotifyRejectMessage
        {
            get { return _notifyRejectMessage; }
            set { _notifyRejectMessage = value; }
        }

        private String _notifyCompleteSubject;

        /// <summary>
        /// A property representation of the NotifyCompleteSubject field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Size = 200)]
        public String NotifyCompleteSubject
        {
            get { return _notifyCompleteSubject; }
            set { _notifyCompleteSubject = value; }
        }

        private String _notifyCompleteMessage;

        /// <summary>
        /// A property representation of the NotifyCompleteMessage field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty()]
        public String NotifyCompleteMessage
        {
            get { return _notifyCompleteMessage; }
            set { _notifyCompleteMessage = value; }
        }

        private Nullable<Int16> _suspenseAdjust;

        /// <summary>
        /// A property representation of the SuspenseAdjust field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> SuspenseAdjust
        {
            get { return _suspenseAdjust; }
            set { _suspenseAdjust = value; }
        }

        private Nullable<Int16> _pastDueDays;

        /// <summary>
        /// A property representation of the PastDueDays field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> PastDueDays
        {
            get { return _pastDueDays; }
            set { _pastDueDays = value; }
        }

        private Nullable<Int16> _nearDueDays;

        /// <summary>
        /// A property representation of the NearDueDays field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> NearDueDays
        {
            get { return _nearDueDays; }
            set { _nearDueDays = value; }
        }

        private Nullable<Boolean> _parallelReview;

        /// <summary>
        /// A property representation of the ParallelReview field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> ParallelReview
        {
            get { return _parallelReview; }
            set { _parallelReview = value; }
        }

    }

    [Serializable]
    public class OrganizationFormTypeSearch : EntitySearchBase
    {
        internal OrganizationFormTypeSearch() { }

        private Nullable<Int32> _formTypeIDMinRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMinRange field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMinRange
        {
            get { return _formTypeIDMinRange; }
            set { _formTypeIDMinRange = value; }
        }

        private Nullable<Int32> _formTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMaxRange field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMaxRange
        {
            get { return _formTypeIDMaxRange; }
            set { _formTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formTypeIDIsIn;

        /// <summary>
        /// A search property representation of the FormTypeIDIsIn field for a record in the dbo.OrganizationFormType data table. 
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
        /// A search property representation of the OrganizationIDMinRange field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMinRange
        {
            get { return _organizationIDMinRange; }
            set { _organizationIDMinRange = value; }
        }

        private Nullable<Int32> _organizationIDMaxRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMaxRange field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMaxRange
        {
            get { return _organizationIDMaxRange; }
            set { _organizationIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _organizationIDIsIn;

        /// <summary>
        /// A search property representation of the OrganizationIDIsIn field for a record in the dbo.OrganizationFormType data table. 
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

        private String _notifyReviewSubjectContains;

        /// <summary>
        /// A search property representation of the NotifyReviewSubjectContains field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public String NotifyReviewSubjectContains
        {
            get { return _notifyReviewSubjectContains; }
            set { _notifyReviewSubjectContains = value; }
        }

        private IList<String> _notifyReviewSubjectIsIn;

        /// <summary>
        /// A search property representation of the NotifyReviewSubjectIsIn field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public IList<String> NotifyReviewSubjectIsIn
        {
            get
            {
                if (_notifyReviewSubjectIsIn == null)
                {
                    _notifyReviewSubjectIsIn = new List<String>();
                }
                return _notifyReviewSubjectIsIn;
            }
            set { _notifyReviewSubjectIsIn = value; }
        }

        private String _notifyReviewMessageContains;

        /// <summary>
        /// A search property representation of the NotifyReviewMessageContains field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String NotifyReviewMessageContains
        {
            get { return _notifyReviewMessageContains; }
            set { _notifyReviewMessageContains = value; }
        }

        private IList<String> _notifyReviewMessageIsIn;

        /// <summary>
        /// A search property representation of the NotifyReviewMessageIsIn field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> NotifyReviewMessageIsIn
        {
            get
            {
                if (_notifyReviewMessageIsIn == null)
                {
                    _notifyReviewMessageIsIn = new List<String>();
                }
                return _notifyReviewMessageIsIn;
            }
            set { _notifyReviewMessageIsIn = value; }
        }

        private String _notifyRejectSubjectContains;

        /// <summary>
        /// A search property representation of the NotifyRejectSubjectContains field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public String NotifyRejectSubjectContains
        {
            get { return _notifyRejectSubjectContains; }
            set { _notifyRejectSubjectContains = value; }
        }

        private IList<String> _notifyRejectSubjectIsIn;

        /// <summary>
        /// A search property representation of the NotifyRejectSubjectIsIn field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public IList<String> NotifyRejectSubjectIsIn
        {
            get
            {
                if (_notifyRejectSubjectIsIn == null)
                {
                    _notifyRejectSubjectIsIn = new List<String>();
                }
                return _notifyRejectSubjectIsIn;
            }
            set { _notifyRejectSubjectIsIn = value; }
        }

        private String _notifyRejectMessageContains;

        /// <summary>
        /// A search property representation of the NotifyRejectMessageContains field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String NotifyRejectMessageContains
        {
            get { return _notifyRejectMessageContains; }
            set { _notifyRejectMessageContains = value; }
        }

        private IList<String> _notifyRejectMessageIsIn;

        /// <summary>
        /// A search property representation of the NotifyRejectMessageIsIn field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> NotifyRejectMessageIsIn
        {
            get
            {
                if (_notifyRejectMessageIsIn == null)
                {
                    _notifyRejectMessageIsIn = new List<String>();
                }
                return _notifyRejectMessageIsIn;
            }
            set { _notifyRejectMessageIsIn = value; }
        }

        private String _notifyCompleteSubjectContains;

        /// <summary>
        /// A search property representation of the NotifyCompleteSubjectContains field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public String NotifyCompleteSubjectContains
        {
            get { return _notifyCompleteSubjectContains; }
            set { _notifyCompleteSubjectContains = value; }
        }

        private IList<String> _notifyCompleteSubjectIsIn;

        /// <summary>
        /// A search property representation of the NotifyCompleteSubjectIsIn field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public IList<String> NotifyCompleteSubjectIsIn
        {
            get
            {
                if (_notifyCompleteSubjectIsIn == null)
                {
                    _notifyCompleteSubjectIsIn = new List<String>();
                }
                return _notifyCompleteSubjectIsIn;
            }
            set { _notifyCompleteSubjectIsIn = value; }
        }

        private String _notifyCompleteMessageContains;

        /// <summary>
        /// A search property representation of the NotifyCompleteMessageContains field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String NotifyCompleteMessageContains
        {
            get { return _notifyCompleteMessageContains; }
            set { _notifyCompleteMessageContains = value; }
        }

        private IList<String> _notifyCompleteMessageIsIn;

        /// <summary>
        /// A search property representation of the NotifyCompleteMessageIsIn field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> NotifyCompleteMessageIsIn
        {
            get
            {
                if (_notifyCompleteMessageIsIn == null)
                {
                    _notifyCompleteMessageIsIn = new List<String>();
                }
                return _notifyCompleteMessageIsIn;
            }
            set { _notifyCompleteMessageIsIn = value; }
        }

        private Nullable<Int16> _suspenseAdjustMinRange;

        /// <summary>
        /// A search property representation of the SuspenseAdjustMinRange field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> SuspenseAdjustMinRange
        {
            get { return _suspenseAdjustMinRange; }
            set { _suspenseAdjustMinRange = value; }
        }

        private Nullable<Int16> _suspenseAdjustMaxRange;

        /// <summary>
        /// A search property representation of the SuspenseAdjustMaxRange field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> SuspenseAdjustMaxRange
        {
            get { return _suspenseAdjustMaxRange; }
            set { _suspenseAdjustMaxRange = value; }
        }

        private IList<Nullable<Int16>> _suspenseAdjustIsIn;

        /// <summary>
        /// A search property representation of the SuspenseAdjustIsIn field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> SuspenseAdjustIsIn
        {
            get
            {
                if (_suspenseAdjustIsIn == null)
                {
                    _suspenseAdjustIsIn = new List<Nullable<Int16>>();
                }
                return _suspenseAdjustIsIn;
            }
            set { _suspenseAdjustIsIn = value; }
        }

        private Nullable<Int16> _pastDueDaysMinRange;

        /// <summary>
        /// A search property representation of the PastDueDaysMinRange field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> PastDueDaysMinRange
        {
            get { return _pastDueDaysMinRange; }
            set { _pastDueDaysMinRange = value; }
        }

        private Nullable<Int16> _pastDueDaysMaxRange;

        /// <summary>
        /// A search property representation of the PastDueDaysMaxRange field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> PastDueDaysMaxRange
        {
            get { return _pastDueDaysMaxRange; }
            set { _pastDueDaysMaxRange = value; }
        }

        private IList<Nullable<Int16>> _pastDueDaysIsIn;

        /// <summary>
        /// A search property representation of the PastDueDaysIsIn field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> PastDueDaysIsIn
        {
            get
            {
                if (_pastDueDaysIsIn == null)
                {
                    _pastDueDaysIsIn = new List<Nullable<Int16>>();
                }
                return _pastDueDaysIsIn;
            }
            set { _pastDueDaysIsIn = value; }
        }

        private Nullable<Int16> _nearDueDaysMinRange;

        /// <summary>
        /// A search property representation of the NearDueDaysMinRange field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> NearDueDaysMinRange
        {
            get { return _nearDueDaysMinRange; }
            set { _nearDueDaysMinRange = value; }
        }

        private Nullable<Int16> _nearDueDaysMaxRange;

        /// <summary>
        /// A search property representation of the NearDueDaysMaxRange field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> NearDueDaysMaxRange
        {
            get { return _nearDueDaysMaxRange; }
            set { _nearDueDaysMaxRange = value; }
        }

        private IList<Nullable<Int16>> _nearDueDaysIsIn;

        /// <summary>
        /// A search property representation of the NearDueDaysIsIn field for a record in the dbo.OrganizationFormType data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> NearDueDaysIsIn
        {
            get
            {
                if (_nearDueDaysIsIn == null)
                {
                    _nearDueDaysIsIn = new List<Nullable<Int16>>();
                }
                return _nearDueDaysIsIn;
            }
            set { _nearDueDaysIsIn = value; }
        }

    }

    [Serializable]
    public partial class OrganizationFormTypeExtended : EntityExtendedBase
    {
        internal OrganizationFormTypeExtended() { }
    }
}