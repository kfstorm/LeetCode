using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private static Random _random = new Random();

    //[TestCase(2, 2, 1000)]
    [TestCase(10, 10, 1000)]
    public void TestMethod(int maxHeight, int maxWidth, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var height = _random.Next(maxHeight + 1);
            var width = _random.Next(maxWidth + 1);
            var matrix = new char[height, width];
            for (var i = 0; i < height; ++i)
            {
                for (var j = 0; j < width; ++j)
                {
                    matrix[i, j] = _random.Next(2) == 0 ? '0' : '1';
                }
            }
            var expectedResult = MaximalRectangle(matrix);
            var answer = new Solution().MaximalRectangle(matrix);
            Assert.AreEqual(expectedResult, answer, JsonConvert.SerializeObject(matrix));
        }
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
