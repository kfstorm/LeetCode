using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(-10, 10, 10, 1000)]
    [TestCase(-10, 10, 1, 100)]
    [TestCase(-1, 1, 10, 100)]
    public void TestMethod(int minNum, int maxNum, int numCount, int repeat)
    {
        Repeat(repeat, () =>
        {
            var nums = GenerateIntegerArray(numCount, numCount, minNum, maxNum);
            var result = new Solution().MaxProduct(nums);
            var expectedResult = MaxProduct(nums);
            Assert.AreEqual(expectedResult, result, JsonConvert.SerializeObject(nums));
        });
    }

    private int MaxProduct(int[] nums)
    {
        var result = int.MinValue;
        for (var i = 0; i < nums.Length; ++i)
        {
            var product = 1;
            for (var j = i; j < nums.Length; ++j)
            {
                product *= nums[j];
                if (product > result)
                {
                    result = product;
                }
            }
        }
        return result;
    }
}
