using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("[2,4,3]", "[5,6,4]", "[7,0,8]")]
    [TestCase("[2,4,3]", "[5,6,4,1,1,1]", "[7,0,8,1,1,1]")]
    [TestCase("[2,4,7]", "[5,6,4,1,1,1]", "[7,0,2,2,1,1]")]
    [TestCase("[9,9,9]", "[9,9,9,9,9]", "[8,9,9,0,0,1]")]
    public void TestMethod(string l1String, string l2String, string expectedResultString)
    {
        var l1 = ListNode.Deserialize(l1String);
        var l2 = ListNode.Deserialize(l2String);
        var result = new Solution().AddTwoNumbers(l1, l2);
        Assert.AreEqual(expectedResultString, ListNode.Serialize(result));
    }
}
