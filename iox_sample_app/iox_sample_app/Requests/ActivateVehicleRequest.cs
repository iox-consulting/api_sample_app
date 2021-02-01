namespace iox_sample_app.Requests
{
    public class ActivateVehicleRequest
    {
        public string referenceId { get; set; }
        public string accountReference { get; set; }
        
        public string vehicleReference { get; set; }
    }
}