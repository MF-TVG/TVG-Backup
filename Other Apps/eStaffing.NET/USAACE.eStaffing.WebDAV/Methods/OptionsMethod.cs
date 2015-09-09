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
    internal class OptionsMethod : MethodBase
    {
        private readonly String DAV_CLASS = "1,2";
        private readonly String[] METHODS = { "COPY", "DELETE", "GET", "GETLIB", "HEAD", "LOCK", "MKCOL", "MOVE", "OPTIONS", "PROPFIND", "PROPPATCH", "PUT", "REPORT", "UNLOCK" };

        internal override WebDAVResponse ExecuteRequest(HttpContext application)
        {
            application.Response.AddHeader("DAV", DAV_CLASS);
            application.Response.AddHeader("MS-Author-Via", "DAV");
            //application.Response.AddHeader("X-MSFSSHTTP", "1.0");
            //application.Response.AddHeader("X-MSDAVEXT", "1");
            application.Response.AddHeader("Allow", String.Join(", ", METHODS));
            application.Response.AddHeader("Public", String.Join(", ", METHODS));
            application.Response.AddHeader("Accept-Ranges", "none");
            //application.Response.AddHeader("MicrosoftSharePointTeamServices", "14.0.0.7113");
            //application.Response.AddHeader("DocumentManagementServer", "Properties Schema;Source Control;Version History;");

            return new WebDAVResponse(WebDAVResponseStatus.Ok);
        }
    }
}
