using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class AwardLevel : LookupEntityBase
    {
        private String _awardLevelName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String AwardLevelName
        {
            get { return _awardLevelName; }
            set { _awardLevelName = value; }
        }
    }
}
