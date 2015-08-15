using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(5, 10, 1000)]
    [TestCase(10000, 5, 1)]
    public void TestMethod(int maxCount, int maxLength, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var strs = GenerateArray<string>(0, maxCount, () => GenerateString(maxLength));
            var expectedResult = ToString(GroupAnagrams(strs));
            var result = ToString(new Solution().GroupAnagrams(strs));
            Assert.AreEqual(expectedResult, result, JsonConvert.SerializeObject(strs));
        });
    }

    private IList<IList<string>> GroupAnagrams(string[] strs)
    {
        return strs.GroupBy(str => new string(str.OrderBy(ch => ch).ToArray())).Select(g => (IList<string>) g.OrderBy(str => str).ToList()).ToList();
    }

    private string ToString(IList<IList<string>> result)
    {
        return JsonConvert.SerializeObject(result.OrderBy(s => JsonConvert.SerializeObject(s)));
    }
}