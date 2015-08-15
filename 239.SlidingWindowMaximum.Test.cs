using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 10, 1000)]
    public void TestMethod(int maxLength, int maxValue, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var nums = GenerateIntegerArray(maxLength, maxValue);
            var k = nums.Length == 0 ? 0 : Random.Next(1, nums.Length + 1);
            var expectedResult = MaxSlidingWindow(nums, k);
            var result = new Solution().MaxSlidingWindow(nums, k);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result),
                string.Format("{0}. {1}.", JsonConvert.SerializeObject(nums), k));
        });
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
