using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Jeeb.Client.Dtos
{
    public class Response<T> : Response
    {
        [DeserializeAs(Name = "result")]
        public T Result { set; get; }
    }
    
    public class Response
    {
        [DeserializeAs(Name = "succeed")]
        public bool Succeed { set; get; }

        [DeserializeAs(Name = "status")]
        public int Status { get; set; }

        [DeserializeAs(Name = "message")]
        public string Message { set; get; }

        [DeserializeAs(Name = "code")]
        public int? Code { set; get; }

        [DeserializeAs(Name = "details")]
        public List<ValidationError> Details { set; get; }

        [DeserializeAs(Name = "version")]
        public string Version { set; get; }
    }
    
    public class ValidationError
    {
        [DeserializeAs(Name = "field")]
        public string Field { get; set; }

        [DeserializeAs(Name = "message")]
        public string Message { get; set; }
    }

}
