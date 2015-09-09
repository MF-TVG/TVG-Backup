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
using USAACE.Common;

namespace USAACE.ATI.Web.Pages
{
    public partial class ClassDev : BasePage, IClassDevView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private ClassDevPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public ClassDevPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new ClassDevPresenter(this);
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
                Presenter.LoadCourseDetails();
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
                Presenter.LoadCourseDetails();
                Presenter.GetCarryOverCourse();
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
        protected void cmbCarryOverProgram_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Presenter.GetCarryOverCourse();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Create Classes button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCreateClasses_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("Class");

                if (Page.IsValid)
                {
                    Presenter.CreateClasses();

                    if (this.OverflowCount.HasValue && this.OverflowCount > 0)
                    {
                        this.ShowNotice(String.Format(MessageConstants.CLASS_CREATE_WARNING,
                            (this.MaximumClasses - this.OverflowCount).ToStringSafe(), this.OverflowCount.ToStringSafe()), NoticeType.Information);
                    }
                    else
                    {
                        this.ShowNotice(MessageConstants.CLASS_CREATE_SUCCESS, NoticeType.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the settings for class creation are validated
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments of the event</param>
        protected void cvCreateClasses_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = this.CourseID.HasValue && this.MaximumClasses.HasValue && this.BeginningClass.HasValue && this.ClassLoad.HasValue
                    && this.ReportDateInterval.HasValue && !String.IsNullOrEmpty(this.StudentPopulationType) && this.FirstReportDate.HasValue;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the report date is validated
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments of the event</param>
        protected void cvReportDate_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = !this.CourseFiscalYear.HasValue || !this.FirstReportDate.HasValue || CalendarUtil.IsInProgramFlightYear(this.FirstReportDate.Value, this.CourseFiscalYear.Value);
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
                cmbCarryOverProgram.Items.Clear();

                cmbProgram.Items.Add(new ListItem("-- Select a Program --", String.Empty));
                cmbCarryOverProgram.Items.Add(new ListItem("-- Select a Program --", String.Empty));

                foreach (Program program in value)
                {
                    cmbProgram.Items.Add(new ListItem(program.ProgramName, program.ProgramID.ToString()));
                    cmbCarryOverProgram.Items.Add(new ListItem(program.ProgramName, program.ProgramID.ToString()));
                }

                cmbProgram.SelectedIndex = 0;
                cmbCarryOverProgram.SelectedIndex = 0;
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
        /// The fiscal year of the currently selected course
        /// </summary>
        public Nullable<Int16> CourseFiscalYear
        {
            get
            {
                return this.ViewState["CourseFiscalYear"] as Nullable<Int16>;
            }
            set
            {
                this.ViewState["CourseFiscalYear"] = value;
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
        /// The value for the maximum classes
        /// </summary>
        public Nullable<Int16> MaximumClasses
        {
            get
            {
                return ncMaximumClasses.Value.ToNullable<Int16>();
            }
            set
            {
                ncMaximumClasses.Value = value;
            }
        }

        /// <summary>
        /// The value for the beginning class
        /// </summary>
        public Nullable<Int16> BeginningClass
        {
            get
            {
                return ncBeginningClass.Value.ToNullable<Int16>();
            }
            set
            {
                ncBeginningClass.Value = value;
            }
        }

        /// <summary>
        /// The value for the class load
        /// </summary>
        public Nullable<Int16> ClassLoad
        {
            get
            {
                return ncClassLoad.Value.ToNullable<Int16>();
            }
            set
            {
                ncClassLoad.Value = value;
            }
        }

        /// <summary>
        /// The value for the report date interval
        /// </summary>
        public Nullable<Int16> ReportDateInterval
        {
            get
            {
                return ncReportDateInterval.Value.ToNullable<Int16>();
            }
            set
            {
                ncReportDateInterval.Value = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The string for the Student Population Type
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
        /// The value for the first report date
        /// </summary>
        public Nullable<DateTime> FirstReportDate
        {
            get
            {
                return dcFirstClassReportDate.SelectedDate;
            }
            set
            {
                dcFirstClassReportDate.SelectedDate = value;
            }
        }

        /// <summary>
        /// The ID of the currently selected carry over program
        /// </summary>
        public Nullable<Int32> CarryOverProgramID
        {
            get
            {
                return cmbCarryOverProgram.SelectedValue.ToNullable<Int32>();
            }
        }

        /// <summary>
        /// The ID of the currently selected carry over course
        /// </summary>
        public Nullable<Int32> CarryOverCourseID
        {
            get
            {
                return this.ViewState["CarryOverCourseID"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["CarryOverCourseID"] = value;
            }
        }

        /// <summary>
        /// The text for the carry over course
        /// </summary>
        public String CarryOverCourseText
        {
            set
            {
                ltrCarryOverCourse.Text = value;
            }
        }

        /// <summary>
        /// The number of classes that overflowed as a result of calculation
        /// </summary>
        public Nullable<Int32> OverflowCount
        {
            get
            {
                return this.ViewState["OverflowCount"] as Nullable<Int32>;
            }
            set
            {
                this.ViewState["OverflowCount"] = value;
            }
        }

        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        public Boolean AllowEditing
        {
            set
            {
                ncMaximumClasses.Enabled = value;
                ncBeginningClass.Enabled = value;
                cmbCourse.Enabled = value;
                cmbAddStudents.Enabled = value;
                ncReportDateInterval.Enabled = value;
                cmbPOI.Enabled = value;
                dcFirstClassReportDate.Enabled = value;
                ncClassLoad.Enabled = value;
                btnCreateClasses.Visible = value;
            }
        }
    }
}