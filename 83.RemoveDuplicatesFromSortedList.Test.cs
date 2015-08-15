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
            var listValues = GenerateIntegerArray(maxLength, maxValue);
            Array.Sort(listValues);
            var head = ListNode.GetHead(listValues);
            var result = new Solution().DeleteDuplicates(head);
            Assert.AreEqual(JsonConvert.SerializeObject(listValues.Distinct()), ListNode.Serialize(result), JsonConvert.SerializeObject(listValues));
        });
    }
}