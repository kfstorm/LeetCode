using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase("[2,1,1,2]", true)]
    [TestCase("[1,2,3,4]", false)]
    [TestCase("[1,1,1,1]", true)]
    public void TestMethod1(string xString, bool expectedResult)
    {
        var x = JsonConvert.DeserializeObject<int[]>(xString);
        var result = new Solution().IsSelfCrossing(x);
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase(100, 100, 10000)]
    public void TestMethod2(int maxValue, int maxLength, int repeatCount)
    {
        Repeat(repeatCount, () =>
        {
            var x = GenerateIntegerArray(1, maxLength, 1, maxValue);
            TestMethod1(JsonConvert.SerializeObject(x), IsSelfCrossing(x));
        });
    }

    private bool IsSelfCrossing(int[] x) {
        var points = new List<Tuple<int, int>>();
        points.Add(Tuple.Create(0, 0));
        var direction = 0;
        foreach (var len in x)
        {
            var original = points.Last();
            Tuple<int, int> current;
            switch (direction)
            {
                case 0:
                    current = Tuple.Create(original.Item1, original.Item2 + len);
                    break;
                case 1:
                    current = Tuple.Create(original.Item1 - len, original.Item2);
                    break;
                case 2:
                    current = Tuple.Create(original.Item1, original.Item2 - len);
                    break;
                default:
                    current = Tuple.Create(original.Item1 + len, original.Item2);
                    break;
            }
            direction++;
            if (direction > 3) direction = 0;
            for (var i = 1; i < points.Count - 1; ++i)
            {
                if (IsCrossing(points[i - 1].Item1, points[i - 1].Item2, points[i].Item1, points[i].Item2, original.Item1, original.Item2, current.Item1, current.Item2))
                {
                    return true;
                }
            }
            points.Add(current);
        }
        return false;
    }

    private bool IsCrossing(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
    {
        if (x1 != x2)
        {
            int temp;
            temp = x1; x1 = y1; y1 = temp;
            temp = x2; x2 = y2; y2 = temp;
            temp = x3; x3 = y3; y3 = temp;
            temp = x4; x4 = y4; y4 = temp;
        }
        if (x3 == x4)
        {
            if (x1 != x3) return false;
            return Math.Max(Math.Min(y1, y2), Math.Min(y3, y4)) <= Math.Min(Math.Max(y1, y2), Math.Max(y3, y4));
        }
        else
        {
            if (x1 < Math.Min(x3, x4) || x1 > Math.Max(x3, x4)) return false;
            if (y3 < Math.Min(y1, y2) || y3 > Math.Max(y1, y2)) return false;
            return true;
        }
    }
}