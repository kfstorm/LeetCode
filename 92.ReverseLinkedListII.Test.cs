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
            var values = GenerateIntegerArray(1, maxLength, 0, maxValue);
            var m = Random.Next(1, values.Length + 1);
            var n = Random.Next(m, values.Length + 1);
            var head = ListNode.GetHead(values);
            var result = new Solution().ReverseBetween(head, m, n);
            var expectedResult = values.Take(m - 1).Concat(values.Skip(m - 1).Take(n - m + 1).Reverse()).Concat(values.Skip(n));
            Assert.AreEqual(JsonConvert.SerializeObject(expectedResult), ListNode.Serialize(result), "{0}. m: {1}. n: {2}.", JsonConvert.SerializeObject(values), m, n);
        });
    }
}
