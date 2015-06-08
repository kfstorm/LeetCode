using System;
using System.Globalization;
using System.Linq;
using System.Text;
using NUnit.Framework;
using P149;

[TestFixture]
public class MaxPointsOnALineTest
{
    [TestCase("", 0)]
    [TestCase("1,2", 1)]
    [TestCase("1,2 1,2", 2)]
    [TestCase("1,2 1,3", 2)]
    [TestCase("1,2 1,3 1,4", 3)]
    [TestCase("1,2 1,3 1,4 2,4 3,6 4,8", 4)]
    public void Test(string pointsString, int expectedResult)
    {
        var points = pointsString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split(',')).Select(ss => new Point(int.Parse(ss[0]), int.Parse(ss[1]))).ToArray();
        var answer = new Solution().MaxPoints(points);
        Assert.AreEqual(expectedResult, answer);
    }
}
