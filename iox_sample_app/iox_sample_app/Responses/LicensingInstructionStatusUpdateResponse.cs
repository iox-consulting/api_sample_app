namespace iox_sample_app.Responses
{
    public class LicensingInstructionStatusUpdateResponse
    {
        public int StatusId { get; set; }

        public string RequestReference { get; set; }

        public object AdditionalDetails { get; set; }

        public int Progress { get; set; }

        public string StatusName { get; set; }
    }
}
