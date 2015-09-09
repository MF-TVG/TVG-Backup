using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using USAACE.eStaffing.WebDAV.Enum;
using USAACE.eStaffing.WebDAV.Response;
using USAACE.eStaffing.WebDAV.Util;

namespace USAACE.eStaffing.WebDAV.Methods
{
    internal class LockMethod : MethodBase
    {
        internal override WebDAVResponse ExecuteRequest(HttpContext application)
        {
            String absolutePath = HttpUtility.UrlDecode(application.Request.Url.AbsolutePath);

            StringBuilder result = new StringBuilder();

            String lockToken = !String.IsNullOrEmpty(application.Request.Headers["If"]) ?
                application.Request.Headers["If"].Substring(2, application.Request.Headers["If"].Length - 4) :
                String.Format("urn:uuid:{0}", Guid.NewGuid().ToString().ToLower());

            application.Response.AddHeader("Lock-Token", String.Format("<{0}>", lockToken));

            result.Append(XML_DECLARE);
            result.Append("<D:prop xmlns:D=\"DAV:\">");
            result.Append("<D:lockdiscovery>");
            result.Append("<D:activelock>");
            result.Append("<D:locktype><D:write /></D:locktype>");
            result.Append("<D:lockscope><D:exclusive /></D:lockscope>");
            result.Append("<D:depth>infinity</D:depth>");
            result.AppendFormat("<D:owner><D:href>{0}</D:href></D:owner>", application.User.Identity.Name);
            result.Append("<D:timeout>Second-3600</D:timeout>");
            result.AppendFormat("<D:locktoken><D:href>{0}</D:href></D:locktoken>", lockToken);
            result.AppendFormat("<D:lockroot><D:href>{0}</D:href></D:lockroot>", absolutePath);
            result.Append("</D:activelock>");
            result.Append("</D:lockdiscovery>");
            result.Append("</D:prop>");

            return new WebDAVResponse(WebDAVResponseStatus.Ok, result.ToString());
        }
    }
}
