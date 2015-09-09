using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using USAACE.Common;
using USAACE.eStaffing.Business.Services;
using USAACE.eStaffing.Domain.Entities;
using USAACE.eStaffing.WebDAV.Enum;
using USAACE.eStaffing.WebDAV.Response;
using USAACE.eStaffing.WebDAV.Util;

namespace USAACE.eStaffing.WebDAV.Methods
{
    internal class PropFindMethod : MethodBase
    {
        internal override WebDAVResponse ExecuteRequest(HttpContext application)
        {
            StringBuilder result = new StringBuilder();

            String appPath = PathUtil.GetAppRelativePath(application.Request);
            String absolutePath = HttpUtility.UrlDecode(application.Request.Url.AbsolutePath);

            String[] pathResults = appPath.Split(new char[] { '/' });

            if (absolutePath.EndsWith("desktop.ini"))
            {
                return new WebDAVResponse(WebDAVResponseStatus.NotFound);
            }
            else if (pathResults.Count() == 1 && pathResults[0].ToLower() == String.Empty)
            {
                result.Append(XML_DECLARE);
                result.Append(MULTISTATUS_START);
                result.Append(XmlUtil.GetStaticFolderNode(String.Empty, absolutePath, 1));

                if (application.Request.Headers["Depth"] == "1")
                {
                    IList<Form> forms = DataService.ListForms();

                    result.Append(XmlUtil.GetStaticFolderNode("Files", absolutePath + "/Files", forms.Count));
                }

                result.Append("</D:multistatus>");
            }
            else if (pathResults.Count() == 1 && pathResults[0].ToLower() == "files")
            {
                IList<Form> forms = DataService.ListForms();

                result.Append(XML_DECLARE);
                result.Append(MULTISTATUS_START);
                result.Append(XmlUtil.GetStaticFolderNode("Files", absolutePath + "/", forms.Count));

                if (application.Request.Headers["Depth"] == "1")
                {
                    foreach (Form form in forms.Take(1000))
                    {
                        result.Append(XmlUtil.GetStaticFolderNode(form.FormID.ToString(), absolutePath + "/" + form.FormID.ToString(), 0));
                    }
                }

                result.Append("</D:multistatus>");
            }
            else if (pathResults.Count() == 2 && pathResults[0].ToLower() == "files" && pathResults[1].ToNullable<Int32>().HasValue)
            {
                FormAttachment attachment = new FormAttachment { FormID = pathResults[1].ToNullable<Int32>() };

                IList<FormAttachment> formAttachments = DataService.ListFormAttachments(attachment);

                result.Append(XML_DECLARE);
                result.Append(MULTISTATUS_START);
                result.Append(XmlUtil.GetStaticFolderNode(attachment.FormID.ToString(), absolutePath + "/", formAttachments.Count));
                
                if (application.Request.Headers["Depth"] == "1")
                {
                    foreach (FormAttachment formAttachment in formAttachments)
                    {
                        result.Append(XmlUtil.GetStaticFileNode(absolutePath + "/", formAttachment));
                    }
                }

                result.Append("</D:multistatus>");
            }
            else if (pathResults.Count() == 3 && pathResults[0].ToLower() == "files" && pathResults[1].ToNullable<Int32>().HasValue)
            {
                FormAttachment attachment = new FormAttachment { FormID = pathResults[1].ToNullable<Int32>() };

                IList<FormAttachment> formAttachments = DataService.ListFormAttachments(attachment);

                FormAttachment requestedAttachment = formAttachments.FirstOrDefault(x => x.FileName == pathResults[2]);

                if (requestedAttachment != null)
                {
                    result.Append(XML_DECLARE);
                    result.Append(MULTISTATUS_START);
                    result.Append(XmlUtil.GetStaticFileNode(absolutePath.Replace(pathResults[2], String.Empty), requestedAttachment));
                    result.Append("</D:multistatus>");
                }
                else
                {
                    return new WebDAVResponse(WebDAVResponseStatus.NotFound);
                }
            }
            else
            {
                return new WebDAVResponse(WebDAVResponseStatus.NotFound);
            }

            application.Response.AddHeader("X-MS-InvokeApp", "1");

            return new WebDAVResponse(WebDAVResponseStatus.MultiStatus, result.ToString());
        }

    }
}
