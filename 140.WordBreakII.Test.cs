using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("leetcode", "leet code", "leet code")]
    [TestCase("catsanddog", "cat cats and sand dog", "cats and dog|cat sand dog")]
    public void TestMethod(string s, string wordDictString, string expectedResultsString)
    {
        var wordDict = new HashSet<string>(wordDictString.Split());
        var expectedResults = expectedResultsString.Split('|').OrderBy(str => str).ToArray();
        var results = new Solution().WordBreak(s, wordDict).OrderBy(str => str).ToArray();
        Assert.AreEqual(string.Join("|", expectedResults), string.Join("|", results));
    }
}
