using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(1000, 1000)]
    public void TestMethod(int maxOpsCount, int repeatTimes)
    {
        Repeat(repeatTimes, () => {
            var opsCount = Random.Next(maxOpsCount + 1);
            var list = new SortedList<Tuple<double, int>, object>(new Comparer());
            var finder = new MedianFinder();
            for (var i = 0; i < opsCount; ++i)
            {
                if (i == 0 || Random.Next(2) == 0)
                {
                    double newValue = Random.Next(100);
                    //System.Console.WriteLine("Add: " + newValue);
                    list.Add(Tuple.Create(newValue, i), null);
                    finder.AddNum(newValue);
                }
                else
                {
                    double expectedMedian;
                    if (list.Count % 2 == 0)
                    {
                        var x = new SortedList<object, object>();
                        expectedMedian = (list.ElementAt(list.Count / 2 - 1).Key.Item1 + list.ElementAt(list.Count / 2).Key.Item1) / 2;
                    }
                    else
                    {
                        expectedMedian = list.ElementAt(list.Count / 2).Key.Item1;
                    }
                    if (expectedMedian != finder.FindMedian())
                    {
                        Assert.AreEqual(expectedMedian, finder.FindMedian(), JsonConvert.SerializeObject(list.Keys.Select(k => k.Item1)));
                    }
                }
            }
        });
    }
}