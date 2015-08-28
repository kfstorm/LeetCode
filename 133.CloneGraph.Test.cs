using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [Test]
    public void TestMethod()
    {
        var nodes = Enumerable.Range(1, 5).Select(i => new UndirectedGraphNode(i)).ToList();
        for (var i = 0; i < nodes.Count; ++i)
        {
            for (var j = 0; j < nodes.Count; ++j)
            {
                if (i != j)
                {
                    nodes[i].neighbors.Add(nodes[j]);
                }
            }
        }

        var result = new Solution().CloneGraph(nodes[0]);
        var settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        };
        Assert.AreEqual(JsonConvert.SerializeObject(nodes[0], settings), JsonConvert.SerializeObject(result, settings));
    }
}
