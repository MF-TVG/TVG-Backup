using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.Objective data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class Objective : EntityBase
    {
        private ObjectiveSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public ObjectiveSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new ObjectiveSearch();
                }

                return _searchProperties;
            }
        }

        private ObjectiveExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public ObjectiveExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new ObjectiveExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _objectiveID;

        /// <summary>
        /// A property representation of the ObjectiveID field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> ObjectiveID
        {
            get { return _objectiveID; }
            set { _objectiveID = value; }
        }

        private String _objectiveName;

        /// <summary>
        /// A property representation of the ObjectiveName field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String ObjectiveName
        {
            get { return _objectiveName; }
            set { _objectiveName = value; }
        }

        private Nullable<Boolean> _nightMission;

        /// <summary>
        /// A property representation of the NightMission field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> NightMission
        {
            get { return _nightMission; }
            set { _nightMission = value; }
        }

        private Nullable<Boolean> _flightHours;

        /// <summary>
        /// A property representation of the FlightHours field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> FlightHours
        {
            get { return _flightHours; }
            set { _flightHours = value; }
        }

        private Nullable<Boolean> _simulatorHours;

        /// <summary>
        /// A property representation of the SimulatorHours field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> SimulatorHours
        {
            get { return _simulatorHours; }
            set { _simulatorHours = value; }
        }

        private Nullable<Boolean> _ammunition;

        /// <summary>
        /// A property representation of the Ammunition field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Ammunition
        {
            get { return _ammunition; }
            set { _ammunition = value; }
        }

        private Nullable<Boolean> _contact;

        /// <summary>
        /// A property representation of the Contact field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        private String _color;

        /// <summary>
        /// A property representation of the Color field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty(Size = 6)]
        public String Color
        {
            get { return _color; }
            set { _color = value; }
        }

    }

    [Serializable]
    public class ObjectiveSearch : EntitySearchBase
    {
        internal ObjectiveSearch() { }

        private String _objectiveNameContains;

        /// <summary>
        /// A search property representation of the ObjectiveNameContains field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String ObjectiveNameContains
        {
            get { return _objectiveNameContains; }
            set { _objectiveNameContains = value; }
        }

        private IList<String> _objectiveNameIsIn;

        /// <summary>
        /// A search property representation of the ObjectiveNameIsIn field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> ObjectiveNameIsIn
        {
            get
            {
                if (_objectiveNameIsIn == null)
                {
                    _objectiveNameIsIn = new List<String>();
                }
                return _objectiveNameIsIn;
            }
            set { _objectiveNameIsIn = value; }
        }

        private String _colorContains;

        /// <summary>
        /// A search property representation of the ColorContains field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty(Size = 6, SearchOnly = true)]
        public String ColorContains
        {
            get { return _colorContains; }
            set { _colorContains = value; }
        }

        private IList<String> _colorIsIn;

        /// <summary>
        /// A search property representation of the ColorIsIn field for a record in the dbo.Objective data table. 
        /// </summary>
        [EntityProperty(Size = 6, SearchOnly = true)]
        public IList<String> ColorIsIn
        {
            get
            {
                if (_colorIsIn == null)
                {
                    _colorIsIn = new List<String>();
                }
                return _colorIsIn;
            }
            set { _colorIsIn = value; }
        }

    }

    [Serializable]
    public partial class ObjectiveExtended : EntityExtendedBase
    {
        internal ObjectiveExtended() { }
    }
}