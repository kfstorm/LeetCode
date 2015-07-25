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
    [TestCase("[1]", "[1]")]
    [TestCase("[1,2]", "[1,2]")]
    [TestCase("[1,2,3]", "[1,3,2]")]
    [TestCase("[1,2,3,4]", "[1,4,2,3]")]
    [TestCase("[1,2,3,4,5]", "[1,5,2,4,3]")]
    public void TestMethod(string listString, string expectedResultString)
    {
        var head = Deserialize(listString);
        new Solution().ReorderList(head);
        Assert.AreEqual(expectedResultString, Serialize(head));
    }
    
    private ListNode Deserialize(string listString)
    {
        var values = JsonConvert.DeserializeObject<int[]>(listString);
        ListNode head = null;
        ListNode last = null;
        for (var i = 0; i < values.Length; ++i)
        {
            var next = new ListNode(values[i]);
            if (head == null)
            {
                head = next;
                last = next;
            }
            else
            {
                last.next = next;
                last = next;
            }
        }
        return head;
    }
    
    private string Serialize(ListNode head)
    {
        var list = new List<int>();
        while (head != null)
        {
            list.Add(head.val);
            head = head.next;
        }
        return JsonConvert.SerializeObject(list);
    }
}
