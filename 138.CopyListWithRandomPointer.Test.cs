using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(10, 1000)]
    public void TestMethod(int maxLength, int repeatTimes)
    {
        Repeat(repeatTimes, () =>
        {
            var length = Random.Next(maxLength + 1);
            var nodes = Enumerable.Range(0, length).Select(i => new RandomListNode(i)).ToList();
            if (nodes.Any()) nodes.Aggregate((tail, next) => { tail.next = next; return next; });
            nodes.ForEach(n => {
                var index = Random.Next(length + 1);
                n.random = index < length ? nodes[index] : null;
            });
            var head = nodes.FirstOrDefault();

            var newHead = new Solution().CopyRandomList(head);
            var settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            Assert.AreEqual(JsonConvert.SerializeObject(head, settings), JsonConvert.SerializeObject(newHead, settings));
        });
    }
}
