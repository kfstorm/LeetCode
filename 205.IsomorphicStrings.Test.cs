using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("egg", "add", true)]
    [TestCase("foo", "bar", false)]
    [TestCase("paper", "title", true)]
    [TestCase("ab", "aa", false)]
    public void TestMethod(string s, string t, bool expectedResult)
    {
        var result = new Solution().IsIsomorphic(s, t);
        Assert.AreEqual(expectedResult, result);
    }
}
