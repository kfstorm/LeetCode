using NUnit.Framework;

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
        var head = ListNode.Deserialize(listString);
        var result = new Solution().RotateRight(head, k);
        Assert.AreEqual(expectedResultString, ListNode.Serialize(result));
    }
}