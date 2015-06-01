using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ContainsDuplicateTest
{
    [TestCase("1,5,7,4,9,4,8,6", true)]
    [TestCase("1,5,7,4,9,1,8,6", true)]
    [TestCase("1,5,7,4,9,5,8,6", true)]
    [TestCase("1,5,7,4,9,6,8,6", true)]
    [TestCase("1,5,7,4,9,0,8,6", false)]
    [TestCase("1,2", false)]
    [TestCase("1,2,3,1,1,2,3", true)]
    [TestCase("1", false)]
    [TestCase("", false)]
    [TestCase("1,1", true)]
    public void Test(string nums, bool expectAnswer)
    {
        var array = nums.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var answer = new Solution().ContainsDuplicate(array);
        Assert.AreEqual(expectAnswer, answer);
    }
}
