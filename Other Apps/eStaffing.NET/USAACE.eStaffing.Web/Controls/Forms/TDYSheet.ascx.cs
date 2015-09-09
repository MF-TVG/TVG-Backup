using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using USAACE.Common;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.Domain.FormEntities;
using USAACE.eStaffing.Domain.LookupEntities;
using USAACE.eStaffing.Presentation.Presenters.Controls.Forms;
using USAACE.eStaffing.Presentation.Views.Controls.Forms;

namespace USAACE.eStaffing.Web.Controls.Forms
{
    public partial class TDYSheet : FormControl, ITDYSheetView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private TDYSheetPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public TDYSheetPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new TDYSheetPresenter(this);
                }

                return _presenter;
            }
        }

        protected override void LoadForm()
        {
            Presenter.LoadLookups();
            Presenter.Load();
        }

        protected override void SaveForm()
        {
            Presenter.Save();
        }

        protected override void SaveDefault()
        {
            Presenter.SaveDefault();
        }

        /// <summary>
        /// Event occurring when an item is bound to the Attendees repeater, it gets information about the attendee and displays the information
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void dlAttendees_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is TDYAttendee)
                {
                    TDYAttendee attendee = e.Item.DataItem as TDYAttendee;

                    (e.Item.FindControl("ltrAttendeeName") as Literal).Text = attendee.Name;
                    (e.Item.FindControl("ltrAttendeeDuty") as Literal).Text = attendee.DutyPosition;
                    (e.Item.FindControl("ltrAttendeePerDiem") as Literal).Text = attendee.PerDiemCost.GetValueOrDefault(0).ToString("C");
                    (e.Item.FindControl("ltrAttendeeLodge") as Literal).Text = attendee.LodgingCost.GetValueOrDefault(0).ToString("C");
                    (e.Item.FindControl("ltrAttendeeTravel") as Literal).Text = attendee.TravelCost.GetValueOrDefault(0).ToString("C");
                    (e.Item.FindControl("ltrAttendeeTravelMode") as Literal).Text = attendee.TDYTravelMode;
                    (e.Item.FindControl("ltrAttendeeRental") as Literal).Text = attendee.RentalCost.GetValueOrDefault(0).ToString("C");
                    (e.Item.FindControl("ltrAttendeeOther") as Literal).Text = attendee.OtherCost.GetValueOrDefault(0).ToString("C");
                    (e.Item.FindControl("ltrAttendeeTotal") as Literal).Text = attendee.TotalCost.GetValueOrDefault(0).ToString("C");
                    (e.Item.FindControl("imbEditAttendee") as ImageButton).CommandArgument = attendee.ListIndex.ToString();
                    (e.Item.FindControl("imbDeleteAttendee") as ImageButton).CommandArgument = attendee.ListIndex.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when Add Attendee is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnAddAttendee_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedAttendeeID = null;
                Presenter.LoadAttendee();
                mpEditAttendee.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when Delete Attendee is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void imbEditAttendee_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedAttendeeID = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                Presenter.LoadAttendee();
                mpEditAttendee.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when Delete Attendee is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The item arguments of the event</param>
        protected void imbDeleteAttendee_Command(object sender, CommandEventArgs e)
        {
            try
            {
                this.SelectedAttendeeID = e.CommandArgument.ToStringSafe().ToNullable<Int32>();
                mpDeleteAttendeeConfirm.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteAttendeeConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteAttendee();
                mpDeleteAttendeeConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteAttendeeCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpDeleteAttendeeConfirm.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnSaveAttendee_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveAttendee();
                mpEditAttendee.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancelAttendee_Click(object sender, EventArgs e)
        {
            try
            {
                mpEditAttendee.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Validates that Start Date and End Date have a value and that End Date comes after Start Date
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments for the event</param>
        protected void cvDates_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = dcDateStart.SelectedDate.HasValue && dcDateEnd.SelectedDate.HasValue && dcDateEnd.SelectedDate > dcDateStart.SelectedDate;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Validates that there is at least one attendee
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments for the event</param>
        protected void cvAttendees_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = this.Attendees.Count() > 0;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public String ActionOffice
        {
            get
            {
                return txtActionOffice.Text;
            }
            set
            {
                txtActionOffice.Text = value;
            }
        }

        public String PhoneNumber
        {
            get
            {
                return txtPhoneNumber.Text;
            }
            set
            {
                txtPhoneNumber.Text = value;
            }
        }

        public Nullable<DateTime> SuspenseDate
        {
            get
            {
                return dcSuspenseDate.SelectedDate;
            }
            set
            {
                dcSuspenseDate.SelectedDate = value;
            }
        }

        public Nullable<DateTime> FormDate
        {
            get
            {
                return dcDate.SelectedDate;
            }
            set
            {
                dcDate.SelectedDate = value;
            }
        }

        public String Subject
        {
            get
            {
                return txtSubject.Text;
            }
            set
            {
                txtSubject.Text = value;
            }
        }

        public String ActionOfficer
        {
            get
            {
                return txtActionOfficer.Text;
            }
            set
            {
                txtActionOfficer.Text = value;
            }
        }

        public Nullable<Boolean> Signature
        {
            get
            {
                return chkSignature.Checked;
            }
            set
            {
                chkSignature.Checked = value == true;
            }
        }

        public Nullable<Boolean> Approval
        {
            get
            {
                return chkApproval.Checked;
            }
            set
            {
                chkApproval.Checked = value == true;
            }
        }

        public Nullable<Boolean> Information
        {
            get
            {
                return chkInformation.Checked;
            }
            set
            {
                chkInformation.Checked = value == true;
            }
        }

        public Nullable<Boolean> ReadAhead
        {
            get
            {
                return chkReadAhead.Checked;
            }
            set
            {
                chkReadAhead.Checked = value == true;
            }
        }

        public String MissionEssential
        {
            get
            {
                return txtMissionEssential.Text;
            }
            set
            {
                txtMissionEssential.Text = value;
            }
        }

        public String Purpose
        {
            get
            {
                return txtPurpose.Text;
            }
            set
            {
                txtPurpose.Text = value;
            }
        }

        public String Location
        {
            get
            {
                return txtLocation.Text;
            }
            set
            {
                txtLocation.Text = value;
            }
        }

        public Nullable<DateTime> DateStart
        {
            get
            {
                return dcDateStart.SelectedDate;
            }
            set
            {
                dcDateStart.SelectedDate = value;
            }
        }

        public Nullable<DateTime> DateEnd
        {
            get
            {
                return dcDateEnd.SelectedDate;
            }
            set
            {
                dcDateEnd.SelectedDate = value;
            }
        }

        public String Funding
        {
            get
            {
                return hteFunding.Text;
            }
            set
            {
                hteFunding.Text = value;
            }
        }

        public String Summary
        {
            get
            {
                return hteSummary.Text;
            }
            set
            {
                hteSummary.Text = value;
            }
        }

        /// <summary>
        /// The list of attendees for this form
        /// </summary>
        public IList<TDYAttendee> Attendees
        {
            get
            {
                return this.ViewState["Attendees"] as IList<TDYAttendee>;
            }
            set
            {
                this.ViewState["Attendees"] = value;

                dlAttendees.DataSource = value;
                dlAttendees.DataBind();
            }
        }

        public Nullable<Int32> SelectedAttendeeID
        {
            get
            {
                return this.ViewState["SelectedAttendeeID"].ToNullable<Int32>();
            }
            set
            {
                this.ViewState["SelectedAttendeeID"] = value;
            }
        }

        public Decimal PerDiemTotal
        {
            set
            {
                ltrAttendeePerDiemTotal.Text = value.ToString("C");
            }
        }

        public Decimal LodgingTotal
        {
            set
            {
                ltrAttendeeLodgeTotal.Text = value.ToString("C");
            }
        }

        public Decimal TravelTotal
        {
            set
            {
                ltrAttendeeTravelTotal.Text = value.ToString("C");
            }
        }

        public Decimal RentalTotal
        {
            set
            {
                ltrAttendeeRentalTotal.Text = value.ToString("C");
            }
        }

        public Decimal OtherTotal
        {
            set
            {
                ltrAttendeeOtherTotal.Text = value.ToString("C");
            }
        }

        public Decimal AttendeeTotal
        {
            set
            {
                ltrAttendeeTotalTotal.Text = value.ToString("C");
            }
        }

        public IList<TravelMode> TravelModes
        {
            set
            {
                ddlAttendeeTravelMode.Items.Clear();

                foreach (TravelMode mode in value)
                {
                    ddlAttendeeTravelMode.Items.Add(new ListItem(mode.TravelModeName, mode.TravelModeName));
                }
            }
        }

        public String AttendeeName
        {
            get
            {
                return txtAttendeeName.Text;
            }
            set
            {
                txtAttendeeName.Text = value;
            }
        }

        public String AttendeeDuty
        {
            get
            {
                return txtAttendeeDuty.Text;
            }
            set
            {
                txtAttendeeDuty.Text = value;
            }
        }

        public Nullable<Decimal> AttendeePerDiem
        {
            get
            {
                return txtAttendeePerDiem.Text.ToNullable<Decimal>();
            }
            set
            {
                txtAttendeePerDiem.Text = value.ToStringSafe();
            }
        }

        public Nullable<Decimal> AttendeeLodge
        {
            get
            {
                return txtAttendeeLodge.Text.ToNullable<Decimal>();
            }
            set
            {
                txtAttendeeLodge.Text = value.ToStringSafe();
            }
        }

        public Nullable<Decimal> AttendeeTravel
        {
            get
            {
                return txtAttendeeTravel.Text.ToNullable<Decimal>();
            }
            set
            {
                txtAttendeeTravel.Text = value.ToStringSafe();
            }
        }

        public String AttendeeTravelMode
        {
            get
            {
                return ddlAttendeeTravelMode.SelectedValue;
            }
            set
            {
                ddlAttendeeTravelMode.SelectedValue = value;
            }
        }

        public Nullable<Decimal> AttendeeRental
        {
            get
            {
                return txtAttendeeRental.Text.ToNullable<Decimal>();
            }
            set
            {
                txtAttendeeRental.Text = value.ToStringSafe();
            }
        }

        public Nullable<Decimal> AttendeeOther
        {
            get
            {
                return txtAttendeeOther.Text.ToNullable<Decimal>();
            }
            set
            {
                txtAttendeeOther.Text = value.ToStringSafe();
            }
        }

        internal override void SetEnabledState(Boolean enabled)
        {
            txtActionOffice.Enabled = enabled;
            txtPhoneNumber.Enabled = enabled;
            dcSuspenseDate.Enabled = enabled;
            dcDate.Enabled = enabled;

            txtSubject.Enabled = enabled;
            txtActionOfficer.Enabled = enabled;

            chkSignature.Enabled = enabled;
            chkApproval.Enabled = enabled;
            chkInformation.Enabled = enabled;
            chkReadAhead.Enabled = enabled;

            txtMissionEssential.Enabled = enabled;
            txtPurpose.Enabled = enabled;
            txtLocation.Enabled = enabled;
            dcDateStart.Enabled = enabled;
            dcDateEnd.Enabled = enabled;
            hteFunding.Enabled = enabled;
            hteSummary.Enabled = enabled;

            btnAddAttendee.Visible = enabled;

            dlAttendees.Enabled = enabled;

            /*foreach (RepeaterItem item in dlAttendees.Items)
            {
                (item.FindControl("imbEditAttendee") as ImageButton).Visible = enabled;
                (item.FindControl("imbDeleteAttendee") as ImageButton).Visible = enabled;
            }*/
        }
    }
}