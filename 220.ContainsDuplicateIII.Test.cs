using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ContainsDuplicateIIITest
{
    [TestCase("1,5,7,4,9,4,8,6", 1, 1, false)]
    [TestCase("1,5,7,4,9,4,8,6", 2, 1, true)]
    [TestCase("1,5,7,4,9,4,8,6", 2, 0, true)]
    [TestCase("1,5,7,4,9,5,8,6", 2, 0, false)]
    [TestCase("1,5,7,4,9,1,8,6", 3, 0, false)]
    [TestCase("1,5,7,4,9,1,8,6", 3, 1, true)]
    [TestCase("1,5,7,0,9,4,8,0", 4, 0, true)]
    [TestCase("1,5,7,0,9,4,8,-1", 4, 0, false)]
    [TestCase("1,5,7,0,9,4,8,-1", 4, 1, true)]
    [TestCase("-8,5,7,0,9,3,11,-2", 4, 1, false)]
    [TestCase("1,2,1", 0, 1, false)]
    [TestCase("1,2,3,1,1,2,3", 1, 0, true)]
    [TestCase("-1,2147483647", 1, 2147483647, false)]
    public void Test(string nums, int k, int t, bool expectAnswer)
    {
        var array = nums.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var answer = new Solution().ContainsNearbyAlmostDuplicate(array, k, t);
        Assert.AreEqual(expectAnswer, answer);
    }
}
