using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Domain.LookupEntities
{
    [Serializable]
    public class TravelMode : LookupEntityBase
    {
        private String _travelModeName;

        /// <summary>
        /// A property representation of the Name field for a record in the dbo.AwardSheet data table. 
        /// </summary>
        public String TravelModeName
        {
            get { return _travelModeName; }
            set { _travelModeName = value; }
        }
    }
}
