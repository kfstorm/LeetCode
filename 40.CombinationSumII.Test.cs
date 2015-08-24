using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase("[1,2,3]", 3)]
    [TestCase("[10,7,4,10,8,4,2,3,9,9]", 55)]
    public void TestMethod1(string candidatesString, int target)
    {
        var candidates = JsonConvert.DeserializeObject<int[]>(candidatesString);
        var expectedResult = CombinationSum2(candidates, target);
        var result = new Solution().CombinationSum2(candidates, target);
        Assert.AreEqual(Serialize(expectedResult), Serialize(result), string.Format("{0}. {1}.", candidatesString, target));
    }

    [TestCase(10, 10, 100)]
    public void TestMethod2(int maxLength, int maxValue, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var candidates = GenerateIntegerArray(0, maxLength, 1, maxValue);
            var candidatesString = JsonConvert.SerializeObject(candidates);
            var target = Random.Next(1, Math.Max(2, candidates.Sum() + 2));
            TestMethod1(candidatesString, target);
        });
    }

    private IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        var results = new List<IList<int>>();
        Search(results, new Stack<int>(), candidates, target, 0);
        results = results.GroupBy(item => JsonConvert.SerializeObject(item)).Select(g => g.First()).ToList();
        return results;
    }

    private void Search(IList<IList<int>> results, Stack<int> temp, int[] candidates, int remaining, int index)
    {
        if (remaining == 0)
        {
            if (temp.Count > 0)
            {
                results.Add(temp.OrderBy(x => x).ToList());
            }
            return;
        }
        if (remaining < 0 || index >= candidates.Length)
        {
            return;
        }
        temp.Push(candidates[index]);
        Search(results, temp, candidates, remaining - candidates[index], index + 1);
        temp.Pop();
        Search(results, temp, candidates, remaining, index + 1);
    }

    private string Serialize(IList<IList<int>> results)
    {
        return JsonConvert.SerializeObject(results.OrderBy(item => JsonConvert.SerializeObject(item)).Select(item => item));
    }
}
