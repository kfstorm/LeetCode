using System;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(0,0)]
    [TestCase(1,1)]
    [TestCase(-1,-1)]
    [TestCase(123,321)]
    [TestCase(-123,-321)]
    [TestCase(12300,321)]
    [TestCase(-12300, -321)]
    [TestCase(-2147483648,0)]
    [TestCase(-2147483647,0)]
    [TestCase(-2147483641,-1463847412)]
    [TestCase(2147483647,0)]
    [TestCase(2147483641,1463847412)]
    public void TestMethod(int x, int expectedResult)
    {
        var result = new Solution().Reverse(x);
        Assert.AreEqual(expectedResult, result);
    }
}
