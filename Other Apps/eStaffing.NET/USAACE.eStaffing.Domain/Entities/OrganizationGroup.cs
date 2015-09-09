using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.OrganizationGroup data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class OrganizationGroup : EntityBase
    {
        private OrganizationGroupSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public OrganizationGroupSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new OrganizationGroupSearch();
                }

                return _searchProperties;
            }
        }

        private OrganizationGroupExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public OrganizationGroupExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new OrganizationGroupExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _organizationGroupID;

        /// <summary>
        /// A property representation of the OrganizationGroupID field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationGroupID
        {
            get { return _organizationGroupID; }
            set { _organizationGroupID = value; }
        }

        private Nullable<Int32> _organizationID;

        /// <summary>
        /// A property representation of the OrganizationID field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value; }
        }

        private String _organizationGroupName;

        /// <summary>
        /// A property representation of the OrganizationGroupName field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String OrganizationGroupName
        {
            get { return _organizationGroupName; }
            set { _organizationGroupName = value; }
        }

        private Nullable<Int32> _groupID;

        /// <summary>
        /// A property representation of the GroupID field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0)]
        public Nullable<Int32> GroupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

    }

    [Serializable]
    public class OrganizationGroupSearch : EntitySearchBase
    {
        internal OrganizationGroupSearch() { }

        private Nullable<Int32> _organizationIDMinRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMinRange field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMinRange
        {
            get { return _organizationIDMinRange; }
            set { _organizationIDMinRange = value; }
        }

        private Nullable<Int32> _organizationIDMaxRange;

        /// <summary>
        /// A search property representation of the OrganizationIDMaxRange field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> OrganizationIDMaxRange
        {
            get { return _organizationIDMaxRange; }
            set { _organizationIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _organizationIDIsIn;

        /// <summary>
        /// A search property representation of the OrganizationIDIsIn field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public IList<Nullable<Int32>> OrganizationIDIsIn
        {
            get
            {
                if (_organizationIDIsIn == null)
                {
                    _organizationIDIsIn = new List<Nullable<Int32>>();
                }
                return _organizationIDIsIn;
            }
            set { _organizationIDIsIn = value; }
        }

        private String _organizationGroupNameContains;

        /// <summary>
        /// A search property representation of the OrganizationGroupNameContains field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String OrganizationGroupNameContains
        {
            get { return _organizationGroupNameContains; }
            set { _organizationGroupNameContains = value; }
        }

        private IList<String> _organizationGroupNameIsIn;

        /// <summary>
        /// A search property representation of the OrganizationGroupNameIsIn field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> OrganizationGroupNameIsIn
        {
            get
            {
                if (_organizationGroupNameIsIn == null)
                {
                    _organizationGroupNameIsIn = new List<String>();
                }
                return _organizationGroupNameIsIn;
            }
            set { _organizationGroupNameIsIn = value; }
        }

        private Nullable<Int32> _groupIDMinRange;

        /// <summary>
        /// A search property representation of the GroupIDMinRange field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> GroupIDMinRange
        {
            get { return _groupIDMinRange; }
            set { _groupIDMinRange = value; }
        }

        private Nullable<Int32> _groupIDMaxRange;

        /// <summary>
        /// A search property representation of the GroupIDMaxRange field for a record in the dbo.OrganizationGroup data table. 
        /// </summary>
        [EntityProperty(Precision = 10, Scale = 0, SearchOnly = true)]
        public Nullable<Int32> GroupIDMaxRange
        {
            get { return _groupIDMaxRange; }
            set { _groupIDMaxRange = value; }
        }

        private IList<Nullable<Int32>> _groupIDIsIn;

        /// <summary>
        /// A search property representation of the GroupIDIsIn field for a record in the dbo.OrganizationGroup data table. 
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

    }

    [Serializable]
    public partial class OrganizationGroupExtended : EntityExtendedBase
    {
        internal OrganizationGroupExtended() { }
    }
}