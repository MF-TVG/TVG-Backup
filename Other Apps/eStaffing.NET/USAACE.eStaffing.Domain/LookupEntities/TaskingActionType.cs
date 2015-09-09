using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class TaskingActionType : LookupEntityBase
    {
        private String _taskingActionTypeName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String TaskingActionTypeName
        {
            get { return _taskingActionTypeName; }
            set { _taskingActionTypeName = value; }
        }
    }
}
