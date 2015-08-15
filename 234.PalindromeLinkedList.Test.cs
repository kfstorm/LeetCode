using Newtonsoft.Json;
using NUnit.Framework;

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
        var head = ListNode.Deserialize(listString);
        var result = new Solution().IsPalindrome(head);
        Assert.AreEqual(expectedResult, result);
    }
}
