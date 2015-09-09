using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.Group data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class Group : EntityBase
    {
        private GroupSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public GroupSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new GroupSearch();
                }

                return _searchProperties;
            }
        }

        private GroupExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public GroupExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new GroupExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _groupID;

        /// <summary>
        /// A property representation of the GroupID field for a record in the dbo.Group data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> GroupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        private String _groupName;

        /// <summary>
        /// A property representation of the GroupName field for a record in the dbo.Group data table. 
        /// </summary>
        [EntityProperty(Size = 100)]
        public String GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

    }

    [Serializable]
    public class GroupSearch : EntitySearchBase
    {
        internal GroupSearch() { }

        private String _groupNameContains;

        /// <summary>
        /// A search property representation of the GroupNameContains field for a record in the dbo.Group data table. 
        /// </summary>
        [EntityProperty(Size = 100, SearchOnly = true)]
        public String GroupNameContains
        {
            get { return _groupNameContains; }
            set { _groupNameContains = value; }
        }

        private IList<String> _groupNameIsIn;

        /// <summary>
        /// A search property representation of the GroupNameIsIn field for a record in the dbo.Group data table. 
        /// </summary>
        [EntityProperty(Size = 100, SearchOnly = true)]
        public IList<String> GroupNameIsIn
        {
            get
            {
                if (_groupNameIsIn == null)
                {
                    _groupNameIsIn = new List<String>();
                }
                return _groupNameIsIn;
            }
            set { _groupNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class GroupExtended : EntityExtendedBase
    {
        internal GroupExtended() { }
    }
}