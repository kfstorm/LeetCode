using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("aa", "a", false)]
    [TestCase("aa", "aa", true)]
    [TestCase("aaa", "aa", false)]
    [TestCase("aa", "*", true)]
    [TestCase("aa", "a*", true)]
    [TestCase("ab", "?*", true)]
    [TestCase("aab", "c*a*b", false)]
    [TestCase("ab", "ab", true)]
    [TestCase("ab", "a*b", true)]
    [TestCase("a", "a*", true)]
    [TestCase("ab", "ab*", true)]
    [TestCase("ab", "*a*b", true)]
    [TestCase("cab", "c*a*b", true)]
    [TestCase("cab", "c*a?", true)]
    [TestCase("cac", "c*a?", true)]
    [TestCase("", "*", true)]
    [TestCase("", "***", true)]
    [TestCase("", "?", false)]
    [TestCase("a", "?", true)]
    [TestCase("a", "*", true)]
    [TestCase("a", "****", true)]
    [TestCase("c", "*?*", true)]
    [TestCase("bbbaaabaababbabbbaabababbbabababaabbaababbbabbbabb", "*b**b***baba***aaa*b***", false)]
    [TestCase("abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb", "**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb", false)]
    public void Test(string s, string p, bool expectedResult)
    {
        var result = new Solution().IsMatch(s, p);
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void Test2()
    {
        var s = new string('a', 32316);
        var p = "*" + new string('a', 32317) + "*";
        Test(s, p, false);
    }
}
