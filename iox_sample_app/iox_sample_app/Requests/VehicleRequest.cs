using System;

namespace iox_sample_app.Requests
{
    public class VehicleRequest
    {
        public string referenceId { get; set; }
        public string accountReference { get; set; }
        public string licenseNumber { get; set; }               // the vehicles license plate

        public string vinNumber { get; set; } //Vin Number is used to unique identify a vehicle

        public string vehicleRegisterNo { get; set; }

        public string engineNumber { get; set; }

        public string licenseDiscNumber { get; set; }

        public DateTime licenseExpiryDate { get; set; }

        public int categoryId { get; set; }                     // VehicleCategories.cs

        public int? descriptionId { get; set; }

        public int tare { get; set; }

        public string make { get; set; }
        public string model { get; set; }
        public string colour { get; set; }

        public string discImage { get; set; }                   // base64 encoded string of the current license disc image

        public string individualIdNumber { get; set; } //For private account vehicles
        public string brn { get; set; }  //For business account vehicles
        public string departmentName { get; set; }
    }
}