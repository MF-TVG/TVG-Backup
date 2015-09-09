using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USAACE.eStaffing.WebDAV.Enum;

namespace USAACE.eStaffing.WebDAV.Response
{
    internal class WebDAVResponse
    {
        private WebDAVResponseStatus _statusCode;
        private String _responseString;
        private Byte[] _responseBinary;
        private Boolean _isBinary;
        private String _contentType;

        internal WebDAVResponse(WebDAVResponseStatus statusCode)
        {
            _statusCode = statusCode;
            _responseString = String.Empty;
            _isBinary = false;
        }

        internal WebDAVResponse(WebDAVResponseStatus statusCode, String responseString)
        {
            _statusCode = statusCode;
            _responseString = responseString;
            _isBinary = false;
            _contentType = "application/xml";
        }

        internal WebDAVResponse(WebDAVResponseStatus statusCode, Byte[] responseBinary, String contentType)
        {
            _statusCode = statusCode;
            _responseBinary = responseBinary;
            _isBinary = true;
            _contentType = contentType;
        }

        internal WebDAVResponseStatus StatusCode
        {
            get
            {
                return _statusCode;
            }
        }

        internal String ResponseString
        {
            get
            {
                return _responseString;
            }
        }

        internal Byte[] ResponseBinary
        {
            get
            {
                return _responseBinary;
            }
        }

        internal Boolean IsBinary
        {
            get
            {
                return _isBinary;
            }
        }

        internal String ContentType
        {
            get
            {
                return _contentType;
            }
        }
    }
}
