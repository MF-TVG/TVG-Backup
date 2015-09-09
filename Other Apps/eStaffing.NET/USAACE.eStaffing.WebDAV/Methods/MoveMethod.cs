using System;
using System.Collections.Generic;
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
    internal class MoveMethod : MethodBase
    {
        internal override WebDAVResponse ExecuteRequest(HttpContext application)
        {
            String appPath = PathUtil.GetAppRelativePath(application.Request);

            String[] pathResults = appPath.Split(new char[] { '/' });

            String destinationUrl = application.Request.Headers["Destination"];

            if (String.IsNullOrEmpty(destinationUrl))
            {
                return new WebDAVResponse(WebDAVResponseStatus.MethodNotAllowed);
            }

            String destinationPath = PathUtil.GetAppRelativePath(destinationUrl);

            String[] destinationPathResults = destinationPath.Split(new char[] { '/' });

            if (pathResults.Count() == 3 && destinationPathResults.Count() == 3 && pathResults[0].ToLower() == "files" && pathResults[1].ToNullable<Int32>().HasValue)
            {
                FormAttachment attachment = new FormAttachment { FormID = pathResults[1].ToNullable<Int32>() };

                IList<FormAttachment> formAttachments = DataService.ListFormAttachments(attachment);

                FormAttachment requestedAttachment = formAttachments.FirstOrDefault(x => x.FileName == pathResults[2]);

                if (requestedAttachment != null)
                {
                    FormAttachment oldAttachment = formAttachments.FirstOrDefault(x => x.FileName == destinationPathResults[2]);

                    requestedAttachment.FileName = destinationPathResults[2];
                    DataService.SaveFormAttachment(requestedAttachment);

                    if (oldAttachment != null)
                    {
                        DataService.DeleteFormAttachment(oldAttachment);
                    }

                    return new WebDAVResponse(WebDAVResponseStatus.NoContent);
                }
                else
                {
                    return new WebDAVResponse(WebDAVResponseStatus.NotFound);
                }
            }
            else
            {
                return new WebDAVResponse(WebDAVResponseStatus.MethodNotAllowed);
            }
        }
    }
}
