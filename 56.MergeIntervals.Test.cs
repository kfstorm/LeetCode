using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

public class Interval {
    public int start;
    public int end;
    public Interval() { start = 0; end = 0; }
    public Interval(int s, int e) { start = s; end = e; }
}

[TestFixture]
public class TestClass
{
    private static Random _random = new Random();

    [TestCase(10, 10, 10, 1000)]
    public void TestMethod(int maxStart, int maxInterval, int maxLength, int repeatTimes)
    {
        for(var r = 0; r < repeatTimes; ++r)
        {
            var length = _random.Next(maxLength + 1);
            var intervals1 = new Interval[length];
            var intervals2 = new Interval[length];
            for (var i = 0; i < length; ++i)
            {
                var start = _random.Next(maxStart + 1);
                var end = start + _random.Next(maxInterval + 1);
                intervals1[i] = new Interval(start, end);
                intervals2[i] = new Interval(start, end);
            }
            var original = JsonConvert.SerializeObject(intervals1);
            var expectedResult = ToString(Merge(intervals1));
            var result = ToString(new Solution().Merge(intervals2));
            Assert.AreEqual(expectedResult, result, original);
        }
    }

    private string ToString(IList<Interval> intervals)
    {
        return JsonConvert.SerializeObject(intervals.OrderBy(i => i.start).ThenBy(i => i.end));
    }

    private IList<Interval> Merge(IList<Interval> intervals)
    {
        var result = new HashSet<Interval>();
        foreach (var interval in intervals)
        {
            var temp = interval;
            while (true)
            {
                var found = result.FirstOrDefault(i => i.start <= temp.end && i.end >= temp.start);
                if (found == null)
                {
                    break;
                }
                result.Remove(found);
                temp = new Interval(Math.Min(found.start, temp.start), Math.Max(found.end, temp.end));
            }
            result.Add(temp);
        }
        return result.ToList();
    }
}