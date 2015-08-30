using System.Linq;
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
            var values = GenerateIntegerArray(maxLength, maxValue);
            var head = ListNode.GetHead(values);
            var result = new Solution().ReverseList(head);
            Assert.AreEqual(JsonConvert.SerializeObject(values.Reverse()), ListNode.Serialize(result));
        });
    }
}
