using System;
using System.Collections.Generic;
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

namespace USAACE.ATI.Web.Pages
{
    public partial class CourseDev : BasePage, ICourseDevView
    {
        /// <summary>
        /// Private member for the presenter
        /// </summary>
        private CourseDevPresenter _presenter;

        /// <summary>
        /// The presenter for this view
        /// </summary>
        public CourseDevPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {
                    _presenter = new CourseDevPresenter(this);
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
                Presenter.LoadCourse();
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
                Presenter.LoadPOIDays();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Update Course button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("Course");

                if (Page.IsValid)
                {
                    Presenter.Save();
                    this.ShowNotice(MessageConstants.COURSE_SAVE_SUCCESS, NoticeType.Information);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            try
            {
                mpConfirmDeleteCourse.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.Delete();
                mpConfirmDeleteCourse.Hide();
                this.ShowNotice(MessageConstants.COURSE_DELETE_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Delete Course Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnDeleteCourseCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpConfirmDeleteCourse.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Copy Course button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCreateCourseCopy_Click(object sender, EventArgs e)
        {
            try
            {
                mpCopyCourse.Show();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Copy Course Confirmation button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCopyCourseConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.CreateCopy();
                mpCopyCourse.Hide();
                this.ShowNotice(MessageConstants.COURSE_COPY_SUCCESS, NoticeType.Information);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the Copy Course Cancel button is clicked
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The arguments of the event</param>
        protected void btnCopyCourseCancel_Click(object sender, EventArgs e)
        {
            try
            {
                mpCopyCourse.Hide();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Event taking place when the course details are validated for save
        /// </summary>
        /// <param name="sender">The object causing the event</param>
        /// <param name="e">The validation arguments of the event</param>
        protected void cvCourse_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = this.ProgramID.HasValue && this.SystemID.HasValue && this.CourseLevelID.HasValue && this.POIID.HasValue && this.Interval.HasValue &&
                    !String.IsNullOrEmpty(this.CourseName);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
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

                if (value != null)
                {
                    cmbCourse.Items.Add(new ListItem("-- New Course --", String.Empty));

                    foreach (Course course in value)
                    {
                        cmbCourse.Items.Add(new ListItem(course.ExtendedProperties.DisplayName, course.CourseID.ToStringSafe()));
                    }
                }
                else
                {
                    cmbCourse.Items.Add(new ListItem("No Program Selected", String.Empty));
                }

                cmbCourse.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the current selected course
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
        /// The value for the course name
        /// </summary>
        public String CourseName
        {
            get
            {
                return txtCourseName.Text;
            }
            set
            {
                txtCourseName.Text = value;
            }
        }

        /// <summary>
        /// The list of course numbers
        /// </summary>
        public IList<CourseNumber> CourseNumbers
        {
            set
            {
                cmbCourseNumber.Items.Clear();

                cmbCourseNumber.Items.Add(new ListItem("-- Select a Course Number --", String.Empty));

                foreach (CourseNumber number in value)
                {
                    cmbCourseNumber.Items.Add(new ListItem(number.CourseNumberName, number.CourseNumberID.ToStringSafe()));
                }

                cmbCourseNumber.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The value for whether training takes place on no fly days
        /// </summary>
        public Nullable<Boolean> TrainNoFlyDay
        {
            get
            {
                return chkTrainNoFlyDays.Checked;
            }
            set
            {
                chkTrainNoFlyDays.Checked = value == true;
            }
        }

        /// <summary>
        /// The value for whether reporting takes place on no fly days
        /// </summary>
        public Nullable<Boolean> ReportNoFlyDay
        {
            get
            {
                return chkReportNoFlyDays.Checked;
            }
            set
            {
                chkReportNoFlyDays.Checked = value == true;
            }
        }

        /// <summary>
        /// The ID of the currently selected course number
        /// </summary>
        public Nullable<Int32> CourseNumberID
        {
            get
            {
                return cmbCourseNumber.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbCourseNumber.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The value for the minimum class size
        /// </summary>
        public Nullable<Int16> MinClassSize
        {
            get
            {
                return ncClassSizeMinimum.Value.ToNullable<Int16>();
            }
            set
            {
                ncClassSizeMinimum.Value = value;
            }
        }

        /// <summary>
        /// The value for the optimum class size
        /// </summary>
        public Nullable<Int16> OptClassSize
        {
            get
            {
                return ncClassSizeOptimum.Value.ToNullable<Int16>();
            }
            set
            {
                ncClassSizeOptimum.Value = value;
            }
        }

        /// <summary>
        /// The value for the maximum class size
        /// </summary>
        public Nullable<Int16> MaxClassSize
        {
            get
            {
                return ncClassSizeMaximum.Value.ToNullable<Int16>();
            }
            set
            {
                ncClassSizeMaximum.Value = value;
            }
        }

        /// <summary>
        /// The value for the class prefix
        /// </summary>
        public String Prefix
        {
            get
            {
                return txtPrefix.Text;
            }
            set
            {
                txtPrefix.Text = value;
            }
        }

        /// <summary>
        /// The value for the class phase
        /// </summary>
        public String Phase
        {
            get
            {
                return txtPhase.Text;
            }
            set
            {
                txtPhase.Text = value;
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

                foreach (CourseLevel level in value)
                {
                    cmbCourseLevel.Items.Add(new ListItem(level.CourseLevelName, level.CourseLevelID.ToStringSafe()));
                }

                cmbCourseLevel.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID for the currently selected course
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
                    cmbSystem.Items.Add(new ListItem(system.SystemName, system.SystemID.ToStringSafe()));
                }

                cmbSystem.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID for the currently selected system
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
        /// The ID for the currently seleted program
        /// </summary>
        public Nullable<Int32> ProgramID
        {
            get
            {
                return cmbProgram.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbProgram.SelectedValue = value.ToStringSafe(String.Empty);
            }
        }

        /// <summary>
        /// The list of course types
        /// </summary>
        public IList<CourseType> CourseTypes
        {
            set
            {
                cmbCourseType.Items.Clear();

                cmbCourseType.Items.Add(new ListItem("-- Select a Course Type --", String.Empty));

                foreach (CourseType type in value)
                {
                    cmbCourseType.Items.Add(new ListItem(type.CourseTypeName, type.CourseTypeID.ToStringSafe()));
                }

                cmbCourseType.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID of the currently selected course type
        /// </summary>
        public Nullable<Int32> CourseTypeID
        {
            get
            {
                return cmbCourseType.SelectedValue.ToNullable<Int32>();
            }
            set
            {
                cmbCourseType.SelectedValue = value.ToStringSafe(String.Empty);
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

                cmbPOI.Items.Add(new ListItem("-- Select a POI --", String.Empty));

                foreach (POI poi in value)
                {
                    cmbPOI.Items.Add(new ListItem(poi.POIName, poi.POIID.ToStringSafe()));
                }

                cmbPOI.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// The ID for the currently selected POI
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
        /// The value for the interval
        /// </summary>
        public Nullable<Int16> Interval
        {
            get
            {
                return ncClassInterval.Value.ToNullable<Int16>();
            }
            set
            {
                ncClassInterval.Value = value;
            }
        }

        /// <summary>
        /// The calculated value for course weeks
        /// </summary>
        public Nullable<Int32> CourseWeeks
        {
            set
            {
                ltrCourseLengthWeeks.Text = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The calculated value for course days
        /// </summary>
        public Nullable<Int32> CourseDays
        {
            set
            {
                ltrCourseLengthDays.Text = value.ToStringSafe();
            }
        }

        /// <summary>
        /// The calculated value for if this course is a carry over course
        /// </summary>
        public Boolean IsCarryOver
        {
            set
            {
                /*cmbCourseNumber.Enabled = !value;
                cmbSystem.Enabled = !value;
                txtClassSizeMinimum.Enabled = !value;
                txtClassSizeMaximum.Enabled = !value;
                txtClassSizeOptimum.Enabled = !value;
                txtCourseName.Enabled = !value;
                cmbPOI.Enabled = !value;
                txtClassInterval.Enabled = !value;
                cmbCourseType.Enabled = !value;
                txtPhase.Enabled = !value;
                cmbCourseLevel.Enabled = !value;
                txtPrefix.Enabled = !value;
                chkReportNoFlyDays.Enabled = !value;
                chkTrainNoFlyDays.Enabled = !value;
                btnUpdateCourse.Enabled = !value;
                btnDeleteCourse.Enabled = !value;
                lblCarryOver.Visible = value;*/
            }
        }

        /// <summary>
        /// The value for the copied course name
        /// </summary>
        public String CopyCourseName
        {
            get
            {
                return txtCopyCourseName.Text;
            }
            set
            {
                txtCopyCourseName.Text = value;
            }
        }

        /// <summary>
        /// The calculated value for if this is a new course
        /// </summary>
        public Boolean IsNewCourse
        {
            set
            {
                btnCreateCourse.Visible = value;
                btnUpdateCourse.Visible = !value;
                btnDeleteCourse.Visible = !value;
                btnCreateCourseCopy.Visible = !value;
            }
        }

        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        public Boolean AllowEditing
        {
            set
            {
                cmbCourseNumber.Enabled = value;
                cmbSystem.Enabled = value;
                ncClassSizeMinimum.Enabled = value;
                ncClassSizeOptimum.Enabled = value;
                ncClassSizeMaximum.Enabled = value;
                txtCourseName.Enabled = value;
                cmbPOI.Enabled = value;
                ncClassInterval.Enabled = value;
                cmbCourseType.Enabled = value;
                txtPhase.Enabled = value;
                cmbCourseLevel.Enabled = value;
                txtPrefix.Enabled = value;
                chkTrainNoFlyDays.Enabled = value;
                chkReportNoFlyDays.Enabled = value;
                btnCreateCourse.Enabled = value;
                btnUpdateCourse.Enabled = value;
                btnDeleteCourse.Enabled = value;
            }
        }
    }
}