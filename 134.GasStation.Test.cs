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
            var length = Random.Next(maxLength + 1);
            var gas = GenerateIntegerArray(length, length, 0, maxValue);
            var cost = GenerateIntegerArray(length, length, 0, maxValue);
            var expectedResult = CanCompleteCircuit(gas, cost);
            var result = new Solution().CanCompleteCircuit(gas, cost);
            Assert.AreEqual(expectedResult, result);
        });
    }

    private int CanCompleteCircuit(int[] gas, int[] cost)
    {
        for (var start = 0; start < gas.Length; ++start)
        {
            var gasLeft = 0;
            var end = start;
            for (; end < start + gas.Length; ++end)
            {
                gasLeft += gas[end % gas.Length] - cost[end % gas.Length];
                if (gasLeft < 0) break;
            }
            if (end == start + gas.Length) return start;
        }
        return -1;
    }
}
