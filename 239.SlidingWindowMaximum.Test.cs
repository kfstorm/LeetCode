using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private static Random _random = new Random();

    [TestCase(10, 10, 1000)]
    public void TestMethod(int maxLength, int maxValue, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var length = _random.Next(maxLength + 1);
            var nums = new int[length];
            for (var i = 0; i < length; ++i)
            {
                nums[i] = _random.Next(maxValue);
            }
            var k = length == 0 ? 0 : _random.Next(1, length + 1);
            var expectedResult = MaxSlidingWindow(nums, k);
            var result = new Solution().MaxSlidingWindow(nums, k);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result),
                string.Format("{0}. {1}.", JsonConvert.SerializeObject(nums), k));
        }
    }

    private int[] MaxSlidingWindow(int[] nums, int k)
    {
        if (nums.Length == 0) return new int[0];
        var result = new int[nums.Length - k + 1];
        for (var i = 0; i < nums.Length - k + 1; ++i)
        {
            result[i] = nums.Skip(i).Take(k).Max();
        }
        return result;
    }
}
