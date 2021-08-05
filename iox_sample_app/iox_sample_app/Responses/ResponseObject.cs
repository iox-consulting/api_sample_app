using System.Collections.Generic;

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
        public string details { get; set; }
        public string severity { get; set; }
        public int severityId { get; set; }
    }
}
