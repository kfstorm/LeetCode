using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

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
        var head = ListNode.Deserialize(listString);
        new Solution().ReorderList(head);
        Assert.AreEqual(expectedResultString, ListNode.Serialize(head));
    }
}
