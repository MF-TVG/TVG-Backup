using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.FormType data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class FormType : EntityBase
    {
        private FormTypeSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public FormTypeSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new FormTypeSearch();
                }

                return _searchProperties;
            }
        }

        private FormTypeExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public FormTypeExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new FormTypeExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _formTypeID;

        /// <summary>
        /// A property representation of the FormTypeID field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> FormTypeID
        {
            get { return _formTypeID; }
            set { _formTypeID = value; }
        }

        private String _formTypeName;

        /// <summary>
        /// A property representation of the FormTypeName field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String FormTypeName
        {
            get { return _formTypeName; }
            set { _formTypeName = value; }
        }

        private String _suspenseDateField;

        /// <summary>
        /// A property representation of the SuspenseDateField field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String SuspenseDateField
        {
            get { return _suspenseDateField; }
            set { _suspenseDateField = value; }
        }

        private String _subjectField;

        /// <summary>
        /// A property representation of the SubjectField field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String SubjectField
        {
            get { return _subjectField; }
            set { _subjectField = value; }
        }

        private String _formNumberField;

        /// <summary>
        /// A property representation of the FormNumberField field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String FormNumberField
        {
            get { return _formNumberField; }
            set { _formNumberField = value; }
        }

        private String _pageName;

        /// <summary>
        /// A property representation of the PageName field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String PageName
        {
            get { return _pageName; }
            set { _pageName = value; }
        }

        private String _formDataTable;

        /// <summary>
        /// A property representation of the FormDataTable field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String FormDataTable
        {
            get { return _formDataTable; }
            set { _formDataTable = value; }
        }

        private String _listPageName;

        /// <summary>
        /// A property representation of the ListPageName field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String ListPageName
        {
            get { return _listPageName; }
            set { _listPageName = value; }
        }

        private Nullable<Int32> _formActionTypeID;

        /// <summary>
        /// A property representation of the FormActionTypeID field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormActionTypeID
        {
            get { return _formActionTypeID; }
            set { _formActionTypeID = value; }
        }

    }

    [Serializable]
    public class FormTypeSearch : EntitySearchBase
    {
        internal FormTypeSearch() { }

        private String _formTypeNameContains;

        /// <summary>
        /// A search property representation of the FormTypeNameContains field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String FormTypeNameContains
        {
            get { return _formTypeNameContains; }
            set { _formTypeNameContains = value; }
        }

        private IList<String> _formTypeNameIsIn;

        /// <summary>
        /// A search property representation of the FormTypeNameIsIn field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> FormTypeNameIsIn
        {
            get
            {
                if (_formTypeNameIsIn == null)
                {
                    _formTypeNameIsIn = new List<String>();
                }
                return _formTypeNameIsIn;
            }
            set { _formTypeNameIsIn = value; }
        }

        private String _suspenseDateFieldContains;

        /// <summary>
        /// A search property representation of the SuspenseDateFieldContains field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String SuspenseDateFieldContains
        {
            get { return _suspenseDateFieldContains; }
            set { _suspenseDateFieldContains = value; }
        }

        private IList<String> _suspenseDateFieldIsIn;

        /// <summary>
        /// A search property representation of the SuspenseDateFieldIsIn field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> SuspenseDateFieldIsIn
        {
            get
            {
                if (_suspenseDateFieldIsIn == null)
                {
                    _suspenseDateFieldIsIn = new List<String>();
                }
                return _suspenseDateFieldIsIn;
            }
            set { _suspenseDateFieldIsIn = value; }
        }

        private String _subjectFieldContains;

        /// <summary>
        /// A search property representation of the SubjectFieldContains field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String SubjectFieldContains
        {
            get { return _subjectFieldContains; }
            set { _subjectFieldContains = value; }
        }

        private IList<String> _subjectFieldIsIn;

        /// <summary>
        /// A search property representation of the SubjectFieldIsIn field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> SubjectFieldIsIn
        {
            get
            {
                if (_subjectFieldIsIn == null)
                {
                    _subjectFieldIsIn = new List<String>();
                }
                return _subjectFieldIsIn;
            }
            set { _subjectFieldIsIn = value; }
        }

        private String _formNumberFieldContains;

        /// <summary>
        /// A search property representation of the FormNumberFieldContains field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String FormNumberFieldContains
        {
            get { return _formNumberFieldContains; }
            set { _formNumberFieldContains = value; }
        }

        private IList<String> _formNumberFieldIsIn;

        /// <summary>
        /// A search property representation of the FormNumberFieldIsIn field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> FormNumberFieldIsIn
        {
            get
            {
                if (_formNumberFieldIsIn == null)
                {
                    _formNumberFieldIsIn = new List<String>();
                }
                return _formNumberFieldIsIn;
            }
            set { _formNumberFieldIsIn = value; }
        }

        private String _pageNameContains;

        /// <summary>
        /// A search property representation of the PageNameContains field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String PageNameContains
        {
            get { return _pageNameContains; }
            set { _pageNameContains = value; }
        }

        private IList<String> _pageNameIsIn;

        /// <summary>
        /// A search property representation of the PageNameIsIn field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> PageNameIsIn
        {
            get
            {
                if (_pageNameIsIn == null)
                {
                    _pageNameIsIn = new List<String>();
                }
                return _pageNameIsIn;
            }
            set { _pageNameIsIn = value; }
        }

        private String _formDataTableContains;

        /// <summary>
        /// A search property representation of the FormDataTableContains field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String FormDataTableContains
        {
            get { return _formDataTableContains; }
            set { _formDataTableContains = value; }
        }

        private IList<String> _formDataTableIsIn;

        /// <summary>
        /// A search property representation of the FormDataTableIsIn field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> FormDataTableIsIn
        {
            get
            {
                if (_formDataTableIsIn == null)
                {
                    _formDataTableIsIn = new List<String>();
                }
                return _formDataTableIsIn;
            }
            set { _formDataTableIsIn = value; }
        }

        private String _listPageNameContains;

        /// <summary>
        /// A search property representation of the ListPageNameContains field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String ListPageNameContains
        {
            get { return _listPageNameContains; }
            set { _listPageNameContains = value; }
        }

        private IList<String> _listPageNameIsIn;

        /// <summary>
        /// A search property representation of the ListPageNameIsIn field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> ListPageNameIsIn
        {
            get
            {
                if (_listPageNameIsIn == null)
                {
                    _listPageNameIsIn = new List<String>();
                }
                return _listPageNameIsIn;
            }
            set { _listPageNameIsIn = value; }
        }

        private Nullable<Int32> _formActionTypeIDMinRange;

        /// <summary>
        /// A search property representation of the FormActionTypeIDMinRange field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormActionTypeIDMinRange
        {
            get { return _formActionTypeIDMinRange; }
            set { _formActionTypeIDMinRange = value; }
        }

        private Nullable<Int32> _formActionTypeIDMaxRange;

        /// <summary>
        /// A search property representation of the FormActionTypeIDMaxRange field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormActionTypeIDMaxRange
        {
            get { return _formActionTypeIDMaxRange; }
            set { _formActionTypeIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formActionTypeIDIsIn;

        /// <summary>
        /// A search property representation of the FormActionTypeIDIsIn field for a record in the dbo.FormType data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> FormActionTypeIDIsIn
        {
            get
            {
                if (_formActionTypeIDIsIn == null)
                {
                    _formActionTypeIDIsIn = new List<Nullable<Int32>>();
                }
                return _formActionTypeIDIsIn;
            }
            set { _formActionTypeIDIsIn = value; }
        }

    }

    [Serializable]
    public partial class FormTypeExtended : EntityExtendedBase
    {
        internal FormTypeExtended() { }
    }
}