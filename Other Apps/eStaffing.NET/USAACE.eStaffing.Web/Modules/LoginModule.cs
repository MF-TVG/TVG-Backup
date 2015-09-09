using System;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Web;
using USAACE.eStaffing.Web.Util;
using USAACE.eStaffing.WebDAV.Constants;

namespace USAACE.eStaffing.Web.Modules
{
    public class LoginModule : IHttpModule
    {
        private static readonly Int32[] ERROR_CODES = { 401, 403, 404, 500 };

        public void Dispose()
        {
        }

        public void Init(HttpApplication application)
        {
            application.AuthenticateRequest += OnAuthenticateRequest;
            application.PostAuthenticateRequest += OnPostAuthenticateRequest;
            FederatedAuthentication.SessionAuthenticationModule.SessionSecurityTokenReceived += SessionAuthenticationModule_SessionSecurityTokenReceived;
        }

        private void SessionAuthenticationModule_SessionSecurityTokenReceived(object sender, SessionSecurityTokenReceivedEventArgs e)
        {
            /*SessionAuthenticationModule sam = sender as SessionAuthenticationModule;
            DateTime now = DateTime.UtcNow;
            DateTime validFrom = e.SessionToken.ValidFrom;
            DateTime validTo = e.SessionToken.ValidTo;
            if (now < validTo && now > validFrom.AddMinutes(validTo.Subtract(validFrom).TotalMinutes / 2))
            {
                e.SessionToken = sam.CreateSessionSecurityToken(e.SessionToken.ClaimsPrincipal, e.SessionToken.Context, now, now.AddMinutes(2), e.SessionToken.IsPersistent);
                e.ReissueCookie = true;
            }
            else
            {
                sam.DeleteSessionTokenCookie();

                e.Cancel = true;
            }*/
        }

        private void OnAuthenticateRequest(object sender, EventArgs e)
        {


            HttpContext current = HttpContext.Current;

            if (current.Request.AppRelativeCurrentExecutionFilePath == "~/" && WebDAVConstants.WEBDAV_METHODS.Contains(current.Request.HttpMethod) == false)
            {
                current.Response.Redirect("~/Home.aspx", false);
                current.ApplicationInstance.CompleteRequest();
            }
        }

        private void OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpContext current = HttpContext.Current;

            String executionPath = current.Request.AppRelativeCurrentExecutionFilePath.ToLower();
            SessionAuthenticationModule sessionAuthModule = FederatedAuthentication.SessionAuthenticationModule;

            if (executionPath.StartsWith("~/pages"))
            {
                if (!LoginUtil.CurrentUserLoggedIn())
                {
                    current.Response.Redirect(String.Format("~/Login.aspx?ReturnUrl={0}", HttpUtility.UrlEncode(current.Request.RawUrl)), false);
                    current.ApplicationInstance.CompleteRequest();
                }
            }

            if (LoginUtil.CurrentUserLoggedIn() && sessionAuthModule.ContextSessionSecurityToken == null)
            {
                ClaimsIdentity identity = new ClaimsIdentity((HttpContext.Current.User.Identity as ClaimsIdentity).Claims, "Federated");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                SessionSecurityToken token = new SessionSecurityToken(principal);
                token.IsPersistent = true;

                sessionAuthModule.WriteSessionTokenToCookie(token);
            }
        }
    }
}
