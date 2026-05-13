using SawNaw.Security.Passwords.Nist.Domain.Hashing;

namespace SawNaw.Security.Passwords.Nist.Domain.Tests;

public class PasswordHasherTests
{
    [Test]
    public void HashedPassword_IsCorrect()
    {
        const string password = "mypassword";
        const string expectedResult = "91dfd9ddb4198affc5c194cd8ce6d338fde470e2";
        
        var hasher = new PasswordHasher(password);
        var result = hasher.Hash().ToLower();
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(5, "91dfd")]
    [TestCase(2, "91")]
    [TestCase(40, "91dfd9ddb4198affc5c194cd8ce6d338fde470e2")]
    public void HashedPassword_ReturnsSpecifiedNumberOfCharacters(int charsToReturn, string expectedResult)
    {
        const string password = "mypassword";
        
        var hasher = new PasswordHasher(password);
        var result = hasher.Hash(charsToReturn).ToLower();
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    [Test]
    public void HashedPassword_UsingStaticApproach_IsCorrect()
    {
        const string password = "mypassword";
        const string expectedResult = "91dfd9ddb4198affc5c194cd8ce6d338fde470e2";
        
        var hasher = new PasswordHasher(password);
        var result = hasher.HashUsingStaticApproach();
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}