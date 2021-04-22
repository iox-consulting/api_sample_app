using System;

namespace iox_sample_app.Responses
{
    public class DocumentUploadItemResponse
    {
        public int documentType { get; set; }
        public int ownerType { get; set; }

        public string documentTypeName { get; set; }

        public string ownerTypeName { get; set; }

        public string ownerReference { get; set; }
        public bool expires { get; set; }
        public DateTime? expiryDate { get; set; }
        public bool success { get; set; }
        public string errorMessage { get; set; }


    }
}
