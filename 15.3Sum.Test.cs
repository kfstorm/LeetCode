using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("-1 0 1 2 -1 -4", "(-1, 0, 1) (-1, -1, 2)")]
    [TestCase("", "")]
    [TestCase("1", "")]
    [TestCase("1 2", "")]
    [TestCase("-1 0 1", "(-1, 0, 1)")]
    [TestCase("0 0 0 0", "(0, 0, 0)")]
    public void TestMethod(string numsString, string expectedResultString)
    {
        var nums = Array.ConvertAll(numsString.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        var expectedResultList = (from threeSum in expectedResultString.Replace(" ", "")
                                    .Split(new [] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                                    select Array.ConvertAll(threeSum.Split(','), int.Parse).ToArray()).ToArray();
        var answer = new Solution().ThreeSum(nums);
        Assert.AreEqual(FormatResults(expectedResultList), FormatResults(answer));
    }
    
    private string FormatResults(IList<IList<int>> results)
    {
        return string.Join(" ", results.Select(threeSum => "(" + string.Join(", ", threeSum) + ")"));
    }
}
