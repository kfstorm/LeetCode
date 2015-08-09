using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private static Random _random = new Random();

    [TestCase(10, -5, 15, 10000)]
    public void TestMethod(int maxLength, int minValue, int maxValue, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var length = _random.Next(maxLength + 1);
            var nums = new int[length];
            for (var i = 0; i < length; ++i)
            {
                nums[i] = _random.Next(minValue, maxValue + 1);
            }
            var original = JsonConvert.SerializeObject(nums);
            var expectedResult = FirstMissingPositive(nums);
            var result = new Solution().FirstMissingPositive(nums);
            Assert.AreEqual(expectedResult, result, original);
        }
    }

    private int FirstMissingPositive(int[] nums)
    {
        return Enumerable.Range(1, nums.Length + 1).First(x => !nums.Contains(x));
    }
}