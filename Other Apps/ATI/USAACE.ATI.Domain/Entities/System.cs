using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.System data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class System : EntityBase
    {
        private SystemSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public SystemSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new SystemSearch();
                }

                return _searchProperties;
            }
        }

        private SystemExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public SystemExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new SystemExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _systemID;

        /// <summary>
        /// A property representation of the SystemID field for a record in the dbo.System data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> SystemID
        {
            get { return _systemID; }
            set { _systemID = value; }
        }

        private String _systemName;

        /// <summary>
        /// A property representation of the SystemName field for a record in the dbo.System data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String SystemName
        {
            get { return _systemName; }
            set { _systemName = value; }
        }

        private String _systemCode;

        /// <summary>
        /// A property representation of the SystemCode field for a record in the dbo.System data table. 
        /// </summary>
        [EntityProperty(Size = 5)]
        public String SystemCode
        {
            get { return _systemCode; }
            set { _systemCode = value; }
        }

    }

    [Serializable]
    public class SystemSearch : EntitySearchBase
    {
        internal SystemSearch() { }

        private String _systemNameContains;

        /// <summary>
        /// A search property representation of the SystemNameContains field for a record in the dbo.System data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String SystemNameContains
        {
            get { return _systemNameContains; }
            set { _systemNameContains = value; }
        }

        private IList<String> _systemNameIsIn;

        /// <summary>
        /// A search property representation of the SystemNameIsIn field for a record in the dbo.System data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> SystemNameIsIn
        {
            get
            {
                if (_systemNameIsIn == null)
                {
                    _systemNameIsIn = new List<String>();
                }
                return _systemNameIsIn;
            }
            set { _systemNameIsIn = value; }
        }

        private String _systemCodeContains;

        /// <summary>
        /// A search property representation of the SystemCodeContains field for a record in the dbo.System data table. 
        /// </summary>
        [EntityProperty(Size = 5, SearchOnly = true)]
        public String SystemCodeContains
        {
            get { return _systemCodeContains; }
            set { _systemCodeContains = value; }
        }

        private IList<String> _systemCodeIsIn;

        /// <summary>
        /// A search property representation of the SystemCodeIsIn field for a record in the dbo.System data table. 
        /// </summary>
        [EntityProperty(Size = 5, SearchOnly = true)]
        public IList<String> SystemCodeIsIn
        {
            get
            {
                if (_systemCodeIsIn == null)
                {
                    _systemCodeIsIn = new List<String>();
                }
                return _systemCodeIsIn;
            }
            set { _systemCodeIsIn = value; }
        }

    }

    [Serializable]
    public partial class SystemExtended : EntityExtendedBase
    {
        internal SystemExtended() { }
    }
}