using System;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(100, 1000)]
    public void TestMethod(int maxDiff, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
           var m = Random.Next();
           var n = m + Math.Min(int.MaxValue - m, Random.Next(maxDiff));
           var expectedResult = RangeBitwiseAnd(m, n);
           var result = new Solution().RangeBitwiseAnd(m, n);
           Assert.AreEqual(expectedResult, result, "m: {0}. n: {1}.", m, n);
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
