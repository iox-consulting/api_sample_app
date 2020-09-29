using System.ComponentModel;

namespace iox_sample_app.Responses
{
    public enum ResponseTypes
    {
        [Description("Instruction Status Update")]
        InstructionStatusUpdate = 1,

        [Description("Account OTP")]
        AccountOtp = 3,

        [Description("New Fine Count")]
        NewFineCount = 4
    }
}