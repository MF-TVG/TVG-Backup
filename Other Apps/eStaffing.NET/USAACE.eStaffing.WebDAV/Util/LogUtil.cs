using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace USAACE.eStaffing.WebDAV.Util
{
    internal class LogUtil
    {
        internal static void LogRequest(HttpRequest request)
        {
            StringBuilder logEntry = new StringBuilder();

            logEntry.AppendFormat("{0} {1} {2}", request.HttpMethod, request.RawUrl, request.ServerVariables["SERVER_PROTOCOL"]);
            logEntry.AppendLine();

            foreach (String header in request.Headers.AllKeys)
            {
                logEntry.AppendFormat("{0}: {1}", header, request.Headers[header]);
                logEntry.AppendLine();
            }

            MemoryStream memoryStream = new MemoryStream();
            request.InputStream.Position = 0;
            request.InputStream.CopyTo(memoryStream);
            memoryStream.Position = 0;

            StreamReader reader = new StreamReader(memoryStream);
            
            String fullRequest = reader.ReadToEnd();
            logEntry.AppendLine(fullRequest);

            reader.Close();

            request.InputStream.Position = 0;

            String logEntryString = logEntry.ToString();

            System.Diagnostics.Debug.WriteLine(logEntryString);
        }

        internal static void LogResponse(HttpResponse response, Object result)
        {
            StringBuilder logEntry = new StringBuilder();

            logEntry.AppendFormat("{0}", response.StatusCode.ToString());
            logEntry.AppendLine();

            foreach (String header in response.Headers.AllKeys)
            {
                logEntry.AppendFormat("{0}: {1}", header, response.Headers[header]);
                logEntry.AppendLine();
            }

            logEntry.AppendLine(result.ToString());

            String logEntryString = logEntry.ToString();

            System.Diagnostics.Debug.WriteLine(logEntryString);
        }
    }
}
