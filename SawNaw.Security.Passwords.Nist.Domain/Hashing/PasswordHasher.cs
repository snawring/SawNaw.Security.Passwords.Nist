using System.Security.Cryptography;
using System.Text;

namespace SawNaw.Security.Passwords.Nist.Domain.Hashing;

public record class PasswordHasher(string Password)
{
    // A SHA-1 hash is commonly represented as a 40-character hexadecimal string 
    private const int LengthOfSha1HashAsHexString = 40;
    
    public string Hash(int charsToReturn = LengthOfSha1HashAsHexString)
    {
        // 1. Calculate length and allocate to the stack
        int byteCount = Encoding.UTF8.GetByteCount(Password);

        // Safety check: Avoid StackOverflow for absurdly long inputs
        if (byteCount > 1024) throw new ArgumentException("Password too long");

        Span<byte> passwordUtf8 = stackalloc byte[byteCount];
        Span<byte> hashBuffer = stackalloc byte[SHA1.HashSizeInBytes];

        try
        {
            // 2. Encode string directly into stack memory
            Encoding.UTF8.GetBytes(Password, passwordUtf8);

            // 3. Compute SHA-1 (The HIBP standard)
            SHA1.HashData(passwordUtf8, hashBuffer);

            // 4. Return as Hex (This allocates a string, which is necessary to leave the method)
            return Convert.ToHexString(hashBuffer)
                          .Substring(0, charsToReturn);
        }
        finally
        {
            // 5. CRITICAL: Clear the sensitive data from the stack immediately
            CryptographicOperations.ZeroMemory(passwordUtf8);
            CryptographicOperations.ZeroMemory(hashBuffer);
        }
    }

    public string HashUsingStaticApproach(int charsToReturn = LengthOfSha1HashAsHexString)
    {
        byte[] sourceBytes = Encoding.UTF8.GetBytes(Password);

        byte[] hashBytes = SHA1.HashData(sourceBytes);

        return Convert.ToHexString(hashBytes)
                      .Substring(0, charsToReturn);
        
    }
}