namespace SawNaw.Security.Passwords.Nist;

public struct Constants
{
    public struct MinLength
    {
        public const int ForUserCreated = 8;
        public const int ForMachineCreated = 6;
        public const int ForSingleFactorAuth = 15;
    }
    
    public const int MaxLength = 64;
}

