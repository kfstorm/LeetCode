using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, -5, 15, 10000)]
    public void TestMethod(int maxLength, int minValue, int maxValue, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var nums = GenerateIntegerArray(0, maxLength, minValue, maxValue);
            var original = JsonConvert.SerializeObject(nums);
            var expectedResult = FirstMissingPositive(nums);
            var result = new Solution().FirstMissingPositive(nums);
            Assert.AreEqual(expectedResult, result, original);
        });
    }

    private int FirstMissingPositive(int[] nums)
    {
        return Enumerable.Range(1, nums.Length + 1).First(x => !nums.Contains(x));
    }
}