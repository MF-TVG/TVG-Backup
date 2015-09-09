using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USAACE.ATI.Web.Util
{
    public static class ImageUtil
    {
        /// <summary>
        /// Gets the URL for the status image based on the difference between the actual date and the calculated date
        /// </summary>
        /// <param name="currentDate">The actual date</param>
        /// <param name="calculatedDate">The calculated date</param>
        /// <returns>The URL for the status image</returns>
        public static String GetReportDateImage(Nullable<DateTime> currentDate, Nullable<DateTime> calculatedDate)
        {
            if (currentDate.HasValue && calculatedDate.HasValue)
            {
                switch (currentDate.Value.CompareTo(calculatedDate.Value))
                {
                    case -1: return "~/images/statusred.png";
                    case 0: return "~/images/statusgreen.png";
                    case 1: return "~/images/statusamber.png";
                    default: return null;
                }
            }

            return null;
        }

        public static String GetPOIImage(Nullable<Boolean> poiMatch)
        {
            return poiMatch != false ? "~/images/statusgreen.png" : "~/images/statusamber.png";
        }
    }
}