using System;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("1,2,3,4,5,6,7", 3, "5,6,7,1,2,3,4")]
    public void TestMethod(string numsString, int k, string expectedResultString)
    {
        var nums = Array.ConvertAll(numsString.Split(','), int.Parse);
        new Solution().Rotate(nums, k);
        Assert.AreEqual(expectedResultString, string.Join(",", nums));
    }
}
