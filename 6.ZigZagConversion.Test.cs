using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase("PAYPALISHIRING", 1, "PAYPALISHIRING")]
    [TestCase("PAYPALISHIRING", 2, "PYAIHRNAPLSIIG")]
    [TestCase("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [TestCase("ORDUERJZD", 6, "ORDDUZEJR")]
    public void TestMethod1(string s, int numRows, string expectedResult)
    {
        var result = new Solution().Convert(s, numRows);
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase(10, 10, 10000)]
    public void TestMethod2(int maxLength, int maxRows, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var s = GenerateString(0, maxLength, 'A', 'Z');
            var numRows = Random.Next(maxRows) + 1;
            var expectedResult = Convert(s, numRows);
            try
            {
                var result = new Solution().Convert(s, numRows);
                Assert.AreEqual(expectedResult, result);
            }
            catch (IndexOutOfRangeException)
            {
                Assert.Fail("s: {0}. numRows: {1}.", s, numRows);
            }
        });
    }

    private string Convert(string s, int numRows)
    {
        if (numRows == 1) return s;
        var points = new List<Tuple<int, int, char>>();
        var i = 0;
        var j = 0;
        var k = 0;
        var down = true;
        while (i < s.Length)
        {
            points.Add(Tuple.Create(j, k, s[i]));
            j = j + (down ? 1 : -1);
            if (j == numRows || j < 0)
            {
                down = !down;
                j = j + (down ? 2 : -2);
                ++k;
            }
            ++i;
        }
        return new string(points.OrderBy(t => t.Item1).ThenBy(t => t.Item2).Select(t => t.Item3).ToArray());
    }
}