using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using USAACE.eStaffing.WebDAV.Enum;
using USAACE.eStaffing.WebDAV.Methods;
using USAACE.eStaffing.WebDAV.Response;
using USAACE.eStaffing.WebDAV.Util;

namespace USAACE.eStaffing.WebDAV.Processors
{
    internal static class RequestProcessor
    {
        internal static void ProcessRequest(HttpContext application)
        {
            try
            {
                if (application.Request.IsAuthenticated == false && application.Request.IsSecureConnection == true)
                {
                    application.Response.StatusCode = (Int32)WebDAVResponseStatus.Unauthorized;
                }
                else
                {
                    application.Response.Clear();
                    application.Response.ClearContent();

                    application.Response.AddHeader("Persistent-Auth", "true");
                    application.Response.AddHeader("Cache-Control", "no-cache");

                    MethodBase method = MethodBase.GetMethodHandler(application.Request.HttpMethod);

                    WebDAVResponse result = method.ExecuteRequest(application);
                    application.Response.StatusCode = (Int32)result.StatusCode;

                    if (!String.IsNullOrEmpty(result.ContentType))
                    {
                        application.Response.AddHeader("Content-Type", result.ContentType);
                    }

                    if (result.IsBinary)
                    {
                        application.Response.AddHeader("Content-Length", result.ResponseBinary.Length.ToString());
                        application.Response.BinaryWrite(result.ResponseBinary);

                        LogUtil.LogResponse(application.Response, result.ResponseBinary);
                    }
                    else
                    {
                        application.Response.ContentEncoding = Encoding.UTF8;
                        application.Response.AddHeader("Content-Length", result.ResponseString.Length.ToString());
                        application.Response.Write(result.ResponseString);

                        LogUtil.LogResponse(application.Response, result.ResponseString);
                    }
                }

                application.ApplicationInstance.CompleteRequest();
            }
            catch (ThreadAbortException)
            {
                Thread.ResetAbort();
            }
            catch (Exception)
            {

            }
        }
    }
}
