using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.Common.Presentation;

namespace USAACE.ATI.Presentation.Views.Pages
{
    /// <summary>
    /// Interface for the ClassView
    /// </summary>
    public interface IClassDevView : IBaseView
    {
        /// <summary>
        /// The list of programs
        /// </summary>
        IList<Program> Programs { set; }

        /// <summary>
        /// The ID of the currently selected program
        /// </summary>
        Nullable<Int32> ProgramID { get; set; }

        /// <summary>
        /// The list of courses
        /// </summary>
        IList<Course> Courses { set; }

        /// <summary>
        /// The ID of the currently selected course
        /// </summary>
        Nullable<Int32> CourseID { get; set; }

        /// <summary>
        /// The fiscal year of the currently selected course
        /// </summary>
        Nullable<Int16> CourseFiscalYear { get; set; }

        /// <summary>
        /// The list of POIs
        /// </summary>
        IList<POI> POIs { set; }

        /// <summary>
        /// The ID of the currently selected POI
        /// </summary>
        Nullable<Int32> POIID { get; set; }

        /// <summary>
        /// The value for the maximum classes
        /// </summary>
        Nullable<Int16> MaximumClasses { get; set; }

        /// <summary>
        /// The value for the beginning class
        /// </summary>
        Nullable<Int16> BeginningClass { get; set; }

        /// <summary>
        /// The value for the class load
        /// </summary>
        Nullable<Int16> ClassLoad { get; set; }

        /// <summary>
        /// The value for the report date interval
        /// </summary>
        Nullable<Int16> ReportDateInterval { get; set; }

        /// <summary>
        /// The string for the Student Population Type
        /// </summary>
        String StudentPopulationType { get; set; }

        /// <summary>
        /// The value for the first report date
        /// </summary>
        Nullable<DateTime> FirstReportDate { get; set; }

        /// <summary>
        /// The ID of the currently selected carry over program
        /// </summary>
        Nullable<Int32> CarryOverProgramID { get; }

        /// <summary>
        /// The ID of the currently selected carry over course
        /// </summary>
        Nullable<Int32> CarryOverCourseID { get; set; }

        /// <summary>
        /// The text for the carry over course
        /// </summary>
        String CarryOverCourseText { set; }

        /// <summary>
        /// The number of classes that overflowed as a result of calculation
        /// </summary>
        Nullable<Int32> OverflowCount { get; set; }

        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        Boolean AllowEditing { set; }
    }
}
