namespace iox_sample_app.Requests
{
    public class CreateDealerStockInstructionRequest
    {
        public string referenceId { get; set; }
        
        public string accountReference { get; set; }
        
        public string brnNumber { get; set; }
        
        public string vehicleRegisterNumber { get; set; }
        
        public string preFilledNCODocument { get; set; }
        
        public string vehiclePaidInFullLetterDocument { get; set; }
    }
}