using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(3, 3)]
    [TestCase(2, 10)]
    public void TestMethod1(int k, int n)
    {
        var expectedResult = CombinationSum3(k, n);
        var result = new Solution().CombinationSum3(k, n);
        Assert.AreEqual(Serialize(expectedResult), Serialize(result), string.Format("{0}. {1}.", k, n));
    }

    [TestCase(10, 10, 100)]
    public void TestMethod2(int maxK, int maxN, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var k = Random.Next(maxK + 1);
            var n = Random.Next(maxN + 1);
            TestMethod1(k, n);
        });
    }

    private IList<IList<int>> CombinationSum3(int k, int n)
    {
        var results = new List<IList<int>>();
        Search(results, new Stack<int>(), 1, k, n);
        results = results.GroupBy(item => JsonConvert.SerializeObject(item)).Select(g => g.First()).ToList();
        return results;
    }

    private void Search(IList<IList<int>> results, Stack<int> temp, int x, int k, int n)
    {
        if (temp.Count > 0 && k == 0 && n == 0)
        {
            results.Add(temp.OrderBy(y => y).ToList());
        }
        if (n <= 0 || x > 9 || k <= 0)
        {
            return;
        }
        temp.Push(x);
        Search(results, temp, x + 1, k - 1, n - x);
        temp.Pop();
        Search(results, temp, x + 1, k, n);
    }

    private string Serialize(IList<IList<int>> results)
    {
        return JsonConvert.SerializeObject(results.OrderBy(item => JsonConvert.SerializeObject(item)).Select(item => item));
    }
}
