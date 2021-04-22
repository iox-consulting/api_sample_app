using System.ComponentModel;

namespace iox_sample_app.Requests.Enums
{
    public enum DocumentOwnerType
    {
        [Description("account")]
        Account = 1,
        [Description("individual")]
        Individual = 2,
        [Description("brn")]
        Brn = 12,
    }
}
