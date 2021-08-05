namespace iox_sample_app.Requests.Enums
{ 
    public enum eLicensingInstructionStatus
    {
        InstructionCreated,
        AgentAcceptedInstruction,
        InstructionFailed,
        InstructionCompleted,
        InstructionSubmittedForCourier,
        InstructionCourierCollected,
        InstructionCourierDelivered,
        InstructionCourierInTransit
    }
}
