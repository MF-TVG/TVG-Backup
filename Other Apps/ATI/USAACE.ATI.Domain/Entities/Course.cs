using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.Course data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class Course : EntityBase
    {
        private CourseSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public CourseSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new CourseSearch();
                }

                return _searchProperties;
            }
        }

        private CourseExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public CourseExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new CourseExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _courseID;

        /// <summary>
        /// A property representation of the CourseID field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }

        private String _courseName;

        /// <summary>
        /// A property representation of the CourseName field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String CourseName
        {
            get { return _courseName; }
            set { _courseName = value; }
        }

        private Nullable<Int32> _courseNumberID;

        /// <summary>
        /// A property representation of the CourseNumberID field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseNumberID
        {
            get { return _courseNumberID; }
            set { _courseNumberID = value; }
        }

        private String _prefix;

        /// <summary>
        /// A property representation of the Prefix field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String Prefix
        {
            get { return _prefix; }
            set { _prefix = value; }
        }

        private String _phase;

        /// <summary>
        /// A property representation of the Phase field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String Phase
        {
            get { return _phase; }
            set { _phase = value; }
        }

        private Nullable<Int32> _courseLevelID;

        /// <summary>
        /// A property representation of the CourseLevelID field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseLevelID
        {
            get { return _courseLevelID; }
            set { _courseLevelID = value; }
        }

        private Nullable<Int32> _systemID;

        /// <summary>
        /// A property representation of the SystemID field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> SystemID
        {
            get { return _systemID; }
            set { _systemID = value; }
        }

        private Nullable<Int32> _pOIID;

        /// <summary>
        /// A property representation of the POIID field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> POIID
        {
            get { return _pOIID; }
            set { _pOIID = value; }
        }

        private Nullable<Int32> _programID;

        /// <summary>
        /// A property representation of the ProgramID field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ProgramID
        {
            get { return _programID; }
            set { _programID = value; }
        }

        private Nullable<Int32> _courseTypeID;

        /// <summary>
        /// A property representation of the CourseTypeID field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseTypeID
        {
            get { return _courseTypeID; }
            set { _courseTypeID = value; }
        }

        private Nullable<Int16> _classInterval;

        /// <summary>
        /// A property representation of the ClassInterval field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> ClassInterval
        {
            get { return _classInterval; }
            set { _classInterval = value; }
        }

        private Nullable<Int16> _maxClassSize;

        /// <summary>
        /// A property representation of the MaxClassSize field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> MaxClassSize
        {
            get { return _maxClassSize; }
            set { _maxClassSize = value; }
        }

        private Nullable<Int16> _minClassSize;

        /// <summary>
        /// A property representation of the MinClassSize field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> MinClassSize
        {
            get { return _minClassSize; }
            set { _minClassSize = value; }
        }

        private Nullable<Int16> _optimumClassSize;

        /// <summary>
        /// A property representation of the OptimumClassSize field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> OptimumClassSize
        {
            get { return _optimumClassSize; }
            set { _optimumClassSize = value; }
        }

        private Nullable<DateTime> _createDate;

        /// <summary>
        /// A property representation of the CreateDate field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        private Nullable<Boolean> _reportNoFlyDay;

        /// <summary>
        /// A property representation of the ReportNoFlyDay field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> ReportNoFlyDay
        {
            get { return _reportNoFlyDay; }
            set { _reportNoFlyDay = value; }
        }

        private Nullable<Boolean> _trainNoFlyDay;

        /// <summary>
        /// A property representation of the TrainNoFlyDay field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> TrainNoFlyDay
        {
            get { return _trainNoFlyDay; }
            set { _trainNoFlyDay = value; }
        }

        private Nullable<Int32> _previousCourseID;

        /// <summary>
        /// A property representation of the PreviousCourseID field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> PreviousCourseID
        {
            get { return _previousCourseID; }
            set { _previousCourseID = value; }
        }

    }

    [Serializable]
    public class CourseSearch : EntitySearchBase
    {
        internal CourseSearch() { }

        private String _courseNameContains;

        /// <summary>
        /// A search property representation of the CourseNameContains field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String CourseNameContains
        {
            get { return _courseNameContains; }
            set { _courseNameContains = value; }
        }

        private IList<String> _courseNameIsIn;

        /// <summary>
        /// A search property representation of the CourseNameIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> CourseNameIsIn
        {
            get
            {
                if (_courseNameIsIn == null)
                {
                    _courseNameIsIn = new List<String>();
                }
                return _courseNameIsIn;
            }
            set { _courseNameIsIn = value; }
        }

        private Nullable<Int32> _courseNumberIDMinRange;

        /// <summary>
        /// A search property representation of the CourseNumberIDMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseNumberIDMinRange
        {
            get { return _courseNumberIDMinRange; }
            set { _courseNumberIDMinRange = value; }
        }

        private Nullable<Int32> _courseNumberIDMaxRange;

        /// <summary>
        /// A search property representation of the CourseNumberIDMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseNumberIDMaxRange
        {
            get { return _courseNumberIDMaxRange; }
            set { _courseNumberIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _courseNumberIDIsIn;

        /// <summary>
        /// A search property representation of the CourseNumberIDIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> CourseNumberIDIsIn
        {
            get
            {
                if (_courseNumberIDIsIn == null)
                {
                    _courseNumberIDIsIn = new List<Nullable<Int32>>();
                }
                return _courseNumberIDIsIn;
            }
            set { _courseNumberIDIsIn = value; }
        }

        private String _prefixContains;

        /// <summary>
        /// A search property representation of the PrefixContains field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String PrefixContains
        {
            get { return _prefixContains; }
            set { _prefixContains = value; }
        }

        private IList<String> _prefixIsIn;

        /// <summary>
        /// A search property representation of the PrefixIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> PrefixIsIn
        {
            get
            {
                if (_prefixIsIn == null)
                {
                    _prefixIsIn = new List<String>();
                }
                return _prefixIsIn;
            }
            set { _prefixIsIn = value; }
        }

        private String _phaseContains;

        /// <summary>
        /// A search property representation of the PhaseContains field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String PhaseContains
        {
            get { return _phaseContains; }
            set { _phaseContains = value; }
        }

        private IList<String> _phaseIsIn;

        /// <summary>
        /// A search property representation of the PhaseIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> PhaseIsIn
        {
            get
            {
                if (_phaseIsIn == null)
                {
                    _phaseIsIn = new List<String>();
                }
                return _phaseIsIn;
            }
            set { _phaseIsIn = value; }
        }

        private Nullable<Int32> _courseLevelIDMinRange;

        /// <summary>
        /// A search property representation of the CourseLevelIDMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseLevelIDMinRange
        {
            get { return _courseLevelIDMinRange; }
            set { _courseLevelIDMinRange = value; }
        }

        private Nullable<Int32> _courseLevelIDMaxRange;

        /// <summary>
        /// A search property representation of the CourseLevelIDMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseLevelIDMaxRange
        {
            get { return _courseLevelIDMaxRange; }
            set { _courseLevelIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _courseLevelIDIsIn;

        /// <summary>
        /// A search property representation of the CourseLevelIDIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> CourseLevelIDIsIn
        {
            get
            {
                if (_courseLevelIDIsIn == null)
                {
                    _courseLevelIDIsIn = new List<Nullable<Int32>>();
                }
                return _courseLevelIDIsIn;
            }
            set { _courseLevelIDIsIn = value; }
        }

        private Nullable<Int32> _systemIDMinRange;

        /// <summary>
        /// A search property representation of the SystemIDMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> SystemIDMinRange
        {
            get { return _systemIDMinRange; }
            set { _systemIDMinRange = value; }
        }

        private Nullable<Int32> _systemIDMaxRange;

        /// <summary>
        /// A search property representation of the SystemIDMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> SystemIDMaxRange
        {
            get { return _systemIDMaxRange; }
            set { _systemIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _systemIDIsIn;

        /// <summary>
        /// A search property representation of the SystemIDIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> SystemIDIsIn
        {
            get
            {
                if (_systemIDIsIn == null)
                {
                    _systemIDIsIn = new List<Nullable<Int32>>();
                }
                return _systemIDIsIn;
            }
            set { _systemIDIsIn = value; }
        }

        private Nullable<Int32> _pOIIDMinRange;

        /// <summary>
        /// A search property representation of the POIIDMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> POIIDMinRange
        {
            get { return _pOIIDMinRange; }
            set { _pOIIDMinRange = value; }
        }

        private Nullable<Int32> _pOIIDMaxRange;

        /// <summary>
        /// A search property representation of the POIIDMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> POIIDMaxRange
        {
            get { return _pOIIDMaxRange; }
            set { _pOIIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _pOIIDIsIn;

        /// <summary>
        /// A search property representation of the POIIDIsIn field for a record in the dbo.Course data table. 
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

        private Nullable<Int32> _programIDMinRange;

        /// <summary>
        /// A search property representation of the ProgramIDMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ProgramIDMinRange
        {
            get { return _programIDMinRange; }
            set { _programIDMinRange = value; }
        }

        private Nullable<Int32> _programIDMaxRange;

        /// <summary>
        /// A search property representation of the ProgramIDMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ProgramIDMaxRange
        {
            get { return _programIDMaxRange; }
            set { _programIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _programIDIsIn;

        /// <summary>
        /// A search property representation of the ProgramIDIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> ProgramIDIsIn
        {
            get
            {
                if (_programIDIsIn == null)
                {
                    _programIDIsIn = new List<Nullable<Int32>>();
                }
                return _programIDIsIn;
            }
            set { _programIDIsIn = value; }
        }

        private Nullable<Int32> _courseTypeIDMinRange;

        /// <summary>
        /// A search property representation of the CourseTypeIDMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseTypeIDMinRange
        {
            get { return _courseTypeIDMinRange; }
            set { _courseTypeIDMinRange = value; }
        }

        private Nullable<Int32> _courseTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the CourseTypeIDMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseTypeIDMaxRange
        {
            get { return _courseTypeIDMaxRange; }
            set { _courseTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _courseTypeIDIsIn;

        /// <summary>
        /// A search property representation of the CourseTypeIDIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> CourseTypeIDIsIn
        {
            get
            {
                if (_courseTypeIDIsIn == null)
                {
                    _courseTypeIDIsIn = new List<Nullable<Int32>>();
                }
                return _courseTypeIDIsIn;
            }
            set { _courseTypeIDIsIn = value; }
        }

        private Nullable<Int16> _classIntervalMinRange;

        /// <summary>
        /// A search property representation of the ClassIntervalMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> ClassIntervalMinRange
        {
            get { return _classIntervalMinRange; }
            set { _classIntervalMinRange = value; }
        }

        private Nullable<Int16> _classIntervalMaxRange;

        /// <summary>
        /// A search property representation of the ClassIntervalMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> ClassIntervalMaxRange
        {
            get { return _classIntervalMaxRange; }
            set { _classIntervalMaxRange = value; }
        }

        private IList<Nullable<Int16>> _classIntervalIsIn;

        /// <summary>
        /// A search property representation of the ClassIntervalIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> ClassIntervalIsIn
        {
            get
            {
                if (_classIntervalIsIn == null)
                {
                    _classIntervalIsIn = new List<Nullable<Int16>>();
                }
                return _classIntervalIsIn;
            }
            set { _classIntervalIsIn = value; }
        }

        private Nullable<Int16> _maxClassSizeMinRange;

        /// <summary>
        /// A search property representation of the MaxClassSizeMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> MaxClassSizeMinRange
        {
            get { return _maxClassSizeMinRange; }
            set { _maxClassSizeMinRange = value; }
        }

        private Nullable<Int16> _maxClassSizeMaxRange;

        /// <summary>
        /// A search property representation of the MaxClassSizeMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> MaxClassSizeMaxRange
        {
            get { return _maxClassSizeMaxRange; }
            set { _maxClassSizeMaxRange = value; }
        }

        private IList<Nullable<Int16>> _maxClassSizeIsIn;

        /// <summary>
        /// A search property representation of the MaxClassSizeIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> MaxClassSizeIsIn
        {
            get
            {
                if (_maxClassSizeIsIn == null)
                {
                    _maxClassSizeIsIn = new List<Nullable<Int16>>();
                }
                return _maxClassSizeIsIn;
            }
            set { _maxClassSizeIsIn = value; }
        }

        private Nullable<Int16> _minClassSizeMinRange;

        /// <summary>
        /// A search property representation of the MinClassSizeMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> MinClassSizeMinRange
        {
            get { return _minClassSizeMinRange; }
            set { _minClassSizeMinRange = value; }
        }

        private Nullable<Int16> _minClassSizeMaxRange;

        /// <summary>
        /// A search property representation of the MinClassSizeMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> MinClassSizeMaxRange
        {
            get { return _minClassSizeMaxRange; }
            set { _minClassSizeMaxRange = value; }
        }

        private IList<Nullable<Int16>> _minClassSizeIsIn;

        /// <summary>
        /// A search property representation of the MinClassSizeIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> MinClassSizeIsIn
        {
            get
            {
                if (_minClassSizeIsIn == null)
                {
                    _minClassSizeIsIn = new List<Nullable<Int16>>();
                }
                return _minClassSizeIsIn;
            }
            set { _minClassSizeIsIn = value; }
        }

        private Nullable<Int16> _optimumClassSizeMinRange;

        /// <summary>
        /// A search property representation of the OptimumClassSizeMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> OptimumClassSizeMinRange
        {
            get { return _optimumClassSizeMinRange; }
            set { _optimumClassSizeMinRange = value; }
        }

        private Nullable<Int16> _optimumClassSizeMaxRange;

        /// <summary>
        /// A search property representation of the OptimumClassSizeMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> OptimumClassSizeMaxRange
        {
            get { return _optimumClassSizeMaxRange; }
            set { _optimumClassSizeMaxRange = value; }
        }

        private IList<Nullable<Int16>> _optimumClassSizeIsIn;

        /// <summary>
        /// A search property representation of the OptimumClassSizeIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> OptimumClassSizeIsIn
        {
            get
            {
                if (_optimumClassSizeIsIn == null)
                {
                    _optimumClassSizeIsIn = new List<Nullable<Int16>>();
                }
                return _optimumClassSizeIsIn;
            }
            set { _optimumClassSizeIsIn = value; }
        }

        private Nullable<DateTime> _createDateMinRange;

        /// <summary>
        /// A search property representation of the CreateDateMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> CreateDateMinRange
        {
            get { return _createDateMinRange; }
            set { _createDateMinRange = value; }
        }

        private Nullable<DateTime> _createDateMaxRange;

        /// <summary>
        /// A search property representation of the CreateDateMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> CreateDateMaxRange
        {
            get { return _createDateMaxRange; }
            set { _createDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _createDateIsIn;

        /// <summary>
        /// A search property representation of the CreateDateIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> CreateDateIsIn
        {
            get
            {
                if (_createDateIsIn == null)
                {
                    _createDateIsIn = new List<Nullable<DateTime>>();
                }
                return _createDateIsIn;
            }
            set { _createDateIsIn = value; }
        }

        private Nullable<Int32> _previousCourseIDMinRange;

        /// <summary>
        /// A search property representation of the PreviousCourseIDMinRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> PreviousCourseIDMinRange
        {
            get { return _previousCourseIDMinRange; }
            set { _previousCourseIDMinRange = value; }
        }

        private Nullable<Int32> _previousCourseIDMaxRange;

        /// <summary>
        /// A search property representation of the PreviousCourseIDMaxRange field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> PreviousCourseIDMaxRange
        {
            get { return _previousCourseIDMaxRange; }
            set { _previousCourseIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _previousCourseIDIsIn;

        /// <summary>
        /// A search property representation of the PreviousCourseIDIsIn field for a record in the dbo.Course data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> PreviousCourseIDIsIn
        {
            get
            {
                if (_previousCourseIDIsIn == null)
                {
                    _previousCourseIDIsIn = new List<Nullable<Int32>>();
                }
                return _previousCourseIDIsIn;
            }
            set { _previousCourseIDIsIn = value; }
        }

    }

    [Serializable]
    public partial class CourseExtended : EntityExtendedBase
    {
        internal CourseExtended() { }
    }
}