using System;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("1 2 3 4 5", 0, 0)]
    [TestCase("1 2 3 4 5", 1, 4)]
    [TestCase("1 2 3 4 5", 2, 4)]
    [TestCase("1 2 3 4 5", 3, 4)]
    [TestCase("5 4 3 2 1", 1, 0)]
    [TestCase("5 4 3 2 1", 2, 0)]
    [TestCase("1 2 5 3 4", 1, 4)]
    [TestCase("1 2 5 3 4", 2, 5)]
    [TestCase("1 2 5 3 4", 3, 5)]
    [TestCase("2 5 3 4 1", 1, 3)]
    [TestCase("2 5 3 4 1", 2, 4)]
    [TestCase("2 5 3 4 1", 3, 4)]
    [TestCase("6 7 4 5 2 3 1", 1, 1)]
    [TestCase("6 7 4 5 2 3 1", 2, 2)]
    [TestCase("6 7 4 5 2 3 1", 3, 3)]
    [TestCase("6 7 4 5 2 3 1", 4, 3)]
    [TestCase("6 1 3 2 4 7", 1, 6)]
    [TestCase("6 1 3 2 4 7", 2, 7)]
    [TestCase("6 1 3 2 4 7", 3, 7)]
    [TestCase("1 2 4 2 5 7 2 4 9 0", 1, 8)]
    [TestCase("1 2 4 2 5 7 2 4 9 0", 2, 13)]
    [TestCase("1 2 4 2 5 7 2 4 9 0", 3, 15)]
    [TestCase("1 2 4 2 5 7 2 4 9 0", 4, 15)]
    [TestCase("2 6 8 7 8 7 9 4 1 2 4 5 8", 2, 14)]
    [TestCase("5 2 3 2 6 6 2 9 1 0 7 4 5 0", 2, 14)]
    [TestCase("3 8 4 9 2 7 5 8 8 7", 1, 6)]
    public void TestMethod(string pricesString, int k, int expectedResult)
    {
        var prices = Array.ConvertAll(pricesString.Split(), int.Parse);
        var result = new Solution().MaxProfit(k, prices);
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase(10, 10)]
    public void TestCaseGenerator(int n, int maxPrice)
    {
        var random = new Random();
        for (var t = 0; t < 100; ++t)
        {
            var prices = new int[n];
            for (var i = 0; i < n; ++i)
            {
                prices[i] = random.Next(1, maxPrice + 1);
            }
            var k = random.Next(1, n/2);
            var stupidResult = new Solution().MaxProfitStupid(k, prices);
            var result = new Solution().MaxProfit(k, prices);
            if (stupidResult != result)
            {
                Console.WriteLine("Stupid result: {0}. Result: {1}.", stupidResult, result);
                Console.WriteLine("k: {0}", k);
                Console.WriteLine("Prices: {0}", string.Join(" ", prices));
                Assert.Fail();
            }
        }
    }
}
