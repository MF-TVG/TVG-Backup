using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class SchoolsChecklistItem : LookupEntityBase
    {
        private String _requestType;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String RequestType
        {
            get { return _requestType; }
            set { _requestType = value; }
        }

        private String _checklistItemName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String ChecklistItemName
        {
            get { return _checklistItemName; }
            set { _checklistItemName = value; }
        }
    }
}
