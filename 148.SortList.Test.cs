using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 20, 1000)]
    public void TestMethod(int maxLength, int maxValue, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var values = GenerateIntegerArray(maxLength, maxValue);
            var originalList = JsonConvert.SerializeObject(values);
            var head = ListNode.GetHead(values);
            var result = new Solution().SortList(head);
            Array.Sort(values);
            Assert.AreEqual(JsonConvert.SerializeObject(values), ListNode.Serialize(result), originalList);
        });
    }
}
