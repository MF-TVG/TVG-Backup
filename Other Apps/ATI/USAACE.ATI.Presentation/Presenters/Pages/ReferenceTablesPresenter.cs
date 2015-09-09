using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Presentation.Views.Pages;
using USAACE.Common.Presentation;
using USAACE.ATI.Business.Services;
using USAACE.ATI.Domain.Entities;

namespace USAACE.ATI.Presentation.Presenters.Pages
{
    /// <summary>
    /// Presenter for the ReferenceTablesView
    /// </summary>
    public class ReferenceTablesPresenter : BasePresenter
    {
        /// <summary>
        /// The ReferenceTablesView for the ReportsPresenter
        /// </summary>
        public new IReferenceTablesView View
        {
            get
            {
                return base.View as IReferenceTablesView;
            }
        }

        /// <summary>
        /// Constructor accepting an instance of the ReferenceTablesView
        /// </summary>
        /// <param name="view">The ReferenceTablesView</param>
        public ReferenceTablesPresenter(IReferenceTablesView view)
        {
            base.View = view;
        }

        /// <summary>
        /// Load action for the presenter
        /// </summary>
        public void Load()
        {
            if (this.View.SelectedTable == "Objectives")
            {
                this.View.IsObjectivesVisible = true;

                this.View.Objectives = DataService.GetObjectives().OrderBy(x => x.ObjectiveName).ToList();

                LoadObjective();
            }
            else if (this.View.SelectedTable == "Systems")
            {
                this.View.IsSystemsVisible = true;

                this.View.Systems = DataService.GetSystems().OrderBy(x => x.SystemName).ToList();
                this.View.Locations = DataService.GetLocations().OrderBy(x => x.LocationName).ToList();

                LoadSystem();
            }
            else if (this.View.SelectedTable == "Miscellaneous Hours")
            {
                this.View.IsMiscHoursVisible = true;

                this.View.MiscHours = DataService.GetMiscHourses().OrderBy(x => x.MiscHoursName).ToList();

                LoadMiscHours();
            }
            else if (this.View.SelectedTable == "Locations")
            {
                this.View.IsLocationsVisible = true;

                this.View.Locations = DataService.GetLocations().OrderBy(x => x.LocationName).ToList();

                LoadLocation();
            }
            else if (this.View.SelectedTable == "Course Levels")
            {
                this.View.IsCourseLevelsVisible = true;

                this.View.CourseLevels = DataService.GetCourseLevels().OrderBy(x => x.CourseLevelName).ToList();

                LoadCourseLevel();
            }
            else if (this.View.SelectedTable == "Course Types")
            {
                this.View.IsCourseTypesVisible = true;

                this.View.CourseTypes = DataService.GetCourseTypes().OrderBy(x => x.CourseTypeName).ToList();

                LoadCourseType();
            }
            else if (this.View.SelectedTable == "Course Numbers")
            {
                this.View.IsCourseNumbersVisible = true;

                this.View.CourseNumbers = DataService.GetCourseNumbers().OrderBy(x => x.CourseNumberName).ToList();

                LoadCourseNumber();
            }
            else if (this.View.SelectedTable == "No Fly Day Types")
            {
                this.View.IsNoFlyTypesVisible = true;

                this.View.NoFlyTypes = DataService.ListNoFlyTypes().OrderBy(x => x.NoFlyTypeName).ToList();

                LoadNoFlyType();
            }
            else if (this.View.SelectedTable == "No Fly Days")
            {
                this.View.IsNoFlyDaysVisible = true;

                this.View.NoFlyDays = DataService.ListNoFlyDays().OrderBy(x => x.NoFlyDayName).ToList();
                this.View.NoFlyDayTypes = DataService.ListNoFlyTypes().OrderBy(x => x.NoFlyTypeName).ToList();

                LoadNoFlyDay();
            }
        }

        /// <summary>
        /// Loads the selected objective
        /// </summary>
        public void LoadObjective()
        {
            if (this.View.ObjectiveID.HasValue)
            {
                Objective objective = new Objective();
                objective.ObjectiveID = this.View.ObjectiveID;

                objective = DataService.GetObjective(objective);

                this.View.ObjectiveName = objective.ObjectiveName;
                this.View.ObjectiveNightMission = objective.NightMission;
                this.View.ObjectiveFlightHours = objective.FlightHours;
                this.View.ObjectiveSimulatorHours = objective.SimulatorHours;
                this.View.ObjectiveAmmunition = objective.Ammunition;
                this.View.ObjectiveContact = objective.Contact;
                this.View.ObjectiveColor = objective.Color;
                this.View.IsNewObjective = false;
            }
            else
            {
                this.View.ObjectiveName = null;
                this.View.ObjectiveNightMission = null;
                this.View.ObjectiveFlightHours = null;
                this.View.ObjectiveSimulatorHours = null;
                this.View.ObjectiveAmmunition = null;
                this.View.ObjectiveContact = null;
                this.View.ObjectiveColor = null;
                this.View.IsNewObjective = true;
            }
        }

        /// <summary>
        /// Saves the selected objective
        /// </summary>
        public void SaveObjective()
        {
            Objective objective = new Objective();
            objective.ObjectiveID = this.View.ObjectiveID;

            if (objective.ObjectiveID.HasValue)
            {
                objective = DataService.GetObjective(objective);
            }

            objective.ObjectiveName = this.View.ObjectiveName;
            objective.NightMission = this.View.ObjectiveNightMission;
            objective.FlightHours = this.View.ObjectiveFlightHours;
            objective.SimulatorHours = this.View.ObjectiveSimulatorHours;
            objective.Ammunition = this.View.ObjectiveAmmunition;
            objective.Contact = this.View.ObjectiveContact;
            objective.Color = this.View.ObjectiveColor;

            objective = DataService.SaveObjective(objective);

            Load();

            this.View.ObjectiveID = objective.ObjectiveID;

            LoadObjective();
        }

        /// <summary>
        /// Deletes the selected objective
        /// </summary>
        public void DeleteObjective()
        {
            Objective objective = new Objective();
            objective.ObjectiveID = this.View.ObjectiveID;

            DataService.DeleteObjective(objective);

            Load();
        }

        /// <summary>
        /// Loads the selected miscellaneous hours
        /// </summary>
        public void LoadMiscHours()
        {
            if (this.View.MiscHoursID.HasValue)
            {
                MiscHours miscHours = new MiscHours();
                miscHours.MiscHoursID = this.View.MiscHoursID;

                miscHours = DataService.GetMiscHours(miscHours);

                this.View.MiscHoursName = miscHours.MiscHoursName;
                this.View.IsNewMiscHours = false;
            }
            else
            {
                this.View.MiscHoursName = null;
                this.View.IsNewMiscHours = true;
            }
        }

        /// <summary>
        /// Saves the selected miscellaneous hours
        /// </summary>
        public void SaveMiscHours()
        {
            MiscHours miscHours = new MiscHours();
            miscHours.MiscHoursID = this.View.MiscHoursID;

            if (miscHours.MiscHoursID.HasValue)
            {
                miscHours = DataService.GetMiscHours(miscHours);
            }

            miscHours.MiscHoursName = this.View.MiscHoursName;

            miscHours = DataService.SaveMiscHours(miscHours);

            Load();

            this.View.MiscHoursID = miscHours.MiscHoursID;

            LoadMiscHours();
        }

        /// <summary>
        /// Deletes the selected miscellaneous hours
        /// </summary>
        public void DeleteMiscHours()
        {
            MiscHours miscHours = new MiscHours();
            miscHours.MiscHoursID = this.View.MiscHoursID;

            DataService.DeleteMiscHours(miscHours);

            Load();
        }

        /// <summary>
        /// Loads the selected location
        /// </summary>
        public void LoadLocation()
        {
            if (this.View.LocationID.HasValue)
            {
                Location location = new Location();
                location.LocationID = this.View.LocationID;

                location = DataService.GetLocation(location);

                this.View.LocationName = location.LocationName;
                this.View.IsNewLocation = false;
            }
            else
            {
                this.View.LocationName = null;
                this.View.IsNewLocation = true;
            }
        }

        /// <summary>
        /// Saves the selected location
        /// </summary>
        public void SaveLocation()
        {
            Location location = new Location();
            location.LocationID = this.View.LocationID;

            if (location.LocationID.HasValue)
            {
                location = DataService.GetLocation(location);
            }

            location.LocationName = this.View.LocationName;

            location = DataService.SaveLocation(location);

            Load();

            this.View.LocationID = location.LocationID;

            LoadLocation();
        }

        /// <summary>
        /// Deletes the selected location
        /// </summary>
        public void DeleteLocation()
        {
            Location location = new Location();
            location.LocationID = this.View.LocationID;

            DataService.DeleteLocation(location);

            Load();
        }

        /// <summary>
        /// Loads the selected system
        /// </summary>
        public void LoadSystem()
        {
            if (this.View.SystemID.HasValue)
            {
                USAACE.ATI.Domain.Entities.System system = new USAACE.ATI.Domain.Entities.System();
                system.SystemID = this.View.SystemID;

                system = DataService.GetSystem(system);

                this.View.SystemName = system.SystemName;
                this.View.SystemCode = system.SystemCode;
                this.View.IsNewSystem = false;

                SystemLocation systemLocation = new SystemLocation();
                systemLocation.SystemID = this.View.SystemID;

                this.View.SystemLocations = DataService.ListSystemLocations(systemLocation);
            }
            else
            {
                this.View.SystemName = null;
                this.View.SystemCode = null;
                this.View.IsNewSystem = true;

                this.View.SystemLocations = null;
            }
        }

        /// <summary>
        /// Saves the selected system
        /// </summary>
        public void SaveSystem()
        {
            USAACE.ATI.Domain.Entities.System system = new USAACE.ATI.Domain.Entities.System();
            system.SystemID = this.View.SystemID;

            if (system.SystemID.HasValue)
            {
                system = DataService.GetSystem(system);
            }

            system.SystemName = this.View.SystemName;
            system.SystemCode = this.View.SystemCode;

            system = DataService.SaveSystem(system);

            SystemLocation systemLocation = new SystemLocation();
            systemLocation.SystemID = system.SystemID;

            DataService.SaveSystemLocations(systemLocation, this.View.SystemLocations);

            Load();

            this.View.SystemID = system.SystemID;

            LoadSystem();
        }

        /// <summary>
        /// Deletes the selected system
        /// </summary>
        public void DeleteSystem()
        {
            USAACE.ATI.Domain.Entities.System system = new USAACE.ATI.Domain.Entities.System();
            system.SystemID = this.View.SystemID;

            DataService.DeleteSystem(system);

            Load();
        }

        /// <summary>
        /// Loads the selected course level
        /// </summary>
        public void LoadCourseLevel()
        {
            if (this.View.CourseLevelID.HasValue)
            {
                CourseLevel courseLevel = new CourseLevel();
                courseLevel.CourseLevelID = this.View.CourseLevelID;

                courseLevel = DataService.GetCourseLevel(courseLevel);

                this.View.CourseLevelName = courseLevel.CourseLevelName;
                this.View.IsNewCourseLevel = false;
            }
            else
            {
                this.View.CourseLevelName = null;
                this.View.IsNewCourseLevel = true;
            }
        }

        /// <summary>
        /// Saves the selected course level
        /// </summary>
        public void SaveCourseLevel()
        {
            CourseLevel courseLevel = new CourseLevel();
            courseLevel.CourseLevelID = this.View.CourseLevelID;

            if (courseLevel.CourseLevelID.HasValue)
            {
                courseLevel = DataService.GetCourseLevel(courseLevel);
            }

            courseLevel.CourseLevelName = this.View.CourseLevelName;

            courseLevel = DataService.SaveCourseLevel(courseLevel);

            Load();

            this.View.CourseLevelID = courseLevel.CourseLevelID;

            LoadCourseLevel();
        }

        /// <summary>
        /// Deletes the selected course level
        /// </summary>
        public void DeleteCourseLevel()
        {
            CourseLevel courseLevel = new CourseLevel();
            courseLevel.CourseLevelID = this.View.CourseLevelID;

            DataService.DeleteCourseLevel(courseLevel);

            Load();
        }

        /// <summary>
        /// Loads the selected course type
        /// </summary>
        public void LoadCourseType()
        {
            if (this.View.CourseTypeID.HasValue)
            {
                CourseType courseType = new CourseType();
                courseType.CourseTypeID = this.View.CourseTypeID;

                courseType = DataService.GetCourseType(courseType);

                this.View.CourseTypeName = courseType.CourseTypeName;
                this.View.CourseTypeCode = courseType.CourseTypeCode;
                this.View.IsNewCourseType = false;
            }
            else
            {
                this.View.CourseTypeName = null;
                this.View.CourseTypeCode = null;
                this.View.IsNewCourseType = true;
            }
        }

        /// <summary>
        /// Saves the selected course type
        /// </summary>
        public void SaveCourseType()
        {
            CourseType courseType = new CourseType();
            courseType.CourseTypeID = this.View.CourseTypeID;

            if (courseType.CourseTypeID.HasValue)
            {
                courseType = DataService.GetCourseType(courseType);
            }

            courseType.CourseTypeName = this.View.CourseTypeName;
            courseType.CourseTypeCode = this.View.CourseTypeCode;

            courseType = DataService.SaveCourseType(courseType);

            Load();

            this.View.CourseTypeID = courseType.CourseTypeID;

            LoadCourseType();
        }

        /// <summary>
        /// Deletes the selected course type
        /// </summary>
        public void DeleteCourseType()
        {
            CourseType courseType = new CourseType();
            courseType.CourseTypeID = this.View.CourseTypeID;

            DataService.DeleteCourseType(courseType);

            Load();
        }

        /// <summary>
        /// Loads the selected course number
        /// </summary>
        public void LoadCourseNumber()
        {
            if (this.View.CourseNumberID.HasValue)
            {
                CourseNumber courseNumber = new CourseNumber();
                courseNumber.CourseNumberID = this.View.CourseNumberID;

                courseNumber = DataService.GetCourseNumber(courseNumber);

                this.View.CourseNumberName = courseNumber.CourseNumberName;
                this.View.IsNewCourseNumber = false;
            }
            else
            {
                this.View.CourseNumberName = null;
                this.View.IsNewCourseNumber = true;
            }
        }

        /// <summary>
        /// Saves the selected course number
        /// </summary>
        public void SaveCourseNumber()
        {
            CourseNumber courseNumber = new CourseNumber();
            courseNumber.CourseNumberID = this.View.CourseNumberID;

            if (courseNumber.CourseNumberID.HasValue)
            {
                courseNumber = DataService.GetCourseNumber(courseNumber);
            }

            courseNumber.CourseNumberName = this.View.CourseNumberName;

            courseNumber = DataService.SaveCourseNumber(courseNumber);

            Load();

            this.View.CourseNumberID = courseNumber.CourseNumberID;

            LoadCourseNumber();
        }

        /// <summary>
        /// Deletes the selected course number
        /// </summary>
        public void DeleteCourseNumber()
        {
            CourseNumber courseNumber = new CourseNumber();
            courseNumber.CourseNumberID = this.View.CourseNumberID;

            DataService.DeleteCourseNumber(courseNumber);

            Load();
        }

        /// <summary>
        /// Imports course numbers from the text
        /// </summary>
        public void ImportCourseNumber()
        {
            IList<CourseNumber> courseNumbers = DataService.GetCourseNumbers();

            foreach (String courseNumber in this.View.CourseNumberImport.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                String courseNumberText = courseNumber.Trim();

                if (!courseNumbers.Any(x => x.CourseNumberName == courseNumberText))
                {
                    CourseNumber number = new CourseNumber();
                    number.CourseNumberName = courseNumberText;

                    number = DataService.SaveCourseNumber(number);

                    courseNumbers.Add(number);
                }
            }

            this.View.CourseNumbers = DataService.GetCourseNumbers().OrderBy(x => x.CourseNumberName).ToList();

            LoadCourseNumber();
        }

        /// <summary>
        /// Loads the selected no fly type
        /// </summary>
        public void LoadNoFlyType()
        {
            if (this.View.NoFlyTypeID.HasValue)
            {
                NoFlyType type = new NoFlyType();
                type.NoFlyTypeID = this.View.NoFlyTypeID;

                type = DataService.LoadNoFlyType(type);

                this.View.NoFlyTypeName = type.NoFlyTypeName;
                this.View.NoFlyTypeColor = type.NoFlyTypeColor;
                this.View.NoFlyTypeGraduationAffect = type.AdjustGradDate;
                this.View.IsNewNoFlyType = false;
            }
            else
            {
                this.View.NoFlyTypeName = null;
                this.View.NoFlyTypeColor = null;
                this.View.NoFlyTypeGraduationAffect = null;
                this.View.IsNewNoFlyType = true;
            }
        }

        /// <summary>
        /// Saves the selected no fly type
        /// </summary>
        public void SaveNoFlyType()
        {
            NoFlyType type = new NoFlyType();
            type.NoFlyTypeID = this.View.NoFlyTypeID;

            if (type.NoFlyTypeID.HasValue)
            {
                type = DataService.LoadNoFlyType(type);
            }

            type.NoFlyTypeName = this.View.NoFlyTypeName;
            type.NoFlyTypeColor = this.View.NoFlyTypeColor;
            type.AdjustGradDate = this.View.NoFlyTypeGraduationAffect;

            type = DataService.SaveNoFlyType(type);

            Load();

            this.View.NoFlyTypeID = type.NoFlyTypeID;

            LoadNoFlyType();
        }

        /// <summary>
        /// Deletes the selected no fly type
        /// </summary>
        public void DeleteNoFlyType()
        {
            NoFlyType type = new NoFlyType();
            type.NoFlyTypeID = this.View.NoFlyTypeID;

            DataService.DeleteNoFlyType(type);

            Load();
        }

        /// <summary>
        /// Loads the selected no fly day
        /// </summary>
        public void LoadNoFlyDay()
        {
            if (this.View.NoFlyDayID.HasValue)
            {
                NoFlyDay day = new NoFlyDay();
                day.NoFlyDayID = this.View.NoFlyDayID;

                day = DataService.LoadNoFlyDay(day);

                this.View.NoFlyDayName = day.NoFlyDayName;
                this.View.NoFlyDayTypeID = day.NoFlyTypeID;

                if (day.StartDateMonth.HasValue && day.StartDateDay.HasValue)
                {
                    if (day.EndDateMonth.HasValue && day.EndDateDay.HasValue)
                    {
                        this.View.NoFlyDaySpecification = "Range";

                        this.View.NoFlyEndDateMonth = day.EndDateMonth;
                        this.View.NoFlyEndDateDay = day.EndDateDay;
                    }
                    else
                    {
                        this.View.NoFlyDaySpecification = "Specific";
                    }

                    this.View.NoFlyStartDateMonth = day.StartDateMonth;
                    this.View.NoFlyStartDateDay = day.StartDateDay;
                }
                else if (day.WeekDay.HasValue)
                {
                    this.View.NoFlyDaySpecification = "Relative";

                    this.View.NoFlyWeekDay = day.WeekDay;
                    this.View.NoFlyWeekCount = day.WeekCount;
                    this.View.NoFlyWeekMonth = day.WeekMonth;
                }

                this.View.NoFlyMobilizationExempt = day.MobilizationExempt;

                this.View.IsNewNoFlyDay = false;
            }
            else
            {
                this.View.NoFlyDayName = null;
                this.View.NoFlyDayTypeID = null;
                this.View.NoFlyDaySpecification = null;
                this.View.NoFlyMobilizationExempt = null;
                this.View.IsNewNoFlyDay = true;
            }

            SetNoFlyDaySpecification();
        }

        /// <summary>
        /// Saves the selected no fly day
        /// </summary>
        public void SaveNoFlyDay()
        {
            NoFlyDay day = new NoFlyDay();
            day.NoFlyDayID = this.View.NoFlyDayID;

            if (day.NoFlyDayID.HasValue)
            {
                day = DataService.LoadNoFlyDay(day);
            }

            day.NoFlyDayName = this.View.NoFlyDayName;
            day.NoFlyTypeID = this.View.NoFlyDayTypeID;
            day.StartDateMonth = this.View.NoFlyStartDateMonth;
            day.StartDateDay = this.View.NoFlyStartDateDay;
            day.EndDateMonth = this.View.NoFlyEndDateMonth;
            day.EndDateDay = this.View.NoFlyEndDateDay;
            day.WeekDay = this.View.NoFlyWeekDay;
            day.WeekCount = this.View.NoFlyWeekCount;
            day.WeekMonth = this.View.NoFlyWeekMonth;
            day.MobilizationExempt = this.View.NoFlyMobilizationExempt;

            day = DataService.SaveNoFlyDay(day);

            Load();

            this.View.NoFlyDayID = day.NoFlyDayID;

            LoadNoFlyDay();
        }

        /// <summary>
        /// Deletes the selected no fly day
        /// </summary>
        public void DeleteNoFlyDay()
        {
            NoFlyDay day = new NoFlyDay();
            day.NoFlyDayID = this.View.NoFlyDayID;

            DataService.DeleteNoFlyDay(day);

            Load();
        }

        /// <summary>
        /// Sets no fly day options based on type
        /// </summary>
        public void SetNoFlyDaySpecification()
        {
            if (this.View.NoFlyDaySpecification == "Specific")
            {
                this.View.IsNoFlyDayStartDateVisible = true;
                this.View.IsNoFlyDayEndDateVisible = false;
                this.View.IsNoFlyDayRelativeDateVisible = false;

                this.View.NoFlyEndDateMonth = null;
                this.View.NoFlyEndDateDay = null;
                this.View.NoFlyWeekDay = null;
                this.View.NoFlyWeekCount = null;
                this.View.NoFlyWeekMonth = null;
            }
            else if (this.View.NoFlyDaySpecification == "Range")
            {
                this.View.IsNoFlyDayStartDateVisible = true;
                this.View.IsNoFlyDayEndDateVisible = true;
                this.View.IsNoFlyDayRelativeDateVisible = false;

                this.View.NoFlyWeekDay = null;
                this.View.NoFlyWeekCount = null;
                this.View.NoFlyWeekMonth = null;
            }
            else if (this.View.NoFlyDaySpecification == "Relative")
            {
                this.View.IsNoFlyDayStartDateVisible = false;
                this.View.IsNoFlyDayEndDateVisible = false;
                this.View.IsNoFlyDayRelativeDateVisible = true;

                this.View.NoFlyStartDateMonth = null;
                this.View.NoFlyStartDateDay = null;
                this.View.NoFlyEndDateMonth = null;
                this.View.NoFlyEndDateDay = null;
            }
            else
            {
                this.View.IsNoFlyDayStartDateVisible = false;
                this.View.IsNoFlyDayEndDateVisible = false;
                this.View.IsNoFlyDayRelativeDateVisible = false;

                this.View.NoFlyStartDateMonth = null;
                this.View.NoFlyStartDateDay = null;
                this.View.NoFlyEndDateMonth = null;
                this.View.NoFlyEndDateDay = null;
                this.View.NoFlyWeekDay = null;
                this.View.NoFlyWeekCount = null;
                this.View.NoFlyWeekMonth = null;
            }
        }
    }
}
