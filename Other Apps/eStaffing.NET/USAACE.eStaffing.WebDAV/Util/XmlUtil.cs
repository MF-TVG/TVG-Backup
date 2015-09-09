using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.eStaffing.Domain.Entities;

namespace USAACE.eStaffing.WebDAV.Util
{
    internal static class XmlUtil
    {
        internal static String GetStaticFolderNode(String folder, String path, Int32 contentLength)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<D:response>");
            result.AppendFormat("<D:href>{0}</D:href>", path);
            result.Append("<D:propstat><D:prop>");
            result.Append("<D:getcontenttype>application/octet-stream</D:getcontenttype>");
            result.Append("<D:getlastmodified>2014-01-01T00:00:00Z</D:getlastmodified>");
            result.Append("<D:creationdate>2014-01-01T00:00:00Z</D:creationdate>");
            result.Append("<D:iscollection>1</D:iscollection>");
            result.Append("<D:ishidden>0</D:ishidden>");
            result.Append("<D:isFolder>t</D:isFolder>");
            result.AppendFormat("<D:displayname>{0}</D:displayname>", !String.IsNullOrEmpty(folder) ? folder : "DavWWWRoot");
            result.Append("<D:resourcetype><D:collection /></D:resourcetype>");
            result.Append("<D:supportedlock /><D:lockdiscovery />");
            result.Append("<D:getcontentlanguage>en-us</D:getcontentlanguage>");
            result.AppendFormat("<D:getcontentlength>{0}</D:getcontentlength>", contentLength.ToString());
            result.Append("</D:prop><D:status>HTTP/1.1 200 OK</D:status></D:propstat>");
            result.Append("</D:response>");

            return result.ToString();
        }

        internal static String GetStaticFileNode(String rootPath, FormAttachment attachment)
        {
            Guid fileGuid = new Guid(attachment.FormAttachmentID.ToString().PadLeft(32, '0'));

            StringBuilder result = new StringBuilder();
            
            result.Append("<D:response>");
            result.AppendFormat("<D:href>{0}{1}</D:href>", rootPath, attachment.FileName);
            result.Append("<D:propstat><D:prop>");
            result.AppendFormat("<D:getcontenttype>{0}</D:getcontenttype>", attachment.ContentType);
            result.AppendFormat("<D:getlastmodified>{0}</D:getlastmodified>", GetFormattedDate(attachment.LastModifiedDate.GetValueOrDefault(DateTime.Now)));
            result.AppendFormat("<D:creationdate>{0}</D:creationdate>", GetFormattedDate(attachment.CreationDate.GetValueOrDefault(DateTime.Now)));
            result.AppendFormat("<D:displayname>{0}</D:displayname>", attachment.FileName);
            result.Append("<D:resourcetype />");
            result.Append("<D:supportedlock>");
            result.Append("<D:lockentry><D:lockscope><D:exclusive /></D:lockscope><D:locktype><D:write /></D:locktype></D:lockentry>");
            result.Append("<D:lockentry><D:lockscope><D:shared /></D:lockscope><D:locktype><D:write /></D:locktype></D:lockentry>");
            result.Append("</D:supportedlock>");
            //result.Append("<D:lockdiscovery />");
            result.Append("<D:getcontentlanguage>en-us</D:getcontentlanguage>");
            result.AppendFormat("<D:getcontentlength>{0}</D:getcontentlength>", attachment.FileSize.GetValueOrDefault(0).ToString());
            result.AppendFormat("<Repl:repl-uid>rid:{0}</Repl:repl-uid>", fileGuid.ToString("B").ToUpper());
            result.AppendFormat("<Repl:resourcetag>rt:{0}@00000000001</Repl:resourcetag>", fileGuid.ToString("D").ToUpper());
            result.AppendFormat("<D:getetag>&quot;{0},1&quot;</D:getetag>", fileGuid.ToString("B").ToUpper());
            result.Append("</D:prop><D:status>HTTP/1.1 200 OK</D:status></D:propstat>");
            result.Append("</D:response>");

            return result.ToString();
        }

        private static String GetFormattedDate(DateTime date)
        {
            return String.Format("{0}Z", date.ToUniversalTime().ToString("s"));
        }
    }
}
