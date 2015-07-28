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
    [TestCase("[]", 0, "[]")]
    [TestCase("[]", 1, "[]")]
    [TestCase("[1]", 0, "[1]")]
    [TestCase("[1]", 1, "[1]")]
    [TestCase("[1]", 2, "[1]")]
    [TestCase("[1,2]", 0, "[1,2]")]
    [TestCase("[1,2]", 1, "[2,1]")]
    [TestCase("[1,2]", 2, "[1,2]")]
    [TestCase("[1,2]", 3, "[2,1]")]
    [TestCase("[1,2,3,4,5]", 0, "[1,2,3,4,5]")]
    [TestCase("[1,2,3,4,5]", 1, "[5,1,2,3,4]")]
    [TestCase("[1,2,3,4,5]", 2, "[4,5,1,2,3]")]
    [TestCase("[1,2,3,4,5]", 3, "[3,4,5,1,2]")]
    [TestCase("[1,2,3,4,5]", 4, "[2,3,4,5,1]")]
    [TestCase("[1,2,3,4,5]", 5, "[1,2,3,4,5]")]
    public void TestMethod(string listString, int k, string expectedResultString)
    {
        var head = GetHead(JsonConvert.DeserializeObject<int[]>(listString));
        var result = new Solution().RotateRight(head, k);
        Assert.AreEqual(expectedResultString, JsonConvert.SerializeObject(GetList(result)));
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