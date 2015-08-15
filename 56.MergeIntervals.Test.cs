using System.Linq;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 10, 10, 1000)]
    public void TestMethod(int maxStart, int maxInterval, int maxLength, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var intervals = GenerateArray<Interval>(0, maxLength, () =>
            {
                var start = Random.Next(maxStart + 1);
                var end = start + Random.Next(maxInterval + 1);
                return new Interval(start, end);
            });
            intervals = intervals.OrderBy(i => i.start).ThenBy(i => i.end).ToArray();
            var original = Interval.SerializeArray(intervals);
            var expectedResult = Interval.SerializeArray(Interval.Merge(Interval.DeserializeArray(original)));
            var result = Interval.SerializeArray(new Solution().Merge(Interval.DeserializeArray(original)));
            Assert.AreEqual(expectedResult, result, original);
        });
    }
}