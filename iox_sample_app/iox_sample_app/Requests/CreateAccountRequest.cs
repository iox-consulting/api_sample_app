using iox_sample_app.Helper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iox_sample_app.Requests
{
    public class CreateAccountRequest
    {
        public CreateAccountRequest()
        {
            brn = new List<BRN>();
            vehicles = new List<Vehicles>();
            Individuals = new List<Individual>();
            departments = new List<Department>();
        }
        [Required]
        public string referenceId { get; set; } // unique id that the 3rd party can use to identify the account with

        [Required]
        public bool isBusinessAccount { get; set; }

        [Required]
        public string accountName { get; set; }

        [EmailAddress]
        public string accountEmail { get; set; }

        [RequiredOnlyIfBusinessAccount]
        public string companyRegistrationNumber { get; set; }

        [Required]
        public string contactPersonFirstName { get; set; }

        [Required]
        public string contactPersonLastName { get; set; }

        [AtleastOneRequiredForBusinessAccount]
        public List<BRN> brn { get; set; }

        public List<Department> departments { get; set; }

        [RequiredForPrivateAccounts]
        public string IdentificationNumber { get; set; }

        public string accountContactNumber { get; set; }
        public List<Vehicles> vehicles { get; set; }
        public List<Individual> Individuals { get; set; }
    }

    public class BRN
    {
        [Required]
        public string BRNNumber { get; set; }

        [Required]
        public string IndividualIdNumber { get; set; }
    }

    public class Individual
    {
        [Required]
        public string IdType { get; set; }             // RSAID | Passport | TRN

        [Required]
        public string IdNumber { get; set; }

        [Required]
        public string initials { get; set; }

        [Required]
        public string firstname { get; set; }

        [Required]
        public string lastname { get; set; }

        public string driversLicenseImage { get; set; }
        public string driversLicenseNumber { get; set; }
        public DateTime? driversLicenseExpiryDate { get; set; }
    }

    public class Department
    {
        [Required]
        public string name { get; set; }
    }

    public class Vehicles
    {
        [Required]
        public string licenseNumber { get; set; }  // The vehicle's license plate

        [Required]
        public string vinNumber { get; set; }

        [Required]
        public string vehicleRegisterNo { get; set; }

        [Required]
        public string licenseDiscNumber { get; set; }

        [Required]
        public DateTime? licenseExpiryDate { get; set; }

        [Required]
        public int categoryId { get; set; } // Vehicle Types (Requests/VehicleCategories.cs)
        [Required]
        public int descriptionId { get; set; }

        [Required]
        public int tare { get; set; }

        [Required]
        public string make { get; set; }

        [Required]
        public string model { get; set; }

        [Required]
        public string colour { get; set; }

        public string discImage { get; set; } // base64 encoded string of the current license disc image
        public string IndividualIdNumber { get; set; }
        public string brn { get; set; } // Optional | When adding a value this value should match a BRNNumber in the CreateAccountRequest's BRN array.
        public string departmentName { get; set; }
        public string engineNumber { get; set; }
    }
}