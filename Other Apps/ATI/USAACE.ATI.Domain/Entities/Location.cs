using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.Location data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class Location : EntityBase
    {
        private LocationSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public LocationSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new LocationSearch();
                }

                return _searchProperties;
            }
        }

        private LocationExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public LocationExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new LocationExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _locationID;

        /// <summary>
        /// A property representation of the LocationID field for a record in the dbo.Location data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }

        private String _locationName;

        /// <summary>
        /// A property representation of the LocationName field for a record in the dbo.Location data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String LocationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }

    }

    [Serializable]
    public class LocationSearch : EntitySearchBase
    {
        internal LocationSearch() { }

        private String _locationNameContains;

        /// <summary>
        /// A search property representation of the LocationNameContains field for a record in the dbo.Location data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String LocationNameContains
        {
            get { return _locationNameContains; }
            set { _locationNameContains = value; }
        }

        private IList<String> _locationNameIsIn;

        /// <summary>
        /// A search property representation of the LocationNameIsIn field for a record in the dbo.Location data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> LocationNameIsIn
        {
            get
            {
                if (_locationNameIsIn == null)
                {
                    _locationNameIsIn = new List<String>();
                }
                return _locationNameIsIn;
            }
            set { _locationNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class LocationExtended : EntityExtendedBase
    {
        internal LocationExtended() { }
    }
}