using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 10, 10000)]
    public void TestMethod(int maxLength, int maxValue, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var nums = GenerateIntegerArray(0, maxLength, 1, maxValue);
            var s = nums.Length == 0 ? 1 : Random.Next(nums.Sum() + 1) + 1;
            var original = JsonConvert.SerializeObject(nums);
            var expectedResult = MinSubArrayLen(s, nums);
            var result = new Solution().MinSubArrayLen(s, nums);
            Assert.AreEqual(expectedResult, result, string.Format("nums: {0}. s: {1}.", original, s));
        });
    }

    private int MinSubArrayLen(int s, int[] nums)
    {
        return Enumerable.Range(1, nums.Length).FirstOrDefault(l => Enumerable.Range(0, nums.Length - l + 1).Any(i => nums.Skip(i).Take(l).Sum() >= s));
    }
}