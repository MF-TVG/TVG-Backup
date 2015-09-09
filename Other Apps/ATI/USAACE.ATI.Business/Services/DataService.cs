using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Business.Util;
using USAACE.Common;
using USAACE.Common.Util;

namespace USAACE.ATI.Business.Services
{
    /// <summary>
    /// Provides methods for accessing data
    /// </summary>
    public static class DataService
    {
        public static POI GetPOI(POI poi)
        {
            IDictionary<Nullable<Int32>, POI> poiDictionary = DataService.ListPOIDictionary();

            return poiDictionary.GetValueOrDefault(poi.POIID);
        }

        /// <summary>
        /// Gets a list of all POIs
        /// </summary>
        /// <returns>A list of all POIs</returns>
        public static IList<POI> GetPOIs()
        {
            IDictionary<Nullable<Int32>, POI> poiDictionary = DataService.ListPOIDictionary();

            return poiDictionary.Values.ToList();
        }

        /// <summary>
        /// Gets a dictionary of all POIs indexed by POI ID
        /// </summary>
        /// <returns>A dictionary of all POIs indexed by POI ID</returns>
        public static IDictionary<Nullable<Int32>, POI> ListPOIDictionary()
        {
            IDictionary<Nullable<Int32>, POI> pois = CacheUtil.GetCache("POIDictionary") as IDictionary<Nullable<Int32>, POI>;

            if (pois == null)
            {
                pois = new POI().ListAllDictionary<POI>();

                CacheUtil.SetCache("POIDictionary", pois);
            }

            return pois;
        }

        /// <summary>
        /// Saves a POI
        /// </summary>
        /// <param name="poi">The POI to save</param>
        /// <returns>The saved POI with POI ID populated if new</returns>
        public static POI SavePOI(POI poi)
        {
            poi.Save();

            CacheUtil.RemoveCache("POIDictionary");

            return poi;
        }

        /// <summary>
        /// Deletes a POI based on a provided POI with POI ID value
        /// </summary>
        /// <param name="poi">The POI to delete</param>
        public static void DeletePOI(POI poi)
        {
            poi.Delete();

            CacheUtil.RemoveCache("POIDictionary");
        }

        /// <summary>
        /// Copies and saves a POI with associated POIFlightDays
        /// </summary>
        /// <param name="poi">The POI to copy</param>
        /// <param name="copyName">The name of the new POI</param>
        /// <returns>The copied POI</returns>
        public static POI CopyPOI(POI poi, String copyName)
        {
            POI poiToCopy = DataService.GetPOI(poi);

            POIFlightDay daysToCopy = new POIFlightDay();
            daysToCopy.POIID = poiToCopy.POIID;

            IList<POIFlightDay> flightDays = DataService.ListPOIFlightDays(daysToCopy);

            poiToCopy.POIID = null;
            poiToCopy.POIName = copyName;
            poiToCopy = DataService.SavePOI(poiToCopy);

            foreach (POIFlightDay day in flightDays)
            {
                day.POIID = poiToCopy.POIID;
                day.POIFlightDayID = null;

                day.Save();
            }

            CacheUtil.RemoveCache("POIDictionary");

            return poiToCopy;
        }

        /// <summary>
        /// Gets a list of POIFlightDays based on a provided POIFlightDay with POI ID value
        /// </summary>
        /// <param name="poiFlightDay">The POIFlightDay containing the POI ID</param>
        /// <returns>A list of POIFlightDays based on the provided POIFlightDay with POI ID value</returns>
        public static IList<POIFlightDay> ListPOIFlightDays(POIFlightDay poiFlightDay)
        {
            IDictionary<Nullable<Int32>, IList<POIFlightDay>> poiFlightDayDictionary = CacheUtil.GetCache("POIFlightDayDictionary") as IDictionary<Nullable<Int32>, IList<POIFlightDay>>;

            if (poiFlightDayDictionary == null)
            {
                poiFlightDayDictionary = new Dictionary<Nullable<Int32>, IList<POIFlightDay>>();
            }

            if (!poiFlightDayDictionary.ContainsKey(poiFlightDay.POIID))
            {
                POIFlightDay poiFlightDayToSearch = new POIFlightDay();
                poiFlightDayToSearch.POIID = poiFlightDay.POIID;

                poiFlightDayDictionary.Add(poiFlightDay.POIID, poiFlightDayToSearch.Search<POIFlightDay>());

                CacheUtil.SetCache("POIFlightDayDictionary", poiFlightDayDictionary);
            }

            return poiFlightDayDictionary[poiFlightDay.POIID];
        }

        /// <summary>
        /// Gets a list of POIFlightDays based on a provided POIFlightDay with POI ID and Objective ID values
        /// </summary>
        /// <param name="poiFlightDay">The POIFlightDay containing the POI ID and Objective ID</param>
        /// <returns>A list of POIFlightDays based on the provided POIFlightDay with POI ID and Objective ID values</returns>
        public static IList<POIFlightDay> ListPOIFlightDaysByObjective(POIFlightDay poiFlightDay)
        {
            IList<POIFlightDay> poiFlightDays = ListPOIFlightDays(poiFlightDay);

            return poiFlightDays.Where(x => x.ObjectiveID == poiFlightDay.ObjectiveID).ToList();
        }

        /// <summary>
        /// Saves a list of POIFlight Days based on a provided POIFlightDay with POI ID and Objective ID values
        /// </summary>
        /// <param name="poiFlightDay">The POIFlightDay containing the POI ID and Objective ID</param>
        /// <param name="poiFlightDays">The list of POIFlightDays to save</param>
        /// <returns>The saved list of POIFlightDays</returns>
        public static IList<POIFlightDay> SavePOIFlightDays(POIFlightDay poiFlightDay, IList<POIFlightDay> poiFlightDays)
        {
            IList<POIFlightDay> currentFlightDays = DataService.ListPOIFlightDaysByObjective(poiFlightDay);

            foreach (POIFlightDay currentFlightDay in currentFlightDays)
            {
                if (!poiFlightDays.Any(x => x.POIFlightDayID == currentFlightDay.POIFlightDayID))
                {
                    currentFlightDay.Delete();
                }
            }

            foreach (POIFlightDay flightDay in poiFlightDays)
            {
                flightDay.POIID = poiFlightDay.POIID;
                flightDay.ObjectiveID = poiFlightDay.ObjectiveID;

                flightDay.Save();
            }

            IDictionary<Nullable<Int32>, IList<POIFlightDay>> poiFlightDayDictionary = CacheUtil.GetCache("POIFlightDayDictionary") as IDictionary<Nullable<Int32>, IList<POIFlightDay>>;

            if (poiFlightDayDictionary == null)
            {
                poiFlightDayDictionary = new Dictionary<Nullable<Int32>, IList<POIFlightDay>>();
            }

            if (poiFlightDayDictionary.ContainsKey(poiFlightDay.POIID))
            {
                poiFlightDayDictionary.Remove(poiFlightDay.POIID);

                CacheUtil.SetCache("POIFlightDayDictionary", poiFlightDayDictionary);
            }

            return poiFlightDays;
        }

        public static Program GetProgram(Program program)
        {
            IDictionary<Nullable<Int32>, Program> programDictionary = DataService.ListProgramDictionary();

            return programDictionary.GetValueOrDefault(program.ProgramID);
        }

        /// <summary>
        /// Gets a list of all Programs
        /// </summary>
        /// <returns>A list of all Programs</returns>
        public static IList<Program> GetPrograms()
        {
            IDictionary<Nullable<Int32>, Program> programDictionary = DataService.ListProgramDictionary();

            return programDictionary.Values.ToList();
        }

        /// <summary>
        /// Gets a dictionary of all Programs indexed by Program ID
        /// </summary>
        /// <returns>A dictionary of all Programs indexed by Program ID</returns>
        public static IDictionary<Nullable<Int32>, Program> ListProgramDictionary()
        {
            IDictionary<Nullable<Int32>, Program> programs = CacheUtil.GetCache("ProgramDictionary") as IDictionary<Nullable<Int32>, Program>;

            if (programs == null)
            {
                programs = new Program().ListAllDictionary<Program>();

                CacheUtil.SetCache("ProgramDictionary", programs);
            }

            return programs;
        }

        /// <summary>
        /// Saves a Program
        /// </summary>
        /// <param name="program">The Program to save</param>
        /// <returns>The saved Program with Program ID populated if new</returns>
        public static Program SaveProgram(Program program)
        {
            program.Save();

            CacheUtil.SetCache("ProgramDictionary", null);

            return program;
        }

        /// <summary>
        /// Deletes a Program based on a provided Program with Program ID value
        /// </summary>
        /// <param name="program">The Program to delete</param>
        public static void DeleteProgram(Program program)
        {
            program.Delete();

            CacheUtil.SetCache("ProgramDictionary", null);
        }

        /// <summary>
        /// Copies and saves a Program with associated Courses, Classes, Historical Percents, and Actuals
        /// </summary>
        /// <param name="program">The Program to copy</param>
        /// <param name="copyName">The name of the new Program</param>
        /// <returns>The copied Program</returns>
        public static Program CopyProgram(Program program, String copyName)
        {
            Program programToCopy = DataService.GetProgram(program);

            Program newProgram = new Program();
            newProgram.ProgramDescription = programToCopy.ProgramDescription;
            newProgram.ProgramName = copyName;
            newProgram.FiscalYear = programToCopy.FiscalYear;

            newProgram = DataService.SaveProgram(newProgram);

            Course courseToSearch = new Course();
            courseToSearch.ProgramID = program.ProgramID;

            IList<Course> courses = DataService.ListCourses(courseToSearch);

            foreach (Course course in courses)
            {
                Course newCourse = course.Copy<Course>();

                newCourse.ProgramID = newProgram.ProgramID;
                newCourse.CourseID = null;

                newCourse = DataService.SaveCourse(newCourse);

                HistoricalPercent percent = new HistoricalPercent();
                percent.CourseID = course.CourseID;

                percent = LoadHistoricalPercent(percent);

                HistoricalPercent newPercent = percent.Copy<HistoricalPercent>();

                newPercent.CourseID = newCourse.CourseID;
                newPercent.HistoricalPercentID = null;

                newPercent.Save();

                Class classToSearch = new Class();
                classToSearch.CourseID = course.CourseID;

                IList<Class> classes = ListClasses(classToSearch);

                foreach (Class classItem in classes)
                {
                    Class newClass = classItem.Copy<Class>();

                    newClass.CourseID = newCourse.CourseID;
                    newClass.ClassID = null;

                    newClass.Save();
                }

                ActualHours courseActualHoursToSearch = new ActualHours();
                courseActualHoursToSearch.CourseID = course.CourseID;

                IList<ActualHours> courseActualHours = ListActualHours(courseActualHoursToSearch);

                foreach (ActualHours hour in courseActualHours)
                {
                    ActualHours newActualHours = hour.Copy<ActualHours>();

                    newActualHours.CourseID = newCourse.CourseID;
                    newActualHours.ProgramID = newProgram.ProgramID;
                    newActualHours.ActualHoursID = null;

                    newActualHours.Save();
                }
            }

            ActualHours programActualHoursToSearch = new ActualHours();
            programActualHoursToSearch.ProgramID = program.ProgramID;

            IList<ActualHours> programActualHours = ListActualHours(programActualHoursToSearch);

            foreach (ActualHours hour in programActualHours)
            {
                if (hour.CourseID == null)
                {
                    ActualHours newActualHours = hour.Copy<ActualHours>();

                    newActualHours.ProgramID = newProgram.ProgramID;
                    newActualHours.ActualHoursID = null;

                    newActualHours.Save();
                }
            }

            CacheUtil.SetCache("Programs", null);

            return newProgram;
        }

        /// <summary>
        /// Gets a list of Classes based on a provided Class with Course ID value
        /// </summary>
        /// <param name="classItem">The Class containing the Course ID</param>
        /// <returns>A list of Classes</returns>
        public static IList<Class> ListClasses(Class classItem)
        {
            Class classToSearch = new Class();
            classToSearch.CourseID = classItem.CourseID;
            classToSearch.POIID = classItem.POIID;

            return classToSearch.Search<Class>();
        }

        /// <summary>
        /// Loads a Class based on a provided Class with Class ID value
        /// </summary>
        /// <param name="classItem">The Class containing the Class ID</param>
        /// <returns>The loaded Class</returns>
        public static Class LoadClass(Class classItem)
        {
            Class classToLoad = new Class();
            classToLoad.ClassID = classItem.ClassID;

            classToLoad.Load();

            return classToLoad;
        }

        /// <summary>
        /// Saves a Class
        /// </summary>
        /// <param name="classItem">The Class to save</param>
        /// <returns>The saved Class with Class ID populated if new</returns>
        public static Class SaveClass(Class classItem)
        {
            classItem.Save();

            return classItem;
        }

        /// <summary>
        /// Deletes a Class based on a provided Class with Class ID value
        /// </summary>
        /// <param name="classItem">The Class to delete</param>
        public static void DeleteClass(Class classItem)
        {
            classItem.Delete();
        }

        /// <summary>
        /// Gets a list of ActualHours based on a provided ActualHours with filter values
        /// </summary>
        /// <param name="actualHours">The ActualHours containing the filter values</param>
        /// <returns>A list of ActualHours</returns>
        public static IList<ActualHours> ListActualHours(ActualHours actualHours)
        {
            ActualHours actualHoursToSearch = new ActualHours();
            actualHoursToSearch.HoursTypeID = actualHours.HoursTypeID;
            actualHoursToSearch.ProgramID = actualHours.ProgramID;
            actualHoursToSearch.CourseID = actualHours.CourseID;
            actualHoursToSearch.SystemID = actualHours.SystemID;
            actualHoursToSearch.CourseLevelID = actualHours.CourseLevelID;
            actualHoursToSearch.Forecast = actualHours.Forecast;
            actualHoursToSearch.Reimbursable = actualHours.Reimbursable;
            actualHoursToSearch.MiscHoursID = actualHours.MiscHoursID;

            return actualHoursToSearch.Search<ActualHours>();
        }

        /// <summary>
        /// Loads a ActualHours based on a provided ActualHours with ActualHours ID value
        /// </summary>
        /// <param name="actualHours">The ActualHours containing the ActualHours ID</param>
        /// <returns>The loaded ActualHours</returns>
        public static ActualHours LoadActualHours(ActualHours actualHours)
        {
            ActualHours actualHoursToLoad = new ActualHours();
            actualHoursToLoad.ActualHoursID = actualHours.ActualHoursID;

            actualHoursToLoad.Load();

            return actualHoursToLoad;
        }

        /// <summary>
        /// Saves a ActualHours
        /// </summary>
        /// <param name="actualHours">The ActualHours to save</param>
        /// <returns>The saved ActualHours with ActualHours ID populated if new</returns>
        public static ActualHours SaveActualHours(ActualHours actualHours)
        {
            actualHours.Save();

            return actualHours;
        }

        /// <summary>
        /// Deletes a ActualHours based on a provided ActualHours with ActualHours ID value
        /// </summary>
        /// <param name="actualHours">The ActualHours to delete</param>
        public static void DeleteActualHours(ActualHours actualHours)
        {
            actualHours.Delete();
        }

        /// <summary>
        /// Gets a list of Courses based on a provided Course with filter values
        /// </summary>
        /// <param name="course">The Course containing the filter values</param>
        /// <returns>A list of Courses</returns>
        public static IList<Course> ListCourses(Course course)
        {
            Course courseToSearch = new Course();
            courseToSearch.ProgramID = course.ProgramID;
            courseToSearch.CourseLevelID = course.CourseLevelID;
            courseToSearch.SystemID = course.SystemID;
            courseToSearch.PreviousCourseID = course.PreviousCourseID;
            courseToSearch.CourseNumberID = course.CourseNumberID;
            courseToSearch.SearchProperties.SystemIDIsIn = course.SearchProperties.SystemIDIsIn;
            courseToSearch.SearchProperties.CourseLevelIDIsIn = course.SearchProperties.CourseLevelIDIsIn;
            courseToSearch.SearchProperties.CourseTypeIDIsIn = course.SearchProperties.CourseTypeIDIsIn;

            return courseToSearch.Search<Course>();
        }

        /// <summary>
        /// Gets a dictionary of all Courses indexed by Course ID
        /// </summary>
        /// <returns>A dictionary of all Courses indexed by Course ID</returns>
        public static IDictionary<Nullable<Int32>, Course> ListCourseDictionary()
        {
            return new Course().ListAllDictionary<Course>();
        }

        /// <summary>
        /// Loads a Course based on a provided Course with Course ID value
        /// </summary>
        /// <param name="course">The Course containing the Course ID</param>
        /// <returns>The loaded Course</returns>
        public static Course LoadCourse(Course course)
        {
            Course courseToLoad = new Course();
            courseToLoad.CourseID = course.CourseID;

            courseToLoad.Load();

            return courseToLoad;
        }

        /// <summary>
        /// Saves a Course
        /// </summary>
        /// <param name="course">The Course to save</param>
        /// <returns>The saved Course with Course ID populated if new</returns>
        public static Course SaveCourse(Course course)
        {
            if (!course.CreateDate.HasValue)
            {
                course.CreateDate = DateTime.Now;
            }

            course.Save();

            /*Course carryOverCourse = new Course();
            carryOverCourse.PreviousCourseID = course.CourseID;

            IList<Course> carryOverCourses = DataService.ListCourses(carryOverCourse);

            foreach (Course carryOver in carryOverCourses)
            {
                carryOver.ClassInterval = course.ClassInterval;
                carryOver.CourseLevelID = course.CourseLevelID;
                carryOver.CourseName = course.CourseName;
                carryOver.CourseNumberID = course.CourseNumberID;
                carryOver.CourseTypeID = course.CourseTypeID;
                carryOver.MaxClassSize = course.MaxClassSize;
                carryOver.MinClassSize = course.MinClassSize;
                carryOver.OptimumClassSize = course.OptimumClassSize;
                carryOver.Phase = course.Phase;
                carryOver.POIID = course.POIID;
                carryOver.Prefix = course.Prefix;
                carryOver.ReportNoFlyDay = course.ReportNoFlyDay;
                carryOver.SystemID = course.SystemID;
                carryOver.TrainNoFlyDay = course.TrainNoFlyDay;

                carryOver.Save();
            }*/

            return course;
        }

        /// <summary>
        /// Deletes a Course and associated ActualHours based on a provided Course with Course ID value
        /// </summary>
        /// <param name="course">The Course to delete</param>
        public static void DeleteCourse(Course course)
        {
            ActualHours hoursToSearch = new ActualHours();
            hoursToSearch.CourseID = course.CourseID;

            IList<ActualHours> hours = ListActualHours(hoursToSearch);

            foreach (ActualHours hour in hours)
            {
                hour.Delete();
            }

            course.Delete();
        }

        /// <summary>
        /// Copies and saves a Course
        /// </summary>
        /// <param name="course">The Course to copy</param>
        /// <param name="copyName">The name of the new Course</param>
        /// <param name="programId">The ID of the program</param>
        /// <param name="previousCourseId">The ID of the linked previous course (no longer used)</param>
        /// <returns>The copied Course</returns>
        public static Course CopyCourse(Course course, String copyName, Nullable<Int32> programId, Nullable<Int32> previousCourseId)
        {
            Course courseToCopy = LoadCourse(course);

            //courseToCopy.PreviousCourseID = previousCourseId;
            courseToCopy.ProgramID = programId;
            courseToCopy.CourseID = null;
            courseToCopy.CourseName = copyName;
            courseToCopy.CreateDate = DateTime.Now;
            courseToCopy = SaveCourse(courseToCopy);

            return courseToCopy;
        }

        public static Objective GetObjective(Objective objective)
        {
            IDictionary<Nullable<Int32>, Objective> objectiveDictionary = DataService.ListObjectiveDictionary();

            return objectiveDictionary.GetValueOrDefault(objective.ObjectiveID);
        }

        /// <summary>
        /// Gets a list of all Objectives
        /// </summary>
        /// <returns>A list of all Objectives</returns>
        public static IList<Objective> GetObjectives()
        {
            IDictionary<Nullable<Int32>, Objective> objectiveDictionary = DataService.ListObjectiveDictionary();

            return objectiveDictionary.Values.ToList();
        }

        /// <summary>
        /// Gets a dictionary of all Objectives indexed by Objective ID
        /// </summary>
        /// <returns>A dictionary of all Objectives indexed by Objective ID</returns>
        public static IDictionary<Nullable<Int32>, Objective> ListObjectiveDictionary()
        {
            IDictionary<Nullable<Int32>, Objective> objectiveDictionary = CacheUtil.GetCache("ObjectiveDictionary") as IDictionary<Nullable<Int32>, Objective>;

            if (objectiveDictionary == null)
            {
                objectiveDictionary = new Objective().ListAllDictionary<Objective>();

                CacheUtil.SetCache("ObjectiveDictionary", objectiveDictionary);
            }

            return objectiveDictionary;
        }

        /// <summary>
        /// Saves a Objective
        /// </summary>
        /// <param name="objective">The Objective to save</param>
        /// <returns>The saved Objective with Objective ID populated if new</returns>
        public static Objective SaveObjective(Objective objective)
        {
            objective.Save();

            CacheUtil.RemoveCache("ObjectiveDictionary");

            return objective;
        }

        /// <summary>
        /// Deletes a Objective based on a provided Objective with Objective ID value
        /// </summary>
        /// <param name="objective">The Objective to delete</param>
        public static void DeleteObjective(Objective objective)
        {
            objective.Delete();

            CacheUtil.RemoveCache("ObjectiveDictionary");
        }

        public static MiscHours GetMiscHours(MiscHours miscHours)
        {
            IDictionary<Nullable<Int32>, MiscHours> miscHoursDictionary = DataService.ListMiscHoursDictionary();

            return miscHoursDictionary.GetValueOrDefault(miscHours.MiscHoursID);
        }

        /// <summary>
        /// Gets a list of all MiscHourss
        /// </summary>
        /// <returns>A list of all MiscHourss</returns>
        public static IList<MiscHours> GetMiscHourses()
        {
            IDictionary<Nullable<Int32>, MiscHours> miscHoursDictionary = DataService.ListMiscHoursDictionary();

            return miscHoursDictionary.Values.ToList();
        }

        /// <summary>
        /// Gets a dictionary of all MiscHourss indexed by MiscHours ID
        /// </summary>
        /// <returns>A dictionary of all MiscHourss indexed by MiscHours ID</returns>
        public static IDictionary<Nullable<Int32>, MiscHours> ListMiscHoursDictionary()
        {
            IDictionary<Nullable<Int32>, MiscHours> miscHoursDictionary = CacheUtil.GetCache("MiscHoursDictionary") as IDictionary<Nullable<Int32>, MiscHours>;

            if (miscHoursDictionary == null)
            {
                miscHoursDictionary = new MiscHours().ListAllDictionary<MiscHours>();

                CacheUtil.SetCache("MiscHoursDictionary", miscHoursDictionary);
            }

            return miscHoursDictionary;
        }

        /// <summary>
        /// Saves a MiscHours
        /// </summary>
        /// <param name="miscHours">The MiscHours to save</param>
        /// <returns>The saved MiscHours with MiscHours ID populated if new</returns>
        public static MiscHours SaveMiscHours(MiscHours miscHours)
        {
            miscHours.Save();

            CacheUtil.RemoveCache("MiscHoursDictionary");

            return miscHours;
        }

        /// <summary>
        /// Deletes a MiscHours based on a provided MiscHours with MiscHours ID value
        /// </summary>
        /// <param name="miscHours">The MiscHours to delete</param>
        public static void DeleteMiscHours(MiscHours miscHours)
        {
            miscHours.Delete();

            CacheUtil.RemoveCache("MiscHoursDictionary");
        }

        public static Domain.Entities.System GetSystem(Domain.Entities.System system)
        {
            IDictionary<Nullable<Int32>, Domain.Entities.System> systemDictionary = DataService.ListSystemDictionary();

            return systemDictionary.GetValueOrDefault(system.SystemID);
        }

        /// <summary>
        /// Gets a list of all Systems
        /// </summary>
        /// <returns>A list of all Systems</returns>
        public static IList<Domain.Entities.System> GetSystems()
        {
            IDictionary<Nullable<Int32>, Domain.Entities.System> systemDictionary = DataService.ListSystemDictionary();

            return systemDictionary.Values.ToList();
        }

        /// <summary>
        /// Gets a list of all Systems
        /// </summary>
        /// <returns>A list of all Systems</returns>
        public static IDictionary<Nullable<Int32>, Domain.Entities.System> ListSystemDictionary()
        {
            IDictionary<Nullable<Int32>, Domain.Entities.System> systems = CacheUtil.GetCache("SystemDictionary") as IDictionary<Nullable<Int32>, Domain.Entities.System>;

            if (systems == null)
            {
                systems = new Domain.Entities.System().ListAllDictionary<Domain.Entities.System>();

                CacheUtil.SetCache("SystemDictionary", systems);
            }

            return systems;
        }

        /// <summary>
        /// Saves a System
        /// </summary>
        /// <param name="system">The System to save</param>
        /// <returns>The saved System with System ID populated if new</returns>
        public static Domain.Entities.System SaveSystem(Domain.Entities.System system)
        {
            system.Save();

            CacheUtil.RemoveCache("SystemDictionary");

            return system;
        }

        /// <summary>
        /// Deletes a System based on a provided System with System ID value
        /// </summary>
        /// <param name="system">The System to delete</param>
        public static void DeleteSystem(Domain.Entities.System system)
        {
            system.Delete();

            CacheUtil.RemoveCache("SystemDictionary");
        }

        public static Location GetLocation(Location location)
        {
            IDictionary<Nullable<Int32>, Location> locationDictionary = DataService.ListLocationDictionary();

            return locationDictionary.GetValueOrDefault(location.LocationID);
        }

        /// <summary>
        /// Gets a list of all Locations
        /// </summary>
        /// <returns>A list of all Locations</returns>
        public static IList<Location> GetLocations()
        {
            IDictionary<Nullable<Int32>, Location> locationDictionary = DataService.ListLocationDictionary();

            return locationDictionary.Values.ToList();
        }

        /// <summary>
        /// Gets a dictionary of all Locations indexed by Location ID
        /// </summary>
        /// <returns>A dictionary of all Locations indexed by Location ID</returns>
        public static IDictionary<Nullable<Int32>, Location> ListLocationDictionary()
        {
            IDictionary<Nullable<Int32>, Location> locationDictionary = CacheUtil.GetCache("LocationDictionary") as IDictionary<Nullable<Int32>, Location>;

            if (locationDictionary == null)
            {
                locationDictionary = new Location().ListAllDictionary<Location>();

                CacheUtil.SetCache("LocationDictionary", locationDictionary);
            }

            return locationDictionary;
        }

        /// <summary>
        /// Saves a Location
        /// </summary>
        /// <param name="location">The Location to save</param>
        /// <returns>The saved Location with Location ID populated if new</returns>
        public static Location SaveLocation(Location location)
        {
            location.Save();

            CacheUtil.RemoveCache("LocationDictionary");

            return location;
        }

        /// <summary>
        /// Deletes a Location based on a provided Location with Location ID value
        /// </summary>
        /// <param name="location">The Location to delete</param>
        public static void DeleteLocation(Location location)
        {
            location.Delete();

            CacheUtil.RemoveCache("LocationDictionary");
        }

        public static CourseLevel GetCourseLevel(CourseLevel courseLevel)
        {
            IDictionary<Nullable<Int32>, CourseLevel> courseLevelDictionary = DataService.ListCourseLevelDictionary();

            return courseLevelDictionary.GetValueOrDefault(courseLevel.CourseLevelID);
        }

        /// <summary>
        /// Gets a list of all CourseLevels
        /// </summary>
        /// <returns>A list of all CourseLevels</returns>
        public static IList<CourseLevel> GetCourseLevels()
        {
            IDictionary<Nullable<Int32>, CourseLevel> courseLevelDictionary = DataService.ListCourseLevelDictionary();

            return courseLevelDictionary.Values.ToList();
        }

        /// <summary>
        /// Gets a dictionary of all CourseLevels indexed by CourseLevel ID
        /// </summary>
        /// <returns>A dictionary of all CourseLevels indexed by CourseLevel ID</returns>
        public static IDictionary<Nullable<Int32>, CourseLevel> ListCourseLevelDictionary()
        {
            IDictionary<Nullable<Int32>, CourseLevel> courseLevelDictionary = CacheUtil.GetCache("CourseLevelDictionary") as IDictionary<Nullable<Int32>, CourseLevel>;

            if (courseLevelDictionary == null)
            {
                courseLevelDictionary = new CourseLevel().ListAllDictionary<CourseLevel>();

                CacheUtil.SetCache("CourseLevelDictionary", courseLevelDictionary);
            }

            return courseLevelDictionary;
        }

        /// <summary>
        /// Saves a CourseLevel
        /// </summary>
        /// <param name="courseLevel">The CourseLevel to save</param>
        /// <returns>The saved CourseLevel with CourseLevel ID populated if new</returns>
        public static CourseLevel SaveCourseLevel(CourseLevel courseLevel)
        {
            courseLevel.Save();

            CacheUtil.RemoveCache("CourseLevelDictionary");

            return courseLevel;
        }

        /// <summary>
        /// Deletes a CourseLevel based on a provided CourseLevel with CourseLevel ID value
        /// </summary>
        /// <param name="courseLevel">The CourseLevel to delete</param>
        public static void DeleteCourseLevel(CourseLevel courseLevel)
        {
            courseLevel.Delete();

            CacheUtil.RemoveCache("CourseLevelDictionary");
        }

        public static CourseType GetCourseType(CourseType courseType)
        {
            IDictionary<Nullable<Int32>, CourseType> courseTypeDictionary = DataService.ListCourseTypeDictionary();

            return courseTypeDictionary.GetValueOrDefault(courseType.CourseTypeID);
        }

        /// <summary>
        /// Gets a list of all CourseTypes
        /// </summary>
        /// <returns>A list of all CourseTypes</returns>
        public static IList<CourseType> GetCourseTypes()
        {
            IDictionary<Nullable<Int32>, CourseType> courseTypeDictionary = DataService.ListCourseTypeDictionary();

            return courseTypeDictionary.Values.ToList();
        }

        /// <summary>
        /// Gets a dictionary of all CourseTypes indexed by CourseType ID
        /// </summary>
        /// <returns>A dictionary of all CourseTypes indexed by CourseType ID</returns>
        public static IDictionary<Nullable<Int32>, CourseType> ListCourseTypeDictionary()
        {
            IDictionary<Nullable<Int32>, CourseType> courseTypeDictionary = CacheUtil.GetCache("CourseTypeDictionary") as IDictionary<Nullable<Int32>, CourseType>;

            if (courseTypeDictionary == null)
            {
                courseTypeDictionary = new CourseType().ListAllDictionary<CourseType>();

                CacheUtil.SetCache("CourseTypeDictionary", courseTypeDictionary);
            }

            return courseTypeDictionary;
        }

        /// <summary>
        /// Saves a CourseType
        /// </summary>
        /// <param name="courseType">The CourseType to save</param>
        /// <returns>The saved CourseType with CourseType ID populated if new</returns>
        public static CourseType SaveCourseType(CourseType courseType)
        {
            courseType.Save();

            CacheUtil.RemoveCache("CourseTypeDictionary");

            return courseType;
        }

        /// <summary>
        /// Deletes a CourseType based on a provided CourseType with CourseType ID value
        /// </summary>
        /// <param name="courseLevel">The CourseType to delete</param>
        public static void DeleteCourseType(CourseType courseType)
        {
            courseType.Delete();

            CacheUtil.RemoveCache("CourseTypeDictionary");
        }

        public static CourseNumber GetCourseNumber(CourseNumber courseNumber)
        {
            IDictionary<Nullable<Int32>, CourseNumber> courseNumberDictionary = DataService.ListCourseNumberDictionary();

            return courseNumberDictionary.GetValueOrDefault(courseNumber.CourseNumberID);
        }

        /// <summary>
        /// Gets a list of all CourseNumbers
        /// </summary>
        /// <returns>A list of all CourseNumbers</returns>
        public static IList<CourseNumber> GetCourseNumbers()
        {
            IDictionary<Nullable<Int32>, CourseNumber> courseNumberDictionary = DataService.ListCourseNumberDictionary();

            return courseNumberDictionary.Values.ToList();
        }

        /// <summary>
        /// Gets a dictionary of all CourseNumbers indexed by CourseNumber ID
        /// </summary>
        /// <returns>A dictionary of all CourseNumbers indexed by CourseNumber ID</returns>
        public static IDictionary<Nullable<Int32>, CourseNumber> ListCourseNumberDictionary()
        {
            IDictionary<Nullable<Int32>, CourseNumber> courseNumberDictionary = CacheUtil.GetCache("CourseNumberDictionary") as IDictionary<Nullable<Int32>, CourseNumber>;

            if (courseNumberDictionary == null)
            {
                courseNumberDictionary = new CourseNumber().ListAllDictionary<CourseNumber>();

                CacheUtil.SetCache("CourseNumberDictionary", courseNumberDictionary);
            }

            return courseNumberDictionary;
        }

        /// <summary>
        /// Saves a CourseNumber
        /// </summary>
        /// <param name="courseNumber">The CourseNumber to save</param>
        /// <returns>The saved CourseNumber with CourseNumber ID populated if new</returns>
        public static CourseNumber SaveCourseNumber(CourseNumber courseNumber)
        {
            courseNumber.Save();

            CacheUtil.RemoveCache("CourseNumberDictionary");

            return courseNumber;
        }

        /// <summary>
        /// Deletes a CourseNumber based on a provided CourseNumber with CourseNumber ID value
        /// </summary>
        /// <param name="courseNumber">The CourseNumber to delete</param>
        public static void DeleteCourseNumber(CourseNumber courseNumber)
        {
            courseNumber.Delete();

            CacheUtil.RemoveCache("CourseNumberDictionary");
        }

        /// <summary>
        /// Gets a list of SystemLocations based on a provided SystemLocation with System ID value
        /// </summary>
        /// <param name="systemLocation">The SystemLocations containing the System ID</param>
        /// <returns>A list of SystemLocations</returns>
        public static IList<SystemLocation> ListSystemLocations(SystemLocation systemLocation)
        {
            SystemLocation systemLocationToSearch = new SystemLocation();
            systemLocationToSearch.SystemID = systemLocation.SystemID;

            return systemLocationToSearch.Search<SystemLocation>();
        }

        /// <summary>
        /// Saves a list of SystemLocations based on a provided SystemLocation with System ID value
        /// </summary>
        /// <param name="systemLocation">The SystemLocation containing the System ID</param>
        /// <param name="systemLocations">The list of SystemLocations to save</param>
        /// <returns>The saved list of SystemLocations</returns>
        public static IList<SystemLocation> SaveSystemLocations(SystemLocation systemLocation, IList<SystemLocation> systemLocations)
        {
            IList<SystemLocation> currentSystemLocations = DataService.ListSystemLocations(systemLocation);

            foreach (SystemLocation currentSystemLocation in currentSystemLocations)
            {
                if (!systemLocations.Any(x => x.SystemLocationID == currentSystemLocation.SystemLocationID))
                {
                    currentSystemLocation.Delete();
                }
            }

            foreach (SystemLocation location in systemLocations)
            {
                location.SystemID = systemLocation.SystemID;

                location.Save();
            }

            return systemLocations;
        }

        /// <summary>
        /// Loads a HistoricalPercent based on a provided HistoricalPercent with Course ID value
        /// </summary>
        /// <param name="percent">The HistoricalPercent containing the Course ID</param>
        /// <returns>The loaded HistoricalPercent if it exists, a new HistoricalPercent with default values if not</returns>
        public static HistoricalPercent LoadHistoricalPercent(HistoricalPercent percent)
        {
            HistoricalPercent percentToLoad = new HistoricalPercent();
            percentToLoad.CourseID = percent.CourseID;

            IList<HistoricalPercent> percents = percentToLoad.Search<HistoricalPercent>();

            if (percents.Count == 0)
            {
                percentToLoad.October = 100;
                percentToLoad.November = 100;
                percentToLoad.December = 100;
                percentToLoad.January = 100;
                percentToLoad.February = 100;
                percentToLoad.March = 100;
                percentToLoad.April = 100;
                percentToLoad.May = 100;
                percentToLoad.June = 100;
                percentToLoad.July = 100;
                percentToLoad.August = 100;
                percentToLoad.September = 100;

                percentToLoad.Save();

                return percentToLoad;
            }
            else
            {
                return percents.First();
            }
        }

        /// <summary>
        /// Saves a HistoricalPercent based on a HistoricalPercent with Course ID value
        /// </summary>
        /// <param name="courseType">The HistoricalPercent to save</param>
        /// <returns>The saved HistoricalPercent</returns>
        public static HistoricalPercent SaveHistoricalPercent(HistoricalPercent percent)
        {
            HistoricalPercent percentToSave = new HistoricalPercent();
            percentToSave.CourseID = percent.CourseID;

            IList<HistoricalPercent> percents = percentToSave.Search<HistoricalPercent>();

            if (percents.Count == 0)
            {
                percent.Save();

                return percent;
            }
            else
            {
                percent.HistoricalPercentID = percents.Single().HistoricalPercentID;

                percent.Save();

                return percent;
            }
        }

        /// <summary>
        /// Gets a list of all NoFlyTypes
        /// </summary>
        /// <returns>A list of all NoFlyTypes</returns>
        public static IList<NoFlyType> ListNoFlyTypes()
        {
            IList<NoFlyType> noFlyTypes = CacheUtil.GetCache("NoFlyTypes") as IList<NoFlyType>;

            if (noFlyTypes == null)
            {
                noFlyTypes = new NoFlyType().ListAll<NoFlyType>();

                CacheUtil.SetCache("NoFlyTypes", noFlyTypes);
            }

            return noFlyTypes;
        }

        public static IDictionary<String, NoFlyType> ListNoFlyTypesByNameDictionary()
        {
            IDictionary<String, NoFlyType> noFlyTypeDictionary = CacheUtil.GetCache("NoFlyTypesByNameDictionary") as IDictionary<String, NoFlyType>;

            if (noFlyTypeDictionary == null)
            {
                noFlyTypeDictionary = new Dictionary<String, NoFlyType>();

                foreach (NoFlyType noFlyType in DataService.ListNoFlyTypes())
                {
                    noFlyTypeDictionary.Add(noFlyType.NoFlyTypeName, noFlyType);
                }

                CacheUtil.SetCache("NoFlyTypesByNameDictionary", noFlyTypeDictionary);
            }

            return noFlyTypeDictionary;
        }

        /// <summary>
        /// Gets a NoFlyType by name
        /// </summary>
        /// <param name="typeName">The name of the NoFlyType</param>
        /// <returns>The NoFlyType with the name provided</returns>
        public static NoFlyType SearchNoFlyTypeByName(String typeName)
        {
            IDictionary<String, NoFlyType> noFlyTypeDictionary = DataService.ListNoFlyTypesByNameDictionary();

            return noFlyTypeDictionary.GetValueOrDefault(typeName);
        }

        /// <summary>
        /// Loads a NoFlyType based on a provided NoFlyType with NoFlyType ID value
        /// </summary>
        /// <param name="type">The NoFlyType containing the NoFlyType ID</param>
        /// <returns>The loaded NoFlyType</returns>
        public static NoFlyType LoadNoFlyType(NoFlyType type)
        {
            NoFlyType typeToLoad = new NoFlyType();
            typeToLoad.NoFlyTypeID = type.NoFlyTypeID;

            typeToLoad.Load();

            return typeToLoad;
        }

        /// <summary>
        /// Saves a NoFlyType
        /// </summary>
        /// <param name="type">The NoFlyType to save</param>
        /// <returns>The saved NoFlyType with NoFlyType ID populated if new</returns>
        public static NoFlyType SaveNoFlyType(NoFlyType type)
        {
            type.Save();

            CacheUtil.RemoveCache("NoFlyTypes");
            CacheUtil.RemoveCache("NoFlyTypesByNameDictionary");

            return type;
        }

        /// <summary>
        /// Deletes a NoFlyType based on a provided NoFlyType with NoFlyType ID value
        /// </summary>
        /// <param name="type">The NoFlyType to delete</param>
        public static void DeleteNoFlyType(NoFlyType type)
        {
            type.Delete();

            CacheUtil.RemoveCache("NoFlyTypes");
            CacheUtil.RemoveCache("NoFlyTypesByNameDictionary");
        }

        /// <summary>
        /// Gets a list of all NoFlyDays
        /// </summary>
        /// <returns>A list of all NoFlyDays</returns>
        public static IList<NoFlyDay> ListNoFlyDays()
        {
            IList<NoFlyDay> noFlyDays = CacheUtil.GetCache("NoFlyDays") as IList<NoFlyDay>;

            if (noFlyDays == null)
            {
                noFlyDays = new NoFlyDay().ListAll<NoFlyDay>();

                CacheUtil.SetCache("NoFlyDays", noFlyDays);
            }

            return noFlyDays;
        }
        /// <summary>
        /// Gets a list of all NoFlyDays
        /// </summary>
        /// <returns>A list of all NoFlyDays</returns>
        public static IDictionary<Nullable<Int32>, IList<NoFlyDay>> ListNoFlyDaysByNoFlyTypeDictionary()
        {
            IDictionary<Nullable<Int32>, IList<NoFlyDay>> noFlyDaysByTypeDictionary = CacheUtil.GetCache("NoFlyDaysByNoFlyTypeDictionary") as IDictionary<Nullable<Int32>, IList<NoFlyDay>>;

            if (noFlyDaysByTypeDictionary == null)
            {
                noFlyDaysByTypeDictionary = new Dictionary<Nullable<Int32>, IList<NoFlyDay>>();

                IList<NoFlyDay> noFlyDays = DataService.ListNoFlyDays();

                foreach (NoFlyDay noFlyDay in noFlyDays)
                {
                    if (!noFlyDaysByTypeDictionary.ContainsKey(noFlyDay.NoFlyTypeID))
                    {
                        noFlyDaysByTypeDictionary.Add(noFlyDay.NoFlyTypeID, new List<NoFlyDay>());
                    }

                    noFlyDaysByTypeDictionary[noFlyDay.NoFlyTypeID].Add(noFlyDay);
                }

                CacheUtil.SetCache("NoFlyDaysByNoFlyTypeDictionary", noFlyDaysByTypeDictionary);
            }

            return noFlyDaysByTypeDictionary;
        }

        /// <summary>
        /// Gets a list of NoFlyDay by NoFlyType ID
        /// </summary>
        /// <param name="typeId">The ID of the NoFlyType</param>
        /// <returns>The list of NoFlyDays with the specified NoFlyType</returns>
        public static IList<NoFlyDay> SearchNoFlyDaysByType(Nullable<Int32> typeId)
        {
            IDictionary<Nullable<Int32>, IList<NoFlyDay>> noFlyDaysByTypeDictionary = DataService.ListNoFlyDaysByNoFlyTypeDictionary();

            return noFlyDaysByTypeDictionary.GetValueOrDefault(typeId);
        }

        /// <summary>
        /// Loads a NoFlyDay based on a provided NoFlyDay with NoFlyDay ID value
        /// </summary>
        /// <param name="day">The NoFlyDay containing the NoFlyDay ID</param>
        /// <returns>The loaded NoFlyDay</returns>
        public static NoFlyDay LoadNoFlyDay(NoFlyDay day)
        {
            NoFlyDay dayToLoad = new NoFlyDay();
            dayToLoad.NoFlyDayID = day.NoFlyDayID;

            dayToLoad.Load();

            return dayToLoad;
        }

        /// <summary>
        /// Saves a NoFlyDay
        /// </summary>
        /// <param name="day">The NoFlyDay to save</param>
        /// <returns>The saved NoFlyDay with NoFlyDay ID populated if new</returns>
        public static NoFlyDay SaveNoFlyDay(NoFlyDay day)
        {
            day.Save();

            CacheUtil.RemoveCache("NoFlyDays");
            CacheUtil.RemoveCache("NoFlyDaysByNoFlyTypeDictionary");

            return day;
        }

        /// <summary>
        /// Deletes a NoFlyDay based on a provided NoFlyDay with NoFlyDay ID value
        /// </summary>
        /// <param name="day">The NoFlyDay to delete</param>
        public static void DeleteNoFlyDay(NoFlyDay day)
        {
            day.Delete();

            CacheUtil.RemoveCache("NoFlyDays");
            CacheUtil.RemoveCache("NoFlyDaysByNoFlyTypeDictionary");
        }

        /// <summary>
        /// Gets a list of all HoursTypes
        /// </summary>
        /// <returns>A list of all HoursTypes</returns>
        public static IList<HoursType> ListHoursTypes()
        {
            IList<HoursType> hoursTypes = CacheUtil.GetCache("HoursTypes") as IList<HoursType>;

            if (hoursTypes == null)
            {
                hoursTypes = new HoursType().ListAll<HoursType>();

                CacheUtil.SetCache("HoursTypes", hoursTypes);
            }

            return hoursTypes;
        }
    }
}
