using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.Common.Presentation;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Business.Util;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Domain.LookupEntities;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;

namespace USAACE.eStaffing.Presentation.Presenters.Controls.Forms
{
    public class TDYSheetPresenter : BasePresenter
    {
        /// <summary>
        /// The ITDYSheetView for the TDYSheetPresenter
        /// </summary>
        private new ITDYSheetView View
        {
            get
            {
                return base.View as ITDYSheetView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ITDYSheetView
        /// </summary>
        /// <param name="view">The ITDYSheetView</param>
        public TDYSheetPresenter(ITDYSheetView view)
        {
            base.View = view;
        }

        public void LoadLookups()
        {
            this.View.TravelModes = FormLookupUtil.LoadSpecificLookup<TravelMode>(this.View.FormTypeID, this.View.SubmitOrganizationID, "TravelMode");
        }

        public void Load()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                TDYSheet tdySheet = FormDataUtil.LoadSpecificFormData<TDYSheet>(formData);

                this.View.ActionOffice = tdySheet.ActionOffice;
                this.View.PhoneNumber = tdySheet.PhoneNumber;
                this.View.SuspenseDate = tdySheet.SuspenseDate;
                this.View.FormDate = tdySheet.TransmittalDate;
                this.View.Subject = tdySheet.Subject;
                this.View.ActionOfficer = tdySheet.ActionOfficer;
                this.View.Signature = tdySheet.Signature;
                this.View.Approval = tdySheet.Approval;
                this.View.Information = tdySheet.Information;
                this.View.ReadAhead = tdySheet.ReadAhead;
                this.View.MissionEssential = tdySheet.MissionEssential;
                this.View.Purpose = tdySheet.Purpose;
                this.View.Location = tdySheet.Location;
                this.View.DateStart = tdySheet.StartDate;
                this.View.DateEnd = tdySheet.EndDate;
                this.View.Funding = tdySheet.Funding;
                this.View.Summary = tdySheet.Summary;

                IList<TDYAttendee> attendees = tdySheet.TDYAttendees;

                foreach (TDYAttendee attendeeItem in attendees)
                {
                    attendeeItem.TotalCost = EntityUtil.GetAttendeeTotalCost(attendeeItem);
                }

                this.View.Attendees = attendees;
            }

            TotalAttendees();
        }

        public void Save()
        {
            if (this.View.FormID.HasValue)
            {
                FormData formData = new FormData();
                formData.FormID = this.View.FormID;

                formData = DataService.LoadFormData(formData);

                TDYSheet tdySheet = FormDataUtil.LoadSpecificFormData<TDYSheet>(formData);

                tdySheet.ActionOffice = this.View.ActionOffice;
                tdySheet.PhoneNumber = this.View.PhoneNumber;
                tdySheet.SuspenseDate = this.View.SuspenseDate;
                tdySheet.TransmittalDate = this.View.FormDate;
                tdySheet.Subject = this.View.Subject;
                tdySheet.ActionOfficer = this.View.ActionOfficer;
                tdySheet.Signature = this.View.Signature;
                tdySheet.Approval = this.View.Approval;
                tdySheet.Information = this.View.Information;
                tdySheet.ReadAhead = this.View.ReadAhead;
                tdySheet.MissionEssential = this.View.MissionEssential;
                tdySheet.Purpose = this.View.Purpose;
                tdySheet.Location = this.View.Location;
                tdySheet.StartDate = this.View.DateStart;
                tdySheet.EndDate = this.View.DateEnd;
                tdySheet.Funding = this.View.Funding;
                tdySheet.Summary = this.View.Summary;

                tdySheet.TDYAttendees = (List<TDYAttendee>)this.View.Attendees;

                DataService.SaveFormData(formData, tdySheet);

                Form form = new Form();
                form.FormID = this.View.FormID;

                form = DataService.LoadForm(form);

                FormUtil.SetFormTypeValues(form, tdySheet);

                form = DataService.SaveForm(form);

                Load();
            }
        }

        public void LoadAttendee()
        {
            if (this.View.SelectedAttendeeID.HasValue)
            {
                TDYAttendee attendee = this.View.Attendees.FirstOrDefault(x => x.ListIndex == this.View.SelectedAttendeeID);

                this.View.AttendeeName = attendee.Name;
                this.View.AttendeeDuty = attendee.DutyPosition;
                this.View.AttendeePerDiem = attendee.PerDiemCost;
                this.View.AttendeeLodge = attendee.LodgingCost;
                this.View.AttendeeTravel = attendee.TravelCost;
                this.View.AttendeeTravelMode = attendee.TDYTravelMode;
                this.View.AttendeeRental = attendee.RentalCost;
                this.View.AttendeeOther = attendee.OtherCost;
            }
            else
            {
                this.View.AttendeeName = null;
                this.View.AttendeeDuty = null;
                this.View.AttendeePerDiem = null;
                this.View.AttendeeLodge = null;
                this.View.AttendeeTravel = null;
                this.View.AttendeeTravelMode = null;
                this.View.AttendeeRental = null;
                this.View.AttendeeOther = null;
            }
        }

        public void SaveAttendee()
        {
            IList<TDYAttendee> attendees = this.View.Attendees;

            TDYAttendee attendee = this.View.SelectedAttendeeID.HasValue ?
                attendees.FirstOrDefault(x => x.ListIndex == this.View.SelectedAttendeeID) :
                new TDYAttendee { ListIndex = attendees.Count > 0 ? attendees.Last().ListIndex + 1 : 0 };

            attendee.Name = this.View.AttendeeName;
            attendee.DutyPosition = this.View.AttendeeDuty;
            attendee.PerDiemCost = this.View.AttendeePerDiem;
            attendee.LodgingCost = this.View.AttendeeLodge;
            attendee.TravelCost = this.View.AttendeeTravel;
            attendee.TDYTravelMode = this.View.AttendeeTravelMode;
            attendee.RentalCost = this.View.AttendeeRental;
            attendee.OtherCost = this.View.AttendeeOther;
            attendee.TotalCost = EntityUtil.GetAttendeeTotalCost(attendee);

            if (this.View.SelectedAttendeeID.HasValue == false)
            {
                attendees.Add(attendee);
            }

            this.View.Attendees = attendees;

            TotalAttendees();
        }

        public void DeleteAttendee()
        {
            if (this.View.SelectedAttendeeID.HasValue)
            {
                IList<TDYAttendee> attendees = this.View.Attendees;

                TDYAttendee attendee = attendees.FirstOrDefault(x => x.ListIndex == this.View.SelectedAttendeeID);

                attendees.Remove(attendee);

                this.View.Attendees = attendees;

                TotalAttendees();
            }
        }

        public void TotalAttendees()
        {
            IEnumerable<TDYAttendee> validAttendees = this.View.Attendees;

            if (validAttendees.Count() > 0)
            {
                this.View.PerDiemTotal = validAttendees.Sum(x => x.PerDiemCost.GetValueOrDefault(0));
                this.View.LodgingTotal = validAttendees.Sum(x => x.LodgingCost.GetValueOrDefault(0));
                this.View.TravelTotal = validAttendees.Sum(x => x.TravelCost.GetValueOrDefault(0));
                this.View.RentalTotal = validAttendees.Sum(x => x.RentalCost.GetValueOrDefault(0));
                this.View.OtherTotal = validAttendees.Sum(x => x.OtherCost.GetValueOrDefault(0));
                this.View.AttendeeTotal = validAttendees.Sum(x => (x.TotalCost).GetValueOrDefault(0));
            }
            else
            {
                this.View.PerDiemTotal = 0;
                this.View.LodgingTotal = 0;
                this.View.TravelTotal = 0;
                this.View.RentalTotal = 0;
                this.View.OtherTotal = 0;
                this.View.AttendeeTotal = 0;
            }
        }

        public void SaveDefault()
        {
            TDYSheet tdySheet = new TDYSheet();

            tdySheet.ActionOffice = this.View.ActionOffice;
            tdySheet.PhoneNumber = this.View.PhoneNumber;
            tdySheet.SuspenseDate = this.View.SuspenseDate;
            tdySheet.TransmittalDate = this.View.FormDate;
            tdySheet.Subject = this.View.Subject;
            tdySheet.ActionOfficer = this.View.ActionOfficer;
            tdySheet.Signature = this.View.Signature;
            tdySheet.Approval = this.View.Approval;
            tdySheet.Information = this.View.Information;
            tdySheet.ReadAhead = this.View.ReadAhead;
            tdySheet.MissionEssential = this.View.MissionEssential;
            tdySheet.Purpose = this.View.Purpose;
            tdySheet.Location = this.View.Location;
            tdySheet.StartDate = this.View.DateStart;
            tdySheet.EndDate = this.View.DateEnd;
            tdySheet.Funding = this.View.Funding;
            tdySheet.Summary = this.View.Summary;

            tdySheet.TDYAttendees = (List<TDYAttendee>)this.View.Attendees;

            OrganizationFormDefault formDefault = new OrganizationFormDefault();
            formDefault.OrganizationGroupID = this.View.SubmitGroupID;
            formDefault.FormTypeID = this.View.FormTypeID;

            DataService.SaveOrganizationFormDefault(formDefault, tdySheet);
        }
    }
}
