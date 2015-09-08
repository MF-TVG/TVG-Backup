using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USAACE.Common.Exceptions
{
    [Serializable]
    public class USAACEException : Exception
    {
        private ExceptionType _type;

        public USAACEException(ExceptionType type, String message) : base(message)
        {
            _type = type;
        }

        public ExceptionType Type
        {
            get
            {
                return _type;
            }
        }
    }
}
