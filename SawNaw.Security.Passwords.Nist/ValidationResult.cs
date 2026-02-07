namespace SawNaw.Security.Passwords.Nist;

public record ValidationResult(
    bool MeetsUserCreatedMinLengthReq,
    bool MeetsMachineCreatedMinLengthReq,
    bool MeetsSingleFactorAuthMinLengthReq,
    bool MeetsMaxLengthReq,
    bool LooksLikePassPhrase
);