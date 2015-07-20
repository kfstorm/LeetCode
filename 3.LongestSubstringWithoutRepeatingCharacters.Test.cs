using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("abcabcbb", 3)]
    [TestCase("abcabcdb", 4)]
    [TestCase("abcabbcd", 3)]
    [TestCase("bbbbb", 1)]
    public void TestMethod(string s, int expectedResult)
    {
        Assert.AreEqual(expectedResult, new Solution().LengthOfLongestSubstring(s));
    }
}