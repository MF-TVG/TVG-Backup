using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using USAACE.Common.Web;

namespace USAACE.ATI.Web.Pages
{
    public partial class HistoricalPercent : BasePage, IHistoricalPercentView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private HistoricalPercentPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public HistoricalPercentPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new HistoricalPercentPresenter(this);
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
        protected void cmbProgram_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.LoadCourses();
                Presenter.LoadPercents();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rblEditMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.ChangeEditMode();
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
                Presenter.LoadPercents();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Historical Percents button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdatePercent_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Save();
                this.ShowNotice(MessageConstants.HISTORICAL_PERCENT_SAVE_SUCCESS, NoticeType.Information);
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
                Presenter.RunReport();
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
                cmbProgram.Items.Clear();

                cmbProgram.Items.Add(new ListItem("-- Select a Program --", String.Empty));

                foreach (Program program in value)
                {
                    cmbProgram.Items.Add(new ListItem(program.ProgramName, program.ProgramID.ToStringSafe()));
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
        /// The edit mode for the historical percents
        /// </summary>
        public String EditMode
        {
            get
            {
                return rblEditMode.SelectedValue;
            }
        }

        /// <summary>
        /// Whether to show by course
        /// </summary>
        public Boolean ShowByCourse
        {
            set
            {
                pnlByCourse.Visible = value;
            }
        }

        /// <summary>
        /// Whether to show mass edit
        /// </summary>
        public Boolean ShowMassEdit
        {
            set
            {
                pnlMassEdit.Visible = value;
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
                cmbCourse.SelectedValue = value.ToStringSafe();
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
        public IList<Nullable<Int32>> SystemIDs
        {
            get
            {
                return cklSystem.GetSelectedItems().Select(x => x.Value.ToNullable<Int32>()).ToList();
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
            }
        }

        /// <summary>
        /// The list of selected course level ID values
        /// </summary>
        public IList<Nullable<Int32>> CourseLevelIDs
        {
            get
            {
                return cklCourseLevel.GetSelectedItems().Select(x => x.Value.ToNullable<Int32>()).ToList();
            }
        }

        /// <summary>
        /// The list of course levels
        /// </summary>
        public IList<CourseType> CourseTypes
        {
            set
            {
                cklCourseType.Items.Clear();

                foreach (CourseType courseType in value)
                {
                    cklCourseType.Items.Add(new ListItem(courseType.CourseTypeName, courseType.CourseTypeID.ToString()));
                }
            }
        }

        /// <summary>
        /// The list of selected course level ID values
        /// </summary>
        public IList<Nullable<Int32>> CourseTypeIDs
        {
            get
            {
                return cklCourseType.GetSelectedItems().Select(x => x.Value.ToNullable<Int32>()).ToList();
            }
        }

        /// <summary>
        /// The value for the historical percent for October
        /// </summary>
        public Nullable<Int16> PercentOctober
        {
            get
            {
                return ncOctober.Value.ToNullable<Int16>();
            }
            set
            {
                ncOctober.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for November
        /// </summary>
        public Nullable<Int16> PercentNovember
        {
            get
            {
                return ncNovember.Value.ToNullable<Int16>();
            }
            set
            {
                ncNovember.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for December
        /// </summary>
        public Nullable<Int16> PercentDecember
        {
            get
            {
                return ncDecember.Value.ToNullable<Int16>();
            }
            set
            {
                ncDecember.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for January
        /// </summary>
        public Nullable<Int16> PercentJanuary
        {
            get
            {
                return ncJanuary.Value.ToNullable<Int16>();
            }
            set
            {
                ncJanuary.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for February
        /// </summary>
        public Nullable<Int16> PercentFebruary
        {
            get
            {
                return ncFebruary.Value.ToNullable<Int16>();
            }
            set
            {
                ncFebruary.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for March
        /// </summary>
        public Nullable<Int16> PercentMarch
        {
            get
            {
                return ncMarch.Value.ToNullable<Int16>();
            }
            set
            {
                ncMarch.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for April
        /// </summary>
        public Nullable<Int16> PercentApril
        {
            get
            {
                return ncApril.Value.ToNullable<Int16>();
            }
            set
            {
                ncApril.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for May
        /// </summary>
        public Nullable<Int16> PercentMay
        {
            get
            {
                return ncMay.Value.ToNullable<Int16>();
            }
            set
            {
                ncMay.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for June
        /// </summary>
        public Nullable<Int16> PercentJune
        {
            get
            {
                return ncJune.Value.ToNullable<Int16>();
            }
            set
            {
                ncJune.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for July
        /// </summary>
        public Nullable<Int16> PercentJuly
        {
            get
            {
                return ncJuly.Value.ToNullable<Int16>();
            }
            set
            {
                ncJuly.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for August
        /// </summary>
        public Nullable<Int16> PercentAugust
        {
            get
            {
                return ncAugust.Value.ToNullable<Int16>();
            }
            set
            {
                ncAugust.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for September
        /// </summary>
        public Nullable<Int16> PercentSeptember
        {
            get
            {
                return ncSeptember.Value.ToNullable<Int16>();
            }
            set
            {
                ncSeptember.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for Support
        /// </summary>
        public Nullable<Int16> PercentSupport
        {
            get
            {
                return ncSupport.Value.ToNullable<Int16>();
            }
            set
            {
                ncSupport.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for Setback
        /// </summary>
        public Nullable<Int16> PercentSetback
        {
            get
            {
                return ncSetback.Value.ToNullable<Int16>();
            }
            set
            {
                ncSetback.Value = value;
            }
        }

        /// <summary>
        /// The value for the historical percent for Test
        /// </summary>
        public Nullable<Int16> PercentTest
        {
            get
            {
                return ncTest.Value.ToNullable<Int16>();
            }
            set
            {
                ncTest.Value = value;
            }
        }

        /// <summary>
        /// The calculated value for whether percents are visible
        /// </summary>
        public Boolean IsPercentVisible
        {
            set
            {
                pnlPercents.Visible = value;
            }
        }

        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        public Boolean AllowEditing
        {
            set
            {
                ncJanuary.Enabled = value;
                ncFebruary.Enabled = value;
                ncMarch.Enabled = value;
                ncApril.Enabled = value;
                ncMay.Enabled = value;
                ncJune.Enabled = value;
                ncJuly.Enabled = value;
                ncAugust.Enabled = value;
                ncSeptember.Enabled = value;
                ncOctober.Enabled = value;
                ncNovember.Enabled = value;
                ncDecember.Enabled = value;
                ncSetback.Enabled = value;
                ncSupport.Enabled = value;
                ncTest.Enabled = value;
                btnUpdatePercent.Enabled = value;
            }
        }

        /// <summary>
        /// Historical percents report as a data table
        /// </summary>
        public DataTable HistoricalPercentsReport
        {
            set
            {
                gvReport.DataSource = value;
                gvReport.DataBind();
            }
        }
    }
}