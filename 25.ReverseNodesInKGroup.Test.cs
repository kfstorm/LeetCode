using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 10, 1000)]
    public void TestMethod(int maxLength, int maxValue, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var nums = GenerateIntegerArray(maxLength, maxValue);
            var original = JsonConvert.SerializeObject(nums);
            var head = ListNode.GetHead(nums);
            var k = nums.Length == 0 ? 0 : Random.Next(1, nums.Length + 1);
            ReverseKGroup(nums, k);
            var result = new Solution().ReverseKGroup(head, k);
            Assert.AreEqual(JsonConvert.SerializeObject(nums), ListNode.Serialize(result),
                string.Format("{0}. {1}.", original, k));
        });
    }

    private void ReverseKGroup(int[] nums, int k)
    {
        if (k < 2) return;
        var i = 0;
        while (i + k <= nums.Length)
        {
            Array.Reverse(nums, i, k);
            i += k;
        }
    }
}
