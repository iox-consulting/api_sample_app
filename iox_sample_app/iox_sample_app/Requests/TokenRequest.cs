namespace iox_sample_app.Requests
{
    public class TokenRequest
    {
        public TokenRequest(string username, string apikey)
        {
            this.username = username;
            this.apikey = apikey;
        }

        public string username { get; set; }
        public string apikey { get; set; }
    }
}