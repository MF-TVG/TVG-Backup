using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.CourseType data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class CourseType : EntityBase
    {
        private CourseTypeSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public CourseTypeSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new CourseTypeSearch();
                }

                return _searchProperties;
            }
        }

        private CourseTypeExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public CourseTypeExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new CourseTypeExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _courseTypeID;

        /// <summary>
        /// A property representation of the CourseTypeID field for a record in the dbo.CourseType data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseTypeID
        {
            get { return _courseTypeID; }
            set { _courseTypeID = value; }
        }

        private String _courseTypeName;

        /// <summary>
        /// A property representation of the CourseTypeName field for a record in the dbo.CourseType data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String CourseTypeName
        {
            get { return _courseTypeName; }
            set { _courseTypeName = value; }
        }

        private String _courseTypeCode;

        /// <summary>
        /// A property representation of the CourseTypeCode field for a record in the dbo.CourseType data table. 
        /// </summary>
        [EntityProperty(Size = 5)]
        public String CourseTypeCode
        {
            get { return _courseTypeCode; }
            set { _courseTypeCode = value; }
        }

    }

    [Serializable]
    public class CourseTypeSearch : EntitySearchBase
    {
        internal CourseTypeSearch() { }

        private String _courseTypeNameContains;

        /// <summary>
        /// A search property representation of the CourseTypeNameContains field for a record in the dbo.CourseType data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String CourseTypeNameContains
        {
            get { return _courseTypeNameContains; }
            set { _courseTypeNameContains = value; }
        }

        private IList<String> _courseTypeNameIsIn;

        /// <summary>
        /// A search property representation of the CourseTypeNameIsIn field for a record in the dbo.CourseType data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> CourseTypeNameIsIn
        {
            get
            {
                if (_courseTypeNameIsIn == null)
                {
                    _courseTypeNameIsIn = new List<String>();
                }
                return _courseTypeNameIsIn;
            }
            set { _courseTypeNameIsIn = value; }
        }

        private String _courseTypeCodeContains;

        /// <summary>
        /// A search property representation of the CourseTypeCodeContains field for a record in the dbo.CourseType data table. 
        /// </summary>
        [EntityProperty(Size = 5, SearchOnly = true)]
        public String CourseTypeCodeContains
        {
            get { return _courseTypeCodeContains; }
            set { _courseTypeCodeContains = value; }
        }

        private IList<String> _courseTypeCodeIsIn;

        /// <summary>
        /// A search property representation of the CourseTypeCodeIsIn field for a record in the dbo.CourseType data table. 
        /// </summary>
        [EntityProperty(Size = 5, SearchOnly = true)]
        public IList<String> CourseTypeCodeIsIn
        {
            get
            {
                if (_courseTypeCodeIsIn == null)
                {
                    _courseTypeCodeIsIn = new List<String>();
                }
                return _courseTypeCodeIsIn;
            }
            set { _courseTypeCodeIsIn = value; }
        }

    }

    [Serializable]
    public partial class CourseTypeExtended : EntityExtendedBase
    {
        internal CourseTypeExtended() { }
    }
}