using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iox_sample_app.Responses
{
    public class ResponseObject
    {
        public string status { get; set; } = "Success";
        public string requestReference { get; set; }
        public int ResponseType { get; set; }
        public object result { get; set; }
        public List<ResponseError> errors { get; set; }
    }
    public class ResponseError
    {
        public int code { get; set; }
        public string message { get; set; }
    }
}
