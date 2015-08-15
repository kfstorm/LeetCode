using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("{ val: 1, left: { val: 2 }, right: { val: 3 } }", 6)]
    [TestCase("{ val: 1 }", 1)]
    [TestCase("{ val: -1 }", -1)]
    [TestCase("{ val: -1, left: { val: 2 }, right: { val: 3 } }", 4)]
    [TestCase("{ val: -2, left: { val: 2 }, right: { val: 3 } }", 3)]
    [TestCase("{ val: -3, left: { val: 2 }, right: { val: 3 } }", 3)]
    [TestCase("{ val: 1, left: { val: 2 }, right: { val: -3 } }", 3)]
    public void TestMethod(string rootString, int expectedResult)
    {
        var root = JsonConvert.DeserializeObject<TreeNode>(rootString);
        var result = new Solution().MaxPathSum(root);
        Assert.AreEqual(expectedResult, result);
    }
}
