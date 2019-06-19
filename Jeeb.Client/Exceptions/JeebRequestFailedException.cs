using System;
using System.Collections.Generic;
using System.Text;

namespace Jeeb.Client.Exceptions
{
    public class JeebRequestFailedException : Exception
    {
        public int HttpStatusCode { get; }

        public int? ErrorCode { get; }

        public JeebRequestFailedException(string errorMessage, int? errorCode, int httpStatusCode)
            : base(errorMessage)
        {
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
        }

        public JeebRequestFailedException(string errorMessage, int? errorCode)
            : base(errorMessage)
        {
            ErrorCode = errorCode;
            HttpStatusCode = -1;
        }
    }
}
