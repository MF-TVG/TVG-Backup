using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.NoFlyDay data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class NoFlyDay : EntityBase
    {
        private NoFlyDaySearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public NoFlyDaySearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new NoFlyDaySearch();
                }

                return _searchProperties;
            }
        }

        private NoFlyDayExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public NoFlyDayExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new NoFlyDayExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _noFlyDayID;

        /// <summary>
        /// A property representation of the NoFlyDayID field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> NoFlyDayID
        {
            get { return _noFlyDayID; }
            set { _noFlyDayID = value; }
        }

        private String _noFlyDayName;

        /// <summary>
        /// A property representation of the NoFlyDayName field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String NoFlyDayName
        {
            get { return _noFlyDayName; }
            set { _noFlyDayName = value; }
        }

        private Nullable<Int32> _noFlyTypeID;

        /// <summary>
        /// A property representation of the NoFlyTypeID field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> NoFlyTypeID
        {
            get { return _noFlyTypeID; }
            set { _noFlyTypeID = value; }
        }

        private Nullable<Byte> _startDateMonth;

        /// <summary>
        /// A property representation of the StartDateMonth field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0)]
        public Nullable<Byte> StartDateMonth
        {
            get { return _startDateMonth; }
            set { _startDateMonth = value; }
        }

        private Nullable<Byte> _startDateDay;

        /// <summary>
        /// A property representation of the StartDateDay field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0)]
        public Nullable<Byte> StartDateDay
        {
            get { return _startDateDay; }
            set { _startDateDay = value; }
        }

        private Nullable<Byte> _endDateMonth;

        /// <summary>
        /// A property representation of the EndDateMonth field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0)]
        public Nullable<Byte> EndDateMonth
        {
            get { return _endDateMonth; }
            set { _endDateMonth = value; }
        }

        private Nullable<Byte> _endDateDay;

        /// <summary>
        /// A property representation of the EndDateDay field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0)]
        public Nullable<Byte> EndDateDay
        {
            get { return _endDateDay; }
            set { _endDateDay = value; }
        }

        private Nullable<Byte> _weekDay;

        /// <summary>
        /// A property representation of the WeekDay field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0)]
        public Nullable<Byte> WeekDay
        {
            get { return _weekDay; }
            set { _weekDay = value; }
        }

        private Nullable<Byte> _weekCount;

        /// <summary>
        /// A property representation of the WeekCount field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0)]
        public Nullable<Byte> WeekCount
        {
            get { return _weekCount; }
            set { _weekCount = value; }
        }

        private Nullable<Byte> _weekMonth;

        /// <summary>
        /// A property representation of the WeekMonth field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0)]
        public Nullable<Byte> WeekMonth
        {
            get { return _weekMonth; }
            set { _weekMonth = value; }
        }

        private Nullable<Boolean> _mobilizationExempt;

        /// <summary>
        /// A property representation of the MobilizationExempt field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> MobilizationExempt
        {
            get { return _mobilizationExempt; }
            set { _mobilizationExempt = value; }
        }

    }

    [Serializable]
    public class NoFlyDaySearch : EntitySearchBase
    {
        internal NoFlyDaySearch() { }

        private String _noFlyDayNameContains;

        /// <summary>
        /// A search property representation of the NoFlyDayNameContains field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String NoFlyDayNameContains
        {
            get { return _noFlyDayNameContains; }
            set { _noFlyDayNameContains = value; }
        }

        private IList<String> _noFlyDayNameIsIn;

        /// <summary>
        /// A search property representation of the NoFlyDayNameIsIn field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> NoFlyDayNameIsIn
        {
            get
            {
                if (_noFlyDayNameIsIn == null)
                {
                    _noFlyDayNameIsIn = new List<String>();
                }
                return _noFlyDayNameIsIn;
            }
            set { _noFlyDayNameIsIn = value; }
        }

        private Nullable<Int32> _noFlyTypeIDMinRange;

        /// <summary>
        /// A search property representation of the NoFlyTypeIDMinRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> NoFlyTypeIDMinRange
        {
            get { return _noFlyTypeIDMinRange; }
            set { _noFlyTypeIDMinRange = value; }
        }

        private Nullable<Int32> _noFlyTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the NoFlyTypeIDMaxRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> NoFlyTypeIDMaxRange
        {
            get { return _noFlyTypeIDMaxRange; }
            set { _noFlyTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _noFlyTypeIDIsIn;

        /// <summary>
        /// A search property representation of the NoFlyTypeIDIsIn field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> NoFlyTypeIDIsIn
        {
            get
            {
                if (_noFlyTypeIDIsIn == null)
                {
                    _noFlyTypeIDIsIn = new List<Nullable<Int32>>();
                }
                return _noFlyTypeIDIsIn;
            }
            set { _noFlyTypeIDIsIn = value; }
        }

        private Nullable<Byte> _startDateMonthMinRange;

        /// <summary>
        /// A search property representation of the StartDateMonthMinRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> StartDateMonthMinRange
        {
            get { return _startDateMonthMinRange; }
            set { _startDateMonthMinRange = value; }
        }

        private Nullable<Byte> _startDateMonthMaxRange;

        /// <summary>
        /// A search property representation of the StartDateMonthMaxRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> StartDateMonthMaxRange
        {
            get { return _startDateMonthMaxRange; }
            set { _startDateMonthMaxRange = value; }
        }

        private IList<Nullable<Byte>> _startDateMonthIsIn;

        /// <summary>
        /// A search property representation of the StartDateMonthIsIn field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Byte>> StartDateMonthIsIn
        {
            get
            {
                if (_startDateMonthIsIn == null)
                {
                    _startDateMonthIsIn = new List<Nullable<Byte>>();
                }
                return _startDateMonthIsIn;
            }
            set { _startDateMonthIsIn = value; }
        }

        private Nullable<Byte> _startDateDayMinRange;

        /// <summary>
        /// A search property representation of the StartDateDayMinRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> StartDateDayMinRange
        {
            get { return _startDateDayMinRange; }
            set { _startDateDayMinRange = value; }
        }

        private Nullable<Byte> _startDateDayMaxRange;

        /// <summary>
        /// A search property representation of the StartDateDayMaxRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> StartDateDayMaxRange
        {
            get { return _startDateDayMaxRange; }
            set { _startDateDayMaxRange = value; }
        }

        private IList<Nullable<Byte>> _startDateDayIsIn;

        /// <summary>
        /// A search property representation of the StartDateDayIsIn field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Byte>> StartDateDayIsIn
        {
            get
            {
                if (_startDateDayIsIn == null)
                {
                    _startDateDayIsIn = new List<Nullable<Byte>>();
                }
                return _startDateDayIsIn;
            }
            set { _startDateDayIsIn = value; }
        }

        private Nullable<Byte> _endDateMonthMinRange;

        /// <summary>
        /// A search property representation of the EndDateMonthMinRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> EndDateMonthMinRange
        {
            get { return _endDateMonthMinRange; }
            set { _endDateMonthMinRange = value; }
        }

        private Nullable<Byte> _endDateMonthMaxRange;

        /// <summary>
        /// A search property representation of the EndDateMonthMaxRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> EndDateMonthMaxRange
        {
            get { return _endDateMonthMaxRange; }
            set { _endDateMonthMaxRange = value; }
        }

        private IList<Nullable<Byte>> _endDateMonthIsIn;

        /// <summary>
        /// A search property representation of the EndDateMonthIsIn field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Byte>> EndDateMonthIsIn
        {
            get
            {
                if (_endDateMonthIsIn == null)
                {
                    _endDateMonthIsIn = new List<Nullable<Byte>>();
                }
                return _endDateMonthIsIn;
            }
            set { _endDateMonthIsIn = value; }
        }

        private Nullable<Byte> _endDateDayMinRange;

        /// <summary>
        /// A search property representation of the EndDateDayMinRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> EndDateDayMinRange
        {
            get { return _endDateDayMinRange; }
            set { _endDateDayMinRange = value; }
        }

        private Nullable<Byte> _endDateDayMaxRange;

        /// <summary>
        /// A search property representation of the EndDateDayMaxRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> EndDateDayMaxRange
        {
            get { return _endDateDayMaxRange; }
            set { _endDateDayMaxRange = value; }
        }

        private IList<Nullable<Byte>> _endDateDayIsIn;

        /// <summary>
        /// A search property representation of the EndDateDayIsIn field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Byte>> EndDateDayIsIn
        {
            get
            {
                if (_endDateDayIsIn == null)
                {
                    _endDateDayIsIn = new List<Nullable<Byte>>();
                }
                return _endDateDayIsIn;
            }
            set { _endDateDayIsIn = value; }
        }

        private Nullable<Byte> _weekDayMinRange;

        /// <summary>
        /// A search property representation of the WeekDayMinRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> WeekDayMinRange
        {
            get { return _weekDayMinRange; }
            set { _weekDayMinRange = value; }
        }

        private Nullable<Byte> _weekDayMaxRange;

        /// <summary>
        /// A search property representation of the WeekDayMaxRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> WeekDayMaxRange
        {
            get { return _weekDayMaxRange; }
            set { _weekDayMaxRange = value; }
        }

        private IList<Nullable<Byte>> _weekDayIsIn;

        /// <summary>
        /// A search property representation of the WeekDayIsIn field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Byte>> WeekDayIsIn
        {
            get
            {
                if (_weekDayIsIn == null)
                {
                    _weekDayIsIn = new List<Nullable<Byte>>();
                }
                return _weekDayIsIn;
            }
            set { _weekDayIsIn = value; }
        }

        private Nullable<Byte> _weekCountMinRange;

        /// <summary>
        /// A search property representation of the WeekCountMinRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> WeekCountMinRange
        {
            get { return _weekCountMinRange; }
            set { _weekCountMinRange = value; }
        }

        private Nullable<Byte> _weekCountMaxRange;

        /// <summary>
        /// A search property representation of the WeekCountMaxRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> WeekCountMaxRange
        {
            get { return _weekCountMaxRange; }
            set { _weekCountMaxRange = value; }
        }

        private IList<Nullable<Byte>> _weekCountIsIn;

        /// <summary>
        /// A search property representation of the WeekCountIsIn field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Byte>> WeekCountIsIn
        {
            get
            {
                if (_weekCountIsIn == null)
                {
                    _weekCountIsIn = new List<Nullable<Byte>>();
                }
                return _weekCountIsIn;
            }
            set { _weekCountIsIn = value; }
        }

        private Nullable<Byte> _weekMonthMinRange;

        /// <summary>
        /// A search property representation of the WeekMonthMinRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> WeekMonthMinRange
        {
            get { return _weekMonthMinRange; }
            set { _weekMonthMinRange = value; }
        }

        private Nullable<Byte> _weekMonthMaxRange;

        /// <summary>
        /// A search property representation of the WeekMonthMaxRange field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public Nullable<Byte> WeekMonthMaxRange
        {
            get { return _weekMonthMaxRange; }
            set { _weekMonthMaxRange = value; }
        }

        private IList<Nullable<Byte>> _weekMonthIsIn;

        /// <summary>
        /// A search property representation of the WeekMonthIsIn field for a record in the dbo.NoFlyDay data table. 
        /// </summary>
        [EntityProperty(Precision = 3, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Byte>> WeekMonthIsIn
        {
            get
            {
                if (_weekMonthIsIn == null)
                {
                    _weekMonthIsIn = new List<Nullable<Byte>>();
                }
                return _weekMonthIsIn;
            }
            set { _weekMonthIsIn = value; }
        }

    }

    [Serializable]
    public partial class NoFlyDayExtended : EntityExtendedBase
    {
        internal NoFlyDayExtended() { }
    }
}