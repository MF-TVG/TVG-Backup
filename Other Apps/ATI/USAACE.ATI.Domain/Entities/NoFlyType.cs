using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.NoFlyType data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class NoFlyType : EntityBase
    {
        private NoFlyTypeSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public NoFlyTypeSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new NoFlyTypeSearch();
                }

                return _searchProperties;
            }
        }

        private NoFlyTypeExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public NoFlyTypeExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new NoFlyTypeExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _noFlyTypeID;

        /// <summary>
        /// A property representation of the NoFlyTypeID field for a record in the dbo.NoFlyType data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> NoFlyTypeID
        {
            get { return _noFlyTypeID; }
            set { _noFlyTypeID = value; }
        }

        private String _noFlyTypeName;

        /// <summary>
        /// A property representation of the NoFlyTypeName field for a record in the dbo.NoFlyType data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String NoFlyTypeName
        {
            get { return _noFlyTypeName; }
            set { _noFlyTypeName = value; }
        }

        private String _noFlyTypeColor;

        /// <summary>
        /// A property representation of the NoFlyTypeColor field for a record in the dbo.NoFlyType data table. 
        /// </summary>
        [EntityProperty(Size = 6)]
        public String NoFlyTypeColor
        {
            get { return _noFlyTypeColor; }
            set { _noFlyTypeColor = value; }
        }

        private Nullable<Boolean> _adjustGradDate;

        /// <summary>
        /// A property representation of the AdjustGradDate field for a record in the dbo.NoFlyType data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> AdjustGradDate
        {
            get { return _adjustGradDate; }
            set { _adjustGradDate = value; }
        }

    }

    [Serializable]
    public class NoFlyTypeSearch : EntitySearchBase
    {
        internal NoFlyTypeSearch() { }

        private String _noFlyTypeNameContains;

        /// <summary>
        /// A search property representation of the NoFlyTypeNameContains field for a record in the dbo.NoFlyType data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String NoFlyTypeNameContains
        {
            get { return _noFlyTypeNameContains; }
            set { _noFlyTypeNameContains = value; }
        }

        private IList<String> _noFlyTypeNameIsIn;

        /// <summary>
        /// A search property representation of the NoFlyTypeNameIsIn field for a record in the dbo.NoFlyType data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> NoFlyTypeNameIsIn
        {
            get
            {
                if (_noFlyTypeNameIsIn == null)
                {
                    _noFlyTypeNameIsIn = new List<String>();
                }
                return _noFlyTypeNameIsIn;
            }
            set { _noFlyTypeNameIsIn = value; }
        }

        private String _noFlyTypeColorContains;

        /// <summary>
        /// A search property representation of the NoFlyTypeColorContains field for a record in the dbo.NoFlyType data table. 
        /// </summary>
        [EntityProperty(Size = 6, SearchOnly = true)]
        public String NoFlyTypeColorContains
        {
            get { return _noFlyTypeColorContains; }
            set { _noFlyTypeColorContains = value; }
        }

        private IList<String> _noFlyTypeColorIsIn;

        /// <summary>
        /// A search property representation of the NoFlyTypeColorIsIn field for a record in the dbo.NoFlyType data table. 
        /// </summary>
        [EntityProperty(Size = 6, SearchOnly = true)]
        public IList<String> NoFlyTypeColorIsIn
        {
            get
            {
                if (_noFlyTypeColorIsIn == null)
                {
                    _noFlyTypeColorIsIn = new List<String>();
                }
                return _noFlyTypeColorIsIn;
            }
            set { _noFlyTypeColorIsIn = value; }
        }

    }

    [Serializable]
    public partial class NoFlyTypeExtended : EntityExtendedBase
    {
        internal NoFlyTypeExtended() { }
    }
}