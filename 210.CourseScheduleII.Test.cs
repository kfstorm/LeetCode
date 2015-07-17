using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(2, "[[1,0]]", true)]
    [TestCase(2, "[[1,0],[0,1]]", false)]
    [TestCase(4, "[[1,0],[2,0],[3,1],[3,2]]", true)]
    public void TestMethod(int numCourses, string prerequisitesString, bool isPossible)
    {
        var prerequisites = JsonConvert.DeserializeObject<int[,]>(prerequisitesString);
        var order = new Solution().FindOrder(numCourses, prerequisites);
        if (isPossible)
        {
            Assert.AreEqual(numCourses, order.Length);
            for (var i = 0; i < numCourses; ++i)
            {
                for (var j = i + 1; j < numCourses; ++j)
                {
                    for (var k = 0; k < prerequisites.GetLength(0); ++k)
                    {
                        Assert.IsFalse(order[i] == prerequisites[k, 0] && order[j] == prerequisites[k, 1]);
                    }
                }
            }
        }
        else
        {
            Assert.IsEmpty(order);
        }
    }
}
