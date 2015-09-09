using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class AwardReason : LookupEntityBase
    {
        private String _awardReasonName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String AwardReasonName
        {
            get { return _awardReasonName; }
            set { _awardReasonName = value; }
        }
    }
}
