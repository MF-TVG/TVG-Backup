using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class TaskingLocation : LookupEntityBase
    {
        private String _taskingLocationName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String TaskingLocationName
        {
            get { return _taskingLocationName; }
            set { _taskingLocationName = value; }
        }
    }
}
