using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 100, 1000)]
    public void TestMethod(int maxlength, int maxValue, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
           var values = GenerateIntegerArray(maxlength, maxValue);
           var val = Random.Next(maxValue + 1);
           var original = JsonConvert.SerializeObject(values);
           var expectedResult = JsonConvert.SerializeObject(values.Where(v => v != val));
           var head = ListNode.GetHead(values);
           var result = new Solution().RemoveElements(head, val);
           Assert.AreEqual(expectedResult, ListNode.Serialize(result), "values: {0}. val: {1}", original, val);
        });
    }

    private int RangeBitwiseAnd(int m, int n) {
        var result = m;
        for (var i = m + 1; i <= n; ++i)
        {
            result &= i;
        }
        return result;
    }
}
