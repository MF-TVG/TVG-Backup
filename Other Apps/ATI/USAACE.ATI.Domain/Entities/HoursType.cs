using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.HoursType data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class HoursType : EntityBase
    {
        private HoursTypeSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public HoursTypeSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new HoursTypeSearch();
                }

                return _searchProperties;
            }
        }

        private HoursTypeExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public HoursTypeExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new HoursTypeExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _hoursTypeID;

        /// <summary>
        /// A property representation of the HoursTypeID field for a record in the dbo.HoursType data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> HoursTypeID
        {
            get { return _hoursTypeID; }
            set { _hoursTypeID = value; }
        }

        private String _hoursTypeName;

        /// <summary>
        /// A property representation of the HoursTypeName field for a record in the dbo.HoursType data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String HoursTypeName
        {
            get { return _hoursTypeName; }
            set { _hoursTypeName = value; }
        }

    }

    [Serializable]
    public class HoursTypeSearch : EntitySearchBase
    {
        internal HoursTypeSearch() { }

        private String _hoursTypeNameContains;

        /// <summary>
        /// A search property representation of the HoursTypeNameContains field for a record in the dbo.HoursType data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String HoursTypeNameContains
        {
            get { return _hoursTypeNameContains; }
            set { _hoursTypeNameContains = value; }
        }

        private IList<String> _hoursTypeNameIsIn;

        /// <summary>
        /// A search property representation of the HoursTypeNameIsIn field for a record in the dbo.HoursType data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> HoursTypeNameIsIn
        {
            get
            {
                if (_hoursTypeNameIsIn == null)
                {
                    _hoursTypeNameIsIn = new List<String>();
                }
                return _hoursTypeNameIsIn;
            }
            set { _hoursTypeNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class HoursTypeExtended : EntityExtendedBase
    {
        internal HoursTypeExtended() { }
    }
}