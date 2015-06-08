using NUnit.Framework;

[TestFixture]
public class ShortestPalindromeTest
{
    [TestCase("", "")]
    [TestCase("aacecaaa", "aaacecaaa")]
    [TestCase("abcd", "dcbabcd")]
    public void Test(string s, string expectedPalindrome)
    {
        var answer = new Solution().ShortestPalindrome(s);
        Assert.AreEqual(expectedPalindrome, answer);
    }
}
