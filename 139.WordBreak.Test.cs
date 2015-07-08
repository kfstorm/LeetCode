using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("leetcode", "leet code", true)]
    public void TestMethod(string s, string wordDictString, bool expectedResult)
    {
        var wordDict = new HashSet<string>(wordDictString.Split());
        var result = new Solution().WordBreak(s, wordDict);
        Assert.AreEqual(expectedResult, result);
    }
}
