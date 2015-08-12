using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private static Random _random = new Random();

    [TestCase(5, 10, 1000)]
    [TestCase(10000, 5, 1)]
    public void TestMethod(int maxCount, int maxLength, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var count = _random.Next(maxCount + 1);
            var strs = new string[count];
            for (var i = 0; i < count; ++i)
            {
                var length = _random.Next(maxLength + 1);
                var sb = new StringBuilder();
                for (var j = 0; j < length; ++j)
                {
                    sb.Append((char)(_random.Next(26) + 'a'));
                }
                strs[i] = sb.ToString();
            }

            var expectedResult = ToString(GroupAnagrams(strs));
            var result = ToString(new Solution().GroupAnagrams(strs));
            Assert.AreEqual(expectedResult, result, JsonConvert.SerializeObject(strs));
        }
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