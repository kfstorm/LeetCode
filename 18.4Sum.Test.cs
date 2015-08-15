using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, -10, 10, 1000)]
    public void TestMethod(int maxLength, int min, int max, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var nums = GenerateIntegerArray(0, maxLength, min, max);
            var target = Random.Next(min * nums.Length, (max + 1) * nums.Length);
            var expectedResult = FourSum(nums, target);
            var expectedResultString = JsonConvert.SerializeObject(expectedResult.OrderBy(x => string.Join(",", x)));
            var result = new Solution().FourSum(nums, target);
            var resultString = JsonConvert.SerializeObject(result.OrderBy(x => string.Join(",", x)));
            Assert.AreEqual(expectedResultString, resultString, string.Format("nums: {0}. target: {1}.", JsonConvert.SerializeObject(nums), target));
        });
    }

    private IList<IList<int>> FourSum(int[] nums, int target)
    {
        var results = new HashSet<IList<int>>(new FourSumComparer());
        for (var i = 0; i < nums.Length; ++i)
        {
            for (var j = i + 1; j < nums.Length; ++j)
            {
                for (var k = j + 1; k < nums.Length; ++k)
                {
                    for (var l = k + 1; l < nums.Length; ++l)
                    {
                        if (nums[i] + nums[j] + nums[k] + nums[l] == target)
                        {
                            var array = new []{ nums[i], nums[j], nums[k], nums[l] };
                            Array.Sort(array);
                            results.Add(array);
                        }
                    }
                }
            }
        }
        return results.ToList();
    }
}
