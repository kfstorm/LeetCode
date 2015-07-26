using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("[1]", 1)]
    [TestCase("[1,1]", 1)]
    [TestCase("[1,2,2]", 2)]
    [TestCase("[2,2,2]", 2)]
    [TestCase("[5,2,6,6,6]", 6)]
    [TestCase("[3,2,3]", 3)]
    [TestCase("[10,9,9,9,10]", 9)]
    public void TestMethod1(string numsString, int expectedresult)
    {
        var nums = JsonConvert.DeserializeObject<int[]>(numsString);
        var result = new Solution().MajorityElement(nums);
        Assert.AreEqual(expectedresult, result);
    }

    private static Random _random = new Random();

    [TestCase(5, 5, 1000)]
    [TestCase(10, 10, 1000)]
    public void TestMethod2(int maxLength, int maxNumber, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var length = _random.Next(1, maxLength + 1);
            var nums = new int[length];
            var majority = _random.Next(maxNumber + 1);
            var majorityLength = _random.Next(length / 2 + 1, length + 1);
            for (var i = 0; i < length; ++i)
            {
                nums[i] = i < majorityLength ? majority : _random.Next(maxNumber + 1);
            }
            for (var i = 0; i < length; ++i)
            {
                var j = _random.Next(i, length);
                var temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
            var result = new Solution().MajorityElement(nums);
            Assert.AreEqual(majority, result);
        }
    }
}
