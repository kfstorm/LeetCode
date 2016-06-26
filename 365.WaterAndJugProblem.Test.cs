using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(0,0,0,true)]
    [TestCase(0,0,1,false)]
    [TestCase(3,5,4,true)]
    [TestCase(2,6,5,false)]
    [TestCase(5,11,1,true)]
    [TestCase(5,11,2,true)]
    [TestCase(5,11,3,true)]
    [TestCase(5,11,4,true)]
    [TestCase(5,12,0,true)]
    [TestCase(5,12,1,true)]
    [TestCase(5,12,2,true)]
    [TestCase(5,12,3,true)]
    [TestCase(5,12,4,true)]
    [TestCase(5,12,5,true)]
    [TestCase(5,12,6,true)]
    [TestCase(5,12,7,true)]
    [TestCase(5,12,8,true)]
    [TestCase(5,12,9,true)]
    [TestCase(5,12,10,true)]
    [TestCase(5,12,11,true)]
    [TestCase(5,12,12,true)]
    [TestCase(5,12,13,true)]
    [TestCase(5,12,14,true)]
    [TestCase(5,12,15,true)]
    [TestCase(5,12,16,true)]
    [TestCase(5,12,17,true)]
    [TestCase(1,100,0,true)]
    [TestCase(1,100,1,true)]
    [TestCase(1,100,2,true)]
    [TestCase(1,100,3,true)]
    [TestCase(1,100,4,true)]
    [TestCase(1,100,5,true)]
    [TestCase(1,100,6,true)]
    [TestCase(1,100,7,true)]
    [TestCase(1,100,8,true)]
    [TestCase(1,100,9,true)]
    public void TestMethod1(int x, int y, int z, bool expectedResult)
    {
        var result = new Solution().CanMeasureWater(x, y, z);
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase(100, 10000)]
    public void TestMethod2(int maxValue, int repeatCount)
    {
        Repeat(repeatCount, () =>
        {
            var x = Random.Next(maxValue) + 1;
            var y = Random.Next(maxValue) + 1;
            var z = Random.Next((x + y) * 2);
            TestMethod1(x, y, z, CanMeasureWater(x, y, z));
        });
    }

    private bool CanMeasureWater(int x, int y, int z) {
        if (z > x + y) return false;
        if (z == 0) return true;
        if (z < 0) return false;
        var states = new HashSet<KeyValuePair<int, int>>();
        var queue = new Queue<KeyValuePair<int, int>>();
        states.Add(new KeyValuePair<int, int>(0, 0));
        queue.Enqueue(states.Single());

        while (queue.Any())
        {
            var updates = GetUpdates(x, y, queue.Dequeue());
            foreach (var update in updates)
            {
                if (states.Add(update))
                {
                    queue.Enqueue(update);
                    if (update.Key == z || update.Value == z || update.Key + update.Value == z)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private IEnumerable<KeyValuePair<int, int>> GetUpdates(int x, int y, KeyValuePair<int, int> original)
    {
        if (original.Key < x)
        {
            yield return new KeyValuePair<int, int>(x, original.Value);
        }
        if (original.Value < y)
        {
            yield return new KeyValuePair<int, int>(original.Key, y);
        }
        if (original.Key > 0)
        {
            yield return new KeyValuePair<int, int>(0, original.Value);
        }
        if (original.Value > 0)
        {
            yield return new KeyValuePair<int, int>(original.Key, 0);
        }
        if (original.Key > 0 && original.Value < y)
        {
            var delta = Math.Min(original.Key, y - original.Value);
            yield return new KeyValuePair<int, int>(original.Key - delta, original.Value + delta);
        }
        if (original.Value > 0 && original.Key < x)
        {
            var delta = Math.Min(original.Value, x - original.Key);
            yield return new KeyValuePair<int, int>(original.Key + delta, original.Value - delta);
        }
    }
}