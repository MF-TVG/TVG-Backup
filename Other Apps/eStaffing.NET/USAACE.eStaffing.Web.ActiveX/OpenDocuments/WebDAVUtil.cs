using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.Web.ActiveX.OpenDocuments
{
    internal static class WebDAVUtil
    {
        internal static String ConvertUrlToWebDav(String uriString)
        {
            Uri uri = new Uri(uriString);

            return String.Format("\\\\{0}{1}{2}{3}", uri.Host, uri.Scheme == "https" ? "@SSL" : String.Empty,
                uri.IsDefaultPort ? String.Empty : "@" + uri.Port.ToString(), uri.AbsolutePath.Replace("/", "\\"));
        }
    }
}
