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
    private static Random _random = new Random();

    [TestCase(10, 20, 1000)]
    public void TestMethod(int maxLength, int maxValue, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var length = _random.Next(maxLength + 1);
            var values = new int[length];
            for (var i = 0; i < length; ++i)
            {
                values[i] = _random.Next(maxValue + 1);
            }
            var originalList = JsonConvert.SerializeObject(values);
            var head = GetHead(values);
            var result = JsonConvert.SerializeObject(GetList(new Solution().SortList(head)));
            Array.Sort(values);
            Assert.AreEqual(JsonConvert.SerializeObject(values), result, originalList);
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
