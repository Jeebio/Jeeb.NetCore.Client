using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Deserializers;

namespace Jeeb.Client.Models
{
    public class Response<T>
    {
        [DeserializeAs(Name = "result")]
        public T Result { set; get; }

        [DeserializeAs(Name = "hasError")]
        public bool HasError { set; get; }

        [DeserializeAs(Name = "errorCode")]
        public int? ErrorCode { set; get; }
        
        [DeserializeAs(Name = "errorMessage")]
        public string ErrorMessage { set; get; }
    }
}
