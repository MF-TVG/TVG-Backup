using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.OrganizationFormActor data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class OrganizationFormActor : EntityBase
    {
        private OrganizationFormActorSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public OrganizationFormActorSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new OrganizationFormActorSearch();
                }

                return _searchProperties;
            }
        }

        private OrganizationFormActorExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public OrganizationFormActorExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new OrganizationFormActorExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _organizationFormActorID;

        /// <summary>
        /// A property representation of the OrganizationFormActorID field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationFormActorID
        {
            get { return _organizationFormActorID; }
            set { _organizationFormActorID = value; }
        }

        private Nullable<Int32> _organizationID;

        /// <summary>
        /// A property representation of the OrganizationID field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value; }
        }

        private Nullable<Int32> _formTypeID;

        /// <summary>
        /// A property representation of the FormTypeID field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormTypeID
        {
            get { return _formTypeID; }
            set { _formTypeID = value; }
        }

        private Nullable<Int32> _organizationGroupID;

        /// <summary>
        /// A property representation of the OrganizationGroupID field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationGroupID
        {
            get { return _organizationGroupID; }
            set { _organizationGroupID = value; }
        }

        private Nullable<Boolean> _canSubmit;

        /// <summary>
        /// A property representation of the CanSubmit field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CanSubmit
        {
            get { return _canSubmit; }
            set { _canSubmit = value; }
        }

        private Nullable<Boolean> _canReview;

        /// <summary>
        /// A property representation of the CanReview field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CanReview
        {
            get { return _canReview; }
            set { _canReview = value; }
        }

        private Nullable<Boolean> _canChangeRoute;

        /// <summary>
        /// A property representation of the CanChangeRoute field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CanChangeRoute
        {
            get { return _canChangeRoute; }
            set { _canChangeRoute = value; }
        }

        private Nullable<Boolean> _canChooseRoute;

        /// <summary>
        /// A property representation of the CanChooseRoute field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CanChooseRoute
        {
            get { return _canChooseRoute; }
            set { _canChooseRoute = value; }
        }

        private Nullable<Boolean> _canAdmin;

        /// <summary>
        /// A property representation of the CanAdmin field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CanAdmin
        {
            get { return _canAdmin; }
            set { _canAdmin = value; }
        }

        private Nullable<Boolean> _canEditSubmission;

        /// <summary>
        /// A property representation of the CanEditSubmission field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CanEditSubmission
        {
            get { return _canEditSubmission; }
            set { _canEditSubmission = value; }
        }

        private Nullable<Boolean> _canForward;

        /// <summary>
        /// A property representation of the CanForward field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CanForward
        {
            get { return _canForward; }
            set { _canForward = value; }
        }

        private Nullable<Boolean> _canSeeComments;

        /// <summary>
        /// A property representation of the CanSeeComments field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CanSeeComments
        {
            get { return _canSeeComments; }
            set { _canSeeComments = value; }
        }

        private Nullable<Boolean> _canAssignAutopen;

        /// <summary>
        /// A property representation of the CanAssignAutopen field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CanAssignAutopen
        {
            get { return _canAssignAutopen; }
            set { _canAssignAutopen = value; }
        }

        private Nullable<Boolean> _canView;

        /// <summary>
        /// A property representation of the CanView field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CanView
        {
            get { return _canView; }
            set { _canView = value; }
        }

        private Nullable<Boolean> _mustReview;

        /// <summary>
        /// A property representation of the MustReview field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> MustReview
        {
            get { return _mustReview; }
            set { _mustReview = value; }
        }

        private Nullable<Boolean> _notifyComplete;

        /// <summary>
        /// A property representation of the NotifyComplete field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> NotifyComplete
        {
            get { return _notifyComplete; }
            set { _notifyComplete = value; }
        }

    }

    [Serializable]
    public class OrganizationFormActorSearch : EntitySearchBase
    {
        internal OrganizationFormActorSearch() { }

        private Nullable<Int32> _organizationIDMinRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMinRange field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMinRange
        {
            get { return _organizationIDMinRange; }
            set { _organizationIDMinRange = value; }
        }

        private Nullable<Int32> _organizationIDMaxRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMaxRange field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMaxRange
        {
            get { return _organizationIDMaxRange; }
            set { _organizationIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _organizationIDIsIn;

        /// <summary>
        /// A search property representation of the OrganizationIDIsIn field for a record in the dbo.OrganizationFormActor data table. 
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
        /// A search property representation of the FormTypeIDMinRange field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMinRange
        {
            get { return _formTypeIDMinRange; }
            set { _formTypeIDMinRange = value; }
        }

        private Nullable<Int32> _formTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMaxRange field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMaxRange
        {
            get { return _formTypeIDMaxRange; }
            set { _formTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formTypeIDIsIn;

        /// <summary>
        /// A search property representation of the FormTypeIDIsIn field for a record in the dbo.OrganizationFormActor data table. 
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

        private Nullable<Int32> _organizationGroupIDMinRange;

        /// <summary>
        /// A search property representation of the OrganizationGroupIDMinRange field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationGroupIDMinRange
        {
            get { return _organizationGroupIDMinRange; }
            set { _organizationGroupIDMinRange = value; }
        }

        private Nullable<Int32> _organizationGroupIDMaxRange;

        /// <summary>
        /// A search property representation of the OrganizationGroupIDMaxRange field for a record in the dbo.OrganizationFormActor data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationGroupIDMaxRange
        {
            get { return _organizationGroupIDMaxRange; }
            set { _organizationGroupIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _organizationGroupIDIsIn;

        /// <summary>
        /// A search property representation of the OrganizationGroupIDIsIn field for a record in the dbo.OrganizationFormActor data table. 
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

    }

    [Serializable]
    public partial class OrganizationFormActorExtended : EntityExtendedBase
    {
        internal OrganizationFormActorExtended() { }
    }
}