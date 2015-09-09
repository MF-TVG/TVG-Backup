using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.ATI.Business.Constants;
using USAACE.ATI.Business.Util;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Presentation.Presenters.Pages;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.ATI.Web.Enum;
using USAACE.ATI.Web.Util;
using USAACE.Common;
using USAACE.Common.Web.Controls;

namespace USAACE.ATI.Web.Pages
{
    public partial class FlightHours : BasePage, IFlightHoursView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private FlightHoursPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public FlightHoursPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new FlightHoursPresenter(this);
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
        /// Event taking place when the program text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbProgramName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadCourses();
                Presenter.LoadHours();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the hours type selection changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void rblHoursType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.SetEntryFields();
                Presenter.LoadHours();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the forecast hours checkbox is checked or unchecked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void chkForecastHours_Changed(object sender, EventArgs e)
        {
            try
            {
                Presenter.SetEntryFields();
                Presenter.LoadHours();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the course text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbCourseName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadCurrentCourse();
                Presenter.LoadHours();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when a parameter selection changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbParameter_Changed(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadHours();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when a row is bound to the flight hours data grid
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The grid item arguments of the event</param>
        protected void dlHours_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is ActualHours)
                {
                    ActualHours currentHours = e.Item.DataItem as ActualHours;

                    //(e.Item.FindControl("dcCutoffDate") as DateControl).Enabled = dlHours.Enabled;
                    (e.Item.FindControl("dcCutoffDate") as DateControl).SelectedDate = currentHours.CutoffDate;
                    (e.Item.FindControl("ncHours") as NumericControl).Value = currentHours.HoursAmount;
                    (e.Item.FindControl("ltrMonth") as Literal).Text = currentHours.CutoffDate.HasValue ?
                        CalendarUtil.Get1352MonthName(currentHours.CutoffDate.Value) : null;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Hours button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateHours_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("Hours");

                if (Page.IsValid)
                {
                    if (this.Hours.Any(x => x.ExtendedProperties.MarkForDeletion == true))
                    {
                        mpConfirmDeleteHours.Show();
                    }
                    else
                    {
                        Presenter.SaveHours();
                        this.ShowNotice(MessageConstants.FLIGHT_HOURS_UPDATE_SUCCESS, NoticeType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Add Hours button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnAddHours_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.AddHours();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Hours Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteHoursConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.SaveHours();
                this.ShowNotice(MessageConstants.FLIGHT_HOURS_UPDATE_DELETE_SUCCESS, NoticeType.Information);
                mpConfirmDeleteHours.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Hours Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteHoursCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpConfirmDeleteHours.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete All Hours button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteHours_Click(object sender, EventArgs e)
        {
            try
            {
                mpConfirmDeleteAllHours.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete All Hours Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteAllHoursConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteHours();
                this.ShowNotice(MessageConstants.FLIGHT_HOURS_ALL_DELETE_SUCCESS, NoticeType.Information);
                mpConfirmDeleteAllHours.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete All Hours Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteAllHoursCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpConfirmDeleteAllHours.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the flight hours are validated for save
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments of the event</param>
        protected void cvHours_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = this.Hours.All(x => x.CutoffDate.HasValue && x.HoursAmount.HasValue);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// The list of programs
        /// </summary>
        public IList<Program> Programs
        {
            set
            {
                cmbProgramName.Items.Clear();

                cmbProgramName.Items.Add(new ListItem("-- Select a Program --", String.Empty));

                foreach (Program program in value)
                {
                    cmbProgramName.Items.Add(new ListItem(program.ProgramName, program.ProgramID.ToStringSafe()));
                }

                cmbProgramName.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected program
        /// </summary>
        public Nullable<Int32> ProgramID
        {
            get
            {
                return cmbProgramName.SelectedValue.ToNullable<Int32>();
            }
        }

        /// <summary>
        /// The value for the default cutoff date
        /// </summary>
        public Nullable<DateTime> DefaultCutoffDate
        {
            get
            {
                return dcDefaultCutoffDate.SelectedDate;
            }
        }

        /// <summary>
        /// The list of courses
        /// </summary>
        public IList<Course> Courses
        {
            set
            {
                cmbCourseName.Items.Clear();

                if (value != null && value.Count > 0)
                {
                    cmbCourseName.Items.Add(new ListItem("-- Select a Course --", String.Empty));
                }
                else
                {
                    cmbCourseName.Items.Add(new ListItem("No Courses for this Program", String.Empty));
                }

                foreach (Course course in value)
                {
                    cmbCourseName.Items.Add(new ListItem(course.ExtendedProperties.DisplayName, course.CourseID.ToStringSafe()));
                }

                cmbCourseName.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID for the currently selected course
        /// </summary>
        public Nullable<Int32> CourseID
        {
            get
            {
                return cmbCourseName.SelectedValue.ToNullable<Int32>();
            }
        }

        /// <summary>
        /// The calculated value for whether to show the course selection
        /// </summary>
        public Boolean ShowCourse
        {
            set
            {
                tdCourse.Visible = value;
                tdCourseTitle.Visible = value;
            }
        }

        /// <summary>
        /// The list of hours types
        /// </summary>
        public IList<HoursType> HoursTypes
        {
            set
            {
                rblHoursType.Items.Clear();

                foreach (HoursType hoursType in value)
                {
                    rblHoursType.Items.Add(new ListItem(hoursType.HoursTypeName, hoursType.HoursTypeID.ToStringSafe()));
                }

                rblHoursType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected hours type
        /// </summary>
        public Nullable<Int32> HoursTypeID
        {
            get
            {
                return rblHoursType.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                rblHoursType.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The list of systems
        /// </summary>
        public IList<USAACE.ATI.Domain.Entities.System> Systems
        {
            set
            {
                cmbSystem.Items.Clear();

                cmbSystem.Items.Add(new ListItem("-- Select a System --", String.Empty));

                foreach (USAACE.ATI.Domain.Entities.System system in value)
                {
                    cmbSystem.Items.Add(new ListItem(system.SystemName, system.SystemID.ToString()));
                }

                cmbSystem.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected system
        /// </summary>
        public Nullable<Int32> SystemID
        {
            get
            {
                return cmbSystem.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbSystem.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The calculated value for whether to enable system selection
        /// </summary>
        public Boolean SystemEnabled
        {
            set
            {
                cmbSystem.Enabled = value;
            }
        }

        /// <summary>
        /// The list of course levels
        /// </summary>
        public IList<CourseLevel> CourseLevels
        {
            set
            {
                cmbCourseLevel.Items.Clear();

                cmbCourseLevel.Items.Add(new ListItem("-- Select a Course Level --", String.Empty));

                foreach (CourseLevel courseLevel in value)
                {
                    cmbCourseLevel.Items.Add(new ListItem(courseLevel.CourseLevelName, courseLevel.CourseLevelID.ToString()));
                }

                cmbCourseLevel.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected course level
        /// </summary>
        public Nullable<Int32> CourseLevelID
        {
            get
            {
                return cmbCourseLevel.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbCourseLevel.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The calculated value for whether to enable course level selection
        /// </summary>
        public Boolean CourseLevelEnabled
        {
            set
            {
                cmbCourseLevel.Enabled = value;
            }
        }

        /// <summary>
        /// The list of miscellaneous hours types
        /// </summary>
        public IList<MiscHours> MiscHoursTypes
        {
            set
            {
                cmbSupportType.Items.Clear();

                cmbSupportType.Items.Add(new ListItem("-- Select a Support Type --", String.Empty));

                foreach (MiscHours miscHoursType in value)
                {
                    cmbSupportType.Items.Add(new ListItem(miscHoursType.MiscHoursName, miscHoursType.MiscHoursID.ToString()));
                }

                cmbSupportType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected miscellaneous hours type
        /// </summary>
        public Nullable<Int32> MiscHoursTypeID
        {
            get
            {
                return cmbSupportType.SelectedValue.ToNullable<Int32>();
            }
        }

        /// <summary>
        /// The calculated value for whether to show the miscellaneous hours type selection
        /// </summary>
        public Boolean ShowMiscHoursType
        {
            set
            {
                tdSupport.Visible = value;
                tdSupportTitle.Visible = value;
            }
        }

        /// <summary>
        /// The value for forecast hours selection
        /// </summary>
        public Boolean ForecastHours
        {
            get
            {
                return chkForecastHours.Checked;
            }
        }

        /// <summary>
        /// The values for reimbursable hours selection
        /// </summary>
        public Boolean ReimbursableHours
        {
            get
            {
                return chkReimburseableHours.Checked;
            }
        }

        /// <summary>
        /// The calculated value for whether actual hours are enabled
        /// </summary>
        public Boolean EnableActualHours
        {
            set
            {
                rblHoursType.Items[0].Enabled = value;
            }
        }

        /// <summary>
        /// The calculated value for whether addin hours are enabled
        /// </summary>
        public Boolean EnableAddinHours
        {
            set
            {
                rblHoursType.Items[1].Enabled = value;
            }
        }

        /// <summary>
        /// The calculated value for whether BASOPS hours are enabled
        /// </summary>
        public Boolean EnableBASOPSHours
        {
            set
            {
                rblHoursType.Items[2].Enabled = value;
            }
        }

        /// <summary>
        /// The calculated value for whether support hours are enabled
        /// </summary>
        public Boolean EnableSupportHours
        {
            set
            {
                rblHoursType.Items[3].Enabled = value;
            }
        }

        /// <summary>
        /// The current list of actual hours
        /// </summary>
        public IList<ActualHours> Hours
        {
            get
            {
                IList<ActualHours> hoursList = this.ViewState["ActualHours"] as IList<ActualHours>;

                for (int i = 0; i < hoursList.Count; i++)
                {
                    RepeaterItem item = dlHours.Items[i];

                    ActualHours hours = hoursList[i];

                    hours.ExtendedProperties.MarkForDeletion = (item.FindControl("chkHoursDelete") as CheckBox).Checked;
                    hours.CutoffDate = (item.FindControl("dcCutoffDate") as DateControl).SelectedDate;
                    hours.HoursAmount = (item.FindControl("ncHours") as NumericControl).Value.ToNullable<Decimal>();
                }

                return hoursList;
            }
            set
            {
                this.ViewState["ActualHours"] = value;

                dlHours.DataSource = value;
                dlHours.DataBind();
            }
        }

        /// <summary>
        /// The calculated value for whether to allow hours updates
        /// </summary>
        public Boolean ShowHoursUpdate
        {
            set
            {
                pnlHours.Visible = value;
            }
        }

        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        public Boolean AllowEditing
        {
            set
            {
                dlHours.Enabled = value;
                btnAddHours.Enabled = value;
                btnUpdateHours.Enabled = value;
                btnDeleteHours.Enabled = value;
            }
        }
    }
}