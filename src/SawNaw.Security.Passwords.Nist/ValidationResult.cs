namespace SawNaw.Security.Passwords.Nist;

public record ValidationResult(
    int Length,
    bool MeetsUserCreatedMinLengthRequirement,
    bool MeetsMachineCreatedMinLengthRequirement,
    bool MeetsSingleFactorAuthMinLengthRequirement,
    bool MeetsMaxLengthRequirement,
    bool LooksLikePassPhrase
);