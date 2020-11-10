using System;
using System.Collections.Generic;
using System.Text;
using Jeeb.Client.Dtos;

namespace Jeeb.Client.Exceptions
{
    public class RequestFailedException : Exception
    {
        private readonly Response _response;
        private readonly string _message;

        public RequestFailedException(string message)
        {
            _message = message;
        }

        public RequestFailedException(Response response)
        {
            _response = response;
        }

        public override string Message
        {
            get
            {
                if (_response == null) return _message;
                var sb = new StringBuilder();
                sb.AppendLine($"Status: {_response.Status}");
                if (!string.IsNullOrEmpty(_response.Message))
                    sb.AppendLine(_response.Message);
                if (_response.Details == null) return sb.ToString();

                foreach (var detail in _response.Details)
                {
                    sb.AppendLine($"{detail.Field}: {detail.Message}");
                }

                return sb.ToString();
            }
        }
    }
}