using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.Organization data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class Organization : EntityBase
    {
        private OrganizationSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public OrganizationSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new OrganizationSearch();
                }

                return _searchProperties;
            }
        }

        private OrganizationExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public OrganizationExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new OrganizationExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _organizationID;

        /// <summary>
        /// A property representation of the OrganizationID field for a record in the dbo.Organization data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value; }
        }

        private String _organizationName;

        /// <summary>
        /// A property representation of the OrganizationName field for a record in the dbo.Organization data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String OrganizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; }
        }

    }

    [Serializable]
    public class OrganizationSearch : EntitySearchBase
    {
        internal OrganizationSearch() { }

        private String _organizationNameContains;

        /// <summary>
        /// A search property representation of the OrganizationNameContains field for a record in the dbo.Organization data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String OrganizationNameContains
        {
            get { return _organizationNameContains; }
            set { _organizationNameContains = value; }
        }

        private IList<String> _organizationNameIsIn;

        /// <summary>
        /// A search property representation of the OrganizationNameIsIn field for a record in the dbo.Organization data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> OrganizationNameIsIn
        {
            get
            {
                if (_organizationNameIsIn == null)
                {
                    _organizationNameIsIn = new List<String>();
                }
                return _organizationNameIsIn;
            }
            set { _organizationNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class OrganizationExtended : EntityExtendedBase
    {
        internal OrganizationExtended() { }
    }
}