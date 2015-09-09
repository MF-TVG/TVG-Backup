using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.Common.Presentation;

namespace USAACE.ATI.Presentation.Views.Pages
{
    /// <summary>
    /// Interface for the FlightHoursView
    /// </summary>
    public interface IHistoricalPercentView : IBaseView
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
        /// The edit mode for the historical percents
        /// </summary>
        String EditMode { get; }

        /// <summary>
        /// Whether to show by course
        /// </summary>
        Boolean ShowByCourse { set; }

        /// <summary>
        /// Whether to show mass edit
        /// </summary>
        Boolean ShowMassEdit { set; }

        /// <summary>
        /// The list of courses
        /// </summary>
        IList<Course> Courses { set; }

        /// <summary>
        /// The ID of the currently selected course
        /// </summary>
        Nullable<Int32> CourseID { get; set; }

        /// <summary>
        /// The list of systems
        /// </summary>
        IList<USAACE.ATI.Domain.Entities.System> Systems { set; }

        /// <summary>
        /// The list of selected system ID values
        /// </summary>
        IList<Nullable<Int32>> SystemIDs { get; }

        /// <summary>
        /// The list of course levels
        /// </summary>
        IList<CourseLevel> CourseLevels { set; }

        /// <summary>
        /// The list of selected course level ID values
        /// </summary>
        IList<Nullable<Int32>> CourseLevelIDs { get; }

        /// <summary>
        /// The list of course types
        /// </summary>
        IList<CourseType> CourseTypes { set; }

        /// <summary>
        /// The list of selected course type ID values
        /// </summary>
        IList<Nullable<Int32>> CourseTypeIDs { get; }

        /// <summary>
        /// The value for the historical percent for October
        /// </summary>
        Nullable<Int16> PercentOctober { get; set; }

        /// <summary>
        /// The value for the historical percent for November
        /// </summary>
        Nullable<Int16> PercentNovember { get; set; }

        /// <summary>
        /// The value for the historical percent for December
        /// </summary>
        Nullable<Int16> PercentDecember { get; set; }

        /// <summary>
        /// The value for the historical percent for January
        /// </summary>
        Nullable<Int16> PercentJanuary { get; set; }

        /// <summary>
        /// The value for the historical percent for February
        /// </summary>
        Nullable<Int16> PercentFebruary { get; set; }

        /// <summary>
        /// The value for the historical percent for March
        /// </summary>
        Nullable<Int16> PercentMarch { get; set; }

        /// <summary>
        /// The value for the historical percent for April
        /// </summary>
        Nullable<Int16> PercentApril { get; set; }

        /// <summary>
        /// The value for the historical percent for May
        /// </summary>
        Nullable<Int16> PercentMay { get; set; }

        /// <summary>
        /// The value for the historical percent for June
        /// </summary>
        Nullable<Int16> PercentJune { get; set; }

        /// <summary>
        /// The value for the historical percent for July
        /// </summary>
        Nullable<Int16> PercentJuly { get; set; }

        /// <summary>
        /// The value for the historical percent for August
        /// </summary>
        Nullable<Int16> PercentAugust { get; set; }

        /// <summary>
        /// The value for the historical percent for September
        /// </summary>
        Nullable<Int16> PercentSeptember { get; set; }

        /// <summary>
        /// The value for the historical percent for Support
        /// </summary>
        Nullable<Int16> PercentSupport { get; set; }

        /// <summary>
        /// The value for the historical percent for Setback
        /// </summary>
        Nullable<Int16> PercentSetback { get; set; }

        /// <summary>
        /// The value for the historical percent for Test
        /// </summary>
        Nullable<Int16> PercentTest { get; set; }

        /// <summary>
        /// The calculated value for whether percents are visible
        /// </summary>
        Boolean IsPercentVisible { set; }

        /// <summary>
        /// Boolean dictating enabling of controls
        /// </summary>
        Boolean AllowEditing { set; }

        /// <summary>
        /// Historical percents report as a data table
        /// </summary>
        DataTable HistoricalPercentsReport { set; }
    }
}
