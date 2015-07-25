using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

[TestFixture]
public class TestClass
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
        var lists = Array.ConvertAll(JsonConvert.DeserializeObject<int[][]>(listsString), GetHead);
        var result = new Solution().MergeKLists(lists);
        Assert.AreEqual(expectedResult, JsonConvert.SerializeObject(GetList(result)));
    }

    [TestCase(10, 10, 10, 10000)]
    public void TestMethod2(int maxK, int maxLength, int maxValue, int repeatCount)
    {
        var random = new Random();
        for (var r = 0; r < repeatCount; ++r)
        {
            var k = random.Next(maxK + 1);
            var lists = new ListNode[k];
            var allValues = new List<int>();
            for (var i = 0; i < k; ++i)
            {
                var length = random.Next(maxLength + 1);
                var values = new int[length];
                for (var j = 0; j < length; ++j)
                {
                    values[j] = random.Next(maxValue + 1);
                }
                Array.Sort(values);
                lists[i] = GetHead(values);
                allValues.AddRange(values);
            }
            allValues.Sort();
            var result = new Solution().MergeKLists(lists);
            Assert.AreEqual(JsonConvert.SerializeObject(allValues), JsonConvert.SerializeObject(GetList(result)));
        }
    }

    private ListNode GetHead(int[] values)
    {
        ListNode head = null;
        ListNode current = null;
        foreach (var val in values)
        {
            if (head == null)
            {
                head = new ListNode(val);
                current = head;
            }
            else
            {
                current.next = new ListNode(val);
                current = current.next;
            }
        }
        return head;
    }

    private IEnumerable<int> GetList(ListNode head)
    {
        while (head != null)
        {
            yield return head.val;
            head = head.next;
        }
    }
}
