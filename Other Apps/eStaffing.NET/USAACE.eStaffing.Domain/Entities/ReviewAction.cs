using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.ReviewAction data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class ReviewAction : EntityBase
    {
        private ReviewActionSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public ReviewActionSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new ReviewActionSearch();
                }

                return _searchProperties;
            }
        }

        private ReviewActionExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public ReviewActionExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new ReviewActionExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _reviewActionID;

        /// <summary>
        /// A property representation of the ReviewActionID field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewActionID
        {
            get { return _reviewActionID; }
            set { _reviewActionID = value; }
        }

        private String _reviewActionName;

        /// <summary>
        /// A property representation of the ReviewActionName field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String ReviewActionName
        {
            get { return _reviewActionName; }
            set { _reviewActionName = value; }
        }

        private Nullable<Boolean> _causesCompletion;

        /// <summary>
        /// A property representation of the CausesCompletion field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CausesCompletion
        {
            get { return _causesCompletion; }
            set { _causesCompletion = value; }
        }

        private Nullable<Boolean> _causesRejection;

        /// <summary>
        /// A property representation of the CausesRejection field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> CausesRejection
        {
            get { return _causesRejection; }
            set { _causesRejection = value; }
        }

        private Nullable<Int32> _formActionTypeID;

        /// <summary>
        /// A property representation of the FormActionTypeID field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormActionTypeID
        {
            get { return _formActionTypeID; }
            set { _formActionTypeID = value; }
        }

        private Nullable<Boolean> _adminOnly;

        /// <summary>
        /// A property representation of the AdminOnly field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> AdminOnly
        {
            get { return _adminOnly; }
            set { _adminOnly = value; }
        }

    }

    [Serializable]
    public class ReviewActionSearch : EntitySearchBase
    {
        internal ReviewActionSearch() { }

        private String _reviewActionNameContains;

        /// <summary>
        /// A search property representation of the ReviewActionNameContains field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String ReviewActionNameContains
        {
            get { return _reviewActionNameContains; }
            set { _reviewActionNameContains = value; }
        }

        private IList<String> _reviewActionNameIsIn;

        /// <summary>
        /// A search property representation of the ReviewActionNameIsIn field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> ReviewActionNameIsIn
        {
            get
            {
                if (_reviewActionNameIsIn == null)
                {
                    _reviewActionNameIsIn = new List<String>();
                }
                return _reviewActionNameIsIn;
            }
            set { _reviewActionNameIsIn = value; }
        }

        private Nullable<Int32> _formActionTypeIDMinRange;

        /// <summary>
        /// A search property representation of the FormActionTypeIDMinRange field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormActionTypeIDMinRange
        {
            get { return _formActionTypeIDMinRange; }
            set { _formActionTypeIDMinRange = value; }
        }

        private Nullable<Int32> _formActionTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the FormActionTypeIDMaxRange field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormActionTypeIDMaxRange
        {
            get { return _formActionTypeIDMaxRange; }
            set { _formActionTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formActionTypeIDIsIn;

        /// <summary>
        /// A search property representation of the FormActionTypeIDIsIn field for a record in the dbo.ReviewAction data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> FormActionTypeIDIsIn
        {
            get
            {
                if (_formActionTypeIDIsIn == null)
                {
                    _formActionTypeIDIsIn = new List<Nullable<Int32>>();
                }
                return _formActionTypeIDIsIn;
            }
            set { _formActionTypeIDIsIn = value; }
        }

    }

    [Serializable]
    public partial class ReviewActionExtended : EntityExtendedBase
    {
        internal ReviewActionExtended() { }
    }
}