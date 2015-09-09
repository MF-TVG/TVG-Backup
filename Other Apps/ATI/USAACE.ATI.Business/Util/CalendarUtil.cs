using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USAACE.ATI.Domain.Entities;
using System.Collections;
using USAACE.ATI.Business.Services;

namespace USAACE.ATI.Business.Util
{
    /// <summary>
    /// A class containing several utility functions for dealing with calendars and dates
    /// </summary>
    public static class CalendarUtil
    {
        /// <summary>
        /// Checks to see if a date is a no fly day
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="mobilization">Whether it is a mobilization program</param>
        /// <returns>The no fly day type if it is no fly day, Null otherwise</returns>
        public static NoFlyType GetNoFlyType(DateTime date, Boolean mobilization)
        {
            if (IsWeekend(date, mobilization))
            {
                return DataService.SearchNoFlyTypeByName("Weekend");
            }
            else if (IsHoliday(date, mobilization))
            {
                return DataService.SearchNoFlyTypeByName("Holiday");
            }
            else if (IsExodus(date, mobilization))
            {
                return DataService.SearchNoFlyTypeByName("Exodus");
            }

            return null;
        }

        /// <summary>
        /// Gets the starting date of a fiscal year
        /// </summary>
        /// <param name="year">The year to check</param>
        /// <returns>The date of the start of the fiscal year</returns>
        public static DateTime GetFiscalYearStart(Int32 year)
        {
            return new DateTime(year - 1, 10, 1);
        }

        /// <summary>
        /// Gets the ending date of a fiscal year
        /// </summary>
        /// <param name="year">The year to check</param>
        /// <returns>The date of the end of the fiscal year</returns>
        public static DateTime GetFiscalYearEnd(Int32 year)
        {
            return new DateTime(year, 9, 30);
        }

        /// <summary>
        /// Checks if a date is within a fiscal year
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="year">The fiscal year</param>
        /// <returns>True if date is within fiscal year, False if not</returns>
        public static Boolean IsInFiscalYear(DateTime date, Int32 year)
        {
            return date >= GetFiscalYearStart(year) && date <= GetFiscalYearEnd(year);
        }

        /// <summary>
        /// Gets the starting date of a program year
        /// </summary>
        /// <param name="year">The year to check</param>
        /// <returns>The date of the start of the program year</returns>
        public static DateTime GetProgramFlightStart(Int32 year)
        {
            return new DateTime(year - 1, 9, 16);
        }

        /// <summary>
        /// Gets the ending date of a program year
        /// </summary>
        /// <param name="year">The year to check</param>
        /// <returns>The date of the end of the program year</returns>
        public static DateTime GetProgramFlightEnd(Int32 year)
        {
            return new DateTime(year, 9, 15);
        }

        /// <summary>
        /// Checks if a date is within a fiscal year
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="year">The fiscal year</param>
        /// <returns>True if date is within fiscal year, False if not</returns>
        public static Boolean IsInProgramFlightYear(DateTime date, Int32 year)
        {
            return date >= GetProgramFlightStart(year) && date <= GetProgramFlightEnd(year);
        }

        /// <summary>
        /// Gets the fiscal year for a specific date
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <returns>The fiscal year of the date</returns>
        public static Int32 GetFiscalYear(DateTime date)
        {
            return date.Month >= 10 ? date.Year + 1 : date.Year;
        }

        /// <summary>
        /// Gets the length of a week in days for a POI based on the weekend holiday settings
        /// </summary>
        /// <param name="poi">The POI to check</param>
        /// <returns>The length of a week in day for the POI</returns>
        public static Int32 GetWeekLength(POI poi)
        {
            poi.Load();

            NoFlyType weekendType = DataService.SearchNoFlyTypeByName("Weekend");

            IList<NoFlyDay> noFlyDays = DataService.SearchNoFlyDaysByType(weekendType.NoFlyTypeID);

            Int32 days = 7;

            foreach (NoFlyDay noFlyDay in noFlyDays)
            {
                if (poi.Mobilization != true || noFlyDay.MobilizationExempt != true)
                {
                    days -= 1;
                }
            }

            return days;
        }

        /// <summary>
        /// Gets the 1352 month name based on the month number
        /// </summary>
        /// <param name="month">The number of the month</param>
        /// <returns>The 1352 month name</returns>
        public static String Get1352MonthName(Int32 month)
        {
            switch (month)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default: return null;
            }
        }

        /// <summary>
        /// Gets the 1352 month name based on a date
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <returns>The name of the 1352 month</returns>
        public static String Get1352MonthName(DateTime date)
        {
            Int32 month = Get1352Month(date);

            return Get1352MonthName(month);
        }

        /// <summary>
        /// Gets the 1352 month number based on a date
        /// </summary>
        /// <param name="date">The date to cvheck</param>
        /// <returns>The number of the 1352 month</returns>
        public static Int32 Get1352Month(DateTime date)
        {
            return date.Day > 15 ? (date.Month % 12 + 1) : date.Month;
        }

        /// <summary>
        /// Gets the flying days for a program
        /// </summary>
        /// <param name="program">The program to check</param>
        /// <param name="mobilization">Whether it is a mobilization program</param>
        /// <param name="carryOver">Whether the program is carried over</param>
        /// <returns>The list of flying days for the program</returns>
        public static IList<DateTime> GetProgramFlyingDays(Program program, Boolean mobilization, Boolean carryOver)
        {
            IList<DateTime> flyingDays = new List<DateTime>();

            Int32 year = carryOver ? program.FiscalYear.Value : program.FiscalYear.Value - 1;

            DateTime currentDate = new DateTime(year, 9, 16);

            DateTime endDate = currentDate.AddYears(1);

            while (currentDate < endDate)
            {
                if (GetNoFlyType(currentDate, mobilization) == null)
                {
                    flyingDays.Add(new DateTime(currentDate.Year, currentDate.Month, currentDate.Day));
                }

                currentDate = currentDate.AddDays(1);
            }

            return flyingDays;
        }

        /// <summary>
        /// Checks to see if a date is a weekend no fly day
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="mobilization">Whether it is a mobilization program</param>
        /// <returns>True if weekend no fly day, False otherwise</returns>
        private static Boolean IsWeekend(DateTime date, Boolean mobilization)
        {
            NoFlyType weekendType = DataService.SearchNoFlyTypeByName("Weekend");

            IList<NoFlyDay> noFlyDays = DataService.SearchNoFlyDaysByType(weekendType.NoFlyTypeID);

            foreach (NoFlyDay noFlyDay in noFlyDays)
            {
                if (mobilization == false || noFlyDay.MobilizationExempt != true)
                {
                    if (noFlyDay.WeekDay.HasValue && date.DayOfWeek == GetDayOfWeek(noFlyDay.WeekDay.Value) && !noFlyDay.WeekCount.HasValue && !noFlyDay.WeekMonth.HasValue)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks to see if a date is a holiday no fly day
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="mobilization">Whether it is a mobilization program</param>
        /// <returns>True if holiday no fly day, False otherwise</returns>
        private static Boolean IsHoliday(DateTime date, Boolean mobilization)
        {
            NoFlyType holidayType = DataService.SearchNoFlyTypeByName("Holiday");

            IList<NoFlyDay> noFlyDays = DataService.SearchNoFlyDaysByType(holidayType.NoFlyTypeID);

            foreach (NoFlyDay noFlyDay in noFlyDays)
            {
                if (mobilization == false || noFlyDay.MobilizationExempt != true)
                {
                    if (noFlyDay.StartDateMonth.HasValue && noFlyDay.StartDateDay.HasValue)
                    {
                        if (IsObservedHoliday(date, noFlyDay.StartDateMonth.Value, noFlyDay.StartDateDay.Value))
                        {
                            return true;
                        }
                    }
                    else if (noFlyDay.WeekDay.HasValue && noFlyDay.WeekCount.HasValue && noFlyDay.WeekMonth.HasValue)
                    {
                        if (IsRelativeHoliday(date, noFlyDay.WeekMonth.Value, noFlyDay.WeekCount.Value, GetDayOfWeek(noFlyDay.WeekDay.Value)))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks to see if a date is an exodus no fly day
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="mobilization">Whether it is a mobilization program</param>
        /// <returns>True if exodus no fly day, False otherwise</returns>
        private static Boolean IsExodus(DateTime date, Boolean mobilization)
        {
            NoFlyType exodusType = DataService.SearchNoFlyTypeByName("Exodus");

            IList<NoFlyDay> noFlyDays = DataService.SearchNoFlyDaysByType(exodusType.NoFlyTypeID);

            foreach (NoFlyDay noFlyDay in noFlyDays)
            {
                if (mobilization == false || noFlyDay.MobilizationExempt != true)
                {
                    if (noFlyDay.StartDateMonth.HasValue && noFlyDay.StartDateDay.HasValue && noFlyDay.EndDateMonth.HasValue && noFlyDay.EndDateDay.HasValue)
                    {
                        if (IsInRange(date, noFlyDay.StartDateMonth.Value, noFlyDay.StartDateDay.Value, noFlyDay.EndDateMonth.Value, noFlyDay.EndDateDay.Value))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a date is a relative holiday based on month, week number, and day of week
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="month">The month of the relative holiday</param>
        /// <param name="week">The week number of the relative holiday</param>
        /// <param name="weekDay">The day of the week of the relative holiday</param>
        /// <returns>True if date is a relative holiday, False otherwise</returns>
        private static Boolean IsRelativeHoliday(DateTime date, Int32 month, Int32 week, DayOfWeek weekDay)
        {
            return date == GetRelativeHolidayDate(month, week, date.Year, weekDay);
        }

        /// <summary>
        /// Checks if a date is an observed holiday for a month and day because of holidays that fall on weekends
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="month">The month of the holiday</param>
        /// <param name="day">The day of the holiday</param>
        /// <returns>True if date is an observed holiday, False otherwise</returns>
        private static Boolean IsObservedHoliday(DateTime date, Int32 month, Int32 day)
        {
            DateTime dayBefore = date.AddDays(-1);
            DateTime dayAfter = date.AddDays(1);

            return (dayBefore.Day == day && dayBefore.Month == month && IsWeekend(dayBefore, false)) ||
                (dayAfter.Day == day && dayAfter.Month == month && IsWeekend(dayAfter, false)) ||
                (date.Day == day && date.Month == month && !IsWeekend(date, false));
        }

        /// <summary>
        /// Checks if a date is within a specified range based on start month and day and an end month and day
        /// </summary>
        /// <param name="date">The date to check</param>
        /// <param name="startMonth">The month of the start date</param>
        /// <param name="startDay">The day of the start date</param>
        /// <param name="endMonth">The month of the end date</param>
        /// <param name="endDay">The day of the end date</param>
        /// <returns>True if date is within the range, False otherwise</returns>
        private static Boolean IsInRange(DateTime date, Int32 startMonth, Int32 startDay, Int32 endMonth, Int32 endDay)
        {
            DateTime startDate = new DateTime(date.Year, startMonth, startDay);
            DateTime endDate = new DateTime(date.Year, endMonth, endDay);

            if (endDate < startDate)
            {
                endDate = endDate.AddYears(1);
            }

            DateTime checkDate = new DateTime(startDate.Year, date.Month, date.Day);

            return endDate.Year > startDate.Year ? checkDate >= startDate || checkDate.AddDays(365) <= endDate : checkDate >= startDate && checkDate <= endDate;
        }

        /// <summary>
        /// Gets the date for a relative holiday for a specific month, week number, year, and day of week
        /// </summary>
        /// <param name="month">The month of the holiday</param>
        /// <param name="week">The week number of the holiday</param>
        /// <param name="year">The year of the holiday</param>
        /// <param name="weekDay">The day of the week of the holiday</param>
        /// <returns>The date for the holiday</returns>
        private static DateTime GetRelativeHolidayDate(Int32 month, Int32 week, Int32 year, DayOfWeek weekDay)
        {
            DateTime day = new DateTime(year, month, 1);

            while (day.DayOfWeek != weekDay)
            {
                day = day.AddDays(1);
            }

            Int32 currentWeek = 1;

            while (currentWeek != week && day.AddDays(7).Month == month)
            {
                day = day.AddDays(7);
                currentWeek += 1;
            }

            return day;
        }

        /// <summary>
        /// Gets the day of the week based on a day number
        /// </summary>
        /// <param name="dayNumber">The day number to check</param>
        /// <returns>The day of the week</returns>
        private static DayOfWeek GetDayOfWeek(Byte dayNumber)
        {
            switch (dayNumber)
            {
                case 1: return DayOfWeek.Sunday;
                case 2: return DayOfWeek.Monday;
                case 3: return DayOfWeek.Tuesday;
                case 4: return DayOfWeek.Wednesday;
                case 5: return DayOfWeek.Thursday;
                case 6: return DayOfWeek.Friday;
                case 7: return DayOfWeek.Saturday;
                default: throw new Exception("Invalid day of week value.");
            }
        }
    }
}
