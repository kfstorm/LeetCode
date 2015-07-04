using System;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("1", "2", 1.5D)]
    [TestCase("1", "", 1D)]
    [TestCase("", "2", 2D)]
    [TestCase("1", "2 3", 2D)]
    [TestCase("1 2 3", "2 3 4", 2.5D)]
    [TestCase("5 6 7", "1 2 3 4", 4D)]
    [TestCase("1 1 1", "2 2 2", 1.5D)]
    [TestCase("1 1 1 1", "2 2 2", 1D)]
    [TestCase("1 1 1 2", "2 2 2", 2D)]
    [TestCase("1 1 1", "2 2 2 2", 2D)]
    [TestCase("1 1 1", "1 2 2 2", 1D)]
    [TestCase("1 3 5 7 9", "2 4 6 8 10", 5.5D)]
    [TestCase("1 3 5 7 9 11", "2 4 6 8 10", 6D)]
    [TestCase("1 3 5 7 9", "2 4 6 8 10 12", 6D)]
    [TestCase("2 3 4", "1", 2.5D)]
    [TestCase("1", "2 3 4", 2.5D)]
    [TestCase("1 2 3", "2 3 4 5 6 7 8 9", 4D)]
    [TestCase("1 2 3", "2 3 4 5 6 7 8 9 10 11 12 13", 6D)]
    [TestCase("1 2 3", "2 3 4 5 6 7 8 9 10 11 12 13 14", 6.5D)]
    [TestCase("-3 -2 -1", "2 3 4 5 6 7 8 9 10 11 12 13", 6D)]
    [TestCase("-3 -2 -1", "2 3 4 5 6 7 8 9 10 11 12 13 14", 6.5D)]
    public void TestMethod(string nums1String, string nums2String, double expectedResult)
    {
        var nums1 = string.IsNullOrEmpty(nums1String) ? new int[0] : Array.ConvertAll(nums1String.Split(), int.Parse);
        var nums2 = string.IsNullOrEmpty(nums2String) ? new int[0] : Array.ConvertAll(nums2String.Split(), int.Parse);
        Assert.AreEqual(expectedResult, new Solution().FindMedianSortedArrays(nums1, nums2));
    }
}