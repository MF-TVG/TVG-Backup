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
    internal class PutMethod : MethodBase
    {
        internal override WebDAVResponse ExecuteRequest(HttpContext application)
        {
            String appPath = PathUtil.GetAppRelativePath(application.Request);

            String[] pathResults = appPath.Split(new char[] { '/' });

            if (pathResults.Count() == 3 && pathResults[0].ToLower() == "files" && pathResults[1].ToNullable<Int32>().HasValue)
            {
                StreamReader stream = new StreamReader(application.Request.InputStream);
                Int32 streamLength = (Int32)stream.BaseStream.Length;

                if (streamLength > 0)
                {
                    Byte[] content = new Byte[streamLength];
                    application.Request.InputStream.Read(content, 0, streamLength);

                    if (application.Request.Headers["X-MSDAVEXT"] == "PROPPATCH")
                    {
                        String contentString = Encoding.Default.GetString(content);

                        Int32 headerLength = Convert.ToInt32(contentString.Substring(0, 16), 16);

                        Int32 dataLength = Convert.ToInt32(contentString.Substring(16 + headerLength, 16), 16);

                        content = content.Skip(headerLength + 32).ToArray();
                    }

                    FormAttachment attachment = new FormAttachment { FormID = pathResults[1].ToNullable<Int32>() };

                    IList<FormAttachment> formAttachments = DataService.ListFormAttachments(attachment);

                    FormAttachment requestedAttachment = formAttachments.FirstOrDefault(x => x.FileName == pathResults[2]);

                    if (requestedAttachment == null)
                    {
                        requestedAttachment = new FormAttachment();
                        requestedAttachment.FileName = pathResults[2];
                        requestedAttachment.FormID = pathResults[1].ToNullable<Int32>();
                        requestedAttachment.CreationDate = DateTime.Now;
                    }

                    requestedAttachment.LastModifiedDate = DateTime.Now;
                    requestedAttachment.FileSize = streamLength;
                    requestedAttachment.ContentType = System.Web.MimeMapping.GetMimeMapping(requestedAttachment.FileName);
                    requestedAttachment = DataService.SaveFormAttachment(requestedAttachment);

                    FormAttachmentData attachmentData = new FormAttachmentData { FormAttachmentID = requestedAttachment.FormAttachmentID };
                    attachmentData = DataService.LoadFormAttachmentData(attachmentData);

                    if (content.Length != 0)
                    {
                        attachmentData.FileContent = content;
                        attachmentData = DataService.SaveFormAttachmentData(attachmentData);
                    }
                }
            }

            return new WebDAVResponse(WebDAVResponseStatus.Ok);
        }
    }
}
