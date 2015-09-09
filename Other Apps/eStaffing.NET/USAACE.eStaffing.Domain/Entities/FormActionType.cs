using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.FormActionType data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class FormActionType : EntityBase
    {
        private FormActionTypeSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public FormActionTypeSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new FormActionTypeSearch();
                }

                return _searchProperties;
            }
        }

        private FormActionTypeExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public FormActionTypeExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new FormActionTypeExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _formActionTypeID;

        /// <summary>
        /// A property representation of the FormActionTypeID field for a record in the dbo.FormActionType data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> FormActionTypeID
        {
            get { return _formActionTypeID; }
            set { _formActionTypeID = value; }
        }

        private String _formActionTypeName;

        /// <summary>
        /// A property representation of the FormActionTypeName field for a record in the dbo.FormActionType data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String FormActionTypeName
        {
            get { return _formActionTypeName; }
            set { _formActionTypeName = value; }
        }

        private Nullable<Boolean> _formActionTopDown;

        /// <summary>
        /// A property representation of the FormActionTopDown field for a record in the dbo.FormActionType data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> FormActionTopDown
        {
            get { return _formActionTopDown; }
            set { _formActionTopDown = value; }
        }

    }

    [Serializable]
    public class FormActionTypeSearch : EntitySearchBase
    {
        internal FormActionTypeSearch() { }

        private String _formActionTypeNameContains;

        /// <summary>
        /// A search property representation of the FormActionTypeNameContains field for a record in the dbo.FormActionType data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String FormActionTypeNameContains
        {
            get { return _formActionTypeNameContains; }
            set { _formActionTypeNameContains = value; }
        }

        private IList<String> _formActionTypeNameIsIn;

        /// <summary>
        /// A search property representation of the FormActionTypeNameIsIn field for a record in the dbo.FormActionType data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> FormActionTypeNameIsIn
        {
            get
            {
                if (_formActionTypeNameIsIn == null)
                {
                    _formActionTypeNameIsIn = new List<String>();
                }
                return _formActionTypeNameIsIn;
            }
            set { _formActionTypeNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class FormActionTypeExtended : EntityExtendedBase
    {
        internal FormActionTypeExtended() { }
    }
}