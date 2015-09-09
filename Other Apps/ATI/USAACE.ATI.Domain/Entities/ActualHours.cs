using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.ActualHours data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class ActualHours : EntityBase
    {
        private ActualHoursSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public ActualHoursSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new ActualHoursSearch();
                }

                return _searchProperties;
            }
        }

        private ActualHoursExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public ActualHoursExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new ActualHoursExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _actualHoursID;

        /// <summary>
        /// A property representation of the ActualHoursID field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> ActualHoursID
        {
            get { return _actualHoursID; }
            set { _actualHoursID = value; }
        }

        private Nullable<Int32> _programID;

        /// <summary>
        /// A property representation of the ProgramID field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ProgramID
        {
            get { return _programID; }
            set { _programID = value; }
        }

        private Nullable<Int32> _courseID;

        /// <summary>
        /// A property representation of the CourseID field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseID
        {
            get { return _courseID; }
            set { _courseID = value; }
        }

        private Nullable<Int32> _courseLevelID;

        /// <summary>
        /// A property representation of the CourseLevelID field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseLevelID
        {
            get { return _courseLevelID; }
            set { _courseLevelID = value; }
        }

        private Nullable<Int32> _systemID;

        /// <summary>
        /// A property representation of the SystemID field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> SystemID
        {
            get { return _systemID; }
            set { _systemID = value; }
        }

        private Nullable<Int32> _miscHoursID;

        /// <summary>
        /// A property representation of the MiscHoursID field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> MiscHoursID
        {
            get { return _miscHoursID; }
            set { _miscHoursID = value; }
        }

        private Nullable<Int32> _hoursTypeID;

        /// <summary>
        /// A property representation of the HoursTypeID field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> HoursTypeID
        {
            get { return _hoursTypeID; }
            set { _hoursTypeID = value; }
        }

        private Nullable<Decimal> _hoursAmount;

        /// <summary>
        /// A property representation of the HoursAmount field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 18, Scale = 1)]
        public Nullable<Decimal> HoursAmount
        {
            get { return _hoursAmount; }
            set { _hoursAmount = value; }
        }

        private Nullable<Boolean> _reimbursable;

        /// <summary>
        /// A property representation of the Reimbursable field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Reimbursable
        {
            get { return _reimbursable; }
            set { _reimbursable = value; }
        }

        private Nullable<Boolean> _forecast;

        /// <summary>
        /// A property representation of the Forecast field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Forecast
        {
            get { return _forecast; }
            set { _forecast = value; }
        }

        private Nullable<DateTime> _cutoffDate;

        /// <summary>
        /// A property representation of the CutoffDate field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> CutoffDate
        {
            get { return _cutoffDate; }
            set { _cutoffDate = value; }
        }

    }

    [Serializable]
    public class ActualHoursSearch : EntitySearchBase
    {
        internal ActualHoursSearch() { }

        private Nullable<Int32> _programIDMinRange;

        /// <summary>
        /// A search property representation of the ProgramIDMinRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ProgramIDMinRange
        {
            get { return _programIDMinRange; }
            set { _programIDMinRange = value; }
        }

        private Nullable<Int32> _programIDMaxRange;

        /// <summary>
        /// A search property representation of the ProgramIDMaxRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ProgramIDMaxRange
        {
            get { return _programIDMaxRange; }
            set { _programIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _programIDIsIn;

        /// <summary>
        /// A search property representation of the ProgramIDIsIn field for a record in the dbo.ActualHours data table. 
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

        private Nullable<Int32> _courseIDMinRange;

        /// <summary>
        /// A search property representation of the CourseIDMinRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseIDMinRange
        {
            get { return _courseIDMinRange; }
            set { _courseIDMinRange = value; }
        }

        private Nullable<Int32> _courseIDMaxRange;

        /// <summary>
        /// A search property representation of the CourseIDMaxRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseIDMaxRange
        {
            get { return _courseIDMaxRange; }
            set { _courseIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _courseIDIsIn;

        /// <summary>
        /// A search property representation of the CourseIDIsIn field for a record in the dbo.ActualHours data table. 
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

        private Nullable<Int32> _courseLevelIDMinRange;

        /// <summary>
        /// A search property representation of the CourseLevelIDMinRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseLevelIDMinRange
        {
            get { return _courseLevelIDMinRange; }
            set { _courseLevelIDMinRange = value; }
        }

        private Nullable<Int32> _courseLevelIDMaxRange;

        /// <summary>
        /// A search property representation of the CourseLevelIDMaxRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> CourseLevelIDMaxRange
        {
            get { return _courseLevelIDMaxRange; }
            set { _courseLevelIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _courseLevelIDIsIn;

        /// <summary>
        /// A search property representation of the CourseLevelIDIsIn field for a record in the dbo.ActualHours data table. 
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
        /// A search property representation of the SystemIDMinRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> SystemIDMinRange
        {
            get { return _systemIDMinRange; }
            set { _systemIDMinRange = value; }
        }

        private Nullable<Int32> _systemIDMaxRange;

        /// <summary>
        /// A search property representation of the SystemIDMaxRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> SystemIDMaxRange
        {
            get { return _systemIDMaxRange; }
            set { _systemIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _systemIDIsIn;

        /// <summary>
        /// A search property representation of the SystemIDIsIn field for a record in the dbo.ActualHours data table. 
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

        private Nullable<Int32> _miscHoursIDMinRange;

        /// <summary>
        /// A search property representation of the MiscHoursIDMinRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> MiscHoursIDMinRange
        {
            get { return _miscHoursIDMinRange; }
            set { _miscHoursIDMinRange = value; }
        }

        private Nullable<Int32> _miscHoursIDMaxRange;

        /// <summary>
        /// A search property representation of the MiscHoursIDMaxRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> MiscHoursIDMaxRange
        {
            get { return _miscHoursIDMaxRange; }
            set { _miscHoursIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _miscHoursIDIsIn;

        /// <summary>
        /// A search property representation of the MiscHoursIDIsIn field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> MiscHoursIDIsIn
        {
            get
            {
                if (_miscHoursIDIsIn == null)
                {
                    _miscHoursIDIsIn = new List<Nullable<Int32>>();
                }
                return _miscHoursIDIsIn;
            }
            set { _miscHoursIDIsIn = value; }
        }

        private Nullable<Int32> _hoursTypeIDMinRange;

        /// <summary>
        /// A search property representation of the HoursTypeIDMinRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> HoursTypeIDMinRange
        {
            get { return _hoursTypeIDMinRange; }
            set { _hoursTypeIDMinRange = value; }
        }

        private Nullable<Int32> _hoursTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the HoursTypeIDMaxRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> HoursTypeIDMaxRange
        {
            get { return _hoursTypeIDMaxRange; }
            set { _hoursTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _hoursTypeIDIsIn;

        /// <summary>
        /// A search property representation of the HoursTypeIDIsIn field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> HoursTypeIDIsIn
        {
            get
            {
                if (_hoursTypeIDIsIn == null)
                {
                    _hoursTypeIDIsIn = new List<Nullable<Int32>>();
                }
                return _hoursTypeIDIsIn;
            }
            set { _hoursTypeIDIsIn = value; }
        }

        private Nullable<Decimal> _hoursAmountMinRange;

        /// <summary>
        /// A search property representation of the HoursAmountMinRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 18, Scale = 1, SearchOnly = true)]
        public Nullable<Decimal> HoursAmountMinRange
        {
            get { return _hoursAmountMinRange; }
            set { _hoursAmountMinRange = value; }
        }

        private Nullable<Decimal> _hoursAmountMaxRange;

        /// <summary>
        /// A search property representation of the HoursAmountMaxRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 18, Scale = 1, SearchOnly = true)]
        public Nullable<Decimal> HoursAmountMaxRange
        {
            get { return _hoursAmountMaxRange; }
            set { _hoursAmountMaxRange = value; }
        }

        private IList<Nullable<Decimal>> _hoursAmountIsIn;

        /// <summary>
        /// A search property representation of the HoursAmountIsIn field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(Precision = 18, Scale = 1, SearchOnly = true)]
        public IList<Nullable<Decimal>> HoursAmountIsIn
        {
            get
            {
                if (_hoursAmountIsIn == null)
                {
                    _hoursAmountIsIn = new List<Nullable<Decimal>>();
                }
                return _hoursAmountIsIn;
            }
            set { _hoursAmountIsIn = value; }
        }

        private Nullable<DateTime> _cutoffDateMinRange;

        /// <summary>
        /// A search property representation of the CutoffDateMinRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> CutoffDateMinRange
        {
            get { return _cutoffDateMinRange; }
            set { _cutoffDateMinRange = value; }
        }

        private Nullable<DateTime> _cutoffDateMaxRange;

        /// <summary>
        /// A search property representation of the CutoffDateMaxRange field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> CutoffDateMaxRange
        {
            get { return _cutoffDateMaxRange; }
            set { _cutoffDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _cutoffDateIsIn;

        /// <summary>
        /// A search property representation of the CutoffDateIsIn field for a record in the dbo.ActualHours data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> CutoffDateIsIn
        {
            get
            {
                if (_cutoffDateIsIn == null)
                {
                    _cutoffDateIsIn = new List<Nullable<DateTime>>();
                }
                return _cutoffDateIsIn;
            }
            set { _cutoffDateIsIn = value; }
        }

    }

    [Serializable]
    public partial class ActualHoursExtended : EntityExtendedBase
    {
        internal ActualHoursExtended() { }
    }
}