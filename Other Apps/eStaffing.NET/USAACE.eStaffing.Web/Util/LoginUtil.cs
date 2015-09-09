using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Linq;
using System.Security.Principal;
using System.Web;
using USAACE.Common.Web.Util;

namespace USAACE.eStaffing.Web.Util
{
    public static class LoginUtil
    {
        public static Boolean CurrentUserLoggedIn()
        {
            return HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static IPrincipal GetCurrentUser()
        {
            return CurrentUserLoggedIn() ? HttpContext.Current.User : null;
        }

        public static String GetDefaultLoginMethod()
        {
            return CookieUtil.TryGetCookieValue(HttpContext.Current, "TRALoginMethod");
        }

        public static void Login(String method)
        {
            CookieUtil.SetCookieValue(HttpContext.Current, "TRALoginMethod", method, DateTime.Now.AddYears(1));
        }

        public static void Logout()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();

            FederatedAuthentication.WSFederationAuthenticationModule.SignOut(false);
            SessionAuthenticationModule module = FederatedAuthentication.SessionAuthenticationModule;
            module.SignOut();

            CookieUtil.ForceCookieExpiration(HttpContext.Current, module.CookieHandler.Name);
            CookieUtil.ForceCookieExpiration(HttpContext.Current, module.CookieHandler.Name + "1");
            CookieUtil.ForceCookieExpiration(HttpContext.Current, "TRALoginMethod");
        }

        public static Boolean IsLoginSuccessful(String authenticationType)
        {
            IPrincipal user = HttpContext.Current.User;

            return user != null && user.Identity.IsAuthenticated == true && UserUtil.GetAuthenticationName(user) == authenticationType;
        }
    }
}