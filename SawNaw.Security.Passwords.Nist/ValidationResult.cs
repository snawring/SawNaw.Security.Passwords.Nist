namespace SawNaw.Security.Passwords.Nist;

public record class ValidationResult(
    bool MeetsUserCreatedMinLengthReq,
    bool MeetsMachineCreatedMinLengthReq,
    bool MeetsSingleFactorAuthMinLengthReq,
    bool MeetsMaxLengthReq
);