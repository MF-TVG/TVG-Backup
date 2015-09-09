using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace USAACE.eStaffing.WebDAV.Util
{
    internal static class PathUtil
    {
        internal static String GetAppRelativePath(HttpRequest request)
        {
            return request.AppRelativeCurrentExecutionFilePath.Length >= 2 ? request.AppRelativeCurrentExecutionFilePath.Substring(2) : String.Empty;
        }

        internal static String GetAppRelativePath(String absoluteUrl)
        {
            String applicationUrl = VirtualPathUtility.ToAbsolute("~/");

            Uri absoluteUri = new Uri(absoluteUrl);

            return absoluteUri.AbsolutePath.Replace(applicationUrl, String.Empty);
        }
    }
}
