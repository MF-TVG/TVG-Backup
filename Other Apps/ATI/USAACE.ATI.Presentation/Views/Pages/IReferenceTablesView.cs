using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.Common.Presentation;

namespace USAACE.ATI.Presentation.Views.Pages
{
    /// <summary>
    /// Interface for the ReferenceTablesView
    /// </summary>
    public interface IReferenceTablesView : IBaseView
    {
        /// <summary>
        /// The value for whether to show the objectives section
        /// </summary>
        Boolean IsObjectivesVisible { get; set; }

        /// <summary>
        /// The value for whether to show the systems section
        /// </summary>
        Boolean IsSystemsVisible { get; set; }

        /// <summary>
        /// The value for whether to show the miscellaneous hours section
        /// </summary>
        Boolean IsMiscHoursVisible { get; set; }

        /// <summary>
        /// The value for whether to show the locations section
        /// </summary>
        Boolean IsLocationsVisible { get; set; }

        /// <summary>
        /// The value for whether to show the course levels section
        /// </summary>
        Boolean IsCourseLevelsVisible { get; set; }

        /// <summary>
        /// The value for whether to show the course types section
        /// </summary>
        Boolean IsCourseTypesVisible { get; set; }

        /// <summary>
        /// The value for whether to show the course numbers section
        /// </summary>
        Boolean IsCourseNumbersVisible { get; set; }

        /// <summary>
        /// The value for whether to show the no fly types section
        /// </summary>
        Boolean IsNoFlyTypesVisible { get; set; }

        /// <summary>
        /// The value for whether to show the no fly days section
        /// </summary>
        Boolean IsNoFlyDaysVisible { get; set; }

        /// <summary>
        /// The value for the selected section
        /// </summary>
        String SelectedTable { get; }

        /// <summary>
        /// The list of objectives
        /// </summary>
        IList<Objective> Objectives { set; }

        /// <summary>
        /// The ID of the currently selected objective
        /// </summary>
        Nullable<Int32> ObjectiveID { get; set; }

        /// <summary>
        /// The value for the objective name
        /// </summary>
        String ObjectiveName { get; set; }

        /// <summary>
        /// The value for objective night mission status
        /// </summary>
        Nullable<Boolean> ObjectiveNightMission { get; set; }

        /// <summary>
        /// The value for objective flight hours status
        /// </summary>
        Nullable<Boolean> ObjectiveFlightHours { get; set; }

        /// <summary>
        /// The value for objective simulator hours status
        /// </summary>
        Nullable<Boolean> ObjectiveSimulatorHours { get; set; }

        /// <summary>
        /// The value for objective ammunition status
        /// </summary>
        Nullable<Boolean> ObjectiveAmmunition { get; set; }

        /// <summary>
        /// The value for objective contact status
        /// </summary>
        Nullable<Boolean> ObjectiveContact { get; set; }

        /// <summary>
        /// The value for the objective color
        /// </summary>
        String ObjectiveColor { get; set; }

        /// <summary>
        /// The calculated value for whether this is a new objective
        /// </summary>
        Boolean IsNewObjective { set; }

        /// <summary>
        /// The list of miscellaneous hours
        /// </summary>
        IList<MiscHours> MiscHours { set; }

        /// <summary>
        /// The ID of the currently selected miscellaneous hours
        /// </summary>
        Nullable<Int32> MiscHoursID { get; set; }

        /// <summary>
        /// The value for miscellaneous hours name
        /// </summary>
        String MiscHoursName { get; set; }

        /// <summary>
        /// The calculated value for whether this is a new miscellaneous hours
        /// </summary>
        Boolean IsNewMiscHours { set; }

        /// <summary>
        /// The list of locations
        /// </summary>
        IList<Location> Locations { set; }

        /// <summary>
        /// The ID of the currently selected location
        /// </summary>
        Nullable<Int32> LocationID { get; set; }

        /// <summary>
        /// The value for the location name
        /// </summary>
        String LocationName { get; set; }

        /// <summary>
        /// The calculated value for whether this is a new location
        /// </summary>
        Boolean IsNewLocation { set; }

        /// <summary>
        /// The list of systems
        /// </summary>
        IList<USAACE.ATI.Domain.Entities.System> Systems { set; }

        /// <summary>
        /// The ID of the currently selected system
        /// </summary>
        Nullable<Int32> SystemID { get; set; }

        /// <summary>
        /// The value for the system name
        /// </summary>
        String SystemName { get; set; }

        /// <summary>
        /// The value for the system code used for overall ADP code
        /// </summary>
        String SystemCode { get; set; }

        /// <summary>
        /// The current list of system locations
        /// </summary>
        IList<SystemLocation> SystemLocations { get; set; }

        /// <summary>
        /// The calculated value for whether this is a new system
        /// </summary>
        Boolean IsNewSystem { set; }

        /// <summary>
        /// The list of course levels
        /// </summary>
        IList<CourseLevel> CourseLevels { set; }

        /// <summary>
        /// The ID of the currently selected course level
        /// </summary>
        Nullable<Int32> CourseLevelID { get; set; }

        /// <summary>
        /// The value for the course level name
        /// </summary>
        String CourseLevelName { get; set; }

        /// <summary>
        /// The calculated value for whether this is a new course level
        /// </summary>
        Boolean IsNewCourseLevel { set; }

        /// <summary>
        /// The list of course types
        /// </summary>
        IList<CourseType> CourseTypes { set; }

        /// <summary>
        /// The ID of the currently selected course type
        /// </summary>
        Nullable<Int32> CourseTypeID { get; set; }

        /// <summary>
        /// The value for the course type name
        /// </summary>
        String CourseTypeName { get; set; }

        /// <summary>
        /// The value for the course type code used for overall ADP code
        /// </summary>
        String CourseTypeCode { get; set; }

        /// <summary>
        /// The calculated value for whether this is a new course type
        /// </summary>
        Boolean IsNewCourseType { set; }

        /// <summary>
        /// The list of course numbers
        /// </summary>
        IList<CourseNumber> CourseNumbers { set; }

        /// <summary>
        /// The ID of the currently selected course number
        /// </summary>
        Nullable<Int32> CourseNumberID { get; set; }

        /// <summary>
        /// The value for the course number name
        /// </summary>
        String CourseNumberName { get; set; }

        /// <summary>
        /// The calculated value for whether this is a new course number
        /// </summary>
        Boolean IsNewCourseNumber { set; }

        /// <summary>
        /// The value for the course number import data
        /// </summary>
        String CourseNumberImport { get; set;  }

        /// <summary>
        /// The list of no fly types
        /// </summary>
        IList<NoFlyType> NoFlyTypes { set; }

        /// <summary>
        /// The ID of the currently selected no fly type
        /// </summary>
        Nullable<Int32> NoFlyTypeID { get; set; }

        /// <summary>
        /// The value for the no fly type name
        /// </summary>
        String NoFlyTypeName { get; set; }

        /// <summary>
        /// The value for the no fly type color
        /// </summary>
        String NoFlyTypeColor { get; set; }

        /// <summary>
        /// The value for whether the no fly type affects graduation dates
        /// </summary>
        Nullable<Boolean> NoFlyTypeGraduationAffect { get; set; }

        /// <summary>
        /// The calculated value for whether this is a new no fly type
        /// </summary>
        Boolean IsNewNoFlyType { set; }

        /// <summary>
        /// The list of no fly days
        /// </summary>
        IList<NoFlyDay> NoFlyDays { set; }

        /// <summary>
        /// The ID of the currently selected no fly day
        /// </summary>
        Nullable<Int32> NoFlyDayID { get; set; }

        /// <summary>
        /// The value for the no fly day name
        /// </summary>
        String NoFlyDayName { get; set; }

        /// <summary>
        /// The list of no fly types for no fly days
        /// </summary>
        IList<NoFlyType> NoFlyDayTypes { set; }

        /// <summary>
        /// The ID of the currently selected no fly day type
        /// </summary>
        Nullable<Int32> NoFlyDayTypeID { get; set; }

        /// <summary>
        /// The specification type for the no fly day
        /// </summary>
        String NoFlyDaySpecification { get; set; }

        /// <summary>
        /// The calculated value for whether the no fly day start date should be visible
        /// </summary>
        Boolean IsNoFlyDayStartDateVisible { set; }

        /// <summary>
        /// The calculated value for whether the no fly day end date should be visible
        /// </summary>
        Boolean IsNoFlyDayEndDateVisible { set; }

        /// <summary>
        /// The calculated value for whether the no fly day relative date should be visible
        /// </summary>
        Boolean IsNoFlyDayRelativeDateVisible { set; }

        /// <summary>
        /// The value for the no fly day start date month
        /// </summary>
        Nullable<Byte> NoFlyStartDateMonth { get; set; }

        /// <summary>
        /// The value for the no fly day start date day
        /// </summary>
        Nullable<Byte> NoFlyStartDateDay { get; set; }

        /// <summary>
        /// The value for the no fly day end date month
        /// </summary>
        Nullable<Byte> NoFlyEndDateMonth { get; set; }

        /// <summary>
        /// The value for the no fly day end date day
        /// </summary>
        Nullable<Byte> NoFlyEndDateDay { get; set; }

        /// <summary>
        /// The value for the no fly day day of week
        /// </summary>
        Nullable<Byte> NoFlyWeekDay { get; set; }

        /// <summary>
        /// The value for the no fly day week number
        /// </summary>
        Nullable<Byte> NoFlyWeekCount { get; set; }

        /// <summary>
        /// The value for the no fly day relative month
        /// </summary>
        Nullable<Byte> NoFlyWeekMonth { get; set; }

        /// <summary>
        /// The value for whether the no fly day is mobilization exempt
        /// </summary>
        Nullable<Boolean> NoFlyMobilizationExempt { get; set; }

        /// <summary>
        /// The calculated value for whether this is a new no fly day
        /// </summary>
        Boolean IsNewNoFlyDay { set; }
    }
}
