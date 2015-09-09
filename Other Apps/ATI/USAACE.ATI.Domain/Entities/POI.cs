using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.POI data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class POI : EntityBase
    {
        private POISearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public POISearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new POISearch();
                }

                return _searchProperties;
            }
        }

        private POIExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public POIExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new POIExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _pOIID;

        /// <summary>
        /// A property representation of the POIID field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> POIID
        {
            get { return _pOIID; }
            set { _pOIID = value; }
        }

        private String _pOIName;

        /// <summary>
        /// A property representation of the POIName field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String POIName
        {
            get { return _pOIName; }
            set { _pOIName = value; }
        }

        private Nullable<Int16> _days;

        /// <summary>
        /// A property representation of the Days field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0)]
        public Nullable<Int16> Days
        {
            get { return _days; }
            set { _days = value; }
        }

        private Nullable<Boolean> _mobilization;

        /// <summary>
        /// A property representation of the Mobilization field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Mobilization
        {
            get { return _mobilization; }
            set { _mobilization = value; }
        }

        private Nullable<DateTime> _effectiveDate;

        /// <summary>
        /// A property representation of the EffectiveDate field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> EffectiveDate
        {
            get { return _effectiveDate; }
            set { _effectiveDate = value; }
        }

    }

    [Serializable]
    public class POISearch : EntitySearchBase
    {
        internal POISearch() { }

        private String _pOINameContains;

        /// <summary>
        /// A search property representation of the POINameContains field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String POINameContains
        {
            get { return _pOINameContains; }
            set { _pOINameContains = value; }
        }

        private IList<String> _pOINameIsIn;

        /// <summary>
        /// A search property representation of the POINameIsIn field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> POINameIsIn
        {
            get
            {
                if (_pOINameIsIn == null)
                {
                    _pOINameIsIn = new List<String>();
                }
                return _pOINameIsIn;
            }
            set { _pOINameIsIn = value; }
        }

        private Nullable<Int16> _daysMinRange;

        /// <summary>
        /// A search property representation of the DaysMinRange field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> DaysMinRange
        {
            get { return _daysMinRange; }
            set { _daysMinRange = value; }
        }

        private Nullable<Int16> _daysMaxRange;

        /// <summary>
        /// A search property representation of the DaysMaxRange field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public Nullable<Int16> DaysMaxRange
        {
            get { return _daysMaxRange; }
            set { _daysMaxRange = value; }
        }

        private IList<Nullable<Int16>> _daysIsIn;

        /// <summary>
        /// A search property representation of the DaysIsIn field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(Precision = 5, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int16>> DaysIsIn
        {
            get
            {
                if (_daysIsIn == null)
                {
                    _daysIsIn = new List<Nullable<Int16>>();
                }
                return _daysIsIn;
            }
            set { _daysIsIn = value; }
        }

        private Nullable<DateTime> _effectiveDateMinRange;

        /// <summary>
        /// A search property representation of the EffectiveDateMinRange field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> EffectiveDateMinRange
        {
            get { return _effectiveDateMinRange; }
            set { _effectiveDateMinRange = value; }
        }

        private Nullable<DateTime> _effectiveDateMaxRange;

        /// <summary>
        /// A search property representation of the EffectiveDateMaxRange field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> EffectiveDateMaxRange
        {
            get { return _effectiveDateMaxRange; }
            set { _effectiveDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _effectiveDateIsIn;

        /// <summary>
        /// A search property representation of the EffectiveDateIsIn field for a record in the dbo.POI data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> EffectiveDateIsIn
        {
            get
            {
                if (_effectiveDateIsIn == null)
                {
                    _effectiveDateIsIn = new List<Nullable<DateTime>>();
                }
                return _effectiveDateIsIn;
            }
            set { _effectiveDateIsIn = value; }
        }

    }

    [Serializable]
    public partial class POIExtended : EntityExtendedBase
    {
        internal POIExtended() { }
    }
}