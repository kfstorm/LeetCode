using System;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("abcba", "abcba")]
    [TestCase("abcbd", "bcb")]
    [TestCase("abcb", "bcb")]
    [TestCase("abc", "a")]
    [TestCase("abba", "abba")]
    [TestCase("abbd", "bb")]
    [TestCase("abb", "bb")]
    [TestCase("ab", "a")]
    [TestCase("a", "a")]
    [TestCase("", "")]
    public void TestMethod(string s, string expectedResult)
    {
        Assert.AreEqual(expectedResult, new Solution().LongestPalindrome(s));
    }
}