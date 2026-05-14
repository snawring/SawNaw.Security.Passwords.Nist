namespace SawNaw.Security.Passwords.Nist.Core.Tests.NistPasswordValidatorTests;

public class ExceptionTests
{
    [Test]
    public void Constructor_ThrowsOnNull()
    {
        Assert.That(() => new NistPasswordValidator(null), Throws.TypeOf<ArgumentException>());
        
    }
    
    [TestCase("")]
    [TestCase("   ")]
    public void Constructor_ThrowsOnWhitespace(string input)
    {
        Assert.That(() => new NistPasswordValidator(input), Throws.TypeOf<ArgumentException>());
    }
}