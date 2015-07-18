using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("aab", 1)]
    [TestCase("a", 0)]
    [TestCase("aaaaa", 0)]
    [TestCase("abcba", 0)]
    [TestCase("abba", 0)]
    public void TestMethod(string s, int expectedResult)
    {
        var result = new Solution().MinCut(s);
        Assert.AreEqual(expectedResult, result);
    }
}
