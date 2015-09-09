using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.Common.Presentation;

namespace USAACE.ATI.Presentation.Views.Pages
{
    /// <summary>
    /// Interface for the CourseDevView
    /// </summary>
    public interface ICourseDevView : IBaseView
    {
        /// <summary>
        /// The list of courses
        /// </summary>
        IList<Course> Courses { set; }

        /// <summary>
        /// The ID of the current selected course
        /// </summary>
        Nullable<Int32> CourseID { get; set; }

        /// <summary>
        /// The value for the course name
        /// </summary>
        String CourseName { get; set; }

        /// <summary>
        /// The list of course numbers
        /// </summary>
        IList<CourseNumber> CourseNumbers { set; }

        /// <summary>
        /// The ID of the currently selected course number
        /// </summary>
        Nullable<Int32> CourseNumberID { get; set; }

        /// <summary>
        /// The value for the minimum class size
        /// </summary>
        Nullable<Int16> MinClassSize { get; set; }

        /// <summary>
        /// The value for the optimum class size
        /// </summary>
        Nullable<Int16> OptClassSize { get; set; }

        /// <summary>
        /// The value for the maximum class size
        /// </summary>
        Nullable<Int16> MaxClassSize { get; set; }

        /// <summary>
        /// The value for the class prefix
        /// </summary>
        String Prefix { get; set; }

        /// <summary>
        /// The value for the class phase
        /// </summary>
        String Phase { get; set; }

        /// <summary>
        /// The list of course levels
        /// </summary>
        IList<CourseLevel> CourseLevels { set; }

        /// <summary>
        /// The ID for the currently selected course
        /// </summary>
        Nullable<Int32> CourseLevelID { get; set; }

        /// <summary>
        /// The list of systems
        /// </summary>
        IList<USAACE.ATI.Domain.Entities.System> Systems { set; }

        /// <summary>
        /// The ID for the currently selected system
        /// </summary>
        Nullable<Int32> SystemID { get; set; }

        /// <summary>
        /// The list of programs
        /// </summary>
        IList<Program> Programs { set; }

        /// <summary>
        /// The ID for the currently seleted program
        /// </summary>
        Nullable<Int32> ProgramID { get; set; }

        /// <summary>
        /// The list of course types
        /// </summary>
        IList<CourseType> CourseTypes { set; }

        /// <summary>
        /// The ID of the currently selected course type
        /// </summary>
        Nullable<Int32> CourseTypeID { get; set; }

        /// <summary>
        /// The list of POIs
        /// </summary>
        IList<POI> POIs { set; }

        /// <summary>
        /// The ID for the currently selected POI
        /// </summary>
        Nullable<Int32> POIID { get; set; }

        /// <summary>
        /// The value for the interval
        /// </summary>
        Nullable<Int16> Interval { get; set; }

        /// <summary>
        /// The calculated value for course weeks
        /// </summary>
        Nullable<Int32> CourseWeeks { set; }

        /// <summary>
        /// The calculated value for course days
        /// </summary>
        Nullable<Int32> CourseDays { set; }

        /// <summary>
        /// The value for whether training takes place on no fly days
        /// </summary>
        Nullable<Boolean> TrainNoFlyDay { get; set; }

        /// <summary>
        /// The value for whether reporting takes place on no fly days
        /// </summary>
        Nullable<Boolean> ReportNoFlyDay { get; set; }

        /// <summary>
        /// The calculated value for if this course is a carry over course
        /// </summary>
        Boolean IsCarryOver { set; }

        /// <summary>
        /// The value for the copied course name
        /// </summary>
        String CopyCourseName { get; set; }

        /// <summary>
        /// The calculated value for if this is a new course
        /// </summary>
        Boolean IsNewCourse { set; }
        
        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        Boolean AllowEditing { set; }
    }
}
