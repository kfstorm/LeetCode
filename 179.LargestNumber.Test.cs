using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class TestClass
{
    [TestCase("3 30 34 5 9", "9534330")]
    [TestCase("5789 57 576 578 56789", "57895785765756789")]
    [TestCase("789 7 76 78 6789", "789787766789")]
    [TestCase("7 7 765 789 78", "7897877765")]
    [TestCase("0 0", "0")]
    [TestCase("1 2 3 4 5 6 7 8 9 0", "9876543210")]
    public void TestMethod(string numString, string expectedResult)
    {
        var nums = numString.Split(' ').Select(int.Parse).ToArray();
        var answer = new Solution().LargestNumber(nums);
        Assert.AreEqual(expectedResult, answer);
    }
}
