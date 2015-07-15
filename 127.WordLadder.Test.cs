using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("hit", "cog", "[\"hot\",\"dot\",\"dog\",\"lot\",\"log\"]", 5)]
    [TestCase("a", "c", "[\"a\",\"b\",\"c\"]", 2)]
    [TestCase("a", "c", "[\"b\"]", 2)]
    [TestCase("ab", "cc", "[\"ab\"]", 0)]
    [TestCase("ab", "cd", "[]", 0)]
    public void TestMethod(string start, string end, string dictString, int expectedResult)
    {
        var dict = JsonConvert.DeserializeObject<HashSet<string>>(dictString);
        var result = new Solution().LadderLength(start, end, dict);
        Assert.AreEqual(expectedResult, result);
    }
}
