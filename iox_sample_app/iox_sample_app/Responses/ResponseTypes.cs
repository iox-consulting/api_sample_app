using System.ComponentModel;

namespace iox_sample_app.Responses
{
    public enum ResponseTypes
    {
        [Description("Instruction Status Update")]
        InstructionStatusUpdate = 1,
        [Description("Quote Created")]
        QuoteCreated = 2,
        [Description("Account OTP")]
        AccountOtp = 3,

        [Description("New Fine Count")]
        NewFineCount = 4,
        [Description("Licensing Instruction Status Updated")]
        LicensingInstructionStatusUpdate = 6,
        [Description("Documents Upload Response")]
        DocumentsUploadResponse = 7
    }
}