using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.Common.Entities;
using USAACE.Common.Entities.Attributes;

namespace USAACE.ATI.Domain.Entities
{
    /// <summary>
    /// An entity representation of a record for the dbo.CourseLevel data table. 
    /// </summary>
    [Serializable]
    [EntityTable(Schema = "dbo", IsView = false)]
    public class CourseLevel : EntityBase
    {
        private CourseLevelSearch _searchProperties;

        /// <summary>
        /// Properties that are used for searching only. 
        /// </summary>
        public CourseLevelSearch SearchProperties
        {
            get
            {
                if (_searchProperties == null)
                {
                    _searchProperties = new CourseLevelSearch();
                }

                return _searchProperties;
            }
        }

        private CourseLevelExtended _extendedProperties;

        /// <summary>
        /// Extended properties that are used only for temporary storage.
        /// </summary>
        public CourseLevelExtended ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new CourseLevelExtended();
                }

                return _extendedProperties;
            }
        }

        private Nullable<Int32> _courseLevelID;

        /// <summary>
        /// A property representation of the CourseLevelID field for a record in the dbo.CourseLevel data table. 
        /// </summary>
        [EntityProperty(IdentityField = true, Precision = 10, Scale = 0)]
        public Nullable<Int32> CourseLevelID
        {
            get { return _courseLevelID; }
            set { _courseLevelID = value; }
        }

        private String _courseLevelName;

        /// <summary>
        /// A property representation of the CourseLevelName field for a record in the dbo.CourseLevel data table. 
        /// </summary>
        [EntityProperty(Size = 50)]
        public String CourseLevelName
        {
            get { return _courseLevelName; }
            set { _courseLevelName = value; }
        }

    }

    [Serializable]
    public class CourseLevelSearch : EntitySearchBase
    {
        internal CourseLevelSearch() { }

        private String _courseLevelNameContains;

        /// <summary>
        /// A search property representation of the CourseLevelNameContains field for a record in the dbo.CourseLevel data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public String CourseLevelNameContains
        {
            get { return _courseLevelNameContains; }
            set { _courseLevelNameContains = value; }
        }

        private IList<String> _courseLevelNameIsIn;

        /// <summary>
        /// A search property representation of the CourseLevelNameIsIn field for a record in the dbo.CourseLevel data table. 
        /// </summary>
        [EntityProperty(Size = 50, SearchOnly = true)]
        public IList<String> CourseLevelNameIsIn
        {
            get
            {
                if (_courseLevelNameIsIn == null)
                {
                    _courseLevelNameIsIn = new List<String>();
                }
                return _courseLevelNameIsIn;
            }
            set { _courseLevelNameIsIn = value; }
        }

    }

    [Serializable]
    public partial class CourseLevelExtended : EntityExtendedBase
    {
        internal CourseLevelExtended() { }
    }
}