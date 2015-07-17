using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(2, "[[1,0]]", true)]
    [TestCase(2, "[[1,0],[0,1]]", false)]
    public void TestMethod(int numCourses, string prerequisitesString, bool expectedResult)
    {
        var prerequisites = JsonConvert.DeserializeObject<int[,]>(prerequisitesString);
        var result = new Solution().CanFinish(numCourses, prerequisites);
        Assert.AreEqual(expectedResult, result);
    }
}
