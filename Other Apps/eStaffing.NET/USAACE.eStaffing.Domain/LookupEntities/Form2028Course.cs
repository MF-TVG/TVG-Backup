using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class Form2028Course : LookupEntityBase
    {
        private String _courseType;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String CourseType
        {
            get { return _courseType; }
            set { _courseType = value; }
        }

        private String _courseNumber;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String CourseNumber
        {
            get { return _courseNumber; }
            set { _courseNumber = value; }
        }

        private String _courseTitle;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String CourseTitle
        {
            get { return _courseTitle; }
            set { _courseTitle = value; }
        }
    }
}
