using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Domain.LookupEntities;

namespace USAACE.eStaffing.Presentation.Views.Controls.Forms
{
    public interface ITDYSheetView : IFormControlView
    {
        String ActionOffice { get; set; }

        String PhoneNumber { get; set; }

        Nullable<DateTime> SuspenseDate { get; set; }

        Nullable<DateTime> FormDate { get; set; }

        String Subject { get; set; }

        String ActionOfficer { get; set; }

        Nullable<Boolean> Signature { get; set; }

        Nullable<Boolean> Approval { get; set; }

        Nullable<Boolean> Information { get; set; }

        Nullable<Boolean> ReadAhead { get; set; }

        String MissionEssential { get; set; }

        String Purpose { get; set; }

        String Location { get; set; }

        Nullable<DateTime> DateStart { get; set; }

        Nullable<DateTime> DateEnd { get; set; }

        String Funding { get; set; }

        String Summary { get; set; }

        IList<TDYAttendee> Attendees { get; set; }

        Nullable<Int32> SelectedAttendeeID { get; }

        Decimal PerDiemTotal { set; }

        Decimal LodgingTotal { set; }

        Decimal TravelTotal { set; }

        Decimal RentalTotal { set; }

        Decimal OtherTotal { set; }

        Decimal AttendeeTotal { set; }

        IList<TravelMode> TravelModes { set; }

        String AttendeeName { get; set; }

        String AttendeeDuty { get; set; }

        Nullable<Decimal> AttendeePerDiem { get; set; }

        Nullable<Decimal> AttendeeLodge { get; set; }

        Nullable<Decimal> AttendeeTravel { get; set; }

        String AttendeeTravelMode { get; set; }

        Nullable<Decimal> AttendeeRental { get; set; }

        Nullable<Decimal> AttendeeOther { get; set; }
    }
}
