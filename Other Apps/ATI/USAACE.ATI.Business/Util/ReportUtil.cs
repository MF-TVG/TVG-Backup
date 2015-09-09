using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Business.Services;
using USAACE.Common;
using System.Data;
using USAACE.ATI.Business.Constants;

namespace USAACE.ATI.Business.Util
{
    /// <summary>
    /// A class containing several utility functions for dealing with reports
    /// </summary>
    public static class ReportUtil
    {
        private const Int32 ROUND_DIGITS = 1;
        private const String ROUND_STRING = "F1";

        /// <summary>
        /// Gets the daily requirements report for a class
        /// </summary>
        /// <param name="classItem">The class to analyze</param>
        /// <returns>A data table for the daily requirements for the class</returns>
        public static DataTable GetClassReport(Class classItem)
        {
            DataTable report = new DataTable();

            classItem = DataService.LoadClass(classItem);

            Course course = new Course();
            course.CourseID = classItem.CourseID;
            course = DataService.LoadCourse(course);

            POI poi = new POI();
            poi.POIID = classItem.POIID;
            poi = DataService.GetPOI(poi);

            POIFlightDay flightDay = new POIFlightDay();
            flightDay.POIID = poi.POIID;

            IList<POIFlightDay> flightDays = DataService.ListPOIFlightDays(flightDay);

            IDictionary<DateTime, IList<POIFlightDay>> dailyRequirements = ClassUtil.GetDailyRequirements(classItem, course, poi, flightDays);

            report.Columns.Add("Day", typeof(String));
            report.Columns.Add("Date", typeof(String));
            report.Columns.Add("Requirement", typeof(String));
            report.Columns.Add("Hours", typeof(String));

            IDictionary<Nullable<Int32>, Objective> objectives = DataService.ListObjectiveDictionary();

            Decimal total = 0;

            foreach (KeyValuePair<DateTime, IList<POIFlightDay>> dailyRequirement in dailyRequirements)
            {
                foreach (POIFlightDay requirementFlightDay in dailyRequirement.Value)
                {
                    report.Rows.Add(new object[] { requirementFlightDay.FlightDayNumber.GetValueOrDefault(0).ToString(), dailyRequirement.Key.ToString("yyyy-MM-dd"), objectives[requirementFlightDay.ObjectiveID].ObjectiveName, requirementFlightDay.Units.GetValueOrDefault(0).ToStringSafe() });

                    total += requirementFlightDay.Units.GetValueOrDefault(0);
                }
            }

            report.Rows.Add(new object[] { String.Empty, "Total", String.Empty, total.ToStringSafe() });

            return report;
        }

        /// <summary>
        /// Gets the daily requirements report for a POI
        /// </summary>
        /// <param name="poi">The POI to analyze</param>
        /// <returns>A data table for the daily requirements for the POI</returns>
        public static DataTable GetPOIReport(POI poi)
        {
            DataTable report = new DataTable();

            poi = DataService.GetPOI(poi);

            POIFlightDay poiFlightDay = new POIFlightDay();
            poiFlightDay.POIID = poi.POIID;

            IList<POIFlightDay> poiFlightDays = DataService.ListPOIFlightDays(poiFlightDay).OrderBy(x => x.FlightDayNumber).ToList();

            IList<Objective> objectives = DataService.GetObjectives().OrderBy(x => x.ObjectiveName).ToList();

            report.Columns.Add("ObjectiveDay", typeof(String));
            report.Columns.Add("QTY", typeof(String));
            report.Columns.Add("Eval", typeof(String));

            foreach (Objective objective in objectives)
            {
                IList<POIFlightDay> objectiveDays = poiFlightDays.Where(x => x.ObjectiveID == objective.ObjectiveID && x.Units.GetValueOrDefault(0) > 0).ToList();

                if (objectiveDays.Count > 0)
                {
                    report.Rows.Add(new object[] { objective.ObjectiveName, "Hours", "Eval" });

                    foreach (POIFlightDay day in objectiveDays)
                    {
                        report.Rows.Add(new object[] { day.FlightDayNumber.GetValueOrDefault(0).ToString(), day.Units.GetValueOrDefault(0).ToString(),
                            day.Evaluation == true ? "Y" : "N" });
                    }

                    report.Rows.Add(new object[] { "Total", objectiveDays.Sum(x => x.Units.GetValueOrDefault(0)).ToString(), String.Empty });

                    if (objectives.IndexOf(objective) != objectives.Count - 1)
                    {
                        report.Rows.Add(new object[] { String.Empty, String.Empty, String.Empty });
                    }
                }
            }

            return report;
        }

        public static DataTable GetYearlyRequirementsReport(Program program, Program carryOverProgram, IList<Int32> courseLevels, IList<Int32> systems, Nullable<Boolean> reimbursable)
        {
            DataTable report = new DataTable();

            IDictionary<Nullable<Int32>, Objective> objectiveList = DataService.ListObjectiveDictionary();
            IDictionary<Nullable<Int32>, POI> poiList = DataService.ListPOIDictionary();

            report.Columns.Add("Program", typeof(String));
            report.Columns.Add("System", typeof(String));
            report.Columns.Add("Course", typeof(String));
            report.Columns.Add("Course Length", typeof(String));
            report.Columns.Add("Max", typeof(String));
            report.Columns.Add("Min", typeof(String));
            report.Columns.Add("Opt", typeof(String));
            report.Columns.Add("POI", typeof(String));
            report.Columns.Add("POI Date", typeof(String));
            report.Columns.Add("Flight Hours", typeof(String));
            report.Columns.Add("Sim Hours", typeof(String));
            report.Columns.Add("Classes", typeof(String));
            report.Columns.Add("Students", typeof(String));
            report.Columns.Add("Reimburseable", typeof(String));

            if (program.ProgramID.HasValue)
            {
                program = DataService.GetProgram(program);

                foreach (Int32 systemId in systems)
                {
                    Domain.Entities.System system = DataService.GetSystem(new Domain.Entities.System() { SystemID = systemId });

                    Course courseSearch = new Course();
                    courseSearch.ProgramID = program.ProgramID;
                    courseSearch.SystemID = systemId;
                    courseSearch.SearchProperties.CourseLevelIDIsIn = courseLevels.Select(x => (Nullable<Int32>)x).ToList();

                    IList<Course> courseList = DataService.ListCourses(courseSearch);

                    foreach (Course course in courseList.OrderBy(x => x.CourseName))
                    {
                        Class classSearch = new Class();
                        classSearch.CourseID = course.CourseID;

                        IList<Class> classes = DataService.ListClasses(classSearch);

                        IDictionary<Nullable<Int32>, List<Class>> poiClasses = classes.GroupBy(x => x.POIID).ToDictionary(x => x.Key, x => x.ToList());

                        foreach (Nullable<Int32> poiId in poiClasses.Keys)
                        {
                            IList<Class> poiClassList = poiClasses[poiId];
                            POI poi = poiList.GetValueOrDefault(poiId);

                            POIFlightDay flightDay = new POIFlightDay();
                            flightDay.POIID = poi.POIID;

                            IList<POIFlightDay> flightDays = DataService.ListPOIFlightDays(flightDay);

                            Int32 daysPerWeek = CalendarUtil.GetWeekLength(poi);

                            Int32 poiWeeks = poi.Days.GetValueOrDefault(0) / daysPerWeek;
                            Int32 poiDays = poi.Days.GetValueOrDefault(0) % daysPerWeek;
                            Int32 classCount = poiClassList.Count;
                            Int32 studentCount = poiClassList.Sum(x => x.Students.GetValueOrDefault(0));
                            Int32 reimburseableCount = poiClassList.Sum(x => x.Reimbursable.GetValueOrDefault(0));

                            report.Rows.Add(new Object[] { program.ProgramName, system.SystemName, course.CourseName,
                                String.Format("{0} Wks {1} Days", poiWeeks.ToString(), poiDays.ToString()), course.MaxClassSize, course.MinClassSize, course.OptimumClassSize,
                                poi.POIName, poi.EffectiveDate.ToDateStringSafe("yyyy-MM-dd"),
                                flightDays.Where(x => objectiveList[x.ObjectiveID].FlightHours == true).Sum(x => x.Units.GetValueOrDefault(0)),
                                flightDays.Where(x => objectiveList[x.ObjectiveID].SimulatorHours == true).Sum(x => x.Units.GetValueOrDefault(0)),
                                classCount, studentCount, reimburseableCount });
                        }
                    }
                }
            }

            if (carryOverProgram.ProgramID.HasValue)
            {
                carryOverProgram = DataService.GetProgram(carryOverProgram);

                foreach (Int32 systemId in systems)
                {
                    Domain.Entities.System system = DataService.GetSystem(new Domain.Entities.System() { SystemID = systemId });

                    Course courseSearch = new Course();
                    courseSearch.ProgramID = carryOverProgram.ProgramID;
                    courseSearch.SystemID = systemId;
                    courseSearch.SearchProperties.CourseLevelIDIsIn = courseLevels.Select(x => (Nullable<Int32>)x).ToList();

                    IList<Course> courseList = DataService.ListCourses(courseSearch);

                    foreach (Course course in courseList.OrderBy(x => x.CourseName))
                    {
                        Class classSearch = new Class();
                        classSearch.CourseID = course.CourseID;

                        IList<Class> classes = DataService.ListClasses(classSearch);

                        IDictionary<Nullable<Int32>, List<Class>> poiClasses = classes.GroupBy(x => x.POIID).ToDictionary(x => x.Key, x => x.ToList());

                        foreach (Nullable<Int32> poiId in poiClasses.Keys)
                        {
                            IList<Class> poiClassList = poiClasses[poiId];
                            POI poi = poiList.GetValueOrDefault(poiId);

                            POIFlightDay flightDay = new POIFlightDay();
                            flightDay.POIID = poi.POIID;

                            IList<POIFlightDay> flightDays = DataService.ListPOIFlightDays(flightDay);

                            Int32 daysPerWeek = CalendarUtil.GetWeekLength(poi);

                            Int32 poiWeeks = poi.Days.GetValueOrDefault(0) / daysPerWeek;
                            Int32 poiDays = poi.Days.GetValueOrDefault(0) % daysPerWeek;
                            Int32 classCount = poiClassList.Count;
                            Int32 studentCount = poiClassList.Sum(x => x.Students.GetValueOrDefault(0));
                            Int32 reimburseableCount = poiClassList.Sum(x => x.Reimbursable.GetValueOrDefault(0));

                            report.Rows.Add(new Object[] { carryOverProgram.ProgramName, system.SystemName, course.CourseName,
                                String.Format("{0} Wks {1} Days", poiWeeks.ToString(), poiDays.ToString()), course.MaxClassSize, course.MinClassSize, course.OptimumClassSize,
                                poi.POIName, poi.EffectiveDate.ToDateStringSafe("yyyy-MM-dd"),
                                flightDays.Where(x => objectiveList[x.ObjectiveID].FlightHours == true).Sum(x => x.Units.GetValueOrDefault(0)),
                                flightDays.Where(x => objectiveList[x.ObjectiveID].SimulatorHours == true).Sum(x => x.Units.GetValueOrDefault(0)),
                                classCount, studentCount, reimburseableCount });
                        }
                    }
                }
            }

            return report;
        }


        /// <summary>
        /// Gets the historical percents report for a Program
        /// </summary>
        /// <param name="poi">The Program to analyze</param>
        /// <returns>A data table for the historical percents for the Program</returns>
        public static DataTable GetProgramHistoricalPercentsReport(Program program)
        {
            DataTable report = new DataTable();

            program = DataService.GetProgram(program);

            Course courseSearch = new Course();
            courseSearch.ProgramID = program.ProgramID;

            IList<Course> courses = DataService.ListCourses(courseSearch).OrderBy(x => x.CourseName).ToList();

            report.Columns.Add("Course", typeof(String));

            for (int i = 0; i < 12; i++)
            {
                Int32 month = (i + 9) % 12 + 1;

                report.Columns.Add(CalendarUtil.Get1352MonthName(month).Substring(0, 3), typeof(String));
            }

            report.Columns.Add("Support", typeof(String));
            report.Columns.Add("Setback", typeof(String));
            report.Columns.Add("Test", typeof(String));
            report.Columns.Add("Min", typeof(String));
            report.Columns.Add("Opt", typeof(String));
            report.Columns.Add("Max", typeof(String));
            report.Columns.Add("Length", typeof(String));
            report.Columns.Add("Level", typeof(String));
            report.Columns.Add("System", typeof(String));
            report.Columns.Add("Students", typeof(String));
            report.Columns.Add("Reimbursable", typeof(String));

            foreach (Course course in courses)
            {
                IList<Decimal> historicalPercents = ReportUtil.GetHistoricalPercentsList(course);

                report.Rows.Add(ReportUtil.ConstructHistoricalPercentsRow(course, historicalPercents));
            }

            return report;
        }

        /// <summary>
        /// Gets the monthly report by system based on the types, program, carry overs, and inclusions
        /// </summary>
        /// <param name="forecast">True for forecast, False for actuals</param>
        /// <param name="program">The program for the report</param>
        /// <param name="carryOverProgram">The carry over program for the report</param>
        /// <param name="courseLevels">The list of course levels to report</param>
        /// <param name="systems">The list of systems to report</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <param name="includeBASOPS">True if BASOPS hours should be includes, False if not</param>
        /// <param name="includeAddins">True if Addins hours should be includes, False if not</param>
        /// <param name="includeSupport">True if Support hours should be includes, False if not</param>
        /// <returns>A data table for the monthly report by system</returns>
        public static DataTable GetMonthlyBySystemReport(Boolean forecast, Program program, Program carryOverProgram, IList<Int32> courseLevels, IList<Int32> systems, Nullable<Boolean> reimbursable, Boolean includeBASOPS, Boolean includeAddins, Boolean includeSupport)
        {
            DataTable report = new DataTable();

            report.Columns.Add("Type", typeof(String));
            report.Columns.Add("Level", typeof(String));
            report.Columns.Add("System", typeof(String));

            for (int i = 0; i < 12; i++)
            {
                Int32 month = (i + 9) % 12 + 1;

                report.Columns.Add(CalendarUtil.Get1352MonthName(month).Substring(0, 3), typeof(String));

                if (month % 3 == 0)
                {
                    Int32 quarterNumber = (i / 3) + 1;

                    report.Columns.Add(String.Format("Q{0}", quarterNumber.ToString()));
                }
            }

            report.Columns.Add("Total", typeof(String));

            IDictionary<Int32, Decimal> overallTotalDictionary = CreateMonthlyDictionary();

            IDictionary<Int32, IDictionary<Int32, Decimal>> systemTotalDictionary = new Dictionary<Int32, IDictionary<Int32, Decimal>>();

            foreach (Int32 courseLevelId in courseLevels)
            {
                IDictionary<Int32, Decimal> totals = CreateMonthlyDictionary();

                CourseLevel courseLevel = DataService.GetCourseLevel(new CourseLevel { CourseLevelID = courseLevelId });

                foreach (Int32 systemId in systems)
                {
                    IDictionary<Int32, Decimal> systemDictionary = systemTotalDictionary.GetValueOrDefault(systemId, CreateMonthlyDictionary());

                    USAACE.ATI.Domain.Entities.System system = DataService.GetSystem(new Domain.Entities.System { SystemID = systemId });

                    IDictionary<Int32, Decimal> values = forecast ? GetMonthlyForecastBySystem(program, carryOverProgram, courseLevel, system, reimbursable, includeBASOPS, includeAddins) :
                        GetMonthlyActualBySystem(program, courseLevel, system, reimbursable, includeBASOPS, includeSupport);

                    if (values.Sum(x => x.Value) > 0)
                    {
                        report.Rows.Add(ConstructMonthlyReportRow(values, forecast ? "Forecast" : "Actual", courseLevel.CourseLevelName, system.SystemName));

                        AddValues<Int32>(totals, values);
                        AddValues<Int32>(systemDictionary, values);
                        AddValues<Int32>(overallTotalDictionary, values);
                    }

                    if (!systemTotalDictionary.ContainsKey(systemId))
                    {
                        systemTotalDictionary.Add(systemId, systemDictionary);
                    }
                }

                report.Rows.Add(ConstructMonthlyReportRow(totals, forecast ? "Forecast" : "Actual", courseLevel.CourseLevelName, "All"));
            }

            foreach (KeyValuePair<Int32, IDictionary<Int32, Decimal>> systemTotal in systemTotalDictionary)
            {
                USAACE.ATI.Domain.Entities.System system = DataService.GetSystem(new Domain.Entities.System { SystemID = systemTotal.Key });

                if (systemTotal.Value.Sum(x => x.Value) > 0)
                {
                    report.Rows.Add(ConstructMonthlyReportRow(systemTotal.Value, forecast ? "Forecast" : "Actual", "Summary", system.SystemName));
                }
            }

            report.Rows.Add(ConstructMonthlyReportRow(overallTotalDictionary, forecast ? "Forecast" : "Actual", "Summary", "All"));

            return report;
        }

        /// <summary>
        /// Gets the monthly report by course based on the types, program, carry overs, and inclusions
        /// </summary>
        /// <param name="forecast">True for forecast, False for actuals</param>
        /// <param name="program">The program for the report</param>
        /// <param name="carryOverProgram">The carry over program for the report</param>
        /// <param name="courseLevels">The list of course levels to report</param>
        /// <param name="systems">The list of systems to report</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <returns>A data table for the monthly report by course</returns>
        public static DataTable GetMonthlyByCourseReport(Boolean forecast, Program program, Program carryOverProgram, IList<Int32> courseLevels, IList<Int32> systems, Nullable<Boolean> reimbursable)
        {
            DataTable report = new DataTable();

            IDictionary<Nullable<Int32>, USAACE.ATI.Domain.Entities.System> systemList = DataService.ListSystemDictionary();
            IDictionary<Nullable<Int32>, CourseLevel> courseLevelList = DataService.ListCourseLevelDictionary();
            IDictionary<Nullable<Int32>, CourseType> courseTypeList = DataService.ListCourseTypeDictionary();

            report.Columns.Add("Type", typeof(String));
            report.Columns.Add("Level", typeof(String));
            report.Columns.Add("System", typeof(String));
            report.Columns.Add("Course Title", typeof(String));

            for (int i = 0; i < 12; i++)
            {
                Int32 month = (i + 9) % 12 + 1;

                report.Columns.Add(CalendarUtil.Get1352MonthName(month).Substring(0, 3), typeof(String));

                if (month % 3 == 0)
                {
                    Int32 quarterNumber = (i / 3) + 1;

                    report.Columns.Add(String.Format("Q{0}", quarterNumber.ToString()));
                }
            }

            report.Columns.Add("Total", typeof(String));

            foreach (Int32 courseLevelId in courseLevels)
            {
                IDictionary<Int32, Decimal> totals = CreateMonthlyDictionary();

                CourseLevel courseLevel = new CourseLevel();
                courseLevel.CourseLevelID = courseLevelId;

                courseLevel = courseLevelList.GetValueOrDefault(courseLevelId);

                foreach (Int32 systemId in systems)
                {
                    USAACE.ATI.Domain.Entities.System system = new USAACE.ATI.Domain.Entities.System();
                    system.SystemID = systemId;

                    system = systemList.GetValueOrDefault(systemId);

                    Course courseSearch = new Course();
                    courseSearch.ProgramID = program.ProgramID;
                    courseSearch.SystemID = systemId;
                    courseSearch.CourseLevelID = courseLevelId;

                    IList<Course> courseList = DataService.ListCourses(courseSearch);

                    foreach (Course course in courseList)
                    {
                        IList<Decimal> percents = GetHistoricalPercentsList(course);

                        IDictionary<Int32, Decimal> values = forecast ? GetMonthlyForecastByCourse(course, reimbursable, false, percents) : GetMonthlyActualByCourse(course, reimbursable);

                        CourseType type = courseTypeList.GetValueOrDefault(course.CourseTypeID);

                        course.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(course, system, type);

                        report.Rows.Add(ConstructMonthlyReportRow(values, forecast ? "Forecast" : "Actual", courseLevel.CourseLevelName, system.SystemName, course.ExtendedProperties.DisplayName));

                        AddValues<Int32>(totals, values);
                    }

                    if (carryOverProgram.ProgramID.HasValue)
                    {
                        Course carryOverCourseSearch = new Course();
                        carryOverCourseSearch.ProgramID = carryOverProgram.ProgramID;
                        carryOverCourseSearch.SystemID = systemId;
                        carryOverCourseSearch.CourseLevelID = courseLevelId;

                        IList<Course> carryOverCourseList = DataService.ListCourses(carryOverCourseSearch);

                        foreach (Course course in carryOverCourseList)
                        {
                            Course mainCourseSearch = new Course();
                            mainCourseSearch.ProgramID = program.ProgramID;
                            mainCourseSearch.CourseNumberID = course.CourseNumberID;

                            IList<Course> mainCourses = DataService.ListCourses(mainCourseSearch);

                            IList<Decimal> percents = mainCourses.Count > 0 ? GetHistoricalPercentsList(mainCourses[0]) : GetHistoricalPercentsList(course);

                            IDictionary<Int32, Decimal> values = forecast ? GetMonthlyForecastByCourse(course, reimbursable, true, percents) : GetMonthlyActualByCourse(course, reimbursable);

                            CourseType type = courseTypeList.GetValueOrDefault(course.CourseTypeID);

                            course.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(course, system, type);

                            report.Rows.Add(ConstructMonthlyReportRow(values, forecast ? "Forecast" : "Actual", courseLevel.CourseLevelName, system.SystemName, course.ExtendedProperties.DisplayName));

                            AddValues<Int32>(totals, values);
                        }
                    }
                }

                report.Rows.Add(ConstructMonthlyReportRow(totals, String.Empty, String.Empty, String.Empty, String.Empty));
            }

            return report;
        }

        /// <summary>
        /// Gets the monthly report by course based on the types, course, and carry over
        /// </summary>
        /// <param name="forecast">True for forecast, False for actuals</param>
        /// <param name="course">The course for the report</param>
        /// <param name="carryOverCourse">The carry over course for the report</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <returns>A data table for the monthly report by course</returns>
        public static DataTable GetMonthlyByCourseReport(Boolean forecast, Course course, Course carryOverCourse, Nullable<Boolean> reimbursable)
        {
            DataTable report = new DataTable();

            IDictionary<Nullable<Int32>, USAACE.ATI.Domain.Entities.System> systemList = DataService.ListSystemDictionary();
            IDictionary<Nullable<Int32>, CourseLevel> courseLevelList = DataService.ListCourseLevelDictionary();
            IDictionary<Nullable<Int32>, CourseType> courseTypeList = DataService.ListCourseTypeDictionary();

            report.Columns.Add("Type", typeof(String));
            report.Columns.Add("Level", typeof(String));
            report.Columns.Add("System", typeof(String));
            report.Columns.Add("Course Title", typeof(String));

            for (int i = 0; i < 12; i++)
            {
                Int32 month = (i + 9) % 12 + 1;

                report.Columns.Add(CalendarUtil.Get1352MonthName(month).Substring(0, 3), typeof(String));

                if (month % 3 == 0)
                {
                    Int32 quarterNumber = (i / 3) + 1;

                    report.Columns.Add(String.Format("Q{0}", quarterNumber.ToString()));
                }
            }

            report.Columns.Add("Total", typeof(String));

            course = DataService.LoadCourse(course);

            IDictionary<Int32, Decimal> totals = CreateMonthlyDictionary();

            String reportType = forecast ? "Forecast" : "Actual";

            if (course.CourseID.HasValue)
            {
                IList<Decimal> percents = GetHistoricalPercentsList(course);

                IDictionary<Int32, Decimal> values = forecast ? GetMonthlyForecastByCourse(course, reimbursable, false, percents) : GetMonthlyActualByCourse(course, reimbursable);

                CourseLevel courseLevel = courseLevelList.GetValueOrDefault(course.CourseLevelID);

                USAACE.ATI.Domain.Entities.System system = systemList.GetValueOrDefault(course.SystemID);

                CourseType type = courseTypeList.GetValueOrDefault(course.CourseTypeID);

                course.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(course, system, type);

                report.Rows.Add(ConstructMonthlyReportRow(values, reportType, courseLevel.CourseLevelName, system.SystemName, course.ExtendedProperties.DisplayName));

                AddValues<Int32>(totals, values);
            }

            if (carryOverCourse.CourseID.HasValue)
            {
                carryOverCourse = DataService.LoadCourse(carryOverCourse);

                IList<Decimal> percents = GetHistoricalPercentsList(course);

                IDictionary<Int32, Decimal> values = forecast ? GetMonthlyForecastByCourse(carryOverCourse, reimbursable, true, percents) : GetMonthlyActualByCourse(carryOverCourse, reimbursable);

                CourseLevel courseLevel = courseLevelList.GetValueOrDefault(carryOverCourse.CourseLevelID);

                USAACE.ATI.Domain.Entities.System system = systemList.GetValueOrDefault(carryOverCourse.SystemID);

                CourseType type = courseTypeList.GetValueOrDefault(carryOverCourse.CourseTypeID);

                carryOverCourse.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(carryOverCourse, system, type);

                report.Rows.Add(ConstructMonthlyReportRow(values, reportType, courseLevel.CourseLevelName, system.SystemName, carryOverCourse.ExtendedProperties.DisplayName));

                AddValues<Int32>(totals, values);
            }

            report.Rows.Add(ConstructMonthlyReportRow(totals, String.Empty, String.Empty, String.Empty, String.Empty));

            return report;
        }

        /// <summary>
        /// Gets the monthly non-POI hours report based on the types, program, and inclusions
        /// </summary>
        /// <param name="forecast">True for forecast, False for actuals</param>
        /// <param name="program">The program for the report</param>
        /// <param name="courseLevels">The list of course levels to report</param>
        /// <param name="systems">The list of systems to report</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <returns>A data table for the monthly non-POI hours report</returns>
        public static DataTable GetNonPOIHoursReport(Boolean forecast, Program program, IList<Int32> courseLevels, IList<Int32> systems, Nullable<Boolean> reimbursable, Boolean includeSupportHours, Boolean includeBASOPSHours, Boolean includeAddinHours)
        {
            DataTable report = new DataTable();

            IDictionary<Nullable<Int32>, USAACE.ATI.Domain.Entities.System> systemList = DataService.ListSystemDictionary();
            IDictionary<Nullable<Int32>, CourseLevel> courseLevelList = DataService.ListCourseLevelDictionary();

            report.Columns.Add("Type", typeof(String));
            report.Columns.Add("Level", typeof(String));
            report.Columns.Add("System", typeof(String));
            report.Columns.Add("Support Type", typeof(String));

            for (int i = 0; i < 12; i++)
            {
                Int32 month = (i + 9) % 12 + 1;

                report.Columns.Add(CalendarUtil.Get1352MonthName(month).Substring(0, 3), typeof(String));

                if (month % 3 == 0)
                {
                    Int32 quarterNumber = (i / 3) + 1;

                    report.Columns.Add(String.Format("Q{0}", quarterNumber.ToString()));
                }
            }

            report.Columns.Add("Total", typeof(String));

            if (includeSupportHours)
            {
                IList<MiscHours> miscHoursTypeList = DataService.GetMiscHourses();

                foreach (Int32 courseLevelId in courseLevels)
                {
                    IDictionary<Int32, Decimal> totals = CreateMonthlyDictionary();

                    CourseLevel courseLevel = new CourseLevel();
                    courseLevel.CourseLevelID = courseLevelId;

                    courseLevel = courseLevelList.GetValueOrDefault(courseLevelId);

                    foreach (Int32 systemId in systems)
                    {
                        USAACE.ATI.Domain.Entities.System system = new USAACE.ATI.Domain.Entities.System();
                        system.SystemID = systemId;

                        system = systemList.GetValueOrDefault(systemId);

                        foreach (MiscHours miscHoursType in miscHoursTypeList)
                        {
                            IDictionary<Int32, Decimal> values = ReportUtil.GetNonPOIHours(program, 2, courseLevel, system, miscHoursType, forecast, reimbursable);

                            if (values.Sum(x => x.Value) > 0)
                            {
                                report.Rows.Add(ConstructMonthlyReportRow(values, "Support", courseLevel.CourseLevelName, system.SystemName, miscHoursType.MiscHoursName));

                                AddValues<Int32>(totals, values);
                            }
                        }
                    }

                    report.Rows.Add(ConstructMonthlyReportRow(totals, "Support", courseLevel.CourseLevelName, "All", "All"));
                }
            }

            if (includeBASOPSHours)
            {
                foreach (Int32 courseLevelId in courseLevels)
                {
                    IDictionary<Int32, Decimal> totals = CreateMonthlyDictionary();

                    CourseLevel courseLevel = new CourseLevel();
                    courseLevel.CourseLevelID = courseLevelId;

                    courseLevel = courseLevelList.GetValueOrDefault(courseLevelId);

                    foreach (Int32 systemId in systems)
                    {
                        USAACE.ATI.Domain.Entities.System system = new USAACE.ATI.Domain.Entities.System();
                        system.SystemID = systemId;

                        system = systemList.GetValueOrDefault(systemId);

                        IDictionary<Int32, Decimal> values = ReportUtil.GetNonPOIHours(program, 3, courseLevel, system, null, forecast, reimbursable);

                        if (values.Sum(x => x.Value) > 0)
                        {
                            report.Rows.Add(ConstructMonthlyReportRow(values, "BASOPS", courseLevel.CourseLevelName, system.SystemName, "N/A"));

                            AddValues<Int32>(totals, values);
                        }
                    }

                    report.Rows.Add(ConstructMonthlyReportRow(totals, "BASOPS", courseLevel.CourseLevelName, "All", "N/A"));
                }
            }

            if (includeAddinHours)
            {
                foreach (Int32 courseLevelId in courseLevels)
                {
                    IDictionary<Int32, Decimal> totals = CreateMonthlyDictionary();

                    CourseLevel courseLevel = new CourseLevel();
                    courseLevel.CourseLevelID = courseLevelId;

                    courseLevel = courseLevelList.GetValueOrDefault(courseLevelId);

                    foreach (Int32 systemId in systems)
                    {
                        USAACE.ATI.Domain.Entities.System system = new USAACE.ATI.Domain.Entities.System();
                        system.SystemID = systemId;

                        system = systemList.GetValueOrDefault(systemId);

                        IDictionary<Int32, Decimal> values = ReportUtil.GetNonPOIHours(program, 4, courseLevel, system, null, forecast, reimbursable);

                        if (values.Sum(x => x.Value) > 0)
                        {
                            report.Rows.Add(ConstructMonthlyReportRow(values, "Add-Ins", courseLevel.CourseLevelName, system.SystemName, "N/A"));

                            AddValues<Int32>(totals, values);
                        }
                    }

                    report.Rows.Add(ConstructMonthlyReportRow(totals, "Add-Ins", courseLevel.CourseLevelName, "All", "N/A"));
                }
            }

            return report;
        }

        /// <summary>
        /// Gets the daily requirements report by system based on the types, program, and carry overs
        /// </summary>
        /// <param name="program">The program for the report</param>
        /// <param name="carryOverProgram">The carry over program for the report</param>
        /// <param name="courseLevels">The list of course levels to report</param>
        /// <param name="systems">The list of systems to report</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <param name="requirements">A list of the daily requirements to calculate</param>
        /// <returns>A data table for the daily requirements report by system</returns>
        public static DataTable GetDailyRequirementsBySystemReport(Program program, Program carryOverProgram, IList<Int32> courseLevels, IList<Int32> systems, Nullable<Boolean> reimbursable, IList<String> requirements)
        {
            DataTable report = new DataTable();

            IDictionary<Nullable<Int32>, USAACE.ATI.Domain.Entities.System> systemList = DataService.ListSystemDictionary();
            IDictionary<Nullable<Int32>, CourseLevel> courseLevelList = DataService.ListCourseLevelDictionary();
            IDictionary<Nullable<Int32>, Objective> objectiveList = DataService.ListObjectiveDictionary();
            IDictionary<Nullable<Int32>, POI> poiList = DataService.ListPOIDictionary();

            report.Columns.Add("Level", typeof(String));
            report.Columns.Add("System", typeof(String));
            report.Columns.Add("Requirement", typeof(String));

            if (program.ProgramID.HasValue)
            {
                program = DataService.GetProgram(program);

                IList<DateTime> flyingDays = CalendarUtil.GetProgramFlyingDays(program, true, false);

                foreach (DateTime flyingDay in flyingDays)
                {
                    report.Columns.Add(flyingDay.ToString("MMM d"), typeof(String));
                }

                foreach (Int32 courseLevelId in courseLevels)
                {
                    CourseLevel courseLevel = new CourseLevel();
                    courseLevel.CourseLevelID = courseLevelId;

                    courseLevel = courseLevelList.GetValueOrDefault(courseLevelId);

                    foreach (Int32 systemId in systems)
                    {
                        USAACE.ATI.Domain.Entities.System system = new USAACE.ATI.Domain.Entities.System();
                        system.SystemID = systemId;

                        system = systemList.GetValueOrDefault(systemId);

                        Course courseSearch = new Course();
                        courseSearch.ProgramID = program.ProgramID;
                        courseSearch.SystemID = systemId;
                        courseSearch.CourseLevelID = courseLevelId;

                        IList<Course> courseList = DataService.ListCourses(courseSearch);

                        if (courseList.Count > 0)
                        {
                            IDictionary<DateTime, Decimal> dayFlightCountTotal = null;
                            IDictionary<DateTime, Decimal> nightFlightCountTotal = null;
                            IDictionary<DateTime, Decimal> studentCountTotal = null;
                            IDictionary<DateTime, Decimal> flightHoursCountTotal = null;
                            IDictionary<DateTime, Decimal> simulatorStudentCountTotal = null;
                            IDictionary<DateTime, Decimal> simulatorHoursCountTotal = null;
                            IDictionary<DateTime, Decimal> dayAircraftCountTotal = null;
                            IDictionary<DateTime, Decimal> nightAircraftCountTotal = null;
                            IDictionary<DateTime, Decimal> dayLaunchCountTotal = null;
                            IDictionary<DateTime, Decimal> nightLaunchCountTotal = null;
                            IDictionary<DateTime, Decimal> totalLaunchCountTotal = null;
                            IDictionary<DateTime, Decimal> totalInstructorCountTotal = null;

                            foreach (Course course in courseList)
                            {
                                Class classSearch = new Class();
                                classSearch.CourseID = course.CourseID;

                                IList<Class> classes = DataService.ListClasses(classSearch);

                                IDictionary<DateTime, Decimal> dayFlightCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, false, false);
                                dayFlightCountTotal = dayFlightCountTotal == null ? dayFlightCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayFlightCount, dayFlightCountTotal });

                                IDictionary<DateTime, Decimal> nightFlightCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, true, false);
                                nightFlightCountTotal = nightFlightCountTotal == null ? nightFlightCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { nightFlightCount, nightFlightCountTotal });

                                IDictionary<DateTime, Decimal> studentCount = GetTotalStudentsByDay(flyingDays, course, classes, poiList, reimbursable);
                                studentCountTotal = studentCountTotal == null ? studentCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { studentCount, studentCountTotal });

                                IDictionary<DateTime, Decimal> flightHoursCount = GetFlightHoursByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, false);
                                flightHoursCountTotal = flightHoursCountTotal == null ? flightHoursCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { flightHoursCount, flightHoursCountTotal });

                                IDictionary<DateTime, Decimal> simulatorStudentCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, false, false, true);
                                simulatorStudentCountTotal = simulatorStudentCountTotal == null ? simulatorStudentCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { simulatorStudentCount, simulatorStudentCountTotal });

                                IDictionary<DateTime, Decimal> simulatorHoursCount = GetFlightHoursByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, false, true);
                                simulatorHoursCountTotal = simulatorHoursCountTotal == null ? simulatorHoursCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { simulatorHoursCount, simulatorHoursCountTotal });

                                IDictionary<DateTime, Decimal> dayAircraftCount = GetDayAircraftByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable);
                                dayAircraftCountTotal = dayAircraftCountTotal == null ? dayAircraftCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayAircraftCount, dayAircraftCountTotal });

                                IDictionary<DateTime, Decimal> nightAircraftCount = nightFlightCount.ToDictionary<KeyValuePair<DateTime, Decimal>, DateTime, Decimal>(x => x.Key, x => Math.Ceiling(x.Value / 2M));
                                nightAircraftCountTotal = nightAircraftCountTotal == null ? nightAircraftCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { nightAircraftCount, nightAircraftCountTotal });

                                IDictionary<DateTime, Decimal> dayLaunchCount = dayAircraftCount.ToDictionary<KeyValuePair<DateTime, Decimal>, DateTime, Decimal>(x => x.Key, x => Math.Ceiling(x.Value) * 2M);
                                dayLaunchCountTotal = dayLaunchCountTotal == null ? dayLaunchCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayLaunchCount, dayLaunchCountTotal });

                                IDictionary<DateTime, Decimal> nightLaunchCount = nightFlightCount.ToDictionary<KeyValuePair<DateTime, Decimal>, DateTime, Decimal>(x => x.Key, x => Math.Ceiling(x.Value / 2M));
                                nightLaunchCountTotal = nightLaunchCountTotal == null ? nightLaunchCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { nightLaunchCount, nightLaunchCountTotal });

                                IDictionary<DateTime, Decimal> totalLaunchCount = SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayLaunchCount, nightLaunchCount });
                                totalLaunchCountTotal = totalLaunchCountTotal == null ? totalLaunchCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { totalLaunchCount, totalLaunchCountTotal });

                                IDictionary<DateTime, Decimal> totalInstructorCount = SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayFlightCount, nightFlightCount, simulatorStudentCount }).ToDictionary<KeyValuePair<DateTime, Decimal>, DateTime, Decimal>(x => x.Key, x => Math.Ceiling(x.Value / 2M));
                                totalInstructorCountTotal = totalInstructorCountTotal == null ? totalInstructorCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { totalInstructorCount, totalInstructorCountTotal });
                            }

                            if (requirements.Contains("Day Flight"))
                            {
                                IList<String> dayFlightCountRow = new List<String>();
                                dayFlightCountRow.Add(courseLevel.CourseLevelName);
                                dayFlightCountRow.Add(system.SystemName);
                                dayFlightCountRow.Add("Day Flight");
                                dayFlightCountRow.AppendList(dayFlightCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(dayFlightCountRow.ToArray());
                            }

                            if (requirements.Contains("Night Flight"))
                            {
                                IList<String> nightFlightCountRow = new List<String>();
                                nightFlightCountRow.Add(courseLevel.CourseLevelName);
                                nightFlightCountRow.Add(system.SystemName);
                                nightFlightCountRow.Add("Night Flight");
                                nightFlightCountRow.AppendList(nightFlightCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(nightFlightCountRow.ToArray());
                            }

                            if (requirements.Contains("Total in Training"))
                            {
                                IList<String> studentCountRow = new List<String>();
                                studentCountRow.Add(courseLevel.CourseLevelName);
                                studentCountRow.Add(system.SystemName);
                                studentCountRow.Add("Total in Training");
                                studentCountRow.AppendList(studentCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(studentCountRow.ToArray());
                            }

                            if (requirements.Contains("Daily Flight Hours"))
                            {
                                IList<String> flightHoursCountRow = new List<String>();
                                flightHoursCountRow.Add(courseLevel.CourseLevelName);
                                flightHoursCountRow.Add(system.SystemName);
                                flightHoursCountRow.Add("Daily Flight Hours");
                                flightHoursCountRow.AppendList(flightHoursCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(flightHoursCountRow.ToArray());
                            }

                            if (requirements.Contains("Simulator Students"))
                            {
                                IList<String> simulatorStudentCountRow = new List<String>();
                                simulatorStudentCountRow.Add(courseLevel.CourseLevelName);
                                simulatorStudentCountRow.Add(system.SystemName);
                                simulatorStudentCountRow.Add("Simulator Students");
                                simulatorStudentCountRow.AppendList(simulatorStudentCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(simulatorStudentCountRow.ToArray());
                            }

                            if (requirements.Contains("Simulator Hours"))
                            {
                                IList<String> simulatorHoursCountRow = new List<String>();
                                simulatorHoursCountRow.Add(courseLevel.CourseLevelName);
                                simulatorHoursCountRow.Add(system.SystemName);
                                simulatorHoursCountRow.Add("Simulator Hours");
                                simulatorHoursCountRow.AppendList(simulatorHoursCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(simulatorHoursCountRow.ToArray());
                            }

                            if (requirements.Contains("Aircraft for Day"))
                            {
                                IList<String> dayAircraftCountRow = new List<String>();
                                dayAircraftCountRow.Add(courseLevel.CourseLevelName);
                                dayAircraftCountRow.Add(system.SystemName);
                                dayAircraftCountRow.Add("Aircraft for Day");
                                dayAircraftCountRow.AppendList(dayAircraftCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(dayAircraftCountRow.ToArray());
                            }

                            if (requirements.Contains("Aircraft for Night"))
                            {
                                IList<String> nightAircraftCountRow = new List<String>();
                                nightAircraftCountRow.Add(courseLevel.CourseLevelName);
                                nightAircraftCountRow.Add(system.SystemName);
                                nightAircraftCountRow.Add("Aircraft for Night");
                                nightAircraftCountRow.AppendList(nightAircraftCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(nightAircraftCountRow.ToArray());
                            }

                            if (requirements.Contains("Launches for Day"))
                            {
                                IList<String> dayLaunchesCountRow = new List<String>();
                                dayLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                dayLaunchesCountRow.Add(system.SystemName);
                                dayLaunchesCountRow.Add("Launches for Day");
                                dayLaunchesCountRow.AppendList(dayLaunchCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(dayLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Launches for Night"))
                            {
                                IList<String> nightLaunchesCountRow = new List<String>();
                                nightLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                nightLaunchesCountRow.Add(system.SystemName);
                                nightLaunchesCountRow.Add("Launches for Night");
                                nightLaunchesCountRow.AppendList(nightLaunchCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(nightLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Total Launches"))
                            {
                                IList<String> totalLaunchesCountRow = new List<String>();
                                totalLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                totalLaunchesCountRow.Add(system.SystemName);
                                totalLaunchesCountRow.Add("Total Launches");
                                totalLaunchesCountRow.AppendList(totalLaunchCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(totalLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Total IPs Required"))
                            {
                                IList<String> totalInstructorsCountRow = new List<String>();
                                totalInstructorsCountRow.Add(courseLevel.CourseLevelName);
                                totalInstructorsCountRow.Add(system.SystemName);
                                totalInstructorsCountRow.Add("Total IPs Required");
                                totalInstructorsCountRow.AppendList(totalInstructorCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(totalInstructorsCountRow.ToArray());
                            }
                        }
                    }
                }
            }

            if (carryOverProgram.ProgramID.HasValue)
            {
                carryOverProgram = DataService.GetProgram(carryOverProgram);

                IList<DateTime> flyingDays = CalendarUtil.GetProgramFlyingDays(carryOverProgram, true, true);

                foreach (Int32 courseLevelId in courseLevels)
                {
                    CourseLevel courseLevel = new CourseLevel();
                    courseLevel.CourseLevelID = courseLevelId;

                    courseLevel = courseLevelList.GetValueOrDefault(courseLevelId);

                    foreach (Int32 systemId in systems)
                    {
                        USAACE.ATI.Domain.Entities.System system = new USAACE.ATI.Domain.Entities.System();
                        system.SystemID = systemId;

                        system = systemList.GetValueOrDefault(systemId);

                        Course courseSearch = new Course();
                        courseSearch.ProgramID = carryOverProgram.ProgramID;
                        courseSearch.SystemID = systemId;
                        courseSearch.CourseLevelID = courseLevelId;

                        IList<Course> courseList = DataService.ListCourses(courseSearch);

                        if (courseList.Count > 0)
                        {
                            IDictionary<DateTime, Decimal> dayFlightCountTotal = null;
                            IDictionary<DateTime, Decimal> nightFlightCountTotal = null;
                            IDictionary<DateTime, Decimal> studentCountTotal = null;
                            IDictionary<DateTime, Decimal> flightHoursCountTotal = null;
                            IDictionary<DateTime, Decimal> simulatorStudentCountTotal = null;
                            IDictionary<DateTime, Decimal> simulatorHoursCountTotal = null;
                            IDictionary<DateTime, Decimal> dayAircraftCountTotal = null;
                            IDictionary<DateTime, Decimal> nightAircraftCountTotal = null;
                            IDictionary<DateTime, Decimal> dayLaunchCountTotal = null;
                            IDictionary<DateTime, Decimal> nightLaunchCountTotal = null;
                            IDictionary<DateTime, Decimal> totalLaunchCountTotal = null;
                            IDictionary<DateTime, Decimal> totalInstructorCountTotal = null;

                            foreach (Course course in courseList)
                            {
                                Class classSearch = new Class();
                                classSearch.CourseID = course.CourseID;

                                IList<Class> classes = DataService.ListClasses(classSearch);

                                IDictionary<DateTime, Decimal> dayFlightCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, false, false);
                                dayFlightCountTotal = dayFlightCountTotal == null ? dayFlightCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayFlightCount, dayFlightCountTotal });

                                IDictionary<DateTime, Decimal> nightFlightCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, true, false);
                                nightFlightCountTotal = nightFlightCountTotal == null ? nightFlightCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { nightFlightCount, nightFlightCountTotal });

                                IDictionary<DateTime, Decimal> studentCount = GetTotalStudentsByDay(flyingDays, course, classes, poiList, reimbursable);
                                studentCountTotal = studentCountTotal == null ? studentCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { studentCount, studentCountTotal });

                                IDictionary<DateTime, Decimal> flightHoursCount = GetFlightHoursByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, false);
                                flightHoursCountTotal = flightHoursCountTotal == null ? flightHoursCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { flightHoursCount, flightHoursCountTotal });

                                IDictionary<DateTime, Decimal> simulatorStudentCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, false, false, true);
                                simulatorStudentCountTotal = simulatorStudentCountTotal == null ? simulatorStudentCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { simulatorStudentCount, simulatorStudentCountTotal });

                                IDictionary<DateTime, Decimal> simulatorHoursCount = GetFlightHoursByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, false, true);
                                simulatorHoursCountTotal = simulatorHoursCountTotal == null ? simulatorHoursCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { simulatorHoursCount, simulatorHoursCountTotal });

                                IDictionary<DateTime, Decimal> dayAircraftCount = GetDayAircraftByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable);
                                dayAircraftCountTotal = dayAircraftCountTotal == null ? dayAircraftCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayAircraftCount, dayAircraftCountTotal });

                                IDictionary<DateTime, Decimal> nightAircraftCount = nightFlightCount.ToDictionary<KeyValuePair<DateTime, Decimal>, DateTime, Decimal>(x => x.Key, x => Math.Ceiling(x.Value / 2M));
                                nightAircraftCountTotal = nightAircraftCountTotal == null ? nightAircraftCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { nightAircraftCount, nightAircraftCountTotal });

                                IDictionary<DateTime, Decimal> dayLaunchCount = dayAircraftCount.ToDictionary<KeyValuePair<DateTime, Decimal>, DateTime, Decimal>(x => x.Key, x => Math.Ceiling(x.Value) * 2M);
                                dayLaunchCountTotal = dayLaunchCountTotal == null ? dayLaunchCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayLaunchCount, dayLaunchCountTotal });

                                IDictionary<DateTime, Decimal> nightLaunchCount = nightFlightCount.ToDictionary<KeyValuePair<DateTime, Decimal>, DateTime, Decimal>(x => x.Key, x => Math.Ceiling(x.Value / 2M));
                                nightLaunchCountTotal = nightLaunchCountTotal == null ? nightLaunchCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { nightLaunchCount, nightLaunchCountTotal });

                                IDictionary<DateTime, Decimal> totalLaunchCount = SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayLaunchCount, nightLaunchCount });
                                totalLaunchCountTotal = totalLaunchCountTotal == null ? totalLaunchCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { totalLaunchCount, totalLaunchCountTotal });

                                IDictionary<DateTime, Decimal> totalInstructorCount = SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayFlightCount, nightFlightCount, simulatorStudentCount }).ToDictionary<KeyValuePair<DateTime, Decimal>, DateTime, Decimal>(x => x.Key, x => Math.Ceiling(x.Value / 2M));
                                totalInstructorCountTotal = totalInstructorCountTotal == null ? totalInstructorCount : SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { totalInstructorCount, totalInstructorCountTotal });
                            }

                            if (requirements.Contains("Day Flight"))
                            {
                                IList<String> dayFlightCountRow = new List<String>();
                                dayFlightCountRow.Add(courseLevel.CourseLevelName);
                                dayFlightCountRow.Add(system.SystemName);
                                dayFlightCountRow.Add("Day Flight");
                                dayFlightCountRow.AppendList(dayFlightCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(dayFlightCountRow.ToArray());
                            }

                            if (requirements.Contains("Night Flight"))
                            {
                                IList<String> nightFlightCountRow = new List<String>();
                                nightFlightCountRow.Add(courseLevel.CourseLevelName);
                                nightFlightCountRow.Add(system.SystemName);
                                nightFlightCountRow.Add("Night Flight");
                                nightFlightCountRow.AppendList(nightFlightCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(nightFlightCountRow.ToArray());
                            }

                            if (requirements.Contains("Total in Training"))
                            {
                                IList<String> studentCountRow = new List<String>();
                                studentCountRow.Add(courseLevel.CourseLevelName);
                                studentCountRow.Add(system.SystemName);
                                studentCountRow.Add("Total in Training");
                                studentCountRow.AppendList(studentCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(studentCountRow.ToArray());
                            }

                            if (requirements.Contains("Daily Flight Hours"))
                            {
                                IList<String> flightHoursCountRow = new List<String>();
                                flightHoursCountRow.Add(courseLevel.CourseLevelName);
                                flightHoursCountRow.Add(system.SystemName);
                                flightHoursCountRow.Add("Daily Flight Hours");
                                flightHoursCountRow.AppendList(flightHoursCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(flightHoursCountRow.ToArray());
                            }

                            if (requirements.Contains("Simulator Students"))
                            {
                                IList<String> simulatorStudentCountRow = new List<String>();
                                simulatorStudentCountRow.Add(courseLevel.CourseLevelName);
                                simulatorStudentCountRow.Add(system.SystemName);
                                simulatorStudentCountRow.Add("Simulator Students");
                                simulatorStudentCountRow.AppendList(simulatorStudentCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(simulatorStudentCountRow.ToArray());
                            }

                            if (requirements.Contains("Simulator Hours"))
                            {
                                IList<String> simulatorHoursCountRow = new List<String>();
                                simulatorHoursCountRow.Add(courseLevel.CourseLevelName);
                                simulatorHoursCountRow.Add(system.SystemName);
                                simulatorHoursCountRow.Add("Simulator Hours");
                                simulatorHoursCountRow.AppendList(simulatorHoursCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(simulatorHoursCountRow.ToArray());
                            }

                            if (requirements.Contains("Aircraft for Day"))
                            {
                                IList<String> dayAircraftCountRow = new List<String>();
                                dayAircraftCountRow.Add(courseLevel.CourseLevelName);
                                dayAircraftCountRow.Add(system.SystemName);
                                dayAircraftCountRow.Add("Aircraft for Day");
                                dayAircraftCountRow.AppendList(dayAircraftCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(dayAircraftCountRow.ToArray());
                            }

                            if (requirements.Contains("Aircraft for Night"))
                            {
                                IList<String> nightAircraftCountRow = new List<String>();
                                nightAircraftCountRow.Add(courseLevel.CourseLevelName);
                                nightAircraftCountRow.Add(system.SystemName);
                                nightAircraftCountRow.Add("Aircraft for Night");
                                nightAircraftCountRow.AppendList(nightAircraftCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(nightAircraftCountRow.ToArray());
                            }

                            if (requirements.Contains("Launches for Day"))
                            {
                                IList<String> dayLaunchesCountRow = new List<String>();
                                dayLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                dayLaunchesCountRow.Add(system.SystemName);
                                dayLaunchesCountRow.Add("Launches for Day");
                                dayLaunchesCountRow.AppendList(dayLaunchCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(dayLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Launches for Night"))
                            {
                                IList<String> nightLaunchesCountRow = new List<String>();
                                nightLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                nightLaunchesCountRow.Add(system.SystemName);
                                nightLaunchesCountRow.Add("Launches for Night");
                                nightLaunchesCountRow.AppendList(nightLaunchCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(nightLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Total Launches"))
                            {
                                IList<String> totalLaunchesCountRow = new List<String>();
                                totalLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                totalLaunchesCountRow.Add(system.SystemName);
                                totalLaunchesCountRow.Add("Total Launches");
                                totalLaunchesCountRow.AppendList(totalLaunchCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(totalLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Total IPs Required"))
                            {
                                IList<String> totalInstructorsCountRow = new List<String>();
                                totalInstructorsCountRow.Add(courseLevel.CourseLevelName);
                                totalInstructorsCountRow.Add(system.SystemName);
                                totalInstructorsCountRow.Add("Total IPs Required");
                                totalInstructorsCountRow.AppendList(totalInstructorCountTotal.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(totalInstructorsCountRow.ToArray());
                            }
                        }
                    }
                }
            }

            return report;
        }

        /// <summary>
        /// Gets the daily requirements report by course based on the types, program, and carry overs
        /// </summary>
        /// <param name="program">The program for the report</param>
        /// <param name="carryOverProgram">The carry over program for the report</param>
        /// <param name="courseLevels">The list of course levels to report</param>
        /// <param name="systems">The list of systems to report</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <param name="requirements">A list of the daily requirements to calculate</param>
        /// <returns>A data table for the daily requirements report by course</returns>
        public static DataTable GetDailyRequirementsByCourseReport(Program program, Program carryOverProgram, IList<Int32> courseLevels, IList<Int32> systems, Nullable<Boolean> reimbursable, IList<String> requirements)
        {
            DataTable report = new DataTable();

            IDictionary<Nullable<Int32>, Objective> objectiveList = DataService.ListObjectiveDictionary();
            IDictionary<Nullable<Int32>, POI> poiList = DataService.ListPOIDictionary();

            report.Columns.Add("Level", typeof(String));
            report.Columns.Add("System", typeof(String));
            report.Columns.Add("Requirement", typeof(String));
            report.Columns.Add("Course Title", typeof(String));

            if (program.ProgramID.HasValue)
            {
                program = DataService.GetProgram(program);

                IList<DateTime> flyingDays = CalendarUtil.GetProgramFlyingDays(program, true, false);

                foreach (DateTime flyingDay in flyingDays)
                {
                    report.Columns.Add(flyingDay.ToString("MMM d"), typeof(String));
                }

                foreach (Int32 courseLevelId in courseLevels)
                {
                    CourseLevel courseLevel = DataService.GetCourseLevel(new CourseLevel { CourseLevelID = courseLevelId });

                    foreach (Int32 systemId in systems)
                    {
                        Domain.Entities.System system = DataService.GetSystem(new Domain.Entities.System() { SystemID = systemId });

                        Course courseSearch = new Course();
                        courseSearch.ProgramID = program.ProgramID;
                        courseSearch.SystemID = systemId;
                        courseSearch.CourseLevelID = courseLevelId;

                        IList<Course> courseList = DataService.ListCourses(courseSearch);

                        foreach (Course course in courseList)
                        {
                            Class classSearch = new Class();
                            classSearch.CourseID = course.CourseID;

                            IList<Class> classes = DataService.ListClasses(classSearch);

                            CourseType type = DataService.GetCourseType(new CourseType { CourseTypeID = course.CourseTypeID });

                            course.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(course, system, type);

                            IDictionary<DateTime, Decimal> dayFlightCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, false, false);

                            if (requirements.Contains("Day Flight"))
                            {
                                IList<String> dayFlightCountRow = new List<String>();
                                dayFlightCountRow.Add(courseLevel.CourseLevelName);
                                dayFlightCountRow.Add(system.SystemName);
                                dayFlightCountRow.Add("Day Flight");
                                dayFlightCountRow.Add(course.ExtendedProperties.DisplayName);
                                dayFlightCountRow.AppendList(dayFlightCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(dayFlightCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> nightFlightCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, true, false);

                            if (requirements.Contains("Night Flight"))
                            {
                                IList<String> nightFlightCountRow = new List<String>();
                                nightFlightCountRow.Add(courseLevel.CourseLevelName);
                                nightFlightCountRow.Add(system.SystemName);
                                nightFlightCountRow.Add("Night Flight");
                                nightFlightCountRow.Add(course.ExtendedProperties.DisplayName);
                                nightFlightCountRow.AppendList(nightFlightCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(nightFlightCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> studentCount = GetTotalStudentsByDay(flyingDays, course, classes, poiList, reimbursable);

                            if (requirements.Contains("Total in Training"))
                            {
                                IList<String> studentCountRow = new List<String>();
                                studentCountRow.Add(courseLevel.CourseLevelName);
                                studentCountRow.Add(system.SystemName);
                                studentCountRow.Add("Total in Training");
                                studentCountRow.Add(course.ExtendedProperties.DisplayName);
                                studentCountRow.AppendList(studentCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(studentCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> flightHoursCount = GetFlightHoursByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, false);

                            if (requirements.Contains("Daily Flight Hours"))
                            {
                                IList<String> flightHoursCountRow = new List<String>();
                                flightHoursCountRow.Add(courseLevel.CourseLevelName);
                                flightHoursCountRow.Add(system.SystemName);
                                flightHoursCountRow.Add("Daily Flight Hours");
                                flightHoursCountRow.Add(course.ExtendedProperties.DisplayName);
                                flightHoursCountRow.AppendList(flightHoursCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(flightHoursCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> simulatorStudentCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, false, false, true);

                            if (requirements.Contains("Simulator Students"))
                            {
                                IList<String> simulatorStudentCountRow = new List<String>();
                                simulatorStudentCountRow.Add(courseLevel.CourseLevelName);
                                simulatorStudentCountRow.Add(system.SystemName);
                                simulatorStudentCountRow.Add("Simulator Students");
                                simulatorStudentCountRow.Add(course.ExtendedProperties.DisplayName);
                                simulatorStudentCountRow.AppendList(simulatorStudentCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(simulatorStudentCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> simulatorHoursCount = GetFlightHoursByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, false, true);

                            if (requirements.Contains("Simulator Hours"))
                            {
                                IList<String> simulatorHoursCountRow = new List<String>();
                                simulatorHoursCountRow.Add(courseLevel.CourseLevelName);
                                simulatorHoursCountRow.Add(system.SystemName);
                                simulatorHoursCountRow.Add("Simulator Hours");
                                simulatorHoursCountRow.Add(course.ExtendedProperties.DisplayName);
                                simulatorHoursCountRow.AppendList(simulatorHoursCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(simulatorHoursCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> dayAircraftCount = GetDayAircraftByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable);

                            if (requirements.Contains("Aircraft for Day"))
                            {
                                IList<String> dayAircraftCountRow = new List<String>();
                                dayAircraftCountRow.Add(courseLevel.CourseLevelName);
                                dayAircraftCountRow.Add(system.SystemName);
                                dayAircraftCountRow.Add("Aircraft for Day");
                                dayAircraftCountRow.Add(course.ExtendedProperties.DisplayName);
                                dayAircraftCountRow.AppendList(dayAircraftCount.Select(x => Math.Ceiling(x.Value).ToString("F1")));

                                report.Rows.Add(dayAircraftCountRow.ToArray());
                            }

                            if (requirements.Contains("Aircraft for Night"))
                            {
                                IList<String> nightAircraftCountRow = new List<String>();
                                nightAircraftCountRow.Add(courseLevel.CourseLevelName);
                                nightAircraftCountRow.Add(system.SystemName);
                                nightAircraftCountRow.Add("Aircraft for Night");
                                nightAircraftCountRow.Add(course.ExtendedProperties.DisplayName);
                                nightAircraftCountRow.AppendList(nightFlightCount.Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                                report.Rows.Add(nightAircraftCountRow.ToArray());
                            }

                            if (requirements.Contains("Launches for Day"))
                            {
                                IList<String> dayLaunchesCountRow = new List<String>();
                                dayLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                dayLaunchesCountRow.Add(system.SystemName);
                                dayLaunchesCountRow.Add("Launches for Day");
                                dayLaunchesCountRow.Add(course.ExtendedProperties.DisplayName);
                                dayLaunchesCountRow.AppendList(dayAircraftCount.Select(x => Math.Ceiling(x.Value * 2M).ToString("F1")));

                                report.Rows.Add(dayLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Launches for Night"))
                            {
                                IList<String> nightLaunchesCountRow = new List<String>();
                                nightLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                nightLaunchesCountRow.Add(system.SystemName);
                                nightLaunchesCountRow.Add("Launches for Night");
                                nightLaunchesCountRow.Add(course.ExtendedProperties.DisplayName);
                                nightLaunchesCountRow.AppendList(nightFlightCount.Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                                report.Rows.Add(nightLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Total Launches"))
                            {
                                IList<String> totalLaunchesCountRow = new List<String>();
                                totalLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                totalLaunchesCountRow.Add(system.SystemName);
                                totalLaunchesCountRow.Add("Total Launches");
                                totalLaunchesCountRow.Add(course.ExtendedProperties.DisplayName);
                                totalLaunchesCountRow.AppendList(dayAircraftCount.Zip(nightFlightCount, (x, y) => (Math.Ceiling(x.Value * 2M) + Math.Ceiling(y.Value / 2M)).ToString("F1")));

                                report.Rows.Add(totalLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Total IPs Required"))
                            {
                                IList<String> totalInstructorsCountRow = new List<String>();
                                totalInstructorsCountRow.Add(courseLevel.CourseLevelName);
                                totalInstructorsCountRow.Add(system.SystemName);
                                totalInstructorsCountRow.Add("Total IPs Required");
                                totalInstructorsCountRow.Add(course.ExtendedProperties.DisplayName);
                                totalInstructorsCountRow.AppendList(SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayFlightCount, nightFlightCount, simulatorStudentCount }).Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                                report.Rows.Add(totalInstructorsCountRow.ToArray());
                            }
                        }
                    }
                }
            }

            if (carryOverProgram.ProgramID.HasValue)
            {
                carryOverProgram = DataService.GetProgram(carryOverProgram);

                IList<DateTime> flyingDays = CalendarUtil.GetProgramFlyingDays(carryOverProgram, true, true);

                foreach (Int32 courseLevelId in courseLevels)
                {
                    CourseLevel courseLevel = DataService.GetCourseLevel(new CourseLevel { CourseLevelID = courseLevelId });

                    foreach (Int32 systemId in systems)
                    {
                        Domain.Entities.System system = DataService.GetSystem(new Domain.Entities.System() { SystemID = systemId });

                        Course courseSearch = new Course();
                        courseSearch.ProgramID = carryOverProgram.ProgramID;
                        courseSearch.SystemID = systemId;
                        courseSearch.CourseLevelID = courseLevelId;

                        IList<Course> courseList = DataService.ListCourses(courseSearch);

                        foreach (Course course in courseList)
                        {
                            Class classSearch = new Class();
                            classSearch.CourseID = course.CourseID;

                            IList<Class> classes = DataService.ListClasses(classSearch);

                            CourseType type = DataService.GetCourseType(new CourseType { CourseTypeID = course.CourseTypeID });

                            course.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(course, system, type);

                            IDictionary<DateTime, Decimal> dayFlightCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, false, false);

                            if (requirements.Contains("Day Flight"))
                            {
                                IList<String> dayFlightCountRow = new List<String>();
                                dayFlightCountRow.Add(courseLevel.CourseLevelName);
                                dayFlightCountRow.Add(system.SystemName);
                                dayFlightCountRow.Add("Day Flight");
                                dayFlightCountRow.Add(course.ExtendedProperties.DisplayName);
                                dayFlightCountRow.AppendList(dayFlightCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(dayFlightCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> nightFlightCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, true, false);

                            if (requirements.Contains("Night Flight"))
                            {
                                IList<String> nightFlightCountRow = new List<String>();
                                nightFlightCountRow.Add(courseLevel.CourseLevelName);
                                nightFlightCountRow.Add(system.SystemName);
                                nightFlightCountRow.Add("Night Flight");
                                nightFlightCountRow.Add(course.ExtendedProperties.DisplayName);
                                nightFlightCountRow.AppendList(nightFlightCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(nightFlightCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> studentCount = GetTotalStudentsByDay(flyingDays, course, classes, poiList, reimbursable);

                            if (requirements.Contains("Total in Training"))
                            {
                                IList<String> studentCountRow = new List<String>();
                                studentCountRow.Add(courseLevel.CourseLevelName);
                                studentCountRow.Add(system.SystemName);
                                studentCountRow.Add("Total in Training");
                                studentCountRow.Add(course.ExtendedProperties.DisplayName);
                                studentCountRow.AppendList(studentCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(studentCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> flightHoursCount = GetFlightHoursByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, false);

                            if (requirements.Contains("Daily Flight Hours"))
                            {
                                IList<String> flightHoursCountRow = new List<String>();
                                flightHoursCountRow.Add(courseLevel.CourseLevelName);
                                flightHoursCountRow.Add(system.SystemName);
                                flightHoursCountRow.Add("Daily Flight Hours");
                                flightHoursCountRow.Add(course.ExtendedProperties.DisplayName);
                                flightHoursCountRow.AppendList(flightHoursCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(flightHoursCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> simulatorStudentCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, false, false, true);

                            if (requirements.Contains("Simulator Students"))
                            {
                                IList<String> simulatorStudentCountRow = new List<String>();
                                simulatorStudentCountRow.Add(courseLevel.CourseLevelName);
                                simulatorStudentCountRow.Add(system.SystemName);
                                simulatorStudentCountRow.Add("Simulator Students");
                                simulatorStudentCountRow.Add(course.ExtendedProperties.DisplayName);
                                simulatorStudentCountRow.AppendList(simulatorStudentCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(simulatorStudentCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> simulatorHoursCount = GetFlightHoursByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, false, true);

                            if (requirements.Contains("Simulator Hours"))
                            {
                                IList<String> simulatorHoursCountRow = new List<String>();
                                simulatorHoursCountRow.Add(courseLevel.CourseLevelName);
                                simulatorHoursCountRow.Add(system.SystemName);
                                simulatorHoursCountRow.Add("Simulator Hours");
                                simulatorHoursCountRow.Add(course.ExtendedProperties.DisplayName);
                                simulatorHoursCountRow.AppendList(simulatorHoursCount.Select(x => x.Value.ToString("F1")));

                                report.Rows.Add(simulatorHoursCountRow.ToArray());
                            }

                            IDictionary<DateTime, Decimal> dayAircraftCount = GetDayAircraftByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable);

                            if (requirements.Contains("Aircraft for Day"))
                            {
                                IList<String> dayAircraftCountRow = new List<String>();
                                dayAircraftCountRow.Add(courseLevel.CourseLevelName);
                                dayAircraftCountRow.Add(system.SystemName);
                                dayAircraftCountRow.Add("Aircraft for Day");
                                dayAircraftCountRow.Add(course.ExtendedProperties.DisplayName);
                                dayAircraftCountRow.AppendList(dayAircraftCount.Select(x => Math.Ceiling(x.Value).ToString("F1")));

                                report.Rows.Add(dayAircraftCountRow.ToArray());
                            }

                            if (requirements.Contains("Aircraft for Night"))
                            {
                                IList<String> nightAircraftCountRow = new List<String>();
                                nightAircraftCountRow.Add(courseLevel.CourseLevelName);
                                nightAircraftCountRow.Add(system.SystemName);
                                nightAircraftCountRow.Add("Aircraft for Night");
                                nightAircraftCountRow.Add(course.ExtendedProperties.DisplayName);
                                nightAircraftCountRow.AppendList(nightFlightCount.Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                                report.Rows.Add(nightAircraftCountRow.ToArray());
                            }

                            if (requirements.Contains("Launches for Day"))
                            {
                                IList<String> dayLaunchesCountRow = new List<String>();
                                dayLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                dayLaunchesCountRow.Add(system.SystemName);
                                dayLaunchesCountRow.Add("Launches for Day");
                                dayLaunchesCountRow.Add(course.ExtendedProperties.DisplayName);
                                dayLaunchesCountRow.AppendList(dayAircraftCount.Select(x => Math.Ceiling(x.Value * 2M).ToString("F1")));

                                report.Rows.Add(dayLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Launches for Night"))
                            {
                                IList<String> nightLaunchesCountRow = new List<String>();
                                nightLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                nightLaunchesCountRow.Add(system.SystemName);
                                nightLaunchesCountRow.Add("Launches for Night");
                                nightLaunchesCountRow.Add(course.ExtendedProperties.DisplayName);
                                nightLaunchesCountRow.AppendList(nightFlightCount.Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                                report.Rows.Add(nightLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Total Launches"))
                            {
                                IList<String> totalLaunchesCountRow = new List<String>();
                                totalLaunchesCountRow.Add(courseLevel.CourseLevelName);
                                totalLaunchesCountRow.Add(system.SystemName);
                                totalLaunchesCountRow.Add("Total Launches");
                                totalLaunchesCountRow.Add(course.ExtendedProperties.DisplayName);
                                totalLaunchesCountRow.AppendList(dayAircraftCount.Zip(nightFlightCount, (x, y) => (Math.Ceiling(x.Value * 2M) + Math.Ceiling(y.Value / 2M)).ToString("F1")));

                                report.Rows.Add(totalLaunchesCountRow.ToArray());
                            }

                            if (requirements.Contains("Total IPs Required"))
                            {
                                IList<String> totalInstructorsCountRow = new List<String>();
                                totalInstructorsCountRow.Add(courseLevel.CourseLevelName);
                                totalInstructorsCountRow.Add(system.SystemName);
                                totalInstructorsCountRow.Add("Total IPs Required");
                                totalInstructorsCountRow.Add(course.ExtendedProperties.DisplayName);
                                totalInstructorsCountRow.AppendList(SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayFlightCount, nightFlightCount, simulatorStudentCount }).Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                                report.Rows.Add(totalInstructorsCountRow.ToArray());
                            }
                        }
                    }
                }
            }

            return report;
        }

        /// <summary>
        /// Gets the daily requirements report by course based on the types, course, and carry overs
        /// </summary>
        /// <param name="course">The course for the report</param>
        /// <param name="carryOverCourse">The carry over course for the report</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <param name="requirements">A list of the daily requirements to calculate</param>
        /// <returns>A data table for the daily requirements report by course</returns>
        public static DataTable GetDailyRequirementsByCourseReport(Course course, Course carryOverCourse, Nullable<Boolean> reimbursable, IList<String> requirements)
        {
            DataTable report = new DataTable();

            IDictionary<Nullable<Int32>, Objective> objectiveList = DataService.ListObjectiveDictionary();
            IDictionary<Nullable<Int32>, POI> poiList = DataService.ListPOIDictionary();

            report.Columns.Add("Level", typeof(String));
            report.Columns.Add("System", typeof(String));
            report.Columns.Add("Requirement", typeof(String));
            report.Columns.Add("Course Title", typeof(String));

            if (course.CourseID.HasValue)
            {
                course = DataService.LoadCourse(course);

                Program program = new Program();
                program.ProgramID = course.ProgramID;

                program = DataService.GetProgram(program);

                CourseLevel courseLevel = DataService.GetCourseLevel(new CourseLevel() { CourseLevelID = course.CourseLevelID });
                Domain.Entities.System system = DataService.GetSystem(new Domain.Entities.System() { SystemID = course.SystemID });
                CourseType type = DataService.GetCourseType(new CourseType() { CourseTypeID = course.CourseTypeID });

                course.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(course, system, type);

                IList<DateTime> flyingDays = CalendarUtil.GetProgramFlyingDays(program, true, false);

                foreach (DateTime flyingDay in flyingDays)
                {
                    report.Columns.Add(flyingDay.ToString("MMM d"), typeof(String));
                }

                Class classSearch = new Class();
                classSearch.CourseID = course.CourseID;

                IList<Class> classes = DataService.ListClasses(classSearch);

                IDictionary<DateTime, Decimal> dayFlightCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, false, false);

                if (requirements.Contains("Day Flight"))
                {
                    IList<String> dayFlightCountRow = new List<String>();
                    dayFlightCountRow.Add(courseLevel.CourseLevelName);
                    dayFlightCountRow.Add(system.SystemName);
                    dayFlightCountRow.Add("Day Flight");
                    dayFlightCountRow.Add(course.ExtendedProperties.DisplayName);
                    dayFlightCountRow.AppendList(dayFlightCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(dayFlightCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> nightFlightCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, true, false);

                if (requirements.Contains("Night Flight"))
                {
                    IList<String> nightFlightCountRow = new List<String>();
                    nightFlightCountRow.Add(courseLevel.CourseLevelName);
                    nightFlightCountRow.Add(system.SystemName);
                    nightFlightCountRow.Add("Night Flight");
                    nightFlightCountRow.Add(course.ExtendedProperties.DisplayName);
                    nightFlightCountRow.AppendList(nightFlightCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(nightFlightCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> studentCount = GetTotalStudentsByDay(flyingDays, course, classes, poiList, reimbursable);

                if (requirements.Contains("Total in Training"))
                {
                    IList<String> studentCountRow = new List<String>();
                    studentCountRow.Add(courseLevel.CourseLevelName);
                    studentCountRow.Add(system.SystemName);
                    studentCountRow.Add("Total in Training");
                    studentCountRow.Add(course.ExtendedProperties.DisplayName);
                    studentCountRow.AppendList(studentCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(studentCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> flightHoursCount = GetFlightHoursByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, true, false);

                if (requirements.Contains("Daily Flight Hours"))
                {
                    IList<String> flightHoursCountRow = new List<String>();
                    flightHoursCountRow.Add(courseLevel.CourseLevelName);
                    flightHoursCountRow.Add(system.SystemName);
                    flightHoursCountRow.Add("Daily Flight Hours");
                    flightHoursCountRow.Add(course.ExtendedProperties.DisplayName);
                    flightHoursCountRow.AppendList(flightHoursCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(flightHoursCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> simulatorStudentCount = GetFlightStudentsByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, false, false, true);

                if (requirements.Contains("Simulator Students"))
                {
                    IList<String> simulatorStudentCountRow = new List<String>();
                    simulatorStudentCountRow.Add(courseLevel.CourseLevelName);
                    simulatorStudentCountRow.Add(system.SystemName);
                    simulatorStudentCountRow.Add("Simulator Students");
                    simulatorStudentCountRow.Add(course.ExtendedProperties.DisplayName);
                    simulatorStudentCountRow.AppendList(simulatorStudentCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(simulatorStudentCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> simulatorHoursCount = GetFlightHoursByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable, false, true);

                if (requirements.Contains("Simulator Hours"))
                {
                    IList<String> simulatorHoursCountRow = new List<String>();
                    simulatorHoursCountRow.Add(courseLevel.CourseLevelName);
                    simulatorHoursCountRow.Add(system.SystemName);
                    simulatorHoursCountRow.Add("Simulator Hours");
                    simulatorHoursCountRow.Add(course.ExtendedProperties.DisplayName);
                    simulatorHoursCountRow.AppendList(simulatorHoursCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(simulatorHoursCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> dayAircraftCount = GetDayAircraftByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable);

                if (requirements.Contains("Aircraft for Day"))
                {
                    IList<String> dayAircraftCountRow = new List<String>();
                    dayAircraftCountRow.Add(courseLevel.CourseLevelName);
                    dayAircraftCountRow.Add(system.SystemName);
                    dayAircraftCountRow.Add("Aircraft for Day");
                    dayAircraftCountRow.Add(course.ExtendedProperties.DisplayName);
                    dayAircraftCountRow.AppendList(dayAircraftCount.Select(x => Math.Ceiling(x.Value).ToString("F1")));

                    report.Rows.Add(dayAircraftCountRow.ToArray());
                }

                if (requirements.Contains("Aircraft for Night"))
                {
                    IList<String> nightAircraftCountRow = new List<String>();
                    nightAircraftCountRow.Add(courseLevel.CourseLevelName);
                    nightAircraftCountRow.Add(system.SystemName);
                    nightAircraftCountRow.Add("Aircraft for Night");
                    nightAircraftCountRow.Add(course.ExtendedProperties.DisplayName);
                    nightAircraftCountRow.AppendList(nightFlightCount.Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                    report.Rows.Add(nightAircraftCountRow.ToArray());
                }

                if (requirements.Contains("Launches for Day"))
                {
                    IList<String> dayLaunchesCountRow = new List<String>();
                    dayLaunchesCountRow.Add(courseLevel.CourseLevelName);
                    dayLaunchesCountRow.Add(system.SystemName);
                    dayLaunchesCountRow.Add("Launches for Day");
                    dayLaunchesCountRow.Add(course.ExtendedProperties.DisplayName);
                    dayLaunchesCountRow.AppendList(dayAircraftCount.Select(x => (Math.Ceiling(x.Value) * 2M).ToString("F1")));

                    report.Rows.Add(dayLaunchesCountRow.ToArray());
                }

                if (requirements.Contains("Launches for Night"))
                {
                    IList<String> nightLaunchesCountRow = new List<String>();
                    nightLaunchesCountRow.Add(courseLevel.CourseLevelName);
                    nightLaunchesCountRow.Add(system.SystemName);
                    nightLaunchesCountRow.Add("Launches for Night");
                    nightLaunchesCountRow.Add(course.ExtendedProperties.DisplayName);
                    nightLaunchesCountRow.AppendList(nightFlightCount.Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                    report.Rows.Add(nightLaunchesCountRow.ToArray());
                }

                if (requirements.Contains("Total Launches"))
                {
                    IList<String> totalLaunchesCountRow = new List<String>();
                    totalLaunchesCountRow.Add(courseLevel.CourseLevelName);
                    totalLaunchesCountRow.Add(system.SystemName);
                    totalLaunchesCountRow.Add("Total Launches");
                    totalLaunchesCountRow.Add(course.ExtendedProperties.DisplayName);
                    totalLaunchesCountRow.AppendList(dayAircraftCount.Zip(nightFlightCount, (x, y) => (Math.Ceiling(x.Value) * 2M + Math.Ceiling(y.Value / 2M)).ToString("F1")));

                    report.Rows.Add(totalLaunchesCountRow.ToArray());
                }

                if (requirements.Contains("Total IPs Required"))
                {
                    IList<String> totalInstructorsCountRow = new List<String>();
                    totalInstructorsCountRow.Add(courseLevel.CourseLevelName);
                    totalInstructorsCountRow.Add(system.SystemName);
                    totalInstructorsCountRow.Add("Total IPs Required");
                    totalInstructorsCountRow.Add(course.ExtendedProperties.DisplayName);
                    totalInstructorsCountRow.AppendList(SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayFlightCount, nightFlightCount, simulatorStudentCount }).Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                    report.Rows.Add(totalInstructorsCountRow.ToArray());
                }
            }

            if (carryOverCourse.CourseID.HasValue)
            {
                carryOverCourse = DataService.LoadCourse(carryOverCourse);

                Program program = new Program();
                program.ProgramID = carryOverCourse.ProgramID;

                program = DataService.GetProgram(program);

                CourseLevel courseLevel = DataService.GetCourseLevel(new CourseLevel() { CourseLevelID = carryOverCourse.CourseLevelID });
                Domain.Entities.System system = DataService.GetSystem(new Domain.Entities.System() { SystemID = carryOverCourse.SystemID });
                CourseType type = DataService.GetCourseType(new CourseType() { CourseTypeID = carryOverCourse.CourseTypeID });

                carryOverCourse.ExtendedProperties.DisplayName = CourseUtil.GetCourseDisplayValue(carryOverCourse, system, type);

                IList<DateTime> flyingDays = CalendarUtil.GetProgramFlyingDays(program, true, true);

                Class classSearch = new Class();
                classSearch.CourseID = carryOverCourse.CourseID;

                IList<Class> classes = DataService.ListClasses(classSearch);

                IDictionary<DateTime, Decimal> dayFlightCount = GetFlightStudentsByDay(flyingDays, carryOverCourse, classes, poiList, objectiveList, reimbursable, true, false, false);

                if (requirements.Contains("Day Flight"))
                {
                    IList<String> dayFlightCountRow = new List<String>();
                    dayFlightCountRow.Add(courseLevel.CourseLevelName);
                    dayFlightCountRow.Add(system.SystemName);
                    dayFlightCountRow.Add("Day Flight");
                    dayFlightCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    dayFlightCountRow.AppendList(dayFlightCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(dayFlightCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> nightFlightCount = GetFlightStudentsByDay(flyingDays, carryOverCourse, classes, poiList, objectiveList, reimbursable, true, true, false);

                if (requirements.Contains("Night Flight"))
                {
                    IList<String> nightFlightCountRow = new List<String>();
                    nightFlightCountRow.Add(courseLevel.CourseLevelName);
                    nightFlightCountRow.Add(system.SystemName);
                    nightFlightCountRow.Add("Night Flight");
                    nightFlightCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    nightFlightCountRow.AppendList(nightFlightCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(nightFlightCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> studentCount = GetTotalStudentsByDay(flyingDays, carryOverCourse, classes, poiList, reimbursable);

                if (requirements.Contains("Total in Training"))
                {
                    IList<String> studentCountRow = new List<String>();
                    studentCountRow.Add(courseLevel.CourseLevelName);
                    studentCountRow.Add(system.SystemName);
                    studentCountRow.Add("Total in Training");
                    studentCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    studentCountRow.AppendList(studentCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(studentCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> flightHoursCount = GetFlightHoursByDay(flyingDays, carryOverCourse, classes, poiList, objectiveList, reimbursable, true, false);

                if (requirements.Contains("Daily Flight Hours"))
                {
                    IList<String> flightHoursCountRow = new List<String>();
                    flightHoursCountRow.Add(courseLevel.CourseLevelName);
                    flightHoursCountRow.Add(system.SystemName);
                    flightHoursCountRow.Add("Daily Flight Hours");
                    flightHoursCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    flightHoursCountRow.AppendList(flightHoursCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(flightHoursCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> simulatorStudentCount = GetFlightStudentsByDay(flyingDays, carryOverCourse, classes, poiList, objectiveList, reimbursable, false, false, true);

                if (requirements.Contains("Simulator Students"))
                {
                    IList<String> simulatorStudentCountRow = new List<String>();
                    simulatorStudentCountRow.Add(courseLevel.CourseLevelName);
                    simulatorStudentCountRow.Add(system.SystemName);
                    simulatorStudentCountRow.Add("Simulator Students");
                    simulatorStudentCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    simulatorStudentCountRow.AppendList(simulatorStudentCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(simulatorStudentCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> simulatorHoursCount = GetFlightHoursByDay(flyingDays, carryOverCourse, classes, poiList, objectiveList, reimbursable, false, true);

                if (requirements.Contains("Simulator Hours"))
                {
                    IList<String> simulatorHoursCountRow = new List<String>();
                    simulatorHoursCountRow.Add(courseLevel.CourseLevelName);
                    simulatorHoursCountRow.Add(system.SystemName);
                    simulatorHoursCountRow.Add("Simulator Hours");
                    simulatorHoursCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    simulatorHoursCountRow.AppendList(simulatorHoursCount.Select(x => x.Value.ToString("F1")));

                    report.Rows.Add(simulatorHoursCountRow.ToArray());
                }

                IDictionary<DateTime, Decimal> dayAircraftCount = GetDayAircraftByDay(flyingDays, course, classes, poiList, objectiveList, reimbursable);

                if (requirements.Contains("Aircraft for Day"))
                {
                    IList<String> dayAircraftCountRow = new List<String>();
                    dayAircraftCountRow.Add(courseLevel.CourseLevelName);
                    dayAircraftCountRow.Add(system.SystemName);
                    dayAircraftCountRow.Add("Aircraft for Day");
                    dayAircraftCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    dayAircraftCountRow.AppendList(dayAircraftCount.Select(x => Math.Ceiling(x.Value).ToString("F1")));

                    report.Rows.Add(dayAircraftCountRow.ToArray());
                }

                if (requirements.Contains("Aircraft for Night"))
                {
                    IList<String> nightAircraftCountRow = new List<String>();
                    nightAircraftCountRow.Add(courseLevel.CourseLevelName);
                    nightAircraftCountRow.Add(system.SystemName);
                    nightAircraftCountRow.Add("Aircraft for Night");
                    nightAircraftCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    nightAircraftCountRow.AppendList(nightFlightCount.Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                    report.Rows.Add(nightAircraftCountRow.ToArray());
                }

                if (requirements.Contains("Launches for Day"))
                {
                    IList<String> dayLaunchesCountRow = new List<String>();
                    dayLaunchesCountRow.Add(courseLevel.CourseLevelName);
                    dayLaunchesCountRow.Add(system.SystemName);
                    dayLaunchesCountRow.Add("Launches for Day");
                    dayLaunchesCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    dayLaunchesCountRow.AppendList(dayAircraftCount.Select(x => (Math.Ceiling(x.Value) * 2M).ToString("F1")));

                    report.Rows.Add(dayLaunchesCountRow.ToArray());
                }

                if (requirements.Contains("Launches for Night"))
                {
                    IList<String> nightLaunchesCountRow = new List<String>();
                    nightLaunchesCountRow.Add(courseLevel.CourseLevelName);
                    nightLaunchesCountRow.Add(system.SystemName);
                    nightLaunchesCountRow.Add("Launches for Night");
                    nightLaunchesCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    nightLaunchesCountRow.AppendList(nightFlightCount.Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                    report.Rows.Add(nightLaunchesCountRow.ToArray());
                }

                if (requirements.Contains("Total Launches"))
                {
                    IList<String> totalLaunchesCountRow = new List<String>();
                    totalLaunchesCountRow.Add(courseLevel.CourseLevelName);
                    totalLaunchesCountRow.Add(system.SystemName);
                    totalLaunchesCountRow.Add("Total Launches");
                    totalLaunchesCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    totalLaunchesCountRow.AppendList(dayAircraftCount.Zip(nightFlightCount, (x, y) => (Math.Ceiling(x.Value) * 2M + Math.Ceiling(y.Value / 2M)).ToString("F1")));

                    report.Rows.Add(totalLaunchesCountRow.ToArray());
                }

                if (requirements.Contains("Total IPs Required"))
                {
                    IList<String> totalInstructorsCountRow = new List<String>();
                    totalInstructorsCountRow.Add(courseLevel.CourseLevelName);
                    totalInstructorsCountRow.Add(system.SystemName);
                    totalInstructorsCountRow.Add("Total IPs Required");
                    totalInstructorsCountRow.Add(carryOverCourse.ExtendedProperties.DisplayName);
                    totalInstructorsCountRow.AppendList(SumHours(flyingDays, new IDictionary<DateTime, Decimal>[] { dayFlightCount, nightFlightCount, simulatorStudentCount }).Select(x => Math.Ceiling(x.Value / 2M).ToString("F1")));

                    report.Rows.Add(totalInstructorsCountRow.ToArray());
                }
            }

            return report;
        }

        /// <summary>
        /// Gets the monthly forecast data based on the program, carry over, course level, system, and inclusions
        /// </summary>
        /// <param name="program">The program to get data for</param>
        /// <param name="carryOverProgram">The carry over program to get data for</param>
        /// <param name="level">The course level to get data for</param>
        /// <param name="system">The system to get data for</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <param name="includeBASOPS">True if BASOPS hours should be includes, False if not</param>
        /// <param name="includeAddins">True if Addins hours should be includes, False if not</param>
        /// <returns>A dictionary by month of the monthly forecast for the specified system and course level</returns>
        private static IDictionary<Int32, Decimal> GetMonthlyForecastBySystem(Program program, Program carryOverProgram, CourseLevel level, USAACE.ATI.Domain.Entities.System system, Nullable<Boolean> reimbursable, Boolean includeBASOPS, Boolean includeAddins)
        {
            IDictionary<Int32, Decimal> forecast = CreateMonthlyDictionary();

            Course courseSearch = new Course();
            courseSearch.ProgramID = program.ProgramID;
            courseSearch.CourseLevelID = level.CourseLevelID;
            courseSearch.SystemID = system.SystemID;

            IList<Course> courses = DataService.ListCourses(courseSearch);

            foreach (Course course in courses)
            {
                IList<Decimal> percents = GetHistoricalPercentsList(course);

                IDictionary<Int32, Decimal> courseForecast = GetMonthlyForecastByCourse(course, reimbursable, false, percents);

                for (int i = 1; i <= 12; i++)
                {
                    forecast[i] += courseForecast[i];
                }
            }

            if (carryOverProgram.ProgramID.HasValue)
            {
                Course carryOverCourseSearch = new Course();
                carryOverCourseSearch.ProgramID = carryOverProgram.ProgramID;
                carryOverCourseSearch.CourseLevelID = level.CourseLevelID;
                carryOverCourseSearch.SystemID = system.SystemID;

                IList<Course> carryOverCourses = DataService.ListCourses(carryOverCourseSearch);

                foreach (Course course in carryOverCourses)
                {
                    Course mainCourseSearch = new Course();
                    mainCourseSearch.ProgramID = program.ProgramID;
                    mainCourseSearch.CourseNumberID = course.CourseNumberID;

                    IList<Course> mainCourses = DataService.ListCourses(mainCourseSearch);

                    IList<Decimal> percents = mainCourses.Count > 0 ? GetHistoricalPercentsList(mainCourses[0]) : GetHistoricalPercentsList(course);

                    IDictionary<Int32, Decimal> courseForecast = GetMonthlyForecastByCourse(course, reimbursable, true, percents);

                    for (int i = 1; i <= 12; i++)
                    {
                        forecast[i] += courseForecast[i];
                    }
                }
            }

            if (includeBASOPS || includeAddins)
            {
                ActualHours hours = new ActualHours();
                hours.ProgramID = program.ProgramID;
                hours.Reimbursable = reimbursable;
                hours.Forecast = true;
                hours.CourseLevelID = level.CourseLevelID;
                hours.SystemID = system.SystemID;

                if (includeBASOPS)
                {
                    hours.SearchProperties.HoursTypeIDIsIn.Add(HoursTypeConstants.BASOPS);
                }

                if (includeAddins)
                {
                    hours.SearchProperties.HoursTypeIDIsIn.Add(HoursTypeConstants.ADDINS);
                }

                IList<ActualHours> programHours = DataService.ListActualHours(hours);

                foreach (ActualHours hour in programHours)
                {
                    Int32 month = CalendarUtil.Get1352Month(hour.CutoffDate.Value);

                    forecast[month] += hour.HoursAmount.GetValueOrDefault(0);
                }
            }

            return forecast;
        }

        /// <summary>
        /// Gets the monthly forecast data based on the course and carry over status
        /// </summary>
        /// <param name="course">The course to get data for</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <param name="carryOver">Whether carry over data is to be calculated</param>
        /// <param name="percents">The list of historical percents</param>
        /// <returns>A dictionary by month of the monthly forecast for the specified course</returns>
        private static IDictionary<Int32, Decimal> GetMonthlyForecastByCourse(Course course, Nullable<Boolean> reimbursable, Boolean carryOver, IList<Decimal> percents)
        {
            IDictionary<Int32, Decimal> forecast = CreateMonthlyDictionary();

            Program program = new Program();
            program.ProgramID = course.ProgramID;

            program = DataService.GetProgram(program);

            IDictionary<Nullable<Int32>, POI> poiDictionary = DataService.ListPOIDictionary();

            Int16 fiscalYear = carryOver ? (Int16)(program.FiscalYear.Value + 1) : program.FiscalYear.Value;

            Class classSearch = new Class();
            classSearch.CourseID = course.CourseID;

            IList<Class> classes = DataService.ListClasses(classSearch);

            IDictionary<Nullable<Int32>, Objective> objectives = DataService.ListObjectiveDictionary();

            foreach (Class classItem in classes)
            {
                POI poi = poiDictionary[classItem.POIID];

                POIFlightDay flightDay = new POIFlightDay();
                flightDay.POIID = poi.POIID;

                IList<POIFlightDay> flightDays = DataService.ListPOIFlightDays(flightDay);

                IDictionary<DateTime, IList<POIFlightDay>> requirements = ClassUtil.GetDailyRequirements(classItem, course, poi, flightDays);

                foreach (KeyValuePair<DateTime, IList<POIFlightDay>> requirement in requirements)
                {
                    if (CalendarUtil.IsInProgramFlightYear(requirement.Key, fiscalYear))
                    {
                        foreach (POIFlightDay day in requirement.Value)
                        {
                            Int32 month = CalendarUtil.Get1352Month(requirement.Key);

                            if (objectives[day.ObjectiveID].FlightHours == true)
                            {
                                Decimal factor = ((day.Units.GetValueOrDefault(0) * (percents[month - 1] / 100)) * (1 + percents[12] / 100 + percents[13] / 100)) * (1 + percents[14] / 100);

                                if (reimbursable == false || reimbursable == null)
                                {
                                    Int16 studentCount = ClassUtil.GetStudentCount(classItem, false);
                                    forecast[month] += Math.Round(studentCount * factor, ROUND_DIGITS);
                                }

                                if (reimbursable == true || reimbursable == null)
                                {
                                    Int16 studentCount = ClassUtil.GetStudentCount(classItem, true);
                                    forecast[month] += Math.Round(studentCount * factor, ROUND_DIGITS);
                                }
                            }
                        }
                    }
                }
            }

            return forecast;
        }

        /// <summary>
        /// Gets a list of the historical percents for a course, or gets the default if values are null
        /// </summary>
        /// <param name="course">The course to get the historical percents for</param>
        /// <returns>The historical percents for the course, or the defaults if empty</returns>
        private static IList<Decimal> GetHistoricalPercentsList(Course course)
        {
            HistoricalPercent percent = new HistoricalPercent();
            percent.CourseID = course.CourseID;

            percent = DataService.LoadHistoricalPercent(percent);

            return new List<Decimal> { percent.January.GetValueOrDefault(100), percent.February.GetValueOrDefault(100), percent.March.GetValueOrDefault(100),
                percent.April.GetValueOrDefault(100), percent.May.GetValueOrDefault(100), percent.June.GetValueOrDefault(100), percent.July.GetValueOrDefault(100),
                percent.August.GetValueOrDefault(100), percent.September.GetValueOrDefault(100), percent.October.GetValueOrDefault(100), percent.November.GetValueOrDefault(100),
                percent.December.GetValueOrDefault(100), percent.Support.GetValueOrDefault(0), percent.Setback.GetValueOrDefault(0), percent.Test.GetValueOrDefault(0) };
        }

        /// <summary>
        /// Gets the monthly actual data based on the program, course level, system, and inclusions
        /// </summary>
        /// <param name="program">The program to get data for</param>
        /// <param name="level">The course level to get data for</param>
        /// <param name="system">The system to get data for</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <param name="includeBASOPS">True if BASOPS hours should be includes, False if not</param>
        /// <param name="includeSupport">True if Support hours should be includes, False if not</param>
        /// <returns>A dictionary by month of the monthly actual for the specified system and course level</returns>
        private static IDictionary<Int32, Decimal> GetMonthlyActualBySystem(Program program, CourseLevel level, Domain.Entities.System system, Nullable<Boolean> reimbursable, Boolean includeBASOPS, Boolean includeSupport)
        {
            ActualHours hours = new ActualHours();
            hours.ProgramID = program.ProgramID;
            hours.Reimbursable = reimbursable;

            IList<ActualHours> programHours = DataService.ListActualHours(hours);

            IList<ActualHours> filterHours = new List<ActualHours>();

            Course courseSearch = new Course();
            courseSearch.ProgramID = program.ProgramID;
            courseSearch.CourseLevelID = level.CourseLevelID;
            courseSearch.SystemID = system.SystemID;

            IList<Course> courses = DataService.ListCourses(courseSearch);

            foreach (Course course in courses)
            {
                filterHours.AppendList(programHours.Where(x => x.CourseID == course.CourseID));
            }

            if (includeBASOPS)
            {
                filterHours.AppendList(programHours.Where(x => x.Forecast == false && x.HoursTypeID == 3 && (level == null || level.CourseLevelID == x.CourseLevelID) && (system == null || system.SystemID == x.SystemID)));
            }

            if (includeSupport)
            {
                filterHours.AppendList(programHours.Where(x => x.Forecast == false && x.HoursTypeID == 2 && (level == null || level.CourseLevelID == x.CourseLevelID) && (system == null || system.SystemID == x.SystemID)));
            }

            IDictionary<Int32, Decimal> actuals = CreateMonthlyDictionary();

            foreach (ActualHours hour in filterHours)
            {
                Int32 month = CalendarUtil.Get1352Month(hour.CutoffDate.Value);

                actuals[month] += hour.HoursAmount.GetValueOrDefault(0);
            }

            return actuals;
        }

        /// <summary>
        /// Gets the monthly actual data based on the course
        /// </summary>
        /// <param name="course">The course to get data for</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <returns>A dictionary by month of the monthly actual for the specified course</returns>
        private static IDictionary<Int32, Decimal> GetMonthlyActualByCourse(Course course, Nullable<Boolean> reimbursable)
        {
            ActualHours hours = new ActualHours();
            hours.CourseID = course.CourseID;
            hours.Reimbursable = reimbursable;

            IList<ActualHours> courseHours = DataService.ListActualHours(hours);

            IDictionary<Int32, Decimal> actuals = CreateMonthlyDictionary();

            foreach (ActualHours hour in courseHours)
            {
                Int32 month = CalendarUtil.Get1352Month(hour.CutoffDate.Value);

                actuals[month] += hour.HoursAmount.GetValueOrDefault(0);
            }

            return actuals;
        }

        /// <summary>
        /// Gets the monthly non-POI data based on the program, course level, system, and hours types
        /// </summary>
        /// <param name="program">The program to get data for</param>
        /// <param name="hoursType">The hours type to retrieve</param>
        /// <param name="level">The course level to get data for</param>
        /// <param name="system">The system to get data for</param>
        /// <param name="miscHoursType">The type of Misc Hours</param>
        /// <param name="forecast">True for forecast, False for actuals</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <returns>A dictionary by month of the monthly non-POI for the specified course level, system, and hours types</returns>
        private static IDictionary<Int32, Decimal> GetNonPOIHours(Program program, Int32 hoursType, CourseLevel level, USAACE.ATI.Domain.Entities.System system, MiscHours miscHoursType, Boolean forecast, Nullable<Boolean> reimbursable)
        {
            ActualHours hours = new ActualHours();
            hours.ProgramID = program.ProgramID;
            hours.HoursTypeID = hoursType;
            hours.CourseLevelID = level.CourseLevelID;
            hours.SystemID = system.SystemID;
            hours.MiscHoursID = miscHoursType != null ? miscHoursType.MiscHoursID : null;
            hours.Reimbursable = reimbursable;
            hours.Forecast = forecast;

            IList<ActualHours> courseHours = DataService.ListActualHours(hours);

            IDictionary<Int32, Decimal> monthlyValues = CreateMonthlyDictionary();

            foreach (ActualHours hour in courseHours)
            {
                if (!hour.CourseID.HasValue)
                {
                    Int32 month = CalendarUtil.Get1352Month(hour.CutoffDate.Value);

                    monthlyValues[month] += hour.HoursAmount.GetValueOrDefault(0);
                }
            }

            return monthlyValues;
        }

        /// <summary>
        /// Gets the total students by day based on a course, a list of classes, reimbursable status
        /// </summary>
        /// <param name="flyingDays">The list of flying days</param>
        /// <param name="course">The course for the classes</param>
        /// <param name="classes">The list of classes</param>
        /// <param name="pois">A dictionary of POIs indexed by POIID, for optimization only</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <returns>A dictionary by day of the total students for each day</returns>
        private static IDictionary<DateTime, Decimal> GetTotalStudentsByDay(IList<DateTime> flyingDays, Course course, IList<Class> classes, IDictionary<Nullable<Int32>, POI> pois, Nullable<Boolean> reimbursable)
        {
            IDictionary<DateTime, Decimal> studentDailyCount = CreateDailyReportDictionary(flyingDays);

            foreach (Class classItem in classes)
            {
                POI poi = pois[classItem.POIID];

                Int16 studentCount = ClassUtil.GetStudentCount(classItem, reimbursable);

                DateTime classDate = ClassUtil.GetNextDate(classItem.ReportDate.Value, classItem.Interval.Value, course.ReportNoFlyDay == true, poi.Mobilization == true);

                for (int i = 1; i <= poi.Days.Value; i++)
                {
                    if (studentDailyCount.ContainsKey(classDate))
                    {
                        studentDailyCount[classDate] += studentCount;
                    }

                    classDate = ClassUtil.GetNextClassDate(classDate, poi.Mobilization == true);
                }
            }

            return studentDailyCount;
        }

        /// <summary>
        /// Gets the flight students by day based on a course, a list of classes, reimbursable status, and the type of flight
        /// </summary>
        /// <param name="flyingDays">The list of flying days</param>
        /// <param name="course">The course for the classes</param>
        /// <param name="classes">The list of classes</param>
        /// <param name="pois">A dictionary of POIs indexed by POIID, for optimization only</param>
        /// <param name="objectives">A dictionary of Objectives indexed by ObjectiveID, for optimization only</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <param name="flight">Whether flight hours should be included</param>
        /// <param name="night">Whether night hours should be included</param>
        /// <param name="simulator">Whether simulator hours should be included</param>
        /// <returns>A dictionary by day of the flight students for each day</returns>
        private static IDictionary<DateTime, Decimal> GetFlightStudentsByDay(IList<DateTime> flyingDays, Course course, IList<Class> classes, IDictionary<Nullable<Int32>, POI> pois, IDictionary<Nullable<Int32>, Objective> objectives, Nullable<Boolean> reimbursable, Nullable<Boolean> flight, Nullable<Boolean> night, Nullable<Boolean> simulator)
        {
            IDictionary<DateTime, Decimal> flightStudentCount = CreateDailyReportDictionary(flyingDays);

            foreach (Class classItem in classes)
            {
                POI poi = pois[classItem.POIID];

                POIFlightDay flightDay = new POIFlightDay();
                flightDay.POIID = poi.POIID;

                IList<POIFlightDay> flightDays = DataService.ListPOIFlightDays(flightDay);

                Int16 studentCount = ClassUtil.GetStudentCount(classItem, reimbursable);

                IDictionary<DateTime, IList<POIFlightDay>> requirements = ClassUtil.GetDailyRequirements(classItem, course, poi, flightDays);

                foreach (KeyValuePair<DateTime, IList<POIFlightDay>> requirement in requirements)
                {
                    if (flightStudentCount.ContainsKey(requirement.Key) && requirement.Value.Any(x => objectives[x.ObjectiveID].FlightHours == flight && objectives[x.ObjectiveID].NightMission == night && objectives[x.ObjectiveID].SimulatorHours == simulator))
                    {
                        flightStudentCount[requirement.Key] += studentCount;
                    }
                }
            }

            return flightStudentCount;
        }

        /// <summary>
        /// Gets the flight hours by day based on a course, a list of classes, reimbursable status, and the type of flight
        /// </summary>
        /// <param name="flyingDays">The list of flying days</param>
        /// <param name="course">The course for the classes</param>
        /// <param name="classes">The list of classes</param>
        /// <param name="pois">A dictionary of POIs indexed by POIID, for optimization only</param>
        /// <param name="objectives">A dictionary of Objectives indexed by ObjectiveID, for optimization only</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <param name="flight">Whether flight hours should be included</param>
        /// <param name="simulator">Whether simulator hours should be included</param>
        /// <returns>A dictionary by day of the flight hours for each day</returns>
        private static IDictionary<DateTime, Decimal> GetFlightHoursByDay(IList<DateTime> flyingDays, Course course, IList<Class> classes, IDictionary<Nullable<Int32>, POI> pois, IDictionary<Nullable<Int32>, Objective> objectives, Nullable<Boolean> reimbursable, Nullable<Boolean> flight, Nullable<Boolean> simulator)
        {
            IDictionary<DateTime, Decimal> flightHourCount = CreateDailyReportDictionary(flyingDays);

            foreach (Class classItem in classes)
            {
                POI poi = pois[classItem.POIID];

                POIFlightDay flightDay = new POIFlightDay();
                flightDay.POIID = poi.POIID;

                IList<POIFlightDay> flightDays = DataService.ListPOIFlightDays(flightDay);

                Int16 studentCount = ClassUtil.GetStudentCount(classItem, reimbursable);

                IDictionary<DateTime, IList<POIFlightDay>> requirements = ClassUtil.GetDailyRequirements(classItem, course, poi, flightDays);

                foreach (KeyValuePair<DateTime, IList<POIFlightDay>> requirement in requirements)
                {
                    if (flightHourCount.ContainsKey(requirement.Key))
                    {
                        foreach (POIFlightDay dayRequirement in requirement.Value.Where(x => objectives[x.ObjectiveID].FlightHours == flight && objectives[x.ObjectiveID].SimulatorHours == simulator))
                        {
                            flightHourCount[requirement.Key] += dayRequirement.Units.GetValueOrDefault(0) * studentCount;
                        }
                    }
                }
            }

            return flightHourCount;
        }

        /// <summary>
        /// Gets the day aircraft count by day based on a course, a list of classes, reimbursable status, and the type of flight
        /// </summary>
        /// <param name="flyingDays">The list of flying days</param>
        /// <param name="course">The course for the classes</param>
        /// <param name="classes">The list of classes</param>
        /// <param name="pois">A dictionary of POIs indexed by POIID, for optimization only</param>
        /// <param name="objectives">A dictionary of Objectives indexed by ObjectiveID, for optimization only</param>
        /// <param name="reimbursable">True for reimbursable only, False for direct only, Null for all</param>
        /// <returns>A dictionary by day of the day aircraft count for each day</returns>
        private static IDictionary<DateTime, Decimal> GetDayAircraftByDay(IList<DateTime> flyingDays, Course course, IList<Class> classes, IDictionary<Nullable<Int32>, POI> pois, IDictionary<Nullable<Int32>, Objective> objectives, Nullable<Boolean> reimbursable)
        {
            IDictionary<DateTime, Decimal> dayAircraftCount = CreateDailyReportDictionary(flyingDays);

            foreach (Class classItem in classes)
            {
                POI poi = pois[classItem.POIID];

                POIFlightDay flightDay = new POIFlightDay();
                flightDay.POIID = poi.POIID;

                IList<POIFlightDay> flightDays = DataService.ListPOIFlightDays(flightDay);

                Decimal dayLaunchDivisor = flightDays.Any(x => objectives[x.ObjectiveID].FlightHours == true && objectives[x.ObjectiveID].NightMission == false && objectives[x.ObjectiveID].Contact == false) ? 4.0M : 3.6M;

                Int16 studentCount = ClassUtil.GetStudentCount(classItem, reimbursable);

                IDictionary<DateTime, IList<POIFlightDay>> requirements = ClassUtil.GetDailyRequirements(classItem, course, poi, flightDays);

                foreach (KeyValuePair<DateTime, IList<POIFlightDay>> requirement in requirements)
                {
                    if (dayAircraftCount.ContainsKey(requirement.Key) && requirement.Value.Any(x => objectives[x.ObjectiveID].FlightHours == true && objectives[x.ObjectiveID].NightMission == false && objectives[x.ObjectiveID].SimulatorHours == false))
                    {
                        dayAircraftCount[requirement.Key] += studentCount / dayLaunchDivisor;
                    }
                }
            }

            return dayAircraftCount.ToDictionary<KeyValuePair<DateTime, Decimal>, DateTime, Decimal>(x => x.Key, x => Math.Ceiling(x.Value));
        }

        /// <summary>
        /// Sums the values of a list of dictionary for a set of days
        /// </summary>
        /// <param name="days">The days of the sum dictionary</param>
        /// <param name="dictionaries">The dictionaries to sum</param>
        /// <returns>The summation of the provided dictionaries in the form of a dictionary</returns>
        private static IDictionary<DateTime, Decimal> SumHours(IList<DateTime> days, IList<IDictionary<DateTime, Decimal>> dictionaries)
        {
            IDictionary<DateTime, Decimal> sum = CreateDailyReportDictionary(days);

            foreach (IDictionary<DateTime, Decimal> dictionary in dictionaries)
            {
                foreach (KeyValuePair<DateTime, Decimal> value in dictionary)
                {
                    if (sum.ContainsKey(value.Key))
                    {
                        sum[value.Key] += value.Value;
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// Adds values from one dictionary to another
        /// </summary>
        /// <typeparam name="T">The type of the key for the dictionary</typeparam>
        /// <param name="dictionary">The dictionary being added to</param>
        /// <param name="addDictionary">The dictionary to be added</param>
        public static void AddValues<T>(IDictionary<T, Decimal> dictionary, IDictionary<T, Decimal> addDictionary)
        {
            IList<T> keys = dictionary.Keys.ToList();

            for (int i = 0; i < keys.Count; i++)
            {
                T keyValue = keys[i];

                if (addDictionary.ContainsKey(keyValue))
                {
                    dictionary[keyValue] = dictionary[keyValue] + Math.Round(addDictionary[keyValue], ROUND_DIGITS);
                }
            }
        }

        /// <summary>
        /// Creates a monthly dictionary for storing values by month
        /// </summary>
        /// <returns>A default month dictionary of values</returns>
        private static IDictionary<Int32, Decimal> CreateMonthlyDictionary()
        {
            IDictionary<Int32, Decimal> template = new Dictionary<Int32, Decimal>();

            for (int i = 1; i <= 12; i++)
            {
                template.Add(i, 0.0M);
            }

            return template;
        }

        /// <summary>
        /// Creates a daily dictionary for storing values by day
        /// </summary>
        /// <param name="days">The days that should be added to the dictionary</param>
        /// <returns>A default daily dictionary of values for the days specified</returns>
        private static IDictionary<DateTime, Decimal> CreateDailyReportDictionary(IList<DateTime> days)
        {
            IDictionary<DateTime, Decimal> template = new Dictionary<DateTime, Decimal>();

            foreach (DateTime day in days)
            {
                template.Add(day, 0.0M);
            }

            return template;
        }

        /// <summary>
        /// Constructs a monthly report row of array values based on the values and headers
        /// </summary>
        /// <param name="values">The dictionary of values by month</param>
        /// <param name="headers">The headers that should be displayed</param>
        /// <returns>An array of values to be used in creating a DataRow</returns>
        private static String[] ConstructMonthlyReportRow(IDictionary<Int32, Decimal> values, params String[] headers)
        {
            IList<String> rowValues = new List<String>();

            rowValues.AppendList(headers);

            for (Int32 i = 0; i < 12; i++)
            {
                Int32 month = (i + 9) % 12 + 1;

                rowValues.Add(values[month].ToString(ROUND_STRING));

                if (month % 3 == 0)
                {
                    Decimal quarterSum = Math.Round(values[month - 2], ROUND_DIGITS) + Math.Round(values[month - 1], ROUND_DIGITS) + Math.Round(values[month], ROUND_DIGITS);

                    rowValues.Add(quarterSum.ToString(ROUND_STRING));
                }
            }

            rowValues.Add(values.Sum(x => Math.Round(x.Value, ROUND_DIGITS)).ToString(ROUND_STRING));

            return rowValues.ToArray();
        }

        /// <summary>
        /// Constructs a historical percent report row of array values based on the values
        /// </summary>
        /// <param name="course">The course for the values</param>
        /// <param name="values">The list of values by month/type</param>
        /// <returns>An array of values to be used in creating a DataRow</returns>
        private static String[] ConstructHistoricalPercentsRow(Course course, IList<Decimal> values)
        {
            IList<String> rowValues = new List<String>();

            rowValues.Add(course.CourseName);

            for (Int32 i = 0; i < values.Count; i++)
            {
                rowValues.Add(values[i].ToString(ROUND_STRING));
            }

            rowValues.Add(course.MinClassSize.ToStringSafe());
            rowValues.Add(course.OptimumClassSize.ToStringSafe());
            rowValues.Add(course.MaxClassSize.ToStringSafe());

            if (course.POIID.HasValue)
            {
                POI poi = new POI();
                poi.POIID = course.POIID;

                poi = DataService.GetPOI(poi);

                Int32 daysPerWeek = CalendarUtil.GetWeekLength(poi);

                if (poi.Days.HasValue)
                {
                    Int32 courseWeeks = poi.Days.Value / daysPerWeek;
                    Int32 courseDays = poi.Days.Value % daysPerWeek;

                    rowValues.Add(String.Format("{0} Wks {1} Days", courseWeeks.ToString(), courseDays.ToString()));
                }
                else
                {
                    rowValues.Add(String.Empty);
                }
            }
            else
            {
                rowValues.Add(String.Empty);
            }

            rowValues.Add(course.CourseLevelID.HasValue ? DataService.GetCourseLevel(new CourseLevel { CourseLevelID = course.CourseLevelID }).CourseLevelName : String.Empty);
            rowValues.Add(course.SystemID.HasValue ? DataService.GetSystem(new Domain.Entities.System { SystemID = course.SystemID }).SystemName : String.Empty);

            IList<Class> classes = DataService.ListClasses(new Class { CourseID = course.CourseID });

            rowValues.Add(classes.Count > 0 ? classes.Sum(x => x.Students.GetValueOrDefault(0)).ToString() : "0");
            rowValues.Add(classes.Count > 0 ? classes.Sum(x => x.Reimbursable.GetValueOrDefault(0)).ToString() : "0");

            return rowValues.ToArray();
        }
    }
}
