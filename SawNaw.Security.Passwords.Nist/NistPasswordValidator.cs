namespace SawNaw.Security.Passwords.Nist;

public class NistPasswordValidator
{
    private readonly string _password;
    
    public NistPasswordValidator(string password)
    {
        _password = password;    
    }

    public ValidationResult Validate()
    {
        return new ValidationResult(
            MeetsMinimumForUserCreated(), 
            MeetsMinimumForMachineCreated(),
            MeetsMinimumForSingleFactorAuth(),
            MeetsMaxLengthRequirement()
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
}