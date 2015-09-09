using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class TaskingSource : LookupEntityBase
    {
        private String _taskingSourceName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String TaskingSourceName
        {
            get { return _taskingSourceName; }
            set { _taskingSourceName = value; }
        }
    }
}
