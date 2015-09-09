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
    internal class MkColMethod : MethodBase
    {
        internal override WebDAVResponse ExecuteRequest(HttpContext application)
        {
            return new WebDAVResponse(WebDAVResponseStatus.Forbidden);
        }
    }
}
