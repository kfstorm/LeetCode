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
    [TestCase("[2,4,3]", "[5,6,4]", "[7,0,8]")]
    [TestCase("[2,4,3]", "[5,6,4,1,1,1]", "[7,0,8,1,1,1]")]
    [TestCase("[2,4,7]", "[5,6,4,1,1,1]", "[7,0,2,2,1,1]")]
    [TestCase("[9,9,9]", "[9,9,9,9,9]", "[8,9,9,0,0,1]")]
    public void TestMethod(string l1String, string l2String, string expectedResultString)
    {
        var l1 = Deserialize(l1String);
        var l2 = Deserialize(l2String);
        var result = new Solution().AddTwoNumbers(l1, l2);
        Assert.AreEqual(expectedResultString, Serialize(result));
    }
    
    private ListNode Deserialize(string list)
    {
        var array = JsonConvert.DeserializeObject<int[]>(list);
        ListNode next = null;
        for (var i = array.Length - 1; i >= 0; --i)
        {
            var node = new ListNode(array[i]) { next = next };
            next = node;
        }
        return next;
    }
    
    private string Serialize(ListNode node)
    {
        var list = new List<int>();
        while (node != null)
        {
            list.Add(node.val);
            node = node.next;
        }
        return JsonConvert.SerializeObject(list);
    }
}
