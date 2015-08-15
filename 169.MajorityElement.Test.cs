using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
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

    [TestCase(5, 5, 1000)]
    [TestCase(10, 10, 1000)]
    public void TestMethod2(int maxLength, int maxNumber, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var nums = GenerateIntegerArray(1, maxLength, 0, maxNumber);
            var majority = Random.Next(maxNumber + 1);
            var majorityLength = Random.Next(nums.Length / 2 + 1, nums.Length + 1);
            for (var i = 0; i < majorityLength; ++i)
            {
                nums[i] = majority;
            }
            Shuffle(nums);
            var result = new Solution().MajorityElement(nums);
            Assert.AreEqual(majority, result);
        });
    }
}
