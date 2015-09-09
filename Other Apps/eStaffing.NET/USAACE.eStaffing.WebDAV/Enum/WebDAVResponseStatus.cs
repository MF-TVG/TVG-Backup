using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.eStaffing.WebDAV.Enum
{
    internal enum WebDAVResponseStatus : int
    {
        None = 0,
        Ok = 200,
        NoContent = 204,
        MultiStatus = 207,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        PreconditionFailed = 412,
        ServerError = 500,
        MethodNotImplemented = 501
    }
}
