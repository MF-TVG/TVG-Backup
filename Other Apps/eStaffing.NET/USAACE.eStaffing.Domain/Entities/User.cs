using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.User data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class User : EntityBase
    {
        private UserSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public UserSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new UserSearch();
                }

                return _searchProperties;
            }
        }

        private UserExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public UserExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new UserExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _userID;

        /// <summary>
        /// A property representation of the UserID field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private String _userName;

        /// <summary>
        /// A property representation of the UserName field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 100)]
        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private String _userSID;

        /// <summary>
        /// A property representation of the UserSID field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 200)]
        public String UserSID
        {
            get { return _userSID; }
            set { _userSID = value; }
        }

        private String _userDisplayName;

        /// <summary>
        /// A property representation of the UserDisplayName field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 100)]
        public String UserDisplayName
        {
            get { return _userDisplayName; }
            set { _userDisplayName = value; }
        }

        private String _userEmail;

        /// <summary>
        /// A property representation of the UserEmail field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 100)]
        public String UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; }
        }

        private Nullable<Boolean> _notifyReject;

        /// <summary>
        /// A property representation of the NotifyReject field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> NotifyReject
        {
            get { return _notifyReject; }
            set { _notifyReject = value; }
        }

        private Nullable<Boolean> _notifyReview;

        /// <summary>
        /// A property representation of the NotifyReview field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> NotifyReview
        {
            get { return _notifyReview; }
            set { _notifyReview = value; }
        }

        private Nullable<Boolean> _notifyComplete;

        /// <summary>
        /// A property representation of the NotifyComplete field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> NotifyComplete
        {
            get { return _notifyComplete; }
            set { _notifyComplete = value; }
        }

        private String _authenticationType;

        /// <summary>
        /// A property representation of the AuthenticationType field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String AuthenticationType
        {
            get { return _authenticationType; }
            set { _authenticationType = value; }
        }

        private Nullable<Boolean> _isADGroup;

        /// <summary>
        /// A property representation of the IsADGroup field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> IsADGroup
        {
            get { return _isADGroup; }
            set { _isADGroup = value; }
        }

    }

    [Serializable]
    public class UserSearch : EntitySearchBase
    {
        internal UserSearch() { }

        private String _userNameContains;

        /// <summary>
        /// A search property representation of the UserNameContains field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 100, SearchOnly = true)]
        public String UserNameContains
        {
            get { return _userNameContains; }
            set { _userNameContains = value; }
        }

        private IList<String> _userNameIsIn;

        /// <summary>
        /// A search property representation of the UserNameIsIn field for a record in the dbo.User data table. 
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

        private String _userSIDContains;

        /// <summary>
        /// A search property representation of the UserSIDContains field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public String UserSIDContains
        {
            get { return _userSIDContains; }
            set { _userSIDContains = value; }
        }

        private IList<String> _userSIDIsIn;

        /// <summary>
        /// A search property representation of the UserSIDIsIn field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 200, SearchOnly = true)]
        public IList<String> UserSIDIsIn
        {
            get
            {
                if (_userSIDIsIn == null)
                {
                    _userSIDIsIn = new List<String>();
                }
                return _userSIDIsIn;
            }
            set { _userSIDIsIn = value; }
        }

        private String _userDisplayNameContains;

        /// <summary>
        /// A search property representation of the UserDisplayNameContains field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 100, SearchOnly = true)]
        public String UserDisplayNameContains
        {
            get { return _userDisplayNameContains; }
            set { _userDisplayNameContains = value; }
        }

        private IList<String> _userDisplayNameIsIn;

        /// <summary>
        /// A search property representation of the UserDisplayNameIsIn field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 100, SearchOnly = true)]
        public IList<String> UserDisplayNameIsIn
        {
            get
            {
                if (_userDisplayNameIsIn == null)
                {
                    _userDisplayNameIsIn = new List<String>();
                }
                return _userDisplayNameIsIn;
            }
            set { _userDisplayNameIsIn = value; }
        }

        private String _userEmailContains;

        /// <summary>
        /// A search property representation of the UserEmailContains field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 100, SearchOnly = true)]
        public String UserEmailContains
        {
            get { return _userEmailContains; }
            set { _userEmailContains = value; }
        }

        private IList<String> _userEmailIsIn;

        /// <summary>
        /// A search property representation of the UserEmailIsIn field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 100, SearchOnly = true)]
        public IList<String> UserEmailIsIn
        {
            get
            {
                if (_userEmailIsIn == null)
                {
                    _userEmailIsIn = new List<String>();
                }
                return _userEmailIsIn;
            }
            set { _userEmailIsIn = value; }
        }

        private String _authenticationTypeContains;

        /// <summary>
        /// A search property representation of the AuthenticationTypeContains field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String AuthenticationTypeContains
        {
            get { return _authenticationTypeContains; }
            set { _authenticationTypeContains = value; }
        }

        private IList<String> _authenticationTypeIsIn;

        /// <summary>
        /// A search property representation of the AuthenticationTypeIsIn field for a record in the dbo.User data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> AuthenticationTypeIsIn
        {
            get
            {
                if (_authenticationTypeIsIn == null)
                {
                    _authenticationTypeIsIn = new List<String>();
                }
                return _authenticationTypeIsIn;
            }
            set { _authenticationTypeIsIn = value; }
        }

    }

    [Serializable]
    public partial class UserExtended : EntityExtendedBase
    {
        internal UserExtended() { }
    }
}