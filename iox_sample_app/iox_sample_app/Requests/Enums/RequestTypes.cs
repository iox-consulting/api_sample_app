using System.ComponentModel;

namespace iox_sample_app.Requests.Enums
{
    public enum RequestTypes
    {
        [Description("Create BRN")] CreateBrn = 1,

        [Description("Update BRN")] UpdateBrn = 2,

        [Description("Create Account")] CreateAccount = 3,

        [Description("Account Email Invites")] AccountEmailInvites = 4,

        [Description("Request Account OTP")] RequestAccountOTP = 5,

        [Description("Create Department")] CreateDepartment = 6,

        [Description("Configure Endpoint")] ConfigureEndpoint = 7,

        [Description("Create Individual")] CreateIndividual = 8,

        [Description("Update Individual")] UpdateIndividual = 9,

        [Description("Create Nomination Driver")]
        CreateNominationDriver = 10,

        [Description("Update Nomination Driver")]
        UpdateNominationDriver = 11,

        [Description("Create Vehicle")] CreateVehicle = 12,

        [Description("Update Vehicle")] UpdateVehicle = 13,

        [Description("Create Dealer Stock Instruction")]
        CreateDealerStock = 14,

        [Description("Activate Vehicle")] ActivateVehicle = 15,

        [Description("Deactivate Vehicle")] DeactivateVehicle = 16,

        [Description("Create Quote")] CreateQuote = 17,

        [Description("Upload Documents")] UploadDocuments = 18
    }
}