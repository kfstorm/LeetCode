using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase("", "", true)]
    [TestCase("", ".*", true)]
    [TestCase("", "a*", true)]
    [TestCase("", ".", false)]
    [TestCase("aa", "a", false)]
    [TestCase("aa", "aa", true)]
    [TestCase("aaa", "aa", false)]
    [TestCase("a", "a*", true)]
    [TestCase("aa", "a*", true)]
    [TestCase("aaa", "a*", true)]
    [TestCase("aaaaaaaa", "a*", true)]
    [TestCase("aa", ".*", true)]
    [TestCase("ab", ".*", true)]
    [TestCase("aab", "c*a*b", true)]
    [TestCase("aab", "c*.*b", true)]
    public void TestMethod1(string s, string p, bool expectedResult)
    {
        var result = new Solution().IsMatch(s, p);
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase(10, 10, 100)]
    public void TestMethod2(int sMaxLength, int pMaxLength, int testCount)
    {
        Repeat(testCount, () => {
            for (var i = 0; i < testCount; ++i)
            {
                var s = GenerateString(Random, sMaxLength, false);
                var p = GenerateString(Random, pMaxLength, true);
                var expectedResult = Regex.Match(s, string.Format("^{0}$", p)).Success;
                var result = new Solution().IsMatch(s, p);
                Assert.AreEqual(expectedResult, result, string.Format("s={0} p={1}", s, p));
            }
        });
    }

    private string GenerateString(Random random, int maxLength, bool isRegex)
    {
        var length = random.Next(maxLength + 1);
        var sb = new StringBuilder(length);
        char ch = '*';
        for (var i = 0; i < length; ++i)
        {
            var op = random.Next(isRegex ? 28 : 26);
            switch (op)
            {
                case 26:
                    ch = '.';
                    break;
                case 27:
                    ch = ch != '*' ? '*' : '.';
                    break;
                default:
                    ch = (char)(op + 'a');
                    break;
            }
            sb.Append(ch);
        }
        return sb.ToString();
    }
}
