using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("[0,1,2,4,5,7]", "[\"0->2\",\"4->5\",\"7\"]")]
    [TestCase("[0]", "[\"0\"]")]
    [TestCase("[]", "[]")]
    [TestCase("[0,1,2]", "[\"0->2\"]")]
    public void TestMethod(string numsString, string expectedResult)
    {
        var nums = JsonConvert.DeserializeObject<int[]>(numsString);
        var result = new Solution().SummaryRanges(nums);
        Assert.AreEqual(expectedResult, JsonConvert.SerializeObject(result));
    }
}
