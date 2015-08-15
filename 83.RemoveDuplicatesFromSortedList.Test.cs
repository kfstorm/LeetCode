using System;
using System.Collections.Generic;
using System.Linq;
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

    [TestCase(10, 10, 1000)]
    public void TestMethod(int maxLength, int maxValue, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var length = _random.Next(maxLength + 1);
            var listValues = new int[length];
            for (var i = 0; i < length; ++i)
            {
                listValues[i] = _random.Next(i == 0 ? 0 : listValues[i - 1], maxValue + 1);
            }

            var head = GetHead(listValues);
            var result = new Solution().DeleteDuplicates(head);
            Assert.AreEqual(JsonConvert.SerializeObject(listValues.Distinct()), JsonConvert.SerializeObject(GetList(result)), JsonConvert.SerializeObject(listValues));
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