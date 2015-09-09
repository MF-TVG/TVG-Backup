using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using USAACE.ATI.Business.Services;
using USAACE.Common;

namespace USAACE.ATI.Business.Util
{
    /// <summary>
    /// A class containing several utility functions for dealing with classes
    /// </summary>
    public static class ClassUtil
    {
        /// <summary>
        /// An enumeration for how to fill students in a class
        /// </summary>
        public enum StudentFillType
        {
            All,
            Odd,
            Even
        }

        /// <summary>
        /// Creates classes based on the course, POI, student count, class count, beginning class number, interval, first date, fill type, and carry over information
        /// </summary>
        /// <param name="course">The course to create the classes for</param>
        /// <param name="poi">The POI to follow in creating the classes</param>
        /// <param name="studentCount">The total student count</param>
        /// <param name="classCount">The total class count</param>
        /// <param name="beginningClass">The beginning class number</param>
        /// <param name="firstInterval">The interval of the class</param>
        /// <param name="firstDate">The first class date</param>
        /// <param name="fillType">The way to fill the students in the classes</param>
        /// <param name="carryOverProgram">The carry over program to use</param>
        /// <param name="carryOverCourse">The carry over course to use</param>
        /// <returns>The number of newly created classes that are in the next fiscal year</returns>
        public static Int32 CreateClasses(Course course, POI poi, Int16 studentCount, Int16 classCount, Int16 beginningClass, Int16 firstInterval, DateTime firstDate, StudentFillType fillType, Program carryOverProgram, Course carryOverCourse)
        {
            course = DataService.LoadCourse(course);

            Program program = new Program();
            program.ProgramID = course.ProgramID;

            program = DataService.GetProgram(program);

            DateTime fiscalYearEndDate = CalendarUtil.GetFiscalYearEnd(program.FiscalYear.Value);

            poi = DataService.GetPOI(poi);

            DateTime currentDate = GetNextDate(firstDate, firstInterval, course.TrainNoFlyDay == true, poi.Mobilization == true);

            IList<Class> classes = new List<Class>();

            Int32 overflowCount = 0;

            for (Int16 i = beginningClass; i < beginningClass + classCount; i++)
            {
                Class newClass = new Class();

                newClass.Students = 0;
                newClass.ReportDate = i == beginningClass ? firstDate : GetNextDate(currentDate, Convert.ToInt16(firstInterval * -1), course.ReportNoFlyDay == true, poi.Mobilization == true);
                newClass.Interval = firstInterval;
                newClass.POIID = poi.POIID;

                if (newClass.ReportDate <= fiscalYearEndDate)
                {
                    /*if (!carryOverCourse.CourseID.HasValue)
                    {
                        carryOverCourse = DataService.CopyCourse(course, course.CourseName, carryOverProgram.ProgramID, course.CourseID);
                    }

                    newClass.CourseID = carryOverCourse.CourseID;*/

                    newClass.CourseID = course.CourseID;

                    newClass.ClassNumber = i.ToString().PadLeft(2, '0');

                    classes.Add(newClass);

                    DataService.SaveClass(newClass);
                }
                else
                {
                    overflowCount += 1;
                }

                currentDate = GetNextDate(currentDate, course.ClassInterval.Value, course.TrainNoFlyDay == true, poi.Mobilization == true);
            }

            classes = SetStudentClassCount(classes, studentCount, fillType);

            foreach (Class newClass in classes)
            {
                DataService.SaveClass(newClass);
            }

            return overflowCount;
        }

        /// <summary>
        /// Sets the individual student class count for a group of classes based on a total count and fill type
        /// </summary>
        /// <param name="classes">The list of classes</param>
        /// <param name="studentCount">The total number of students</param>
        /// <param name="fillType">The method of filling the classes</param>
        /// <returns>The list of classes with the student counts populated</returns>
        public static IList<Class> SetStudentClassCount(IList<Class> classes, Int16 studentCount, StudentFillType fillType)
        {
            for (Int32 i = classes.Count - 1; i >= 0; i--)
            {
                classes[i].Students = 0;
                classes[i].Reimbursable = 0;
            }

            Int16 studentsRemaining = studentCount;

            while (studentCount > 0)
            {
                for (Int32 i = classes.Count - 1; i >= 0; i--)
                {
                    if (ClassHasStudents(classes[i].ClassNumber.ToNullable<Int16>(), fillType))
                    {
                        if (studentCount >= 2)
                        {
                            classes[i].Students += 2;
                            studentCount -= 2;
                        }
                        else if (studentCount == 1)
                        {
                            classes[i].Students += 1;
                            studentCount -= 1;
                        }
                    }

                    if (studentCount == 0)
                    {
                        break;
                    }
                }
            }

            return classes;
        }

        /// <summary>
        /// Gets the ADP code for a class
        /// </summary>
        /// <param name="classItem">The class to get the ADP code for</param>
        /// <returns>The ADP code for the class</returns>
        public static String GetADPCode(Class classItem)
        {
            Course classCourse = DataService.LoadCourse(new Course { CourseID = classItem.CourseID });
            Program classProgram = DataService.GetProgram(new Program { ProgramID = classCourse.ProgramID });
            Domain.Entities.System classSystem = DataService.GetSystem(new Domain.Entities.System { SystemID = classCourse.SystemID });
            CourseType classCourseType = DataService.GetCourseType(new CourseType { CourseTypeID = classCourse.CourseTypeID });

            return String.Format("{0}{1}{2}{3}", (classProgram.FiscalYear % 10).ToStringSafe(), classSystem.SystemCode, classCourseType != null ? classCourseType.CourseTypeCode : "0", classItem.ClassNumber != null ? classItem.ClassNumber.PadLeft(3, '0') : "000");
        }

        /// <summary>
        /// Gets the next date based on a current date, interval, mobilization, and inclusion of no fly days
        /// </summary>
        /// <param name="date">The current date</param>
        /// <param name="interval">The interval between dates</param>
        /// <param name="includeNoFlyDays">Whether no fly days should be considered</param>
        /// <param name="mobilization">Whether it is a mobilization program</param>
        /// <returns>The next date based on the details provided</returns>
        public static DateTime GetNextDate(DateTime date, Int16 interval, Boolean includeNoFlyDays, Boolean mobilization)
        {
            DateTime nextDate = new DateTime(date.Year, date.Month, date.Day);

            Int32 direction = interval >= 0 ? 1 : -1;

            for (Int16 i = 0; i < Math.Abs(interval); i++)
            {
                nextDate = nextDate.AddDays(direction);

                if (!includeNoFlyDays && CalendarUtil.GetNoFlyType(nextDate, mobilization) != null)
                {
                    i--;
                }
            }

            while (!includeNoFlyDays && CalendarUtil.GetNoFlyType(nextDate, mobilization) != null)
            {
                nextDate = nextDate.AddDays(direction);
            }

            return nextDate;
        }

        /// <summary>
        /// Gets the next class date based on a current date and mobilization
        /// </summary>
        /// <param name="date">The current date</param>
        /// <param name="mobilization">Whether it is a mobilization POI</param>
        /// <returns>The date for the next class</returns>
        public static DateTime GetNextClassDate(DateTime date, Boolean mobilization)
        {
            DateTime nextDate = new DateTime(date.Year, date.Month, date.Day);

            do
            {
                nextDate = nextDate.AddDays(1);
            }
            while (CalendarUtil.GetNoFlyType(nextDate, mobilization) != null);

            return nextDate;
        }

        /// <summary>
        /// Calculates a dictionary by date of the daily requirements for a specific class
        /// </summary>
        /// <param name="classItem">The class to analyze</param>
        /// <param name="course">The course the class belongs to</param>
        /// <param name="poi">The POI of the class</param>
        /// <param name="flightDays">The flight days for the POI</param>
        /// <returns>A dictionary by date of the daily requirements for the class</returns>
        public static IDictionary<DateTime, IList<POIFlightDay>> GetDailyRequirements(Class classItem, Course course, POI poi, IList<POIFlightDay> flightDays)
        {
            IDictionary<DateTime, IList<POIFlightDay>> dailyRequirements = new Dictionary<DateTime, IList<POIFlightDay>>();

            DateTime classDate = GetNextDate(classItem.ReportDate.Value, classItem.Interval.Value, course.ReportNoFlyDay == true, poi.Mobilization == true);

            for (int i = 1; i <= poi.Days.Value; i++)
            {
                IList<POIFlightDay> classFlightDays = flightDays.Where(x => x.FlightDayNumber == i && x.Units.GetValueOrDefault(0) > 0).ToList();

                if (classFlightDays.Count > 0)
                {
                    if (dailyRequirements.ContainsKey(classDate))
                    {
                        dailyRequirements[classDate].AppendList(classFlightDays);
                    }
                    else
                    {
                        dailyRequirements.Add(new KeyValuePair<DateTime, IList<POIFlightDay>>(classDate, classFlightDays));
                    }
                }

                classDate = GetNextClassDate(classDate, poi.Mobilization == true);
            }

            return dailyRequirements;
        }

        /// <summary>
        /// Gets the student count for a class based on reimburseable status
        /// </summary>
        /// <param name="classItem">The class to analyze</param>
        /// <param name="reimbursable">True for reimbursable only, False for non-reimbursable only, Null for all</param>
        /// <returns>The student count for the class</returns>
        public static Int16 GetStudentCount(Class classItem, Nullable<Boolean> reimbursable)
        {
            if (reimbursable == true)
            {
                return classItem.Reimbursable.GetValueOrDefault(0);
            }
            else if (reimbursable == false)
            {
                return (Int16)(classItem.Students.GetValueOrDefault(0) - classItem.Reimbursable.GetValueOrDefault(0));
            }
            else
            {
                return classItem.Students.GetValueOrDefault(0);
            }
        }

        /// <summary>
        /// Determines if the class has students based on the class number and fill type
        /// </summary>
        /// <param name="classNumber">The number of the class</param>
        /// <param name="fillType">The fill type of the class</param>
        /// <returns>True if the class will have students, False if not</returns>
        private static Boolean ClassHasStudents(Nullable<Int16> classNumber, StudentFillType fillType)
        {
            if (classNumber.HasValue)
            {
                return fillType == StudentFillType.All || (fillType == StudentFillType.Even && classNumber.Value % 2 == 0) || (fillType == StudentFillType.Odd && classNumber.Value % 2 == 1);
            }
            else
            {
                return fillType == StudentFillType.All;
            }
        }
    }
}
