using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class TaskingSecurityLevel : LookupEntityBase
    {
        private String _taskingSecurityLevelName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String TaskingSecurityLevelName
        {
            get { return _taskingSecurityLevelName; }
            set { _taskingSecurityLevelName = value; }
        }
    }
}
