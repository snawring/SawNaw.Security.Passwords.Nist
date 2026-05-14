namespace SawNaw.Security.Passwords.Nist;

public class NistPasswordValidator
{
    private const string NullOrWhiteSpaceErrorMessage = "Password cannot be null or whitespace. Prevent this from happening before using this class.";
    
    private readonly string _password;

    public NistPasswordValidator(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException(NullOrWhiteSpaceErrorMessage, nameof(password));
        }
        
        _password = password;
    }
    
    public ValidationResult Validate()
    {
        return new ValidationResult(
            _password.Length,
            MeetsMinimumForUserCreated(), 
            MeetsMinimumForMachineCreated(),
            MeetsMinimumForSingleFactorAuth(),
            MeetsMaxLengthRequirement(),
            LooksLikePassphrase()
        );
    }

    private bool MeetsMinimumForUserCreated()
    {
        return _password.Length >= Constants.MinLength.ForUserCreated;
    }
    
    private bool MeetsMinimumForSingleFactorAuth()
    {
        return _password.Length >= Constants.MinLength.ForSingleFactorAuth;
    }
    
    private bool MeetsMinimumForMachineCreated()
    {
        return _password.Length >= Constants.MinLength.ForMachineCreated;
    }
    
    private bool MeetsMaxLengthRequirement()
    {
        return _password.Length <= Constants.MaxLength;
    }
    
    private bool LooksLikePassphrase()
    {
        return _password.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length >= 3;
    }
}