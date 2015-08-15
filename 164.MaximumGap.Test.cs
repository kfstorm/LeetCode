using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 10, 1000)]
    [TestCase(100, 100, 10000)]
    [TestCase(int.MaxValue, 100, 10000)]
    public void TestMethod(int maxValue, int maxLength, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var nums = GenerateIntegerArray(maxLength, maxValue);
            var expectedResult = MaximumGap(nums);
            var result = new Solution().MaximumGap(nums);
            Assert.AreEqual(expectedResult, result, JsonConvert.SerializeObject(nums));
        });
    }

    private int MaximumGap(int[] nums)
    {
        var copy = nums.ToList();
        copy.Sort();
        var result = 0;
        for (var i = 1; i < copy.Count; ++i)
        {
            result = Math.Max(result, copy[i] - copy[i - 1]);
        }
        return result;
    }
}
