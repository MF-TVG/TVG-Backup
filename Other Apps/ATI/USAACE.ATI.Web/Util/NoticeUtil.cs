using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USAACE.ATI.Web.Enum;

namespace USAACE.ATI.Web.Util
{
    public static class NoticeUtil
    {
        public static String GetNoticeImageUrl(NoticeType noticeType)
        {
            switch (noticeType)
            {
                case NoticeType.Information: return "~/images/info.gif";
                case NoticeType.Warning: return "~/images/warning.gif";
                case NoticeType.Critical:
                case NoticeType.Error: return "~/images/error.gif";
                default: return null;
            }
        }

        public static String GetNoticeTitle(NoticeType noticeType)
        {
            switch (noticeType)
            {
                case NoticeType.Information: return "Notice";
                case NoticeType.Warning: return "Warning";
                case NoticeType.Critical:
                case NoticeType.Error: return "Error";
                default: return null;
            }
        }
    }
}