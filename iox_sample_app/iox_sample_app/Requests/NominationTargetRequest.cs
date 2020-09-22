using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iox_sample_app.Requests
{
    public class NominationTargetRequest
    {
        public NominationTargetRequest()
        {
            Documents = new List<NominationTargetDocument>();
        }
        public string referenceId { get; set; }
        public string accountReference { get; set; }
        public NominationTargetPersonalDetails PersonalDetails { get; set; }
        public NominationTargetAddressDetails AddressDetails { get; set; }
        public List<NominationTargetDocument> Documents { get; set; }
    }

    public class NominationTargetPersonalDetails
    {
        [MaxLength(3)]
        public string Initials { get; set; } //required
        public string FullName { get; set; } //required
        public string Surname { get; set; } //required
        public string IdNumber { get; set; } //required
        public string Gender { get; set; }//required
        public int IdType { get; set; } //required   |  NominationIdTypes.cs
        public string CountryOfIssue { get; set; } //required
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }

    public class NominationTargetAddressDetails
    {
        public string StreetNo { get; set; } //required
        public string StreetName { get; set; } //required
        public string Suburb { get; set; }
        public string City { get; set; }//required
        public string PostalCode { get; set; }//required

        public string Country { get; set; }//required
    }

    public class NominationTargetDocument
    {
        //Allowed documents: .png .jpeg .pdf
        public string DocumentBase64String { get; set; } //required
        public int DocumentType { get; set; } //required   | NominationDocumentTypes.cs
        public DateTime? ExpiryDate { get; set; }
        public string Reference { get; set; }
    }
}