using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    //[TestCase(2, 2, 1000)]
    [TestCase(10, 10, 1000)]
    public void TestMethod(int maxHeight, int maxWidth, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var matrix = GenerateMatrix(0, maxHeight, 0, maxWidth, () => Random.Next(2) == 0 ? '0' : '1');
            var expectedResult = MaximalRectangle(matrix);
            var answer = new Solution().MaximalRectangle(matrix);
            Assert.AreEqual(expectedResult, answer, JsonConvert.SerializeObject(matrix));
        });
    }

    private int MaximalRectangle(char[,] matrix)
    {
        var height = matrix.GetLength(0);
        var width = matrix.GetLength(1);
        var result = 0;
        for (var i = 0; i < height; ++i)
        {
            for (var j = 0; j < width; ++j)
            {
                for (var k = i; k < height; ++k)
                {
                    for (var l = j; l < width; ++l)
                    {
                        var isRectangle = true;
                        for (var ii = i; ii <= k; ++ii)
                        {
                            for (var jj = j; jj <= l; ++jj)
                            {
                                if (matrix[ii, jj] == '0')
                                {
                                    isRectangle = false;
                                    break;
                                }
                            }
                        }
                        if (isRectangle)
                        {
                            result = Math.Max(result, (k - i + 1) * (l - j + 1));
                        }
                    }
                }
            }
        }
        return result;
    }
}
