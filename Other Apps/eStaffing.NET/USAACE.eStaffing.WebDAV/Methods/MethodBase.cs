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
    internal abstract class MethodBase
    {
        internal abstract WebDAVResponse ExecuteRequest(HttpContext application);

        protected const String XML_DECLARE = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
        protected const String MULTISTATUS_START = "<D:multistatus xmlns:D=\"DAV:\" xmlns:Office=\"urn:schemas-microsoft-com:office:office\" xmlns:Repl=\"http://schemas.microsoft.com/repl/\" xmlns:Z=\"urn:schemas-microsoft-com:\">";

        internal static MethodBase GetMethodHandler(String httpMethod)
        {
            switch (httpMethod)
            {
                case "COPY": return new CopyMethod();
                case "DELETE": return new DeleteMethod();
                case "GET": return new GetMethod();
                case "HEAD": return new HeadMethod();
                case "LOCK": return new LockMethod();
                case "MKCOL": return new MkColMethod();
                case "MOVE": return new MoveMethod();
                case "OPTIONS": return new OptionsMethod();
                case "PROPFIND": return new PropFindMethod();
                case "PROPPATCH": return new PropPatchMethod();
                case "PUT": return new PutMethod();
                case "UNLOCK": return new UnlockMethod();
                default: return null;
            }
        }
    }
}
