using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.Web.Util
{
    public static class NavigateUtil
    {
        public static String GetFormAttachmentUrl(FormAttachment attachment)
        {
            return String.Format("javascript:OpenServerDocument(\"{0}\");", HttpUtility.UrlPathEncode(ToAbsoluteUrl(String.Format("~/Files/{0}/{1}", attachment.FormID.ToString(), attachment.FileName))));
        }

        public static String ToAbsoluteUrl(String relativeUrl)
        {
            if (String.IsNullOrEmpty(relativeUrl) || HttpContext.Current == null)
            {
                return relativeUrl;
            }
            
            Uri url = HttpContext.Current.Request.Url;

            if (relativeUrl.StartsWith("/"))
            {
                relativeUrl = relativeUrl.Insert(0, "~");
            }
            else if (!relativeUrl.StartsWith("~/"))
            {
                relativeUrl = relativeUrl.Insert(0, "~/");
            }

            return String.Format("{0}://{1}:{2}{3}", url.Scheme, url.Host, url.Port.ToString(), VirtualPathUtility.ToAbsolute(relativeUrl));
        }

        public static String GetFormLink(Form form)
        {
            return GetFormLink(form.FormID);
        }

        public static String GetFormLink(Nullable<Int32> formId)
        {
            return String.Format("~/Pages/FormEntry.aspx?FormID={0}", formId.ToString());
        }

        public static String GetFormListLink(FormType formType)
        {
            return String.Format("~/Pages/FormList.aspx?FormTypeID={0}", formType.FormTypeID.ToString());
        }

        public static String GetFormAttachmentLink(FormAttachment attachment)
        {
            return String.Format("~/Pages/FileDownload.aspx?AttachmentID={0}", attachment.FormAttachmentID.ToString());
        }

        public static String GetSignatureScript(String hashData, String controlClientId)
        {
            return String.Format("SignData('{0}','{1}')", hashData, controlClientId);
        }
    }
}