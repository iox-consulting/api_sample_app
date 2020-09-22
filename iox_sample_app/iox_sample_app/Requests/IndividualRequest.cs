using System;
using System.ComponentModel.DataAnnotations;

namespace iox_sample_app.Requests
{
    public class IndividualRequest
    {
        [Required]
        public string referenceId { get; set; }

        [Required]
        public string accountReference { get; set; }

        [Required]
        public string IdType { get; set; } // RSAID | Passport | TRN

        [Required]
        public string IdNumber { get; set; }

        public string driversLicenseImage { get; set; }
        public string driversLicenseNumber { get; set; }
        public DateTime? driversLicenseExpiryDate { get; set; }

        [Required]
        public string initials { get; set; }

        [Required]
        public string firstname { get; set; }

        [Required]
        public string lastname { get; set; }
    }
}