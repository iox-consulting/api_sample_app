using System.Collections.Generic;

namespace iox_sample_app.Requests
{
    public class AccountInviteTokenRequest
    {
        public AccountInviteTokenRequest()
        {
            accountInvites = new List<AccountInvite>();
        }

        public string accountReference { get; set; }
        public string referenceId { get; set; }
        public List<AccountInvite> accountInvites { get; set; }
    }

    public class AccountInvite
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
    }
}