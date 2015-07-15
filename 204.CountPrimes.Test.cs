using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(0, 0)]
    [TestCase(1, 0)]
    [TestCase(2, 0)]
    [TestCase(3, 1)]
    [TestCase(4, 2)]
    [TestCase(5, 2)]
    [TestCase(6, 3)]
    [TestCase(7, 3)]
    [TestCase(8, 4)]
    [TestCase(9, 4)]
    [TestCase(10, 4)]
    [TestCase(11, 4)]
    [TestCase(12, 5)]
    [TestCase(13, 5)]
    public void TestMethod(int n, int expectedResult)
    {
        var result = new Solution().CountPrimes(n);
        Assert.AreEqual(expectedResult, result);
    }
}
