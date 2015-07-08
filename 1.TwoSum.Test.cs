using System;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("2 7 11 15", 9, 1, 2)]
    public void TestMethod(string numsString, int target, int expectedIndex1, int expectedIndex2)
    {
        var nums = Array.ConvertAll(numsString.Split(), int.Parse);
        var indices = new Solution().TwoSum(nums, target);
        Assert.AreEqual(expectedIndex1, indices[0]);
        Assert.AreEqual(expectedIndex2, indices[1]);
    }
}
