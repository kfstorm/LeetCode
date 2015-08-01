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
    [TestCase("[]", true)]
    [TestCase("[1]", true)]
    [TestCase("[1,2]", false)]
    [TestCase("[1,1]", true)]
    [TestCase("[1,2,3]", false)]
    [TestCase("[1,2,1]", true)]
    [TestCase("[1,1,1]", true)]
    [TestCase("[1,2,3,4]", false)]
    [TestCase("[1,2,3,3]", false)]
    [TestCase("[1,2,3,1]", false)]
    [TestCase("[1,2,2,1]", true)]
    public void TestMethod(string listString, bool expectedResult)
    {
        var values = JsonConvert.DeserializeObject<int[]>(listString);
        var head = GetHead(values);
        var result = new Solution().IsPalindrome(head);
        Assert.AreEqual(expectedResult, result);
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
}
