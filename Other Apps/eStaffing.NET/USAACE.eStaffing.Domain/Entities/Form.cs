using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.Form data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class Form : EntityBase
    {
        private FormSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public FormSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new FormSearch();
                }

                return _searchProperties;
            }
        }

        private FormExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public FormExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new FormExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _formID;

        /// <summary>
        /// A property representation of the FormID field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> FormID
        {
            get { return _formID; }
            set { _formID = value; }
        }

        private String _formNumber;

        /// <summary>
        /// A property representation of the FormNumber field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String FormNumber
        {
            get { return _formNumber; }
            set { _formNumber = value; }
        }

        private Nullable<Int32> _formTypeID;

        /// <summary>
        /// A property representation of the FormTypeID field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormTypeID
        {
            get { return _formTypeID; }
            set { _formTypeID = value; }
        }

        private Nullable<Int32> _submitterGroupID;

        /// <summary>
        /// A property representation of the SubmitterGroupID field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> SubmitterGroupID
        {
            get { return _submitterGroupID; }
            set { _submitterGroupID = value; }
        }

        private Nullable<DateTime> _submitDate;

        /// <summary>
        /// A property representation of the SubmitDate field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> SubmitDate
        {
            get { return _submitDate; }
            set { _submitDate = value; }
        }

        private Nullable<Boolean> _submitted;

        /// <summary>
        /// A property representation of the Submitted field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Submitted
        {
            get { return _submitted; }
            set { _submitted = value; }
        }

        private String _subject;

        /// <summary>
        /// A property representation of the Subject field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Size = 200)]
        public String Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private Nullable<DateTime> _suspenseDate;

        /// <summary>
        /// A property representation of the SuspenseDate field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> SuspenseDate
        {
            get { return _suspenseDate; }
            set { _suspenseDate = value; }
        }

        private Nullable<Boolean> _highPriority;

        /// <summary>
        /// A property representation of the HighPriority field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> HighPriority
        {
            get { return _highPriority; }
            set { _highPriority = value; }
        }

        private Nullable<Int32> _formStatusID;

        /// <summary>
        /// A property representation of the FormStatusID field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormStatusID
        {
            get { return _formStatusID; }
            set { _formStatusID = value; }
        }

    }

    [Serializable]
    public class FormSearch : EntitySearchBase
    {
        internal FormSearch() { }

        private String _formNumberContains;

        /// <summary>
        /// A search property representation of the FormNumberContains field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String FormNumberContains
        {
            get { return _formNumberContains; }
            set { _formNumberContains = value; }
        }

        private IList<String> _formNumberIsIn;

        /// <summary>
        /// A search property representation of the FormNumberIsIn field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> FormNumberIsIn
        {
            get
            {
                if (_formNumberIsIn == null)
                {
                    _formNumberIsIn = new List<String>();
                }
                return _formNumberIsIn;
            }
            set { _formNumberIsIn = value; }
        }

        private Nullable<Int32> _formTypeIDMinRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMinRange field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMinRange
        {
            get { return _formTypeIDMinRange; }
            set { _formTypeIDMinRange = value; }
        }

        private Nullable<Int32> _formTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the FormTypeIDMaxRange field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormTypeIDMaxRange
        {
            get { return _formTypeIDMaxRange; }
            set { _formTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formTypeIDIsIn;

        /// <summary>
        /// A search property representation of the FormTypeIDIsIn field for a record in the dbo.Form data table. 
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

        private Nullable<Int32> _submitterGroupIDMinRange;

        /// <summary>
        /// A search property representation of the SubmitterGroupIDMinRange field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> SubmitterGroupIDMinRange
        {
            get { return _submitterGroupIDMinRange; }
            set { _submitterGroupIDMinRange = value; }
        }

        private Nullable<Int32> _submitterGroupIDMaxRange;

        /// <summary>
        /// A search property representation of the SubmitterGroupIDMaxRange field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> SubmitterGroupIDMaxRange
        {
            get { return _submitterGroupIDMaxRange; }
            set { _submitterGroupIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _submitterGroupIDIsIn;

        /// <summary>
        /// A search property representation of the SubmitterGroupIDIsIn field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> SubmitterGroupIDIsIn
        {
            get
            {
                if (_submitterGroupIDIsIn == null)
                {
                    _submitterGroupIDIsIn = new List<Nullable<Int32>>();
                }
                return _submitterGroupIDIsIn;
            }
            set { _submitterGroupIDIsIn = value; }
        }

        private Nullable<DateTime> _submitDateMinRange;

        /// <summary>
        /// A search property representation of the SubmitDateMinRange field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> SubmitDateMinRange
        {
            get { return _submitDateMinRange; }
            set { _submitDateMinRange = value; }
        }

        private Nullable<DateTime> _submitDateMaxRange;

        /// <summary>
        /// A search property representation of the SubmitDateMaxRange field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> SubmitDateMaxRange
        {
            get { return _submitDateMaxRange; }
            set { _submitDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _submitDateIsIn;

        /// <summary>
        /// A search property representation of the SubmitDateIsIn field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> SubmitDateIsIn
        {
            get
            {
                if (_submitDateIsIn == null)
                {
                    _submitDateIsIn = new List<Nullable<DateTime>>();
                }
                return _submitDateIsIn;
            }
            set { _submitDateIsIn = value; }
        }

        private String _subjectContains;

        /// <summary>
        /// A search property representation of the SubjectContains field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public String SubjectContains
        {
            get { return _subjectContains; }
            set { _subjectContains = value; }
        }

        private IList<String> _subjectIsIn;

        /// <summary>
        /// A search property representation of the SubjectIsIn field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public IList<String> SubjectIsIn
        {
            get
            {
                if (_subjectIsIn == null)
                {
                    _subjectIsIn = new List<String>();
                }
                return _subjectIsIn;
            }
            set { _subjectIsIn = value; }
        }

        private Nullable<DateTime> _suspenseDateMinRange;

        /// <summary>
        /// A search property representation of the SuspenseDateMinRange field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> SuspenseDateMinRange
        {
            get { return _suspenseDateMinRange; }
            set { _suspenseDateMinRange = value; }
        }

        private Nullable<DateTime> _suspenseDateMaxRange;

        /// <summary>
        /// A search property representation of the SuspenseDateMaxRange field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> SuspenseDateMaxRange
        {
            get { return _suspenseDateMaxRange; }
            set { _suspenseDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _suspenseDateIsIn;

        /// <summary>
        /// A search property representation of the SuspenseDateIsIn field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> SuspenseDateIsIn
        {
            get
            {
                if (_suspenseDateIsIn == null)
                {
                    _suspenseDateIsIn = new List<Nullable<DateTime>>();
                }
                return _suspenseDateIsIn;
            }
            set { _suspenseDateIsIn = value; }
        }

        private Nullable<Int32> _formStatusIDMinRange;

        /// <summary>
        /// A search property representation of the FormStatusIDMinRange field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormStatusIDMinRange
        {
            get { return _formStatusIDMinRange; }
            set { _formStatusIDMinRange = value; }
        }

        private Nullable<Int32> _formStatusIDMaxRange;

        /// <summary>
        /// A search property representation of the FormStatusIDMaxRange field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormStatusIDMaxRange
        {
            get { return _formStatusIDMaxRange; }
            set { _formStatusIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formStatusIDIsIn;

        /// <summary>
        /// A search property representation of the FormStatusIDIsIn field for a record in the dbo.Form data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> FormStatusIDIsIn
        {
            get
            {
                if (_formStatusIDIsIn == null)
                {
                    _formStatusIDIsIn = new List<Nullable<Int32>>();
                }
                return _formStatusIDIsIn;
            }
            set { _formStatusIDIsIn = value; }
        }

    }

    [Serializable]
    public partial class FormExtended : EntityExtendedBase
    {
        internal FormExtended() { }
    }
}