using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.WebDAV.Constants
{
    public static class WebDAVConstants
    {
        public static readonly IList<String> WEBDAV_METHODS = new List<String>() { "COPY", "DELETE", "HEAD", "LOCK", "MKCOL", "MOVE", "OPTIONS", "PROPFIND", "PROPPATCH", "REPORT", "UNLOCK" };
    }
}
