using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.eStaffing.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.ReviewRole data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class ReviewRole : EntityBase
    {
        private ReviewRoleSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public ReviewRoleSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new ReviewRoleSearch();
                }

                return _searchProperties;
            }
        }

        private ReviewRoleExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public ReviewRoleExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new ReviewRoleExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _reviewRoleID;

        /// <summary>
        /// A property representation of the ReviewRoleID field for a record in the dbo.ReviewRole data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> ReviewRoleID
        {
            get { return _reviewRoleID; }
            set { _reviewRoleID = value; }
        }

        private String _reviewRoleName;

        /// <summary>
        /// A property representation of the ReviewRoleName field for a record in the dbo.ReviewRole data table. 
        /// </summary>
        [EntityProperty(Size = 20)]
        public String ReviewRoleName
        {
            get { return _reviewRoleName; }
            set { _reviewRoleName = value; }
        }

        private Nullable<Boolean> _actionRequired;

        /// <summary>
        /// A property representation of the ActionRequired field for a record in the dbo.ReviewRole data table. 
        /// </summary>
        [EntityProperty()]
        public Nullable<Boolean> ActionRequired
        {
            get { return _actionRequired; }
            set { _actionRequired = value; }
        }

    }

    [Serializable]
    public class ReviewRoleSearch : EntitySearchBase
    {
        internal ReviewRoleSearch() { }

        private String _reviewRoleNameContains;

        /// <summary>
        /// A search property representation of the ReviewRoleNameContains field for a record in the dbo.ReviewRole data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public String ReviewRoleNameContains
        {
            get { return _reviewRoleNameContains; }
            set { _reviewRoleNameContains = value; }
        }

        private IList<String> _reviewRoleNameIsIn;

        /// <summary>
        /// A search property representation of the ReviewRoleNameIsIn field for a record in the dbo.ReviewRole data table. 
        /// </summary>
        [EntityProperty(Size = 20, SearchOnly = true)]
        public IList<String> ReviewRoleNameIsIn
        {
            get
            {
                if (_reviewRoleNameIsIn == null)
                {
                    _reviewRoleNameIsIn = new List<String>();
                }
                return _reviewRoleNameIsIn;
            }
            set { _reviewRoleNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class ReviewRoleExtended : EntityExtendedBase
    {
        internal ReviewRoleExtended() { }
    }
}