using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.MiscHours data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class MiscHours : EntityBase
    {
        private MiscHoursSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public MiscHoursSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new MiscHoursSearch();
                }

                return _searchProperties;
            }
        }

        private MiscHoursExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public MiscHoursExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new MiscHoursExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _miscHoursID;

        /// <summary>
        /// A property representation of the MiscHoursID field for a record in the dbo.MiscHours data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> MiscHoursID
        {
            get { return _miscHoursID; }
            set { _miscHoursID = value; }
        }

        private String _miscHoursName;

        /// <summary>
        /// A property representation of the MiscHoursName field for a record in the dbo.MiscHours data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String MiscHoursName
        {
            get { return _miscHoursName; }
            set { _miscHoursName = value; }
        }

    }

    [Serializable]
    public class MiscHoursSearch : EntitySearchBase
    {
        internal MiscHoursSearch() { }

        private String _miscHoursNameContains;

        /// <summary>
        /// A search property representation of the MiscHoursNameContains field for a record in the dbo.MiscHours data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String MiscHoursNameContains
        {
            get { return _miscHoursNameContains; }
            set { _miscHoursNameContains = value; }
        }

        private IList<String> _miscHoursNameIsIn;

        /// <summary>
        /// A search property representation of the MiscHoursNameIsIn field for a record in the dbo.MiscHours data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> MiscHoursNameIsIn
        {
            get
            {
                if (_miscHoursNameIsIn == null)
                {
                    _miscHoursNameIsIn = new List<String>();
                }
                return _miscHoursNameIsIn;
            }
            set { _miscHoursNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class MiscHoursExtended : EntityExtendedBase
    {
        internal MiscHoursExtended() { }
    }
}