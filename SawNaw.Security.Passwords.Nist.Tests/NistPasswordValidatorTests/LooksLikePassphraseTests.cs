namespace SawNaw.Security.Passwords.Nist.Core.Tests.NistPasswordValidatorTests;

public class LooksLikePassphraseTests
{
    [TestCase("correct horse battery")]
    [TestCase("correct horse battery staple")]
    [TestCase("correct    horse    battery")]
    [TestCase("correct horse   battery      staple")]
    public void HasTwoOrMoreSpaces_Sets_LooksLikePassphraseFlag(string pw)
    {
        var validator = new NistPasswordValidator(pw);
        var result = validator.Validate();
        Assert.That(result.LooksLikePassPhrase, Is.True);
    }

    [TestCase("correct horse")]
    [TestCase("correct        horse")]
    [TestCase("correct")]
    public void HasLessThanTwoSpaces_Sets_LooksLikePassphraseFlag(string pw)
    {
        var validator = new NistPasswordValidator(pw);
        var result = validator.Validate();
        Assert.That(result.LooksLikePassPhrase, Is.False);
    }
}