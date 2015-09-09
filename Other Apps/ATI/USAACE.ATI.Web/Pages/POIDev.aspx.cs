using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.ATI.Business.Constants;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Presentation.Presenters.Pages;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.ATI.Web.Enum;
using USAACE.Common;
using USAACE.Common.Web.Controls;

namespace USAACE.ATI.Web.Pages
{
    public partial class POIDev : BasePage, IPOIDevView
    {
        private const Double POI_DAYS_COLUMNS = 12.0;

        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private POIDevPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public POIDevPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new POIDevPresenter(this);
                }

                return _presenter;
            }
        }

        /// <summary>
        /// Loads the control
        /// </summary>
        protected override void LoadPage()
        {
            try
            {
                if (!IsPostBack)
                {
                    Presenter.Load();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the POI text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbPOI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadPOI();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the POI days text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void ncPOIDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.ResetFlightDays();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the objective text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbObjective_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadPOIDays();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update POI button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdatePOI_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("POI");

                if (Page.IsValid)
                {
                    Presenter.Save();
                    this.ShowNotice(MessageConstants.POI_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete POI button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeletePOI_Click(object sender, EventArgs e)
        {
            try
            {
                mpConfirmDeletePOI.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete POI Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeletePOIConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Delete();
                mpConfirmDeletePOI.Hide();
                this.ShowNotice(MessageConstants.POI_DELETE_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete POI Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeletePOICancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpConfirmDeletePOI.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Copy POI button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCreatePOICopy_Click(object sender, EventArgs e)
        {
            try
            {
                mpCopyPOI.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Copy POI Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCopyPOIConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("CopyPOI");

                if (Page.IsValid)
                {
                    Presenter.CreateCopy();
                    mpCopyPOI.Hide();
                    this.ShowNotice(MessageConstants.POI_COPY_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Copy POI cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCopyPOICancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpCopyPOI.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the POI Report button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnReportPOI_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.GeneratePOIReport();
                mpPOIReport.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when an item is bound to the flight days list
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The data list item arguments of the event</param>
        protected void dlFlightDays_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is POIFlightDay)
                {
                    POIFlightDay value = e.Item.DataItem as POIFlightDay;

                    if (value != null)
                    {
                        Label lblDayNumber = e.Item.FindControl("lblDayNumber") as Label;

                        if (lblDayNumber != null)
                        {
                            lblDayNumber.Text = value.FlightDayNumber.ToStringSafe();
                            lblDayNumber.Visible = true;
                        }

                        NumericControl ncDayUnits = e.Item.FindControl("ncDayUnits") as NumericControl;

                        if (ncDayUnits != null)
                        {
                            ncDayUnits.TabIndex = Convert.ToInt16(1000 + value.FlightDayNumber.Value);
                            ncDayUnits.Value = value.Units;
                            ncDayUnits.TextBoxCssClass = value.Units > 0 ? "poiDay" : null;
                            ncDayUnits.Visible = true;
                            ncDayUnits.Enabled = dlFlightDays.Enabled;
                        }

                        CheckBox chkDayEval = e.Item.FindControl("chkDayEval") as CheckBox;

                        if (chkDayEval != null)
                        {
                            chkDayEval.Checked = value.Evaluation == true;
                            chkDayEval.Visible = true;
                            chkDayEval.Enabled = dlFlightDays.Enabled;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Close POI Report button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnClosePOIReport_Click(object sender, EventArgs e)
        {
            try
            {
                mpPOIReport.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// The list of POIs
        /// </summary>
        public IList<POI> POIs
        {
            set
            {
                cmbPOI.Items.Clear();

                cmbPOI.Items.Add(new ListItem("-- New POI --", String.Empty));

                foreach (POI poi in value)
                {
                    cmbPOI.Items.Add(new ListItem(poi.POIName, poi.POIID.ToStringSafe()));
                }

                cmbPOI.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected POI
        /// </summary>
        public Nullable<Int32> POIID
        {
            get
            {
                return cmbPOI.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbPOI.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The value for POI name
        /// </summary>
        public String POIName
        {
            get
            {
                return txtPOIName.Text;
            }
            set
            {
                txtPOIName.Text = value;
            }
        }

        /// <summary>
        /// The value for number of POI days
        /// </summary>
        public Nullable<Int16> POIDays
        {
            get
            {
                return ncPOIDays.Value.ToNullable<Int16>();
            }
            set
            {
                ncPOIDays.Value = value;
            }
        }

        /// <summary>
        /// The value for POI mobilization
        /// </summary>
        public Nullable<Boolean> Mobilization
        {
            get
            {
                return chkMobilization.Checked;
            }
            set
            {
                chkMobilization.Checked = value == true;
            }
        }

        /// <summary>
        /// The value for POI effective date
        /// </summary>
        public Nullable<DateTime> EffectiveDate
        {
            get
            {
                return dcEffectiveDate.SelectedDate;
            }
            set
            {
                dcEffectiveDate.SelectedDate = value;
            }
        }

        /// <summary>
        /// The calculated value for if this is a new POI
        /// </summary>
        public Boolean IsNewPOI
        {
            set
            {
                btnDeletePOI.Visible = !value;
                btnCreatePOICopy.Visible = !value;
                btnReportPOI.Visible = !value;
            }
        }

        /// <summary>
        /// The list of objectives
        /// </summary>
        public IList<Objective> Objectives
        {
            set
            {
                cmbObjective.Items.Clear();

                cmbObjective.Items.Add(new ListItem("-- Select an Objective --", String.Empty));

                foreach (Objective objective in value)
                {
                    cmbObjective.Items.Add(new ListItem(objective.ObjectiveName, objective.ObjectiveID.ToStringSafe()));
                }

                cmbObjective.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID for the currently selected objective
        /// </summary>
        public Nullable<Int32> ObjectiveID
        {
            get
            {
                return cmbObjective.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbObjective.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The current list of POI flight days
        /// </summary>
        public IList<POIFlightDay> FlightDays
        {
            get
            {
                IList<POIFlightDay> flightDays = this.ViewState["POIFlightDays"] as IList<POIFlightDay>;

                for (int i = 0; i < flightDays.Count; i++)
                {
                    DataListItem item = dlFlightDays.Items[i];

                    POIFlightDay flightDay = flightDays[i];

                    flightDay.FlightDayNumber = (item.FindControl("lblDayNumber") as Label).Text.ToNullable<Int16>();
                    flightDay.Units = (item.FindControl("ncDayUnits") as NumericControl).Value.ToNullable<Decimal>();
                    flightDay.Evaluation = (item.FindControl("chkDayEval") as CheckBox).Checked;
                }

                return flightDays;
            }
            set
            {
                this.ViewState["POIFlightDays"] = value;

                dlFlightDays.RepeatColumns = Math.Max(1, Convert.ToInt32(Math.Ceiling(value.Count / POI_DAYS_COLUMNS)));

                pnlObjectiveHours.Visible = value.Count > 0;

                dlFlightDays.DataSource = FormatFlightDays(value);
                dlFlightDays.DataBind();
            }
        }

        /// <summary>
        /// The calculated value for total of objective hours
        /// </summary>
        public Nullable<Decimal> ObjectiveHours
        {
            set
            {
                ltrObjectiveHours.Text = value.ToStringSafe("0.00");
            }
        }

        /// <summary>
        /// The calculated value for total of POI hours
        /// </summary>
        public Nullable<Decimal> TotalHours
        {
            set
            {
                ltrTotalHours.Text = value.ToStringSafe("0.00");
            }
        }

        /// <summary>
        /// The value for the copied POI name
        /// </summary>
        public String CopyPOIName
        {
            get
            {
                return txtCopyPOIName.Text;
            }
            set
            {
                txtCopyPOIName.Text = value;
            }
        }

        /// <summary>
        /// The data for the POI report
        /// </summary>
        public DataTable POIReport
        {
            set
            {
                dlReport.DataSource = value;
                dlReport.DataBind();
            }
        }

        /// <summary>
        /// The name of the POI report
        /// </summary>
        public String POIReportName
        {
            set
            {
                lblPOIReportName.Text = value;
            }
        }

        /// <summary>
        /// The length in days of the POI report
        /// </summary>
        public String POIReportLength
        {
            set
            {
                ltrPOIReportLength.Text = value;
            }
        }

        /// <summary>
        /// Formats the flight days list such that it shows in columns of 12 by padding with null entries
        /// </summary>
        /// <param name="flightDays">The original list of flight days</param>
        /// <returns>A padded list of flight days</returns>
        private IList<POIFlightDay> FormatFlightDays(IList<POIFlightDay> flightDays)
        {
            IList<POIFlightDay> formattedList = new List<POIFlightDay>();

            if (flightDays != null)
            {
                foreach (POIFlightDay value in flightDays)
                {
                    formattedList.Add(value);
                }

                while (formattedList.Count % POI_DAYS_COLUMNS != 0)
                {
                    formattedList.Add(null);
                }
            }

            return formattedList;
        }

        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        public Boolean AllowEditing
        {
            set
            {
                txtPOIName.Enabled = value;
                ncPOIDays.Enabled = value;
                chkMobilization.Enabled = value;
                dlFlightDays.Enabled = value;
                dcEffectiveDate.Enabled = value;
                btnUpdatePOI.Enabled = value;
                btnDeletePOI.Enabled = value;
            }
        }
    }
}