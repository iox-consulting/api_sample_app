namespace iox_sample_app.Responses
{
    public class QuoteCreatedRealtimeResponse
    {
        public bool success { get; set; }
        public string accountReference { get; set; }
        public QuoteCreatedResponse quote { get; set; }
    }
}
