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
    internal class DeleteMethod : MethodBase
    {
        internal override WebDAVResponse ExecuteRequest(HttpContext application)
        {
            String appPath = PathUtil.GetAppRelativePath(application.Request);

            String[] pathResults = appPath.Split(new char[] { '/' });

            if (pathResults.Count() == 3 && pathResults[0].ToLower() == "files" && pathResults[1].ToNullable<Int32>().HasValue)
            {
                FormAttachment attachment = new FormAttachment { FormID = pathResults[1].ToNullable<Int32>() };

                IList<FormAttachment> formAttachments = DataService.ListFormAttachments(attachment);

                FormAttachment requestedAttachment = formAttachments.FirstOrDefault(x => x.FileName == pathResults[2]);

                if (requestedAttachment != null)
                {
                    DataService.DeleteFormAttachment(requestedAttachment);

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
