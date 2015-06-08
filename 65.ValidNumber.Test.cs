using NUnit.Framework;

[TestFixture]
public class ValidNumberTest
{
    [TestCase("0", true)]
    [TestCase("00", true)]
    [TestCase("000.", true)]
    [TestCase("001.2149000", true)]
    [TestCase(".1231231", true)]
    [TestCase("0.1", true)]
    [TestCase(" 0.1 ", true)]
    [TestCase("abc", false)]
    [TestCase("1 a", false)]
    [TestCase("2e10", true)]
    [TestCase("2.14e213", true)]
    [TestCase("1e233.43", false)]
    [TestCase("0e12324", true)]
    [TestCase("0.5e0", true)]
    [TestCase("0.5e.234", false)]
    [TestCase("0.5E.234", false)]
    [TestCase("e902424", false)]
    [TestCase("123e", false)]
    [TestCase("e", false)]
    [TestCase(".", false)]
    [TestCase("1.e", false)]
    [TestCase("e3", false)]
    [TestCase("e.", false)]
    [TestCase(".e6", false)]
    [TestCase("-1.6454", true)]
    [TestCase("-1.-6", false)]
    [TestCase("-1.e-6", true)]
    [TestCase("+1.e-6", true)]
    [TestCase("+1.e+6", true)]
    public void Test(string @string, bool expectedResult)
    {
        var answer = new Solution().IsNumber(@string);
        Assert.AreEqual(expectedResult, answer, @string);
    }
}
