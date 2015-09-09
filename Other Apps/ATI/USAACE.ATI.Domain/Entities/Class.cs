using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.Class data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class Class : EntityBase
    {
        private ClassSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public ClassSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new ClassSearch();
                }

                return _searchProperties;
            }
        }

        private ClassExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public ClassExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new ClassExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _classID;

        /// <summary>
        /// A property representation of the ClassID field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> ClassID
        {
            get { return _classID; }
            set { _classID = value; }
        }

        private Nullable<Int32> _courseID;

        /// <summary>
        /// A property representation of the CourseID field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }

        private Nullable<Int32> _pOIID;

        /// <summary>
        /// A property representation of the POIID field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> POIID
        {
            get { return _pOIID; }
            set { _pOIID = value; }
        }

        private String _classNumber;

        /// <summary>
        /// A property representation of the ClassNumber field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Size = 3)]
        public String ClassNumber
        {
            get { return _classNumber; }
            set { _classNumber = value; }
        }

        private Nullable<DateTime> _reportDate;

        /// <summary>
        /// A property representation of the ReportDate field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> ReportDate
        {
            get { return _reportDate; }
            set { _reportDate = value; }
        }

        private Nullable<Int16> _interval;

        /// <summary>
        /// A property representation of the Interval field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

        private Nullable<Int16> _students;

        /// <summary>
        /// A property representation of the Students field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> Students
        {
            get { return _students; }
            set { _students = value; }
        }

        private Nullable<Int16> _reimbursable;

        /// <summary>
        /// A property representation of the Reimbursable field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> Reimbursable
        {
            get { return _reimbursable; }
            set { _reimbursable = value; }
        }

    }

    [Serializable]
    public class ClassSearch : EntitySearchBase
    {
        internal ClassSearch() { }

        private Nullable<Int32> _courseIDMinRange;

        /// <summary>
        /// A search property representation of the CourseIDMinRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseIDMinRange
        {
            get { return _courseIDMinRange; }
            set { _courseIDMinRange = value; }
        }

        private Nullable<Int32> _courseIDMaxRange;

        /// <summary>
        /// A search property representation of the CourseIDMaxRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseIDMaxRange
        {
            get { return _courseIDMaxRange; }
            set { _courseIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _courseIDIsIn;

        /// <summary>
        /// A search property representation of the CourseIDIsIn field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> CourseIDIsIn
        {
            get
            {
                if (_courseIDIsIn == null)
                {
                    _courseIDIsIn = new List<Nullable<Int32>>();
                }
                return _courseIDIsIn;
            }
            set { _courseIDIsIn = value; }
        }

        private Nullable<Int32> _pOIIDMinRange;

        /// <summary>
        /// A search property representation of the POIIDMinRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> POIIDMinRange
        {
            get { return _pOIIDMinRange; }
            set { _pOIIDMinRange = value; }
        }

        private Nullable<Int32> _pOIIDMaxRange;

        /// <summary>
        /// A search property representation of the POIIDMaxRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> POIIDMaxRange
        {
            get { return _pOIIDMaxRange; }
            set { _pOIIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _pOIIDIsIn;

        /// <summary>
        /// A search property representation of the POIIDIsIn field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> POIIDIsIn
        {
            get
            {
                if (_pOIIDIsIn == null)
                {
                    _pOIIDIsIn = new List<Nullable<Int32>>();
                }
                return _pOIIDIsIn;
            }
            set { _pOIIDIsIn = value; }
        }

        private String _classNumberContains;

        /// <summary>
        /// A search property representation of the ClassNumberContains field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Size = 3, SearchOnly = true)]
        public String ClassNumberContains
        {
            get { return _classNumberContains; }
            set { _classNumberContains = value; }
        }

        private IList<String> _classNumberIsIn;

        /// <summary>
        /// A search property representation of the ClassNumberIsIn field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Size = 3, SearchOnly = true)]
        public IList<String> ClassNumberIsIn
        {
            get
            {
                if (_classNumberIsIn == null)
                {
                    _classNumberIsIn = new List<String>();
                }
                return _classNumberIsIn;
            }
            set { _classNumberIsIn = value; }
        }

        private Nullable<DateTime> _reportDateMinRange;

        /// <summary>
        /// A search property representation of the ReportDateMinRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> ReportDateMinRange
        {
            get { return _reportDateMinRange; }
            set { _reportDateMinRange = value; }
        }

        private Nullable<DateTime> _reportDateMaxRange;

        /// <summary>
        /// A search property representation of the ReportDateMaxRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> ReportDateMaxRange
        {
            get { return _reportDateMaxRange; }
            set { _reportDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _reportDateIsIn;

        /// <summary>
        /// A search property representation of the ReportDateIsIn field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> ReportDateIsIn
        {
            get
            {
                if (_reportDateIsIn == null)
                {
                    _reportDateIsIn = new List<Nullable<DateTime>>();
                }
                return _reportDateIsIn;
            }
            set { _reportDateIsIn = value; }
        }

        private Nullable<Int16> _intervalMinRange;

        /// <summary>
        /// A search property representation of the IntervalMinRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> IntervalMinRange
        {
            get { return _intervalMinRange; }
            set { _intervalMinRange = value; }
        }

        private Nullable<Int16> _intervalMaxRange;

        /// <summary>
        /// A search property representation of the IntervalMaxRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> IntervalMaxRange
        {
            get { return _intervalMaxRange; }
            set { _intervalMaxRange = value; }
        }

        private IList<Nullable<Int16>> _intervalIsIn;

        /// <summary>
        /// A search property representation of the IntervalIsIn field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> IntervalIsIn
        {
            get
            {
                if (_intervalIsIn == null)
                {
                    _intervalIsIn = new List<Nullable<Int16>>();
                }
                return _intervalIsIn;
            }
            set { _intervalIsIn = value; }
        }

        private Nullable<Int16> _studentsMinRange;

        /// <summary>
        /// A search property representation of the StudentsMinRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> StudentsMinRange
        {
            get { return _studentsMinRange; }
            set { _studentsMinRange = value; }
        }

        private Nullable<Int16> _studentsMaxRange;

        /// <summary>
        /// A search property representation of the StudentsMaxRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> StudentsMaxRange
        {
            get { return _studentsMaxRange; }
            set { _studentsMaxRange = value; }
        }

        private IList<Nullable<Int16>> _studentsIsIn;

        /// <summary>
        /// A search property representation of the StudentsIsIn field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> StudentsIsIn
        {
            get
            {
                if (_studentsIsIn == null)
                {
                    _studentsIsIn = new List<Nullable<Int16>>();
                }
                return _studentsIsIn;
            }
            set { _studentsIsIn = value; }
        }

        private Nullable<Int16> _reimbursableMinRange;

        /// <summary>
        /// A search property representation of the ReimbursableMinRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> ReimbursableMinRange
        {
            get { return _reimbursableMinRange; }
            set { _reimbursableMinRange = value; }
        }

        private Nullable<Int16> _reimbursableMaxRange;

        /// <summary>
        /// A search property representation of the ReimbursableMaxRange field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> ReimbursableMaxRange
        {
            get { return _reimbursableMaxRange; }
            set { _reimbursableMaxRange = value; }
        }

        private IList<Nullable<Int16>> _reimbursableIsIn;

        /// <summary>
        /// A search property representation of the ReimbursableIsIn field for a record in the dbo.Class data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> ReimbursableIsIn
        {
            get
            {
                if (_reimbursableIsIn == null)
                {
                    _reimbursableIsIn = new List<Nullable<Int16>>();
                }
                return _reimbursableIsIn;
            }
            set { _reimbursableIsIn = value; }
        }

    }

    [Serializable]
    public partial class ClassExtended : EntityExtendedBase
    {
        internal ClassExtended() { }
    }
}