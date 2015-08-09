using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private static Random _random = new Random();

    [TestCase(10, 10, 10000)]
    public void TestMethod(int maxLength, int maxValue, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var length = _random.Next(maxLength + 1);
            var nums = new int[length];
            for (var i = 0; i < length; ++i)
            {
                nums[i] = _random.Next(1, maxValue + 1);
            }
            var s = length == 0 ? 1 : _random.Next(nums.Sum() + 1) + 1;
            var original = JsonConvert.SerializeObject(nums);
            var expectedResult = MinSubArrayLen(s, nums);
            var result = new Solution().MinSubArrayLen(s, nums);
            Assert.AreEqual(expectedResult, result, string.Format("nums: {0}. s: {1}.", original, s));
        }
    }

    private int MinSubArrayLen(int s, int[] nums)
    {
        return Enumerable.Range(1, nums.Length).FirstOrDefault(l => Enumerable.Range(0, nums.Length - l + 1).Any(i => nums.Skip(i).Take(l).Sum() >= s));
    }
}