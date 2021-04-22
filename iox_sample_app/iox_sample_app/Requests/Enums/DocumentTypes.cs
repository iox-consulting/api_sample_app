using System.ComponentModel;

namespace iox_sample_app.Requests.Enums
{
    public enum DocumentTypes
    {
        [Description("South African ID")]
        SAID = 1,
        [Description("Passport Document")]
        Passport = 2,
        [Description("Proof of Residence")]
        ProofOfResidence = 3,
        [Description("Drivers License")]
        DriversLicense = 5,
        [Description("Company Registration Document")]
        CompanyProofOfRegistration = 6,
        [Description("Proof of Address")]
        ProofOfAddress = 7,
        [Description("Proxy Authorization Letter")]
        ProxyAuthorizationLetter = 12,
        [Description("BRN certificate")]
        BRNCertificate = 14,
    }
}
