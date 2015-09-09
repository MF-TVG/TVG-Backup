using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.Common.Presentation;
using USAACE.ATI.Business.Services;
using USAACE.ATI.Domain.Entities;
using System.Data;
using USAACE.ATI.Business.Util;

namespace USAACE.ATI.Presentation.Presenters.Pages
{
    /// <summary>
    /// Presenter for the ReportsView
    /// </summary>
    public class ReportsPresenter : BasePresenter
    {
        /// <summary>
        /// The ReportsView for the ReportsPresenter
        /// </summary>
        public new IReportsView View
        {
            get
            {
                return base.View as IReportsView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ReportsView
        /// </summary>
        /// <param name="view">The ReportsView</param>
        public ReportsPresenter(IReportsView view)
        {
            base.View = view;
        }

        /// <summary>
        /// Load action for the presenter
        /// </summary>
        public void Load()
        {
            this.View.Programs = DataService.GetPrograms().OrderBy(x => x.ProgramName).ToList();

            LoadCourses();
            LoadCarryOverPrograms();
            LoadCarryOverCourses();

            this.View.Systems = DataService.GetSystems().OrderBy(x => x.SystemName).ToList();
            this.View.CourseLevels = DataService.GetCourseLevels().OrderByDescending(x => x.CourseLevelName).ToList();

            SetEntryFields();
        }

        /// <summary>
        /// Loads eligible carry over programs for the selected program
        /// </summary>
        public void LoadCarryOverPrograms()
        {
            if (this.View.ProgramID.HasValue)
            {
                Program program = new Program();
                program.ProgramID = this.View.ProgramID;

                program = DataService.GetProgram(program);

                this.View.CarryOverPrograms = DataService.GetPrograms().Where(x => x.FiscalYear == (Nullable<Int16>)(program.FiscalYear - 1)).ToList();
            }
            else
            {
                this.View.CarryOverPrograms = new List<Program>();
            }
        }

        /// <summary>
        /// Loads courses for the selected program
        /// </summary>
        public void LoadCourses()
        {
            if (this.View.ProgramID.HasValue)
            {
                IList<USAACE.ATI.Domain.Entities.System> systems = DataService.GetSystems().OrderBy(x => x.SystemName).ToList();
                IList<CourseType> courseTypes = DataService.GetCourseTypes().OrderBy(x => x.CourseTypeName).ToList();

                Course courseToSearch = new Course();
                courseToSearch.ProgramID = this.View.ProgramID;

                IList<Course> courses = DataService.ListCourses(courseToSearch);

                foreach (Course course in courses)
                {
                    course.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(course, systems, courseTypes);
                }

                this.View.Courses = courses.OrderBy(x => x.ExtendedProperties.DisplayName).ToList();
            }
            else
            {
                this.View.Courses = new List<Course>();
            }

            LoadCurrentCourse();
        }

        /// <summary>
        /// Loads eligible carry over courses for the selected course
        /// </summary>
        public void LoadCarryOverCourses()
        {
            if (this.View.CarryOverProgramID.HasValue)
            {
                IList<Domain.Entities.System> systems = DataService.GetSystems().OrderBy(x => x.SystemName).ToList();
                IList<CourseType> courseTypes = DataService.GetCourseTypes().OrderBy(x => x.CourseTypeName).ToList();

                Course courseToSearch = new Course();
                courseToSearch.ProgramID = this.View.CarryOverProgramID;

                IList<Course> courses = DataService.ListCourses(courseToSearch).OrderBy(x => x.CourseName).ToList();

                foreach (Course course in courses)
                {
                    course.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(course, systems, courseTypes);
                }

                this.View.CarryOverCourses = courses;
            }
            else
            {
                this.View.CarryOverCourses = new List<Course>();
            }
        }

        /// <summary>
        /// Loads the current course
        /// </summary>
        public void LoadCurrentCourse()
        {
            if (this.View.CourseID.HasValue)
            {
                Course course = new Course();
                course.CourseID = this.View.CourseID;

                course = DataService.LoadCourse(course);

                this.View.SystemIDs = new Int32[] { course.SystemID.Value }.ToList();
                this.View.CourseLevelIDs = new Int32[] { course.CourseLevelID.Value }.ToList();
            }
        }

        /// <summary>
        /// Sets the entry fields pertinent to the filter settings
        /// </summary>
        public void SetEntryFields()
        {
            this.View.EnableCourse = this.View.GroupByType != "None" && this.View.GroupByType != "FYByCourse";
            this.View.EnableReportType = this.View.GroupByType != "None" && this.View.GroupByType != "FYByCourse";

            if (this.View.GroupByType == "None")
            {
                this.View.CourseID = null;
                this.View.ReportType = "Monthly";
            }
            else if (this.View.GroupByType == "FYByCourse")
            {
                this.View.CourseID = null;
                this.View.HoursType = "Forecast";
                this.View.ReportType = "Yearly";
            }
            else
            {
                if (this.View.ReportType == "Yearly")
                {
                    this.View.ReportType = "Monthly";
                }
            }

            this.View.EnableSystem = !this.View.CourseID.HasValue;
            this.View.EnableCourseLevel = !this.View.CourseID.HasValue;

            if (this.View.CourseID.HasValue)
            {
                this.View.GroupByType = "Course";
            }

            this.View.EnableDailyRequirements = this.View.ReportType == "Daily";
            this.View.EnableHoursType = this.View.ReportType == "Monthly";

            if (this.View.ReportType != "Daily")
            {
                this.View.DailyRequirements = null;
            }
            else if (this.View.GroupByType != "FYByCourse")
            {
                this.View.HoursType = "Forecast";
            }

            this.View.EnableSupportHours = this.View.HoursType == "Actual" && this.View.GroupByType != "Course" && this.View.ReportType == "Monthly";

            if (this.View.HoursType != "Actual" || this.View.GroupByType == "Course" || (this.View.ReportType != "Monthly" && this.View.GroupByType != "FYByCourse"))
            {
                this.View.IncludeSupportHours = false;
            }

            this.View.EnableBASOPSHours = this.View.GroupByType != "Course" && this.View.ReportType == "Monthly";

            if (this.View.GroupByType == "Course" || this.View.ReportType != "Monthly")
            {
                this.View.IncludeBASOPSHours = false;
            }

            this.View.EnableAddInHours = this.View.HoursType == "Forecast" && this.View.GroupByType != "Course" && this.View.ReportType == "Monthly";

            if (this.View.HoursType != "Forecast" || this.View.GroupByType == "Course" || this.View.ReportType != "Monthly")
            {
                this.View.IncludeAddInHours = false;
            }
        }

        /// <summary>
        /// Runs the report
        /// </summary>
        public void RunReport()
        {
            DataTable table = null;

            Program program = new Program();
            program.ProgramID = this.View.ProgramID;

            Program carryOverProgram = new Program();
            carryOverProgram.ProgramID = this.View.CarryOverProgramID;

            if (this.View.ReportType == "Monthly")
            {
                if (this.View.GroupByType == "None")
                {
                    table = ReportUtil.GetNonPOIHoursReport(this.View.HoursType == "Forecast", program, this.View.CourseLevelIDs, this.View.SystemIDs, this.View.Reimbursable, this.View.IncludeSupportHours, this.View.IncludeBASOPSHours, this.View.IncludeAddInHours);
                }
                else
                {
                    if (this.View.CourseID.HasValue)
                    {
                        Course course = new Course();
                        course.CourseID = this.View.CourseID;

                        Course carryOverCourse = new Course();
                        carryOverCourse.CourseID = this.View.CarryOverCourseID;

                        table = ReportUtil.GetMonthlyByCourseReport(this.View.HoursType == "Forecast", course, carryOverCourse, this.View.Reimbursable);
                    }
                    else
                    {
                        if (this.View.GroupByType == "System")
                        {
                            table = ReportUtil.GetMonthlyBySystemReport(this.View.HoursType == "Forecast", program, carryOverProgram, this.View.CourseLevelIDs, this.View.SystemIDs, this.View.Reimbursable, this.View.IncludeBASOPSHours, this.View.IncludeAddInHours, this.View.IncludeSupportHours);
                        }
                        else
                        {
                            table = ReportUtil.GetMonthlyByCourseReport(this.View.HoursType == "Forecast", program, carryOverProgram, this.View.CourseLevelIDs, this.View.SystemIDs, this.View.Reimbursable);
                        }
                    }
                }
            }
            else if (this.View.ReportType == "Yearly")
            {
                table = ReportUtil.GetYearlyRequirementsReport(program, carryOverProgram, this.View.CourseLevelIDs, this.View.SystemIDs, this.View.Reimbursable);
            }
            else
            {
                if (this.View.CourseID.HasValue)
                {
                    Course course = new Course();
                    course.CourseID = this.View.CourseID;

                    Course carryOverCourse = new Course();
                    carryOverCourse.CourseID = this.View.CarryOverCourseID;

                    table = ReportUtil.GetDailyRequirementsByCourseReport(course, carryOverCourse, this.View.Reimbursable, this.View.DailyRequirements);
                }
                else
                {
                    if (this.View.GroupByType == "System")
                    {
                        table = ReportUtil.GetDailyRequirementsBySystemReport(program, carryOverProgram, this.View.CourseLevelIDs, this.View.SystemIDs, this.View.Reimbursable, this.View.DailyRequirements);
                    }
                    else
                    {
                        table = ReportUtil.GetDailyRequirementsByCourseReport(program, carryOverProgram, this.View.CourseLevelIDs, this.View.SystemIDs, this.View.Reimbursable, this.View.DailyRequirements);
                    }
                }
            }

            this.View.ReportData = table;
        }
    }
}
