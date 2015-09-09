using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class SchoolsRequestType : LookupEntityBase
    {
        private String _requestTypeName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String RequestTypeName
        {
            get { return _requestTypeName; }
            set { _requestTypeName = value; }
        }
    }
}
