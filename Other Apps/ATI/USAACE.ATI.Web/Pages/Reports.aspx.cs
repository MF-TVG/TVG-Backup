using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Presentation.Presenters.Pages;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.Common;
using USAACE.Common.Web;

namespace USAACE.ATI.Web.Pages
{
    public partial class Reports : BasePage, IReportsView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private ReportsPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public ReportsPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new ReportsPresenter(this);
                }

                return _presenter;
            }
        }

        /// <summary>
        /// Event taking place when the page loads
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected override void InitPage()
        {
            try
            {
                ScriptManager.GetCurrent(this).RegisterPostBackControl(this.lkbDownloadExcel);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
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
                Presenter.LoadCarryOverPrograms();
                Presenter.LoadCourses();
                Presenter.LoadCarryOverCourses();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the carry over program text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbCarryProgramName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadCarryOverCourses();
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
                Presenter.SetEntryFields();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the carry over course text changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void cmbCarryCourseName_TextChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the frequency selection changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void rblFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.SetEntryFields();
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
        protected void rblHours_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.SetEntryFields();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the grouping selection changes
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void rblGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.SetEntryFields();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Run Report button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("Reports");

                if (Page.IsValid)
                {
                    Presenter.RunReport();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Select All Systems button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void lkbAllSystem_Click(object sender, EventArgs e)
        {
            try
            {
                cklSystem.SetAll(true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Select All Requirements button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void lkbAllRequirements_Click(object sender, EventArgs e)
        {
            try
            {
                cklRequirements.SetAll(true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Download to Excel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void lkbDownloadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                StringWriter sw = new StringWriter();

                HtmlTextWriter hw = new HtmlTextWriter(sw);

                gvReport.RenderControl(hw);

                Response.Write(sw.ToString());

                Response.End();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            try
            {
                if (control == gvReport && Response.Headers["content-disposition"] == "attachment;filename=Report.xls")
                {
                    return;
                }
                else
                {
                    base.VerifyRenderingInServerForm(control);
                }
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
        /// The list of carry over programs
        /// </summary>
        public IList<Program> CarryOverPrograms
        {
            set
            {
                cmbCarryProgramName.Items.Clear();

                if (value != null && value.Count > 0)
                {
                    cmbCarryProgramName.Items.Add(new ListItem("-- Select a Carry Over Program --", String.Empty));
                }
                else
                {
                    cmbCarryProgramName.Items.Add(new ListItem("No Carry Over Programs Available", String.Empty));
                }

                foreach (Program program in value)
                {
                    cmbCarryProgramName.Items.Add(new ListItem(program.ProgramName, program.ProgramID.ToStringSafe()));
                }

                cmbCarryProgramName.SelectedIndex = 0;
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
        /// The ID of the currently selected carry over program
        /// </summary>
        public Nullable<Int32> CarryOverProgramID
        {
            get
            {
                return cmbCarryProgramName.SelectedValue.ToNullable<Int32>();
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
                    cmbCourseName.Items.Add(new ListItem("All", String.Empty));
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
        /// The list of carry over courses
        /// </summary>
        public IList<Course> CarryOverCourses
        {
            set
            {
                cmbCarryCourseName.Items.Clear();

                if (value != null && value.Count > 0)
                {
                    cmbCarryCourseName.Items.Add(new ListItem("All", String.Empty));
                }
                else
                {
                    cmbCarryCourseName.Items.Add(new ListItem("No Courses for this Carry Over Program", String.Empty));
                }

                foreach (Course course in value)
                {
                    cmbCarryCourseName.Items.Add(new ListItem(course.ExtendedProperties.DisplayName, course.CourseID.ToStringSafe()));
                }

                cmbCarryCourseName.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected course
        /// </summary>
        public Nullable<Int32> CourseID
        {
            get
            {
                return cmbCourseName.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbCourseName.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The ID of the currently selected carry over course
        /// </summary>
        public Nullable<Int32> CarryOverCourseID
        {
            get
            {
                return cmbCarryCourseName.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbCarryCourseName.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The calculated value for whether to enable course selection
        /// </summary>
        public Boolean EnableCourse
        {
            set
            {
                cmbCourseName.Enabled = value;
                cmbCarryCourseName.Enabled = value;
            }
        }

        /// <summary>
        /// The list of systems
        /// </summary>
        public IList<USAACE.ATI.Domain.Entities.System> Systems
        {
            set
            {
                cklSystem.Items.Clear();

                foreach (USAACE.ATI.Domain.Entities.System system in value)
                {
                    cklSystem.Items.Add(new ListItem(system.SystemName, system.SystemID.ToString()));
                }
            }
        }

        /// <summary>
        /// The list of selected system ID values
        /// </summary>
        public IList<Int32> SystemIDs
        {
            get
            {
                return cklSystem.GetSelectedItems().Select(x => x.Value.ToNullable<Int32>().Value).ToList();
            }
            set
            {
                foreach (ListItem item in cklSystem.Items)
                {
                    item.Selected = value != null && value.Contains(item.Value.ToNullable<Int32>().Value);
                }
            }
        }

        /// <summary>
        /// The calculated value for whether to enable system selection
        /// </summary>
        public Boolean EnableSystem
        {
            set
            {
                cklSystem.Enabled = value;
                lkbAllSystem.Enabled = value;
            }
        }

        /// <summary>
        /// The list of course levels
        /// </summary>
        public IList<CourseLevel> CourseLevels
        {
            set
            {
                cklCourseLevel.Items.Clear();

                foreach (CourseLevel courseLevel in value)
                {
                    cklCourseLevel.Items.Add(new ListItem(courseLevel.CourseLevelName, courseLevel.CourseLevelID.ToString()));
                }

                cklCourseLevel.SetAll(true);
            }
        }

        /// <summary>
        /// The list of selected course level ID values
        /// </summary>
        public IList<Int32> CourseLevelIDs
        {
            get
            {
                return cklCourseLevel.GetSelectedItems().Select(x => x.Value.ToNullable<Int32>().Value).ToList();
            }
            set
            {
                foreach (ListItem item in cklCourseLevel.Items)
                {
                    item.Selected = value != null && value.Contains(item.Value.ToNullable<Int32>().Value);
                }
            }
        }

        /// <summary>
        /// The calculated value for whether to enable course level selection
        /// </summary>
        public Boolean EnableCourseLevel
        {
            set
            {
                cklCourseLevel.Enabled = value;
            }
        }

        /// <summary>
        /// The value for the type of report, Monthly or Daily
        /// </summary>
        public String ReportType
        {
            get
            {
                return rblFrequency.SelectedValue;
            }
            set
            {
                rblFrequency.SelectedValue = value;
            }
        }

        /// <summary>
        /// The calculated value for whether to enable report type selection
        /// </summary>
        public Boolean EnableReportType
        {
            set
            {
                rblFrequency.Enabled = value;
            }
        }

        /// <summary>
        /// The value for the type of hours, Forecast or Actual
        /// </summary>
        public String HoursType
        {
            get
            {
                return rblHours.SelectedValue;
            }
            set
            {
                rblHours.SelectedValue = value;
            }
        }

        /// <summary>
        /// The calculated value for whether to enable hours type selection
        /// </summary>
        public Boolean EnableHoursType
        {
            set
            {
                rblHours.Enabled = value;
            }
        }

        /// <summary>
        /// The value for the grouping parameter for the hours
        /// </summary>
        public String GroupByType
        {
            get
            {
                return rblGroupBy.SelectedValue;
            }
            set
            {
                rblGroupBy.SelectedValue = value;
            }
        }

        /// <summary>
        /// The value for whether to include BASOPS hours
        /// </summary>
        public Boolean IncludeBASOPSHours
        {
            get
            {
                return cklHoursType.Items[0].Selected;
            }
            set
            {
                cklHoursType.Items[0].Selected = value;
            }
        }

        /// <summary>
        /// The calculated value for whether to enable BASOPS hours selection
        /// </summary>
        public Boolean EnableBASOPSHours
        {
            set
            {
                cklHoursType.Items[0].Enabled = value;
            }
        }

        /// <summary>
        /// The value for whether to include addin hours
        /// </summary>
        public Boolean IncludeAddInHours
        {
            get
            {
                return cklHoursType.Items[1].Selected;
            }
            set
            {
                cklHoursType.Items[1].Selected = value;
            }
        }

        /// <summary>
        /// The calculated value for whether to enable addins hours selection
        /// </summary>
        public Boolean EnableAddInHours
        {
            set
            {
                cklHoursType.Items[1].Enabled = value;
            }
        }

        /// <summary>
        /// The value for whether to include support hours
        /// </summary>
        public Boolean IncludeSupportHours
        {
            get
            {
                return cklHoursType.Items[2].Selected;
            }
            set
            {
                cklHoursType.Items[2].Selected = value;
            }
        }

        /// <summary>
        /// The calculated value for whether to enable support hours selection
        /// </summary>
        public Boolean EnableSupportHours
        {
            set
            {
                cklHoursType.Items[2].Enabled = value;
            }
        }

        /// <summary>
        /// The value for what reimbursable status to include, All, Direct, or Reimbursable
        /// </summary>
        public Nullable<Boolean> Reimbursable
        {
            get
            {
                return rblReimbursable.SelectedValue.ToNullable<Boolean>();
            }
        }

        /// <summary>
        /// The value for the currently selected daily requirements
        /// </summary>
        public IList<String> DailyRequirements
        {
            get
            {
                return cklRequirements.GetSelectedItems().Select(x => x.Value).ToList();
            }
            set
            {
                foreach (ListItem item in cklRequirements.Items)
                {
                    item.Selected = value != null && value.Contains(item.Value);
                }
            }
        }

        /// <summary>
        /// The calculated value for whether to enable daily requirements selection
        /// </summary>
        public Boolean EnableDailyRequirements
        {
            set
            {
                cklRequirements.Enabled = value;
                lkbAllRequirements.Enabled = value;
            }
        }

        /// <summary>
        /// The data for the report
        /// </summary>
        public DataTable ReportData
        {
            set
            {
                gvReport.DataSource = value;
                gvReport.DataBind();
            }
        }
    }
}