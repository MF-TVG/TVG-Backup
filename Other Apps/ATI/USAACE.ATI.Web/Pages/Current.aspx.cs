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
using USAACE.ATI.Web.Util;
using USAACE.Common;
using USAACE.Common.Util;
using USAACE.Common.Web.Controls;

namespace USAACE.ATI.Web.Pages
{
    public partial class Current : BasePage, ICurrentView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private CurrentPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public CurrentPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new CurrentPresenter(this);
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
        protected void cmbProgram_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadCourses();
                Presenter.LoadClasses();
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
        protected void cmbCourse_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadClasses();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when a row is bound to the classes data grid
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The grid item arguments of the event</param>
        protected void dlClasses_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.DataItem is Class)
                {
                    Class currentClass = e.Item.DataItem as Class;

                    ImageButton imgPOI = e.Item.FindControl("imgPOI") as ImageButton;

                    if (imgPOI != null)
                    {
                        imgPOI.ToolTip = currentClass.ExtendedProperties.POIName;
                        imgPOI.ImageUrl = ImageUtil.GetPOIImage(currentClass.ExtendedProperties.POIMatch);
                        imgPOI.CommandArgument = currentClass.ClassID.ToStringSafe();
                    }

                    (e.Item.FindControl("ltrPOIName") as Literal).Text = currentClass.ExtendedProperties.POIName;

                    (e.Item.FindControl("ncClassNumber") as NumericControl).Value = currentClass.ClassNumber != null ? currentClass.ClassNumber.PadLeft(3, '0') : null;

                    Image imgReportDate = e.Item.FindControl("imgReportDate") as Image;

                    if (imgReportDate != null)
                    {
                        imgReportDate.ToolTip = currentClass.ExtendedProperties.CalcReportDate.ToDateStringSafe(ConfigUtil.GetConfigurationValue("DateFormat"));
                        imgReportDate.ImageUrl = ImageUtil.GetReportDateImage(currentClass.ReportDate, currentClass.ExtendedProperties.CalcReportDate);
                        imgReportDate.Style[HtmlTextWriterStyle.Visibility] = currentClass.ExtendedProperties.CalcReportDate.HasValue ? "visible" : "hidden";
                    }

                    DateControl dcReportDate = e.Item.FindControl("dcReportDate") as DateControl;

                    if (dcReportDate != null)
                    {
                        dcReportDate.SelectedDate = currentClass.ReportDate;
                    }

                    (e.Item.FindControl("ltrStartDate") as Literal).Text = currentClass.ExtendedProperties.StartDate.ToDateStringSafe(ConfigUtil.GetConfigurationValue("DateFormat"));
                    (e.Item.FindControl("ltrEndDate") as Literal).Text = currentClass.ExtendedProperties.EndDate.ToDateStringSafe(ConfigUtil.GetConfigurationValue("DateFormat"));
                    (e.Item.FindControl("ncClassStudents") as NumericControl).Value = currentClass.Students;
                    (e.Item.FindControl("ncClassReimbursable") as NumericControl).Value = currentClass.Reimbursable;
                    (e.Item.FindControl("ltrClassADPCode") as Literal).Text = currentClass.ExtendedProperties.ADPCode;
                    (e.Item.FindControl("ncInterval") as NumericControl).Value = currentClass.Interval;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the POI image is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The command arguments of the event</param>
        protected void imgPOI_Command(object sender, CommandEventArgs e)
        {
            try
            {
                mpClassReport.Show();
                this.ClassReportID = e.CommandArgument.ToNullable<Int32>();

                Presenter.LoadClassReport();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Classes button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateClasses_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("Classes");

                if (Page.IsValid)
                {
                    Presenter.SaveClasses();
                    this.ShowNotice(MessageConstants.CLASS_UPDATE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Add Class button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnAddClasses_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.AddClass();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Classes Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteClassConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.DeleteClasses();
                this.ShowNotice(MessageConstants.CLASS_DELETE_SUCCESS, NoticeType.Information);
                mpConfirmDeleteClass.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteClassCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpConfirmDeleteClass.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Classes button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteClasses_Click(object sender, EventArgs e)
        {
            try
            {
                mpConfirmDeleteClass.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Apply POI button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnApplyPOI_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.ApplyPOI();
                this.ShowNotice(MessageConstants.CLASS_POI_APPLY, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the classes are validated for save
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments of the event</param>
        protected void cvClasses_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = this.Classes.All(x => !String.IsNullOrEmpty(x.ClassNumber) && x.ReportDate.HasValue && x.Students.HasValue && x.Reimbursable.HasValue && x.Interval.HasValue);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Change All Classes button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnChangeAll_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.ChangeAllClasses();
                this.ShowNotice(MessageConstants.CLASS_MASS_CHANGE, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Apply Recommended Report Dates button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnApplyRecommended_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.RecalculateReportDates();
                this.ShowNotice(MessageConstants.CLASS_REPORT_DATE_CALC, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Classes header checkbox is checked or unchecked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void chkAllClasses_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem item in dlClasses.Items)
                {
                    (item.FindControl("chkClassSelect") as CheckBox).Checked = chkAllClasses.Checked;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCloseClassReport_Click(object sender, EventArgs e)
        {
            try
            {
                mpClassReport.Hide();
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
                cmbProgram.Items.Clear();

                cmbProgram.Items.Add(new ListItem("-- Select a Program --", String.Empty));

                foreach (Program program in value)
                {
                    cmbProgram.Items.Add(new ListItem(program.ProgramName, program.ProgramID.ToString()));
                }

                cmbProgram.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected program
        /// </summary>
        public Nullable<Int32> ProgramID
        {
            get
            {
                return cmbProgram.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbProgram.SelectedValue = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The list of courses
        /// </summary>
        public IList<Course> Courses
        {
            set
            {
                cmbCourse.Items.Clear();

                if (value != null && value.Count > 0)
                {
                    cmbCourse.Items.Add(new ListItem("-- Select a Course --", String.Empty));
                }
                else
                {
                    cmbCourse.Items.Add(new ListItem("No Courses for this Program", String.Empty));
                }

                foreach (Course course in value)
                {
                    cmbCourse.Items.Add(new ListItem(course.ExtendedProperties.DisplayName, course.CourseID.ToStringSafe()));
                }

                cmbCourse.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected course
        /// </summary>
        public Nullable<Int32> CourseID
        {
            get
            {
                return cmbCourse.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbCourse.SelectedValue = value.ToStringSafe(String.Empty);
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

                if (value != null && value.Count > 0)
                {
                    cmbPOI.Items.Add(new ListItem("-- Select a POI --", String.Empty));
                }

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
        /// The current list of classes
        /// </summary>
        public IList<Class> Classes
        {
            get
            {
                IList<Class> classes = this.ViewState["Classes"] as IList<Class>;

                for (int i = 0; i < classes.Count; i++)
                {
                    RepeaterItem item = dlClasses.Items[i];

                    Class classItem = classes[i];

                    classItem.ExtendedProperties.IsSelected = (item.FindControl("chkClassSelect") as CheckBox).Checked;
                    classItem.ClassNumber = (item.FindControl("ncClassNumber") as NumericControl).Value.ToStringSafe();
                    classItem.ReportDate = (item.FindControl("dcReportDate") as DateControl).SelectedDate;
                    classItem.Students = (item.FindControl("ncClassStudents") as NumericControl).Value.ToNullable<Int16>();
                    classItem.Reimbursable = (item.FindControl("ncClassReimbursable") as NumericControl).Value.ToNullable<Int16>();
                    classItem.Interval = (item.FindControl("ncInterval") as NumericControl).Value.ToNullable<Int16>();
                }

                return classes;
            }
            set
            {
                this.ViewState["Classes"] = value;

                dlClasses.DataSource = value;
                dlClasses.DataBind();
            }
        }

        public Nullable<Int32> TotalClasses
        {
            set
            {
                ltrTotalClasses.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int32> TotalStudents
        {
            set
            {
                ltrTotalStudents.Text = value.ToStringSafe();
            }
        }

        public Nullable<Int32> TotalReimbursable
        {
            set
            {
                ltrTotalReimbursable.Text = value.ToStringSafe();
            }
        }

        public Boolean ShowClassInfo
        {
            set
            {
                pnlClassInfo.Visible = value;
            }
        }

        /// <summary>
        /// The value for the beginning class number
        /// </summary>
        public Nullable<Int16> BeginClassNumber
        {
            get
            {
                return ncBeginClassNumber.Value.ToNullable<Int16>();
            }
            set
            {
                ncBeginClassNumber.Value = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the new interval
        /// </summary>
        public Nullable<Int16> NewInterval
        {
            get
            {
                return ncNewInterval.Value.ToNullable<Int16>();
            }
            set
            {
                ncNewInterval.Value = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the new student load
        /// </summary>
        public Nullable<Int16> NewStudentLoad
        {
            get
            {
                return ncStudentLoad.Value.ToNullable<Int16>();
            }
            set
            {
                ncStudentLoad.Value = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The value for the student population type
        /// </summary>
        public String StudentPopulationType
        {
            get
            {
                return cmbAddStudents.SelectedValue;
            }
            set
            {
                cmbAddStudents.SelectedValue = value;
            }
        }

        /// <summary>
        /// The calculated value for whether report dates can be fixed
        /// </summary>
        public Boolean AllowFixReportDates
        {
            set
            {
                btnApplyRecommended.Visible = value;
            }
        }

        /// <summary>
        /// The ID value for the current class report
        /// </summary>
        public Nullable<Int32> ClassReportID
        {
            get
            {
                return this.ViewState["ClassReportID"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["ClassReportID"] = value;
            }
        }

        /// <summary>
        /// The data for the class report
        /// </summary>
        public DataTable ClassReport
        {
            set
            {
                gvReport.DataSource = value;
                gvReport.DataBind();
            }
        }

        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        public Boolean AllowEditing
        {
            set
            {
                chkAllClasses.Enabled = value;
                dlClasses.Enabled = value;
                pnlMassEdit.Visible = value;
                btnApplyRecommended.Visible = value;
                btnAddClasses.Visible = value;
                btnUpdateClasses.Visible = value;
                btnDeleteClasses.Visible = value;
                cmbPOI.Enabled = value;
                btnApplyPOI.Visible = value;
                ncBeginClassNumber.Enabled = value;
                ncNewInterval.Enabled = value;
                ncStudentLoad.Enabled = value;
                cmbAddStudents.Enabled = value;
                btnChangeAll.Visible = value;
            }
        }
    }
}