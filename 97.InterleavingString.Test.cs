using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("", "", "", true)]
    [TestCase("", "a", "a", true)]
    [TestCase("a", "a", "aa", true)]
    [TestCase("a", "b", "aa", false)]
    [TestCase("a", "b", "ab", true)]
    [TestCase("a", "b", "ba", true)]
    [TestCase("b", "a", "ba", true)]
    [TestCase("b", "a", "ab", true)]
    [TestCase("aabcc", "dbbca", "aadbbcbcac", true)]
    [TestCase("aabcc", "dbbca", "aadbbbaccc", false)]
    public void TestMethod(string s1, string s2, string s3, bool expectedResult)
    {
        var answer = new Solution().IsInterleave(s1, s2, s3);
        Assert.AreEqual(expectedResult, answer);
    }
}
