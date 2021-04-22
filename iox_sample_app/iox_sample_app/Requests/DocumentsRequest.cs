using System;
using System.Collections.Generic;

namespace iox_sample_app.Requests
{
    public class DocumentsRequest
    {
        public string referenceId { get; set; }
        public string accountReference { get; set; }
        public List<DocumentItem> documents { get; set; }
    }

    public class DocumentItem
    {
        public string document { get; set; }
        public string ownerReference { get; set; }
        public int documentType { get; set; }
        public int ownerType { get; set; }
        public bool expires { get; set; } = false;
        public DateTime? expiryDate { get; set; }


    }
}
