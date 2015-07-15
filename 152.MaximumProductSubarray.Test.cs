using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private static Random _random = new Random(); 
    
    [TestCase(-10, 10, 10, 1000)]
    [TestCase(-10, 10, 1, 100)]
    [TestCase(-1, 1, 10, 100)]
    public void TestMethod(int minNum, int maxNum, int numCount, int repeat)
    {
        for (var r = 0; r < repeat; ++r)
        {
            var nums = new int[numCount];
            for (var i = 0; i < numCount; ++i)
            {
                nums[i] = _random.Next(minNum, maxNum);
            }
            var result = new Solution().MaxProduct(nums);
            var expectedResult = MaxProduct(nums);
            Assert.AreEqual(expectedResult, result, JsonConvert.SerializeObject(nums));
        }
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
