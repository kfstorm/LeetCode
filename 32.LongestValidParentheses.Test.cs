using System;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("", 0)]
    [TestCase("(", 0)]
    [TestCase(")", 0)]
    [TestCase("((", 0)]
    [TestCase("()", 2)]
    [TestCase(")(", 0)]
    [TestCase("))", 0)]
    [TestCase("(()", 2)]
    [TestCase(")()())", 4)]
    [TestCase(")()())()(())(())))))", 10)]
    [TestCase("()(()", 2)]
    [TestCase("(()(((()", 2)]
    [TestCase("((()((()()", 4)]
    public void TestMethod1(string s, int expectedResult)
    {
        var result = new Solution().LongestValidParentheses(s);
        Assert.AreEqual(expectedResult, result);
    }
    
    [TestCase(10, 1000)]
    public void TestMethod2(int maxLength, int repeatCount)
    {
        var random = new Random();
        for (var r = 0; r < repeatCount; ++r)
        {
            var length = random.Next(maxLength + 1);
            var sb = new StringBuilder();
            for (var i = 0; i < length; ++i)
            {
                sb.Append(random.Next(2) == 0 ? '(' : ')');
            }
            var s = sb.ToString();
            Assert.AreEqual(LongestValidParentheses(s), new Solution().LongestValidParentheses(s), s);
        }
    }
    
    private int LongestValidParentheses(string s)
    {
        var result = 0;
        for (var i = 0; i < s.Length; ++i)
        {
            for (var j = i + result + 1; j < s.Length; ++j)
            {
                var valid = true;
                var count = 0;
                for (var k = i; k <= j; ++k)
                {
                    if (s[k] == '(')
                    {
                        ++count;
                    }
                    else
                    {
                        if (count > 0)
                        {
                            --count;
                        }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }
                }
                if (valid && count == 0 && j - i + 1 > result)
                {
                    result = j - i + 1;
                } 
            }
        }
        return result;
    }
}