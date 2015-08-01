using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("A man, a plan, a canal: Panama", true)]
    [TestCase("race a car", false)]
    [TestCase("1a2", false)]
    [TestCase("", true)]
    public void TestMethod(string s, bool expectedResult)
    {
        var result = new Solution().IsPalindrome(s);
        Assert.AreEqual(expectedResult, result);
    }
}
