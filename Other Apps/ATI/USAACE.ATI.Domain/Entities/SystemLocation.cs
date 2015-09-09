using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.SystemLocation data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class SystemLocation : EntityBase
    {
        private SystemLocationSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public SystemLocationSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new SystemLocationSearch();
                }

                return _searchProperties;
            }
        }

        private SystemLocationExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public SystemLocationExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new SystemLocationExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _systemLocationID;

        /// <summary>
        /// A property representation of the SystemLocationID field for a record in the dbo.SystemLocation data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> SystemLocationID
        {
            get { return _systemLocationID; }
            set { _systemLocationID = value; }
        }

        private Nullable<Int32> _systemID;

        /// <summary>
        /// A property representation of the SystemID field for a record in the dbo.SystemLocation data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> SystemID
        {
            get { return _systemID; }
            set { _systemID = value; }
        }

        private Nullable<Int32> _locationID;

        /// <summary>
        /// A property representation of the LocationID field for a record in the dbo.SystemLocation data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }

    }

    [Serializable]
    public class SystemLocationSearch : EntitySearchBase
    {
        internal SystemLocationSearch() { }

        private Nullable<Int32> _systemIDMinRange;

        /// <summary>
        /// A search property representation of the SystemIDMinRange field for a record in the dbo.SystemLocation data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> SystemIDMinRange
        {
            get { return _systemIDMinRange; }
            set { _systemIDMinRange = value; }
        }

        private Nullable<Int32> _systemIDMaxRange;

        /// <summary>
        /// A search property representation of the SystemIDMaxRange field for a record in the dbo.SystemLocation data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> SystemIDMaxRange
        {
            get { return _systemIDMaxRange; }
            set { _systemIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _systemIDIsIn;

        /// <summary>
        /// A search property representation of the SystemIDIsIn field for a record in the dbo.SystemLocation data table. 
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

        private Nullable<Int32> _locationIDMinRange;

        /// <summary>
        /// A search property representation of the LocationIDMinRange field for a record in the dbo.SystemLocation data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> LocationIDMinRange
        {
            get { return _locationIDMinRange; }
            set { _locationIDMinRange = value; }
        }

        private Nullable<Int32> _locationIDMaxRange;

        /// <summary>
        /// A search property representation of the LocationIDMaxRange field for a record in the dbo.SystemLocation data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> LocationIDMaxRange
        {
            get { return _locationIDMaxRange; }
            set { _locationIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _locationIDIsIn;

        /// <summary>
        /// A search property representation of the LocationIDIsIn field for a record in the dbo.SystemLocation data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> LocationIDIsIn
        {
            get
            {
                if (_locationIDIsIn == null)
                {
                    _locationIDIsIn = new List<Nullable<Int32>>();
                }
                return _locationIDIsIn;
            }
            set { _locationIDIsIn = value; }
        }

    }

    [Serializable]
    public partial class SystemLocationExtended : EntityExtendedBase
    {
        internal SystemLocationExtended() { }
    }
}