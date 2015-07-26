using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("[]", "[]")]
    [TestCase("[1]", "[1]")]
    [TestCase("[1,1]", "[1]")]
    [TestCase("[1,2,2]", "[2]")]
    [TestCase("[2,2,2]", "[2]")]
    [TestCase("[5,2,6,6,6]", "[6]")]
    [TestCase("[3,2,3]", "[3]")]
    [TestCase("[10,9,9,9,10]", "[9,10]")]
    public void TestMethod1(string numsString, string expectedresultString)
    {
        var nums = JsonConvert.DeserializeObject<int[]>(numsString);
        expectedresultString = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<int[]>(expectedresultString).OrderBy(i => i));
        var result = new Solution().MajorityElement(nums);
        Assert.AreEqual(expectedresultString, JsonConvert.SerializeObject(result.OrderBy(i => i)));
    }

    private static Random _random = new Random();

    [TestCase(5, 5, 1000)]
    [TestCase(10, 10, 1000)]
    public void TestMethod2(int maxLength, int maxNumber, int repeatTimes)
    {
        var majorityCounts = new HashSet<int>();
        for (var r = 0; r < repeatTimes; ++r)
        {
            var length = _random.Next(1, maxLength + 1);
            var nums = new int[length];
            var oneMajority = _random.Next(maxNumber + 1);
            var oneMajorityLength = _random.Next(length / 2 + 1, length + 1);
            for (var i = 0; i < length; ++i)
            {
                nums[i] = i < oneMajorityLength ? oneMajority : _random.Next(maxNumber + 1);
            }
            for (var i = 0; i < length; ++i)
            {
                var j = _random.Next(i, length);
                var temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
            var expectedresult = nums.GroupBy(i => i).Where(g => g.Count() > length / 3).Select(g => g.Key).OrderBy(i => i);
            var result = new Solution().MajorityElement(nums).OrderBy(i => i);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedresult), JsonConvert.SerializeObject(result));
            majorityCounts.Add(result.Count());
        }
        Assert.IsFalse(majorityCounts.Contains(0));
        Assert.IsTrue(majorityCounts.Contains(1));
        Assert.IsTrue(majorityCounts.Contains(2));
        Assert.IsTrue(majorityCounts.Contains(2));
    }
}
