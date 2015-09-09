using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.CourseNumber data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class CourseNumber : EntityBase
    {
        private CourseNumberSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public CourseNumberSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new CourseNumberSearch();
                }

                return _searchProperties;
            }
        }

        private CourseNumberExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public CourseNumberExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new CourseNumberExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _courseNumberID;

        /// <summary>
        /// A property representation of the CourseNumberID field for a record in the dbo.CourseNumber data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseNumberID
        {
            get { return _courseNumberID; }
            set { _courseNumberID = value; }
        }

        private String _courseNumberName;

        /// <summary>
        /// A property representation of the CourseNumberName field for a record in the dbo.CourseNumber data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String CourseNumberName
        {
            get { return _courseNumberName; }
            set { _courseNumberName = value; }
        }

    }

    [Serializable]
    public class CourseNumberSearch : EntitySearchBase
    {
        internal CourseNumberSearch() { }

        private String _courseNumberNameContains;

        /// <summary>
        /// A search property representation of the CourseNumberNameContains field for a record in the dbo.CourseNumber data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String CourseNumberNameContains
        {
            get { return _courseNumberNameContains; }
            set { _courseNumberNameContains = value; }
        }

        private IList<String> _courseNumberNameIsIn;

        /// <summary>
        /// A search property representation of the CourseNumberNameIsIn field for a record in the dbo.CourseNumber data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> CourseNumberNameIsIn
        {
            get
            {
                if (_courseNumberNameIsIn == null)
                {
                    _courseNumberNameIsIn = new List<String>();
                }
                return _courseNumberNameIsIn;
            }
            set { _courseNumberNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class CourseNumberExtended : EntityExtendedBase
    {
        internal CourseNumberExtended() { }
    }
}