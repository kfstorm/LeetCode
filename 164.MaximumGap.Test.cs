using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private static Random _random = new Random();
    [TestCase(10, 10, 1000)]
    [TestCase(100, 100, 10000)]
    [TestCase(int.MaxValue, 100, 10000)]
    public void TestMethod(int maxValue, int maxLength, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var length = _random.Next(maxLength + 1);
            var nums = new int[length];
            for (var i = 0; i < nums.Length; ++i)
            {
                nums[i] = _random.Next(maxValue < int.MaxValue ? maxValue + 1 : int.MaxValue);
            }
            var expectedResult = MaximumGap(nums);
            var result = new Solution().MaximumGap(nums);
            Assert.AreEqual(expectedResult, result, JsonConvert.SerializeObject(nums));
        }
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
