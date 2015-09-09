using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using USAACE.eStaffing.WebDAV.Enum;
using USAACE.eStaffing.WebDAV.Response;

namespace USAACE.eStaffing.WebDAV.Methods
{
    internal class PropPatchMethod : MethodBase
    {
        internal override WebDAVResponse ExecuteRequest(HttpContext application)
        {
            String absolutePath = HttpUtility.UrlDecode(application.Request.Url.AbsolutePath);

            StringBuilder result = new StringBuilder();

            result.Append(XML_DECLARE);
            result.Append(MULTISTATUS_START);
            result.Append("<D:response>");
            result.AppendFormat("<D:href>{0}</D:href>", absolutePath);
            result.Append("<D:propstat><D:prop><Z:Win32CreationTime /></D:prop><D:status>HTTP/1.1 200 OK</D:status></D:propstat>");
            result.Append("<D:propstat><D:prop><Z:Win32LastAccessTime /></D:prop><D:status>HTTP/1.1 200 OK</D:status></D:propstat>");
            result.Append("<D:propstat><D:prop><Z:Win32LastModifiedTime /></D:prop><D:status>HTTP/1.1 200 OK</D:status></D:propstat>");
            result.Append("<D:propstat><D:prop><Z:Win32FileAttributes /></D:prop><D:status>HTTP/1.1 200 OK</D:status></D:propstat>");
            result.Append("</D:response>");
            result.Append("</D:multistatus>");

            return new WebDAVResponse(WebDAVResponseStatus.MultiStatus, result.ToString());
        }
    }
}
