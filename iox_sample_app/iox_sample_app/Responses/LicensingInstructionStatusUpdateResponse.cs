using iox_sample_app.Requests.Enums;
using System;
using System.Collections.Generic;

namespace iox_sample_app.Responses
{
    public class LicensingInstructionStatusUpdateResponse
    {
        public eLicensingInstructionStatus StatusId { get; set; }

        public string RequestReference { get; set; }

        public object AdditionalDetails { get; set; }

        public int Progress { get; set; }

        public string StatusName { get; set; }
    }

    public class LicensingInstructionFailedResponse
    {
        public string requestReference { get; set; }

        public string vehicleRegisterNumber { get; set; }
        public string vehicleLicenseNumber { get; set; }
        public string failureReason { get; set; }
        public bool cancelled { get; set; }
    }

    public class LicensingInstructionCompletedResponse
    {
        public string requestReference { get; set; }

        public string vehicleRegisterNumber { get; set; }
        public string vehicleLicenseNumber { get; set; }
        public DateTime estimatedDeliveryDate { get; set; }
        public string newLicenseDiscNo { get; set; }
        public DateTime licenseExpiryDate { get; set; }
        public string licenseNo { get; set; }

        public bool reprintRequired { get; set; }

        public string reprintReason { get; set; }

        public bool reprintIncludedAdditional { get; set; }
    }

    public class LicensingInstructionCourierUpdateResponse
    {
        public string requestReference { get; set; }

        public string vehicleRegisterNumber { get; set; }
        public string vehicleLicenseNumber { get; set; }
        public string waybillTrackingNo { get; set; }
        public string courierCompany { get; set; }
        public string trackingUri { get; set; }
        public string deliveryBatchReference { get; set; }
        public DateTime estimatedDeliveryDate { get; set; }
        public List<LicensingInstructionCourierUpdateResponseTrackingEvent> trackingEvents { get; set; }
    }

    public class LicensingInstructionCourierUpdateResponseTrackingEvent
    {
        public DateTime timestamp;
        public string trackingEvent;
    }

    public class LicensingInstructionUpdateGeneralDetails
    {
        public string requestReference { get; set; }

        public string vehicleRegisterNumber { get; set; }
        public string vehicleLicenseNumber { get; set; }
    }

}
