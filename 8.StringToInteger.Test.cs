using NUnit.Framework;

[TestFixture]
public class StringToIntegerTest
{
    [TestCase("0", 0)]
    [TestCase("00", 0)]
    [TestCase("000.", 0)]
    [TestCase("001.2149000", 1)]
    [TestCase(".1231231", 0)]
    [TestCase("0.1", 0)]
    [TestCase(" 0.1 ", 0)]
    [TestCase("abc", 0)]
    [TestCase("1 a", 1)]
    [TestCase("2e10", 2)]
    [TestCase("2.14e213", 2)]
    [TestCase("1e233.43", 1)]
    [TestCase("0e12324", 0)]
    [TestCase("0.5e0", 0)]
    [TestCase("0.5e.234", 0)]
    [TestCase("0.5E.234", 0)]
    [TestCase("e902424", 0)]
    [TestCase("123e", 123)]
    [TestCase("e", 0)]
    [TestCase(".", 0)]
    [TestCase("1.e", 1)]
    [TestCase("e3", 0)]
    [TestCase("e.", 0)]
    [TestCase(".e6", 0)]
    [TestCase("-1.6454", -1)]
    [TestCase("-1.-6", -1)]
    [TestCase("-1.e-6", -1)]
    [TestCase("+1.e-6", 1)]
    [TestCase("+1.e+6", 1)]
    [TestCase("-2147483648", -2147483648)]
    [TestCase("2147483648", 2147483647)]
    public void Test(string @string, int expectedResult)
    {
        var answer = new Solution().MyAtoi(@string);
        Assert.AreEqual(expectedResult, answer, @string);
    }
}
