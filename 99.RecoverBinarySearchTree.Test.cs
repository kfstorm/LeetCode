using System;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 1000)]
    public void TestMethod(int maxSize, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var size = Random.Next(2, maxSize + 1);
            var allNodes = new TreeNode[size];
            var root = CreateTree(allNodes, 0, size - 1);
            var value1 = Random.Next(0, size - 1);
            var value2 = Random.Next(value1 + 1, size);
            Assert.IsTrue(value1 < value2);
            allNodes[value1].val = value2;
            allNodes[value2].val = value1;
            var testData = string.Format("value1: {0}. value2: {1}.\r\ntree:\r\n {2}",
                value1, value2, JsonConvert.SerializeObject(root, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            try
            {
                new Solution().RecoverTree(root);
            }
            catch (Exception ex)
            {
                Assert.Fail("{0}\r\nException: {1}", testData, ex);
            }
            Assert.AreEqual(value1, allNodes[value1].val, testData);
            Assert.AreEqual(value2, allNodes[value2].val, testData);
        });
    }

    private TreeNode CreateTree(TreeNode[] allNodes, int minValue, int maxValue)
    {
        if (minValue > maxValue) return null;
        var value = Random.Next(minValue, maxValue + 1);
        var node = new TreeNode(value)
        {
            left = CreateTree(allNodes, minValue, value - 1),
            right = CreateTree(allNodes, value + 1, maxValue)
        };
        allNodes[node.val] = node;
        return node;
    }
}
