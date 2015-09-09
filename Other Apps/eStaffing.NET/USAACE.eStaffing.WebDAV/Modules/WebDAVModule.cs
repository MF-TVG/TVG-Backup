using System;
using System.IO;
using System.Web;
using USAACE.eStaffing.WebDAV.Constants;
using USAACE.eStaffing.WebDAV.Processors;
using USAACE.eStaffing.WebDAV.Util;

namespace USAACE.eStaffing.WebDAV.Modules
{
    public class WebDAVModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.AuthorizeRequest += OnAuthorizeRequest;
        }

        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext current = HttpContext.Current;
            HttpRequest request = current.Request;

            String executionPath = request.AppRelativeCurrentExecutionFilePath.ToLower();

            if (WebDAVConstants.WEBDAV_METHODS.Contains(request.HttpMethod) || executionPath.StartsWith("~/files"))
            {
                LogUtil.LogRequest(request);
            }
        }

        private void OnAuthorizeRequest(Object sender, EventArgs e)
        {
            HttpContext current = HttpContext.Current;
            HttpRequest request = current.Request;

            String executionPath = request.AppRelativeCurrentExecutionFilePath.ToLower();

            if (WebDAVConstants.WEBDAV_METHODS.Contains(request.HttpMethod) || (executionPath.StartsWith("~/files") && current.User != null && current.User.Identity.IsAuthenticated))
            {
                RequestProcessor.ProcessRequest(current);
            }
        }
    }
}
