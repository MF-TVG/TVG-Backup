using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.POIFlightDay data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class POIFlightDay : EntityBase
    {
        private POIFlightDaySearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public POIFlightDaySearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new POIFlightDaySearch();
                }

                return _searchProperties;
            }
        }

        private POIFlightDayExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public POIFlightDayExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new POIFlightDayExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _pOIFlightDayID;

        /// <summary>
        /// A property representation of the POIFlightDayID field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> POIFlightDayID
        {
            get { return _pOIFlightDayID; }
            set { _pOIFlightDayID = value; }
        }

        private Nullable<Int32> _pOIID;

        /// <summary>
        /// A property representation of the POIID field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> POIID
        {
            get { return _pOIID; }
            set { _pOIID = value; }
        }

        private Nullable<Int32> _objectiveID;

        /// <summary>
        /// A property representation of the ObjectiveID field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> ObjectiveID
        {
            get { return _objectiveID; }
            set { _objectiveID = value; }
        }

        private Nullable<Int16> _flightDayNumber;

        /// <summary>
        /// A property representation of the FlightDayNumber field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> FlightDayNumber
        {
            get { return _flightDayNumber; }
            set { _flightDayNumber = value; }
        }

        private Nullable<Decimal> _units;

        /// <summary>
        /// A property representation of the Units field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 2)]
        public Nullable<Decimal> Units
        {
            get { return _units; }
            set { _units = value; }
        }

        private Nullable<Boolean> _evaluation;

        /// <summary>
        /// A property representation of the Evaluation field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Evaluation
        {
            get { return _evaluation; }
            set { _evaluation = value; }
        }

    }

    [Serializable]
    public class POIFlightDaySearch : EntitySearchBase
    {
        internal POIFlightDaySearch() { }

        private Nullable<Int32> _pOIIDMinRange;

        /// <summary>
        /// A search property representation of the POIIDMinRange field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> POIIDMinRange
        {
            get { return _pOIIDMinRange; }
            set { _pOIIDMinRange = value; }
        }

        private Nullable<Int32> _pOIIDMaxRange;

        /// <summary>
        /// A search property representation of the POIIDMaxRange field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> POIIDMaxRange
        {
            get { return _pOIIDMaxRange; }
            set { _pOIIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _pOIIDIsIn;

        /// <summary>
        /// A search property representation of the POIIDIsIn field for a record in the dbo.POIFlightDay data table. 
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

        private Nullable<Int32> _objectiveIDMinRange;

        /// <summary>
        /// A search property representation of the ObjectiveIDMinRange field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ObjectiveIDMinRange
        {
            get { return _objectiveIDMinRange; }
            set { _objectiveIDMinRange = value; }
        }

        private Nullable<Int32> _objectiveIDMaxRange;

        /// <summary>
        /// A search property representation of the ObjectiveIDMaxRange field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> ObjectiveIDMaxRange
        {
            get { return _objectiveIDMaxRange; }
            set { _objectiveIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _objectiveIDIsIn;

        /// <summary>
        /// A search property representation of the ObjectiveIDIsIn field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> ObjectiveIDIsIn
        {
            get
            {
                if (_objectiveIDIsIn == null)
                {
                    _objectiveIDIsIn = new List<Nullable<Int32>>();
                }
                return _objectiveIDIsIn;
            }
            set { _objectiveIDIsIn = value; }
        }

        private Nullable<Int16> _flightDayNumberMinRange;

        /// <summary>
        /// A search property representation of the FlightDayNumberMinRange field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> FlightDayNumberMinRange
        {
            get { return _flightDayNumberMinRange; }
            set { _flightDayNumberMinRange = value; }
        }

        private Nullable<Int16> _flightDayNumberMaxRange;

        /// <summary>
        /// A search property representation of the FlightDayNumberMaxRange field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> FlightDayNumberMaxRange
        {
            get { return _flightDayNumberMaxRange; }
            set { _flightDayNumberMaxRange = value; }
        }

        private IList<Nullable<Int16>> _flightDayNumberIsIn;

        /// <summary>
        /// A search property representation of the FlightDayNumberIsIn field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> FlightDayNumberIsIn
        {
            get
            {
                if (_flightDayNumberIsIn == null)
                {
                    _flightDayNumberIsIn = new List<Nullable<Int16>>();
                }
                return _flightDayNumberIsIn;
            }
            set { _flightDayNumberIsIn = value; }
        }

        private Nullable<Decimal> _unitsMinRange;

        /// <summary>
        /// A search property representation of the UnitsMinRange field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 2, SearchOnly = true)]
        public Nullable<Decimal> UnitsMinRange
        {
            get { return _unitsMinRange; }
            set { _unitsMinRange = value; }
        }

        private Nullable<Decimal> _unitsMaxRange;

        /// <summary>
        /// A search property representation of the UnitsMaxRange field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 2, SearchOnly = true)]
        public Nullable<Decimal> UnitsMaxRange
        {
            get { return _unitsMaxRange; }
            set { _unitsMaxRange = value; }
        }

        private IList<Nullable<Decimal>> _unitsIsIn;

        /// <summary>
        /// A search property representation of the UnitsIsIn field for a record in the dbo.POIFlightDay data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 2, SearchOnly = true)]
        public IList<Nullable<Decimal>> UnitsIsIn
        {
            get
            {
                if (_unitsIsIn == null)
                {
                    _unitsIsIn = new List<Nullable<Decimal>>();
                }
                return _unitsIsIn;
            }
            set { _unitsIsIn = value; }
        }

    }

    [Serializable]
    public partial class POIFlightDayExtended : EntityExtendedBase
    {
        internal POIFlightDayExtended() { }
    }
}