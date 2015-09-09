using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class TaskingType : LookupEntityBase
    {
        private String _taskingTypeName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String TaskingTypeName
        {
            get { return _taskingTypeName; }
            set { _taskingTypeName = value; }
        }
    }
}
