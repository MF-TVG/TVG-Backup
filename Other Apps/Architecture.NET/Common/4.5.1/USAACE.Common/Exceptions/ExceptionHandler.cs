using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USAACE.Common.Exceptions
{
    /// <summary>
    /// A class used to assist in the handling of exceptions
    /// </summary>
    public static class ExceptionHandler
    {
        /// <summary>
        /// Handles the exception
        /// </summary>
        /// <param name="ex">The exception to handle</param>
        public static void HandleException(Exception ex)
        {
            if (ex is USAACEException)
            {
                USAACEException exception = ex as USAACEException;

                
            }
            else
            {

            }
        }
    }
}
