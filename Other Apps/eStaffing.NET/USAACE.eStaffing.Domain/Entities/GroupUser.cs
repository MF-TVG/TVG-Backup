using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.GroupUser data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class GroupUser : EntityBase
    {
        private GroupUserSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public GroupUserSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new GroupUserSearch();
                }

                return _searchProperties;
            }
        }

        private GroupUserExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public GroupUserExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new GroupUserExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _groupUserID;

        /// <summary>
        /// A property representation of the GroupUserID field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> GroupUserID
        {
            get { return _groupUserID; }
            set { _groupUserID = value; }
        }

        private Nullable<Int32> _groupID;

        /// <summary>
        /// A property representation of the GroupID field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> GroupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        private Nullable<Int32> _userID;

        /// <summary>
        /// A property representation of the UserID field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private Nullable<Boolean> _admin;

        /// <summary>
        /// A property representation of the Admin field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Admin
        {
            get { return _admin; }
            set { _admin = value; }
        }

        private Nullable<Boolean> _member;

        /// <summary>
        /// A property representation of the Member field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> Member
        {
            get { return _member; }
            set { _member = value; }
        }

    }

    [Serializable]
    public class GroupUserSearch : EntitySearchBase
    {
        internal GroupUserSearch() { }

        private Nullable<Int32> _groupIDMinRange;

        /// <summary>
        /// A search property representation of the GroupIDMinRange field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> GroupIDMinRange
        {
            get { return _groupIDMinRange; }
            set { _groupIDMinRange = value; }
        }

        private Nullable<Int32> _groupIDMaxRange;

        /// <summary>
        /// A search property representation of the GroupIDMaxRange field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> GroupIDMaxRange
        {
            get { return _groupIDMaxRange; }
            set { _groupIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _groupIDIsIn;

        /// <summary>
        /// A search property representation of the GroupIDIsIn field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> GroupIDIsIn
        {
            get
            {
                if (_groupIDIsIn == null)
                {
                    _groupIDIsIn = new List<Nullable<Int32>>();
                }
                return _groupIDIsIn;
            }
            set { _groupIDIsIn = value; }
        }

        private Nullable<Int32> _userIDMinRange;

        /// <summary>
        /// A search property representation of the UserIDMinRange field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> UserIDMinRange
        {
            get { return _userIDMinRange; }
            set { _userIDMinRange = value; }
        }

        private Nullable<Int32> _userIDMaxRange;

        /// <summary>
        /// A search property representation of the UserIDMaxRange field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> UserIDMaxRange
        {
            get { return _userIDMaxRange; }
            set { _userIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _userIDIsIn;

        /// <summary>
        /// A search property representation of the UserIDIsIn field for a record in the dbo.GroupUser data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> UserIDIsIn
        {
            get
            {
                if (_userIDIsIn == null)
                {
                    _userIDIsIn = new List<Nullable<Int32>>();
                }
                return _userIDIsIn;
            }
            set { _userIDIsIn = value; }
        }

    }

    [Serializable]
    public partial class GroupUserExtended : EntityExtendedBase
    {
        internal GroupUserExtended() { }
    }
}