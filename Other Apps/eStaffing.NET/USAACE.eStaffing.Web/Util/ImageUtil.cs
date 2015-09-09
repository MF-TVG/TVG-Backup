using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USAACE.eStaffing.Business.Constants;
using USAACE.eStaffing.Business.Enums;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Web.Util
{
    public static class ImageUtil
    {
        public static String GetColorCode(StatusType statusType)
        {
            switch (statusType)
            {
                case StatusType.NotSubmitted: return "~/images/statusblack.png";
                case StatusType.InReview: return "~/images/statusblue.png";
                case StatusType.NearDue: return "~/images/statusamber.png";
                case StatusType.PastDue: return "~/images/statusred.png";
                case StatusType.Completed: return "~/images/statusgreen.png";
                case StatusType.Rejected: return "~/images/statusreject.png";
                default: return null;
            }
        }

        public static String GetSignatureImage(Boolean valid)
        {
            return valid ? "~/images/certvalid.gif" : "~/images/certinvalid.gif";
        }
    }
}