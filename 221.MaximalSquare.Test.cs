using System;
using NUnit.Framework;

[TestFixture]
public class MaximalSquareTest
{
    [TestCase("", 0)]
    [TestCase("0", 0)]
    [TestCase("1", 1)]
    [TestCase(@"0 1
                0 0", 1)]
    [TestCase(@"0 1
                0 1", 1)]
    [TestCase(@"0 1
                1 0", 1)]
    [TestCase(@"0 1
                1 1", 1)]
    [TestCase(@"1 0
                1 1", 1)]
    [TestCase(@"1 1
                1 1", 4)]
    [TestCase(@"1 0 1 0 0
                1 0 1 1 1
                1 1 1 1 1
                1 0 0 1 0", 4)]
    [TestCase(@"1 0 1 0 0
                1 0 1 1 1
                1 1 1 1 1
                1 1 1 1 1
                1 0 0 1 0", 9)]
    [TestCase(@"1 1 0 0 0
                1 1 1 0 0
                0 1 1 1 0
                0 0 1 1 1
                0 0 0 1 1", 4)]
    [TestCase(@"11111111
                11111110
                11111110
                11111000
                01111000", 16)]
    public void Test(string matrixString, int expectedArea)
    {
        var lines = matrixString.Replace(" ", string.Empty).Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var matrix = new char[lines.Length, lines.Length == 0 ? 0 : lines[0].Length];
        for (var i = 0; i < lines.Length; ++i)
        {
            for (var j = 0; j < lines[0].Length; ++j)
            {
                matrix[i, j] = lines[i][j];
            }
        }

        var result = new Solution().MaximalSquare(matrix);
        Assert.AreEqual(expectedArea, result);
    }
}