using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class CountCompleteTreeNodesTest
{
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(1000)]
    [TestCase(2047)]
    [TestCase(2048)]
    [TestCase(2049)]
    public void Test(int count)
    {
        var queue = new Queue<TreeNode>();
        TreeNode root = null;
        for (int i = 0; i < count; i++)
        {
            var node = new TreeNode(i);
            if (i == 0) root = node;
            if (queue.Count != 0)
            {
                var parent = queue.Peek();
                if (parent.left == null)
                {
                    parent.left = node;
                }
                else
                {
                    parent.right = node;
                    queue.Dequeue();
                }
            }
            queue.Enqueue(node);
        }
        var result = new Solution().CountNodes(root);
        Assert.AreEqual(count, result);
    }
}
