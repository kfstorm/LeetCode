using System;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("1 2 3 4 5", 4)]
    [TestCase("5 4 3 2 1", 0)]
    [TestCase("1 2 5 3 4", 5)]
    [TestCase("2 5 3 4 1", 4)]
    [TestCase("6 7 4 5 2 3 1", 2)]
    [TestCase("6 1 3 2 4 7", 7)]
    [TestCase("1 2 4 2 5 7 2 4 9 0", 13)]
    public void TestMethod(string pricesString, int expectedResult)
    {
        var prices = Array.ConvertAll(pricesString.Split(), int.Parse);
        var result = new Solution().MaxProfit(prices);
        Assert.AreEqual(expectedResult, result);
    }
}
