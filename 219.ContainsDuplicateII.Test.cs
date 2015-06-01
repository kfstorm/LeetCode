using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ContainsDuplicateIITest
{
    [TestCase("1,5,7,4,9,4,8,6", 1, false)]
    [TestCase("1,5,7,4,9,4,8,6", 2, true)]
    [TestCase("1,5,7,4,9,1,8,6", 3, false)]
    [TestCase("1,5,7,4,9,1,8,6", 4, false)]
    [TestCase("1,5,7,4,9,1,8,6", 5, true)]
    [TestCase("1,5,7,4,9,5,8,6", 6, true)]
    [TestCase("1,5,7,4,9,6,8,6", 7, true)]
    [TestCase("1,5,7,4,9,0,8,6", 8, false)]
    [TestCase("1,2,1", 0, false)]
    [TestCase("1,2,3,1,1,2,3", 0, false)]
    public void Test(string nums, int k, bool expectAnswer)
    {
        var array = nums.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var answer = new Solution().ContainsNearbyDuplicate(array, k);
        Assert.AreEqual(expectAnswer, answer);
    }
}
