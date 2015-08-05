using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private static Random _random = new Random();

    [TestCase(10,10,1000)]
    public void TestMethod(int maxLength, int maxHeight, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var length = _random.Next(maxLength + 1);
            var height = new int[length];
            for (var i = 0; i < length; ++i)
            {
                height[i] = _random.Next(maxHeight + 1);
            }
            var expectedResult = LargestRectangleArea(height);
            var result = new Solution().LargestRectangleArea(height);
            Assert.AreEqual(expectedResult, result, JsonConvert.SerializeObject(height));
        }
    }

    private int LargestRectangleArea(int[] height)
    {
        var result = 0;
        for (var i = 0; i < height.Length; ++i)
        {
            for (var j = i; j < height.Length; ++j)
            {
                var minHeight = int.MaxValue;
                for (var k = i; k <= j; ++k)
                {
                    minHeight = Math.Min(minHeight, height[k]);
                }
                result = Math.Max(result, minHeight * (j - i + 1));
            }
        }
        return result;
    }
}
