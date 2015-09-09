using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.ErrorLog data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class ErrorLog : EntityBase
    {
        private ErrorLogSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public ErrorLogSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new ErrorLogSearch();
                }

                return _searchProperties;
            }
        }

        private ErrorLogExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public ErrorLogExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new ErrorLogExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _errorLogID;

        /// <summary>
        /// A property representation of the ErrorLogID field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> ErrorLogID
        {
            get { return _errorLogID; }
            set { _errorLogID = value; }
        }

        private String _message;

        /// <summary>
        /// A property representation of the Message field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty()]
        public String Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private String _stackTrace;

        /// <summary>
        /// A property representation of the StackTrace field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty()]
        public String StackTrace
        {
            get { return _stackTrace; }
            set { _stackTrace = value; }
        }

        private String _userName;

        /// <summary>
        /// A property representation of the UserName field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(Size = 100)]
        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private Nullable<DateTime> _errorDate;

        /// <summary>
        /// A property representation of the ErrorDate field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<DateTime> ErrorDate
        {
            get { return _errorDate; }
            set { _errorDate = value; }
        }

        private String _location;

        /// <summary>
        /// A property representation of the Location field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(Size = 200)]
        public String Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private String _errorType;

        /// <summary>
        /// A property representation of the ErrorType field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String ErrorType
        {
            get { return _errorType; }
            set { _errorType = value; }
        }

    }

    [Serializable]
    public class ErrorLogSearch : EntitySearchBase
    {
        internal ErrorLogSearch() { }

        private String _messageContains;

        /// <summary>
        /// A search property representation of the MessageContains field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String MessageContains
        {
            get { return _messageContains; }
            set { _messageContains = value; }
        }

        private IList<String> _messageIsIn;

        /// <summary>
        /// A search property representation of the MessageIsIn field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> MessageIsIn
        {
            get
            {
                if (_messageIsIn == null)
                {
                    _messageIsIn = new List<String>();
                }
                return _messageIsIn;
            }
            set { _messageIsIn = value; }
        }

        private String _stackTraceContains;

        /// <summary>
        /// A search property representation of the StackTraceContains field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public String StackTraceContains
        {
            get { return _stackTraceContains; }
            set { _stackTraceContains = value; }
        }

        private IList<String> _stackTraceIsIn;

        /// <summary>
        /// A search property representation of the StackTraceIsIn field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<String> StackTraceIsIn
        {
            get
            {
                if (_stackTraceIsIn == null)
                {
                    _stackTraceIsIn = new List<String>();
                }
                return _stackTraceIsIn;
            }
            set { _stackTraceIsIn = value; }
        }

        private String _userNameContains;

        /// <summary>
        /// A search property representation of the UserNameContains field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(Size = 100, SearchOnly = true)]
        public String UserNameContains
        {
            get { return _userNameContains; }
            set { _userNameContains = value; }
        }

        private IList<String> _userNameIsIn;

        /// <summary>
        /// A search property representation of the UserNameIsIn field for a record in the dbo.ErrorLog data table. 
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

        private Nullable<DateTime> _errorDateMinRange;

        /// <summary>
        /// A search property representation of the ErrorDateMinRange field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> ErrorDateMinRange
        {
            get { return _errorDateMinRange; }
            set { _errorDateMinRange = value; }
        }

        private Nullable<DateTime> _errorDateMaxRange;

        /// <summary>
        /// A search property representation of the ErrorDateMaxRange field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public Nullable<DateTime> ErrorDateMaxRange
        {
            get { return _errorDateMaxRange; }
            set { _errorDateMaxRange = value; }
        }

        private IList<Nullable<DateTime>> _errorDateIsIn;

        /// <summary>
        /// A search property representation of the ErrorDateIsIn field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(SearchOnly = true)]
        public IList<Nullable<DateTime>> ErrorDateIsIn
        {
            get
            {
                if (_errorDateIsIn == null)
                {
                    _errorDateIsIn = new List<Nullable<DateTime>>();
                }
                return _errorDateIsIn;
            }
            set { _errorDateIsIn = value; }
        }

        private String _locationContains;

        /// <summary>
        /// A search property representation of the LocationContains field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public String LocationContains
        {
            get { return _locationContains; }
            set { _locationContains = value; }
        }

        private IList<String> _locationIsIn;

        /// <summary>
        /// A search property representation of the LocationIsIn field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public IList<String> LocationIsIn
        {
            get
            {
                if (_locationIsIn == null)
                {
                    _locationIsIn = new List<String>();
                }
                return _locationIsIn;
            }
            set { _locationIsIn = value; }
        }

        private String _errorTypeContains;

        /// <summary>
        /// A search property representation of the ErrorTypeContains field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String ErrorTypeContains
        {
            get { return _errorTypeContains; }
            set { _errorTypeContains = value; }
        }

        private IList<String> _errorTypeIsIn;

        /// <summary>
        /// A search property representation of the ErrorTypeIsIn field for a record in the dbo.ErrorLog data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> ErrorTypeIsIn
        {
            get
            {
                if (_errorTypeIsIn == null)
                {
                    _errorTypeIsIn = new List<String>();
                }
                return _errorTypeIsIn;
            }
            set { _errorTypeIsIn = value; }
        }

    }

    [Serializable]
    public partial class ErrorLogExtended : EntityExtendedBase
    {
        internal ErrorLogExtended() { }
    }
}