using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace USAACE.ATI.Web.Util
{
    public static class DateSelectorUtil
    {
        public static void BindMonths(ListControl control, String defaultValue)
        {
            control.Items.Clear();

            if (!String.IsNullOrEmpty(defaultValue))
            {
                control.Items.Add(new ListItem(defaultValue, String.Empty));
            }

            for (int i = 1; i <= 12; i++)
            {
                control.Items.Add(new ListItem(DateTimeFormatInfo.CurrentInfo.GetMonthName(i), i.ToString()));
            }
        }

        public static void BindDays(ListControl control, String defaultValue)
        {
            control.Items.Clear();

            if (!String.IsNullOrEmpty(defaultValue))
            {
                control.Items.Add(new ListItem(defaultValue, String.Empty));
            }

            for (int i = 1; i <= 31; i++)
            {
                control.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        public static void BindWeekdays(ListControl control, String defaultValue)
        {
            control.Items.Clear();

            if (!String.IsNullOrEmpty(defaultValue))
            {
                control.Items.Add(new ListItem(defaultValue, String.Empty));
            }

            for (int i = 1; i <= 7; i++)
            {
                control.Items.Add(new ListItem(DateTimeFormatInfo.CurrentInfo.GetDayName((DayOfWeek)(i - 1)), i.ToString()));
            }
        }
    }
}