using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 10, 1000)]
    public void TestMethod(int maxLength, int maxCount, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var strs = GenerateArray(0, maxCount, () => GenerateString(maxLength));
            var expectedResult = LongestCommonPrefix(strs);
            var result = new Solution().LongestCommonPrefix(strs);
            Assert.AreEqual(expectedResult, result, JsonConvert.SerializeObject(strs));
        });
    }

    private string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 0) return string.Empty;
        var result = string.Empty;
        for (var i = 1; i <= strs[0].Length; ++i)
        {
            var prefix = strs[0].Substring(0, i);
            if (strs.All(str => str.IndexOf(prefix) == 0))
            {
                result = prefix;
            }
            else
            {
                break;
            }
        }
        return result;
    }
}
