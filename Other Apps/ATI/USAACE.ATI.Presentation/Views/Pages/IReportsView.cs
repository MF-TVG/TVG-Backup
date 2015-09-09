using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.Common.Presentation;
using System.Data;

namespace USAACE.ATI.Presentation.Views.Pages
{
    /// <summary>
    /// Interface for the ReportsView
    /// </summary>
    public interface IReportsView : IBaseView
    {
        /// <summary>
        /// The list of programs
        /// </summary>
        IList<Program> Programs { set; }

        /// <summary>
        /// The list of carry over programs
        /// </summary>
        IList<Program> CarryOverPrograms { set; }

        /// <summary>
        /// The ID of the currently selected program
        /// </summary>
        Nullable<Int32> ProgramID { get; }

        /// <summary>
        /// The ID of the currently selected carry over program
        /// </summary>
        Nullable<Int32> CarryOverProgramID { get; }

        /// <summary>
        /// The list of courses
        /// </summary>
        IList<Course> Courses { set; }

        /// <summary>
        /// The list of carry over courses
        /// </summary>
        IList<Course> CarryOverCourses { set; }

        /// <summary>
        /// The ID of the currently selected course
        /// </summary>
        Nullable<Int32> CourseID { get; set; }

        /// <summary>
        /// The ID of the currently selected carry over course
        /// </summary>
        Nullable<Int32> CarryOverCourseID { get; set;  }

        /// <summary>
        /// The calculated value for whether to enable course selection
        /// </summary>
        Boolean EnableCourse { set; }

        /// <summary>
        /// The list of systems
        /// </summary>
        IList<USAACE.ATI.Domain.Entities.System> Systems { set; }

        /// <summary>
        /// The list of selected system ID values
        /// </summary>
        IList<Int32> SystemIDs { get; set; }

        /// <summary>
        /// The calculated value for whether to enable system selection
        /// </summary>
        Boolean EnableSystem { set; }

        /// <summary>
        /// The list of course levels
        /// </summary>
        IList<CourseLevel> CourseLevels { set; }

        /// <summary>
        /// The list of selected course level ID values
        /// </summary>
        IList<Int32> CourseLevelIDs { get; set; }

        /// <summary>
        /// The calculated value for whether to enable course level selection
        /// </summary>
        Boolean EnableCourseLevel { set; }

        /// <summary>
        /// The value for the type of report, Monthly or Daily
        /// </summary>
        String ReportType { get; set; }

        /// <summary>
        /// The calculated value for whether to enable report type selection
        /// </summary>
        Boolean EnableReportType { set; }

        /// <summary>
        /// The value for the type of hours, Forecast or Actual
        /// </summary>
        String HoursType { get; set; }

        /// <summary>
        /// The calculated value for whether to enable hours type selection
        /// </summary>
        Boolean EnableHoursType { set; }

        /// <summary>
        /// The value for the grouping parameter for the hours
        /// </summary>
        String GroupByType { get; set; }

        /// <summary>
        /// The value for whether to include support hours
        /// </summary>
        Boolean IncludeSupportHours { get; set; }

        /// <summary>
        /// The calculated value for whether to enable support hours selection
        /// </summary>
        Boolean EnableSupportHours { set; }

        /// <summary>
        /// The value for whether to include BASOPS hours
        /// </summary>
        Boolean IncludeBASOPSHours { get; set; }

        /// <summary>
        /// The calculated value for whether to enable BASOPS hours selection
        /// </summary>
        Boolean EnableBASOPSHours { set; }

        /// <summary>
        /// The value for whether to include addin hours
        /// </summary>
        Boolean IncludeAddInHours { get; set; }

        /// <summary>
        /// The calculated value for whether to enable addins hours selection
        /// </summary>
        Boolean EnableAddInHours { set; }

        /// <summary>
        /// The value for what reimbursable status to include, All, Direct, or Reimbursable
        /// </summary>
        Nullable<Boolean> Reimbursable { get; }

        /// <summary>
        /// The value for the currently selected daily requirements
        /// </summary>
        IList<String> DailyRequirements { get; set; }

        /// <summary>
        /// The calculated value for whether to enable daily requirements selection
        /// </summary>
        Boolean EnableDailyRequirements { set; }

        /// <summary>
        /// The data for the report
        /// </summary>
        DataTable ReportData { set; }
    }
}
