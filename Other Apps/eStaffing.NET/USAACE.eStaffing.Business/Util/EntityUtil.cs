using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.eStaffing.Domain.FormEntities;

namespace USAACE.eStaffing.Business.Util
{
    public static class EntityUtil
    {
        public static Decimal GetAttendeeTotalCost(TDYAttendee attendee)
        {
            return attendee.PerDiemCost.GetValueOrDefault(0) + attendee.LodgingCost.GetValueOrDefault(0) + attendee.TravelCost.GetValueOrDefault(0) +
                attendee.RentalCost.GetValueOrDefault(0) + attendee.OtherCost.GetValueOrDefault(0);
        }
    }
}
