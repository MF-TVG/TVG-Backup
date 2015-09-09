using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.Common.Presentation;

namespace USAACE.ATI.Presentation.Views.Pages
{
    /// <summary>
    /// Interface for the FlightHoursView
    /// </summary>
    public interface IFlightHoursView : IBaseView
    {
        /// <summary>
        /// The list of programs
        /// </summary>
        IList<Program> Programs { set; }

        /// <summary>
        /// The ID of the currently selected program
        /// </summary>
        Nullable<Int32> ProgramID { get; }

        /// <summary>
        /// The value for the default cutoff date
        /// </summary>
        Nullable<DateTime> DefaultCutoffDate { get; }

        /// <summary>
        /// The list of courses
        /// </summary>
        IList<Course> Courses { set; }

        /// <summary>
        /// The ID for the currently selected course
        /// </summary>
        Nullable<Int32> CourseID { get; }

        /// <summary>
        /// The calculated value for whether to show the course selection
        /// </summary>
        Boolean ShowCourse { set; }

        /// <summary>
        /// The list of hours types
        /// </summary>
        IList<HoursType> HoursTypes { set; }

        /// <summary>
        /// The ID of the currently selected hours type
        /// </summary>
        Nullable<Int32> HoursTypeID { get; set; }

        /// <summary>
        /// The list of systems
        /// </summary>
        IList<USAACE.ATI.Domain.Entities.System> Systems { set; }

        /// <summary>
        /// The ID of the currently selected system
        /// </summary>
        Nullable<Int32> SystemID { get; set; }

        /// <summary>
        /// The calculated value for whether to enable system selection
        /// </summary>
        Boolean SystemEnabled { set; }

        /// <summary>
        /// The list of course levels
        /// </summary>
        IList<CourseLevel> CourseLevels { set; }

        /// <summary>
        /// The ID of the currently selected course level
        /// </summary>
        Nullable<Int32> CourseLevelID { get; set; }

        /// <summary>
        /// The calculated value for whether to enable course level selection
        /// </summary>
        Boolean CourseLevelEnabled { set; }

        /// <summary>
        /// The list of miscellaneous hours types
        /// </summary>
        IList<MiscHours> MiscHoursTypes { set; }

        /// <summary>
        /// The ID of the currently selected miscellaneous hours type
        /// </summary>
        Nullable<Int32> MiscHoursTypeID { get; }

        /// <summary>
        /// The calculated value for whether to show the miscellaneous hours type selection
        /// </summary>
        Boolean ShowMiscHoursType { set; }

        /// <summary>
        /// The value for forecast hours selection
        /// </summary>
        Boolean ForecastHours { get; }

        /// <summary>
        /// The values for reimbursable hours selection
        /// </summary>
        Boolean ReimbursableHours { get; }

        /// <summary>
        /// The calculated value for whether actual hours are enabled
        /// </summary>
        Boolean EnableActualHours { set; }

        /// <summary>
        /// The calculated value for whether addin hours are enabled
        /// </summary>
        Boolean EnableAddinHours { set; }

        /// <summary>
        /// The calculated value for whether BASOPS hours are enabled
        /// </summary>
        Boolean EnableBASOPSHours { set; }

        /// <summary>
        /// The calculated value for whether support hours are enabled
        /// </summary>
        Boolean EnableSupportHours { set; }

        /// <summary>
        /// The current list of actual hours
        /// </summary>
        IList<ActualHours> Hours { get; set; }

        /// <summary>
        /// The calculated value for whether to allow hours updates
        /// </summary>
        Boolean ShowHoursUpdate { set; }

        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        Boolean AllowEditing { set; }
    }
}
