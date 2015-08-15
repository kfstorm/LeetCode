using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("null", true)]
    [TestCase("{ val: 1 }", true)]
    [TestCase("{ val: 1, left: { val: 2 }, right: { val: 3 } }", false)]
    [TestCase("{ val: 2, left: { val: 1 }, right: { val: 3 } }", true)]
    [TestCase("{ val: 2, left: { val: 1 }, right: { val: 3, left: { val: 4 }, right: { val: 5 } } }", false)]
    [TestCase("{ val: 2, left: { val: 1 }, right: { val: 3, left: { val: 1 }, right: { val: 5 } } }", false)]
    [TestCase("{ val: 2, left: { val: 1 }, right: { val: 4, left: { val: 3 }, right: { val: 5 } } }", true)]
    [TestCase("{ val: -2147483648 }", true)]
    [TestCase("{ val: -2147483648, left: { val: 2 }, right: { val: 3 } }", false)]
    [TestCase("{ val: -2147483648, left: { val: -2147483648 }, right: { val: 2147483647 } }", false)]
    [TestCase("{ val: -2147483647, left: { val: -2147483648 }, right: { val: 2147483647 } }", true)]
    [TestCase("{ val: 2147483647 }", true)]
    [TestCase("{ val: 2147483647, left: { val: 2 }, right: { val: 3 } }", false)]
    [TestCase("{ val: 2147483647, left: { val: -2147483648 }, right: { val: 2147483647 } }", false)]
    [TestCase("{ val: 2147483646, left: { val: -2147483648 }, right: { val: 2147483647 } }", true)]
    public void TestMethod(string rootString, bool expectedResult)
    {
        var root = JsonConvert.DeserializeObject<TreeNode>(rootString);
        var answer = new Solution().IsValidBST(root);
        Assert.AreEqual(expectedResult, answer);
    }
}
