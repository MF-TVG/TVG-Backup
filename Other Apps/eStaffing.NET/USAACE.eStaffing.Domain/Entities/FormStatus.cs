using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.FormStatus data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class FormStatus : EntityBase
    {
        private FormStatusSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public FormStatusSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new FormStatusSearch();
                }

                return _searchProperties;
            }
        }

        private FormStatusExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public FormStatusExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new FormStatusExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _formStatusID;

        /// <summary>
        /// A property representation of the FormStatusID field for a record in the dbo.FormStatus data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> FormStatusID
        {
            get { return _formStatusID; }
            set { _formStatusID = value; }
        }

        private String _formStatusName;

        /// <summary>
        /// A property representation of the FormStatusName field for a record in the dbo.FormStatus data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String FormStatusName
        {
            get { return _formStatusName; }
            set { _formStatusName = value; }
        }

    }

    [Serializable]
    public class FormStatusSearch : EntitySearchBase
    {
        internal FormStatusSearch() { }

        private String _formStatusNameContains;

        /// <summary>
        /// A search property representation of the FormStatusNameContains field for a record in the dbo.FormStatus data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String FormStatusNameContains
        {
            get { return _formStatusNameContains; }
            set { _formStatusNameContains = value; }
        }

        private IList<String> _formStatusNameIsIn;

        /// <summary>
        /// A search property representation of the FormStatusNameIsIn field for a record in the dbo.FormStatus data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> FormStatusNameIsIn
        {
            get
            {
                if (_formStatusNameIsIn == null)
                {
                    _formStatusNameIsIn = new List<String>();
                }
                return _formStatusNameIsIn;
            }
            set { _formStatusNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class FormStatusExtended : EntityExtendedBase
    {
        internal FormStatusExtended() { }
    }
}