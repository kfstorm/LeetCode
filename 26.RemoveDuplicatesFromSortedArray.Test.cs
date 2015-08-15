using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 10, 1000)]
    public void TestMethod(int maxLength, int maxValue, int repeatTimes)
    {
        Repeat(repeatTimes, () => {
            var nums = GenerateIntegerArray(maxLength, maxValue);
            Array.Sort(nums);
            var original = JsonConvert.SerializeObject(nums);
            var expectedArray = nums.Distinct().ToArray();
            var resultLength = new Solution().RemoveDuplicates(nums);
            Assert.AreEqual(expectedArray.Length, resultLength, original);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedArray), JsonConvert.SerializeObject(nums.Take(resultLength)), original);
        });
    }
}