using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class Form2028CourseType : LookupEntityBase
    {
        private String _courseTypeName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String CourseTypeName
        {
            get { return _courseTypeName; }
            set { _courseTypeName = value; }
        }
    }
}
