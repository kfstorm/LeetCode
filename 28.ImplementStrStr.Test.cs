using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("12345", "123", 0)]
    [TestCase("12345", "234", 1)]
    [TestCase("12345", "124", -1)]
    public void TestMethod(string haystack, string needle, int expectedResult)
    {
        Assert.AreEqual(expectedResult, new Solution().StrStr(haystack, needle));
    }
}
