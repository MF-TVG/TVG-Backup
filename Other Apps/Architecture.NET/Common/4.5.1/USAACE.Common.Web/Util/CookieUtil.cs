using System;
using System.Web;

namespace USAACE.Common.Web.Util
{
    public static class CookieUtil
    {
        public static void ForceCookieExpiration(HttpContext context, String cookieName)
        {
            if (context.Request.Cookies[cookieName] != null)
            {
                HttpCookie cookie = context.Request.Cookies[cookieName];
                cookie.Expires = DateTime.Now.AddDays(-1);
                context.Response.SetCookie(cookie);
            }
        }

        public static String TryGetCookieValue(HttpContext context, String cookieName)
        {
            return context.Request.Cookies[cookieName] != null ? context.Request.Cookies[cookieName].Value : null;
        }

        public static void SetCookieValue(HttpContext context, String cookieName, String value, Nullable<DateTime> expiration)
        {
            context.Response.Cookies[cookieName].Value = value;

            if (expiration.HasValue)
            {
                context.Response.Cookies[cookieName].Expires = expiration.Value;
            }
        }
    }
}