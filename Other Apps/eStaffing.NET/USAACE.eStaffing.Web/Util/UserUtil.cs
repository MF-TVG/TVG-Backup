using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using USAACE.eStaffing.Business.Constants;

namespace USAACE.eStaffing.Web.Util
{
    public static class UserUtil
    {
        private static readonly String[] WINDOWS_AUTH_TYPES = { "Kerberos", "Negotiate", "NTLM" };
        private static readonly String[] SSO_AUTH_TYPES = { "Federation" };

        public static String GetAuthenticationName(IPrincipal user)
        {
            String authenticationType = user != null && user.Identity.IsAuthenticated == true ? user.Identity.AuthenticationType : String.Empty;

            if (WINDOWS_AUTH_TYPES.Contains(authenticationType))
            {
                return AuthenticationTypeConstants.WINDOWS_AUTH_NAME;
            }
            else if (SSO_AUTH_TYPES.Contains(authenticationType))
            {
                return AuthenticationTypeConstants.SSO_AUTH_NAME;
            }
            else
            {
                return null;
            }
        }
    }
}
