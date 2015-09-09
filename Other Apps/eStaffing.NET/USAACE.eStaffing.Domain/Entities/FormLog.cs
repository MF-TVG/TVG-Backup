using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.FormLog data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class FormLog : EntityBase
    {
        private FormLogSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public FormLogSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new FormLogSearch();
                }

                return _searchProperties;
            }
        }

        private FormLogExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public FormLogExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new FormLogExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _formLogID;

        /// <summary>
        /// A property representation of the FormLogID field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> FormLogID
        {
            get { return _formLogID; }
            set { _formLogID = value; }
        }

        private Nullable<Int32> _formID;

        /// <summary>
        /// A property representation of the FormID field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> FormID
        {
            get { return _formID; }
            set { _formID = value; }
        }

        private Nullable<DateTime> _logDate;

        /// <summary>
        /// A property representation of the LogDate field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> LogDate
        {
            get { return _logDate; }
            set { _logDate = value; }
        }

        private String _action;

        /// <summary>
        /// A property representation of the Action field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String Action
        {
            get { return _action; }
            set { _action = value; }
        }

        private String _notes;

        /// <summary>
        /// A property representation of the Notes field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty()]
        public String Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        private String _role;

        /// <summary>
        /// A property representation of the Role field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String Role
        {
            get { return _role; }
            set { _role = value; }
        }

        private String _userName;

        /// <summary>
        /// A property representation of the UserName field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Size = 100)]
        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

    }

    [Serializable]
    public class FormLogSearch : EntitySearchBase
    {
        internal FormLogSearch() { }

        private Nullable<Int32> _formIDMinRange;

        /// <summary>
        /// A search property representation of the FormIDMinRange field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormIDMinRange
        {
            get { return _formIDMinRange; }
            set { _formIDMinRange = value; }
        }

        private Nullable<Int32> _formIDMaxRange;

        /// <summary>
        /// A search property representation of the FormIDMaxRange field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> FormIDMaxRange
        {
            get { return _formIDMaxRange; }
            set { _formIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _formIDIsIn;

        /// <summary>
        /// A search property representation of the FormIDIsIn field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> FormIDIsIn
        {
            get
            {
                if (_formIDIsIn == null)
                {
                    _formIDIsIn = new List<Nullable<Int32>>();
                }
                return _formIDIsIn;
            }
            set { _formIDIsIn = value; }
        }

        private Nullable<DateTime> _logDateMinRange;

        /// <summary>
        /// A search property representation of the LogDateMinRange field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> LogDateMinRange
        {
            get { return _logDateMinRange; }
            set { _logDateMinRange = value; }
        }

        private Nullable<DateTime> _logDateMaxRange;

        /// <summary>
        /// A search property representation of the LogDateMaxRange field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> LogDateMaxRange
        {
            get { return _logDateMaxRange; }
            set { _logDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _logDateIsIn;

        /// <summary>
        /// A search property representation of the LogDateIsIn field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> LogDateIsIn
        {
            get
            {
                if (_logDateIsIn == null)
                {
                    _logDateIsIn = new List<Nullable<DateTime>>();
                }
                return _logDateIsIn;
            }
            set { _logDateIsIn = value; }
        }

        private String _actionContains;

        /// <summary>
        /// A search property representation of the ActionContains field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String ActionContains
        {
            get { return _actionContains; }
            set { _actionContains = value; }
        }

        private IList<String> _actionIsIn;

        /// <summary>
        /// A search property representation of the ActionIsIn field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> ActionIsIn
        {
            get
            {
                if (_actionIsIn == null)
                {
                    _actionIsIn = new List<String>();
                }
                return _actionIsIn;
            }
            set { _actionIsIn = value; }
        }

        private String _notesContains;

        /// <summary>
        /// A search property representation of the NotesContains field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String NotesContains
        {
            get { return _notesContains; }
            set { _notesContains = value; }
        }

        private IList<String> _notesIsIn;

        /// <summary>
        /// A search property representation of the NotesIsIn field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> NotesIsIn
        {
            get
            {
                if (_notesIsIn == null)
                {
                    _notesIsIn = new List<String>();
                }
                return _notesIsIn;
            }
            set { _notesIsIn = value; }
        }

        private String _roleContains;

        /// <summary>
        /// A search property representation of the RoleContains field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String RoleContains
        {
            get { return _roleContains; }
            set { _roleContains = value; }
        }

        private IList<String> _roleIsIn;

        /// <summary>
        /// A search property representation of the RoleIsIn field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> RoleIsIn
        {
            get
            {
                if (_roleIsIn == null)
                {
                    _roleIsIn = new List<String>();
                }
                return _roleIsIn;
            }
            set { _roleIsIn = value; }
        }

        private String _userNameContains;

        /// <summary>
        /// A search property representation of the UserNameContains field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Size = 100, SearchOnly = true)]
        public String UserNameContains
        {
            get { return _userNameContains; }
            set { _userNameContains = value; }
        }

        private IList<String> _userNameIsIn;

        /// <summary>
        /// A search property representation of the UserNameIsIn field for a record in the dbo.FormLog data table. 
        /// </summary>
        [EntityProperty(Size = 100, SearchOnly = true)]
        public IList<String> UserNameIsIn
        {
            get
            {
                if (_userNameIsIn == null)
                {
                    _userNameIsIn = new List<String>();
                }
                return _userNameIsIn;
            }
            set { _userNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class FormLogExtended : EntityExtendedBase
    {
        internal FormLogExtended() { }
    }
}