using System.ComponentModel.DataAnnotations;

namespace iox_sample_app.Requests
{
    public class AccountOTPRequest
    {
        [Required]
        public string accountReference { get; set; }

        [Required]
        public string referenceId { get; set; }
    }
}