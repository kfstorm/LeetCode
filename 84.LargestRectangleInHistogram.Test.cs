using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10,10,1000)]
    public void TestMethod(int maxLength, int maxHeight, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var height = GenerateIntegerArray(maxLength, maxHeight);
            var expectedResult = LargestRectangleArea(height);
            var result = new Solution().LargestRectangleArea(height);
            Assert.AreEqual(expectedResult, result, JsonConvert.SerializeObject(height));
        });
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
