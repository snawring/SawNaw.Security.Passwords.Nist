namespace SawNaw.Security.Passwords.Nist.Core.Tests.NistPasswordValidatorTests;

public class MinimumLengthTests
{
    [TestCase("1")]
    [TestCase("123")]
    [TestCase("1234567")]
    public void Length_LessThanMinForUserCreated_SetsProperty(string pw)
    {
        var validator = new NistPasswordValidator(pw);
        var result = validator.Validate();
        Assert.That(result.MeetsUserCreatedMinLengthRequirement, Is.False);
    }
    
    [TestCase("123456789")]
    [TestCase("12345678")]
    public void Length_MeetsMinForUserCreated_SetsProperty(string pw)
    {
        var validator = new NistPasswordValidator(pw);
        var result = validator.Validate();
        Assert.That(result.MeetsUserCreatedMinLengthRequirement, Is.True);
    }
}