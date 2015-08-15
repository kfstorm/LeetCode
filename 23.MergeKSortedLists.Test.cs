using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase("[]", "[]")]
    [TestCase("[[]]", "[]")]
    [TestCase("[[1]]", "[1]")]
    [TestCase("[[1,2,3]]", "[1,2,3]")]
    [TestCase("[[1,1]]", "[1,1]")]
    [TestCase("[[1],[1]]", "[1,1]")]
    [TestCase("[[1],[1],[2]]", "[1,1,2]")]
    [TestCase("[[1],[1],[2]]", "[1,1,2]")]
    public void TestMethod1(string listsString, string expectedResult)
    {
        var lists = Array.ConvertAll(JsonConvert.DeserializeObject<int[][]>(listsString), ListNode.GetHead);
        var result = new Solution().MergeKLists(lists);
        Assert.AreEqual(expectedResult, ListNode.Serialize(result));
    }

    [TestCase(10, 10, 10, 10000)]
    public void TestMethod2(int maxK, int maxLength, int maxValue, int repeatCount)
    {
        Repeat(repeatCount, () =>
        {
            var k = Random.Next(maxK + 1);
            var lists = new ListNode[k];
            var allValues = new List<int>();
            for (var i = 0; i < k; ++i)
            {
                var values = GenerateIntegerArray(maxLength, maxValue);
                Array.Sort(values);
                lists[i] = ListNode.GetHead(values);
                allValues.AddRange(values);
            }
            allValues.Sort();
            var result = new Solution().MergeKLists(lists);
            Assert.AreEqual(JsonConvert.SerializeObject(allValues), ListNode.Serialize(result));
        });
    }
}
