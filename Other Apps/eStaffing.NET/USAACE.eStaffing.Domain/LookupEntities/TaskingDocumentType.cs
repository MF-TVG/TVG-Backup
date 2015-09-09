using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class TaskingDocumentType : LookupEntityBase
    {
        private String _taskingDocumentTypeName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String TaskingDocumentTypeName
        {
            get { return _taskingDocumentTypeName; }
            set { _taskingDocumentTypeName = value; }
        }
    }
}
