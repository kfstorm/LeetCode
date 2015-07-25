using System.Numerics;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("0", "0")]
    [TestCase("0", "12345")]
    [TestCase("12345", "0")]
    [TestCase("1", "1")]
    [TestCase("1", "12345")]
    [TestCase("123456789", "123456789")]
    [TestCase("999999999999999999999", "99999999999999999999999")]
    [TestCase("0000060156056004050605464984080900809", "000560605646549849849123161056105605640564056049498040840503056045605605056498490")]
    public void TestMethod(string num1, string num2)
    {
        var expectedResult = (BigInteger.Parse(num1) * BigInteger.Parse(num2)).ToString();
        var result = new Solution().Multiply(num1, num2);
        Assert.AreEqual(expectedResult, result);
    }
}