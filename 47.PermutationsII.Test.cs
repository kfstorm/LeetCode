using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase("[1,2,3]", "[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]")]
    [TestCase("[1,1,3]", "[[1,1,3],[1,3,1],[3,1,1]]")]
    [TestCase("[]", "[]")]
    [TestCase("[1]", "[[1]]")]
    [TestCase("[1,1]", "[[1,1]]")]
    public void TestMethod(string numsString, string expectedResultString)
    {
        var nums = JsonConvert.DeserializeObject<int[]>(numsString);
        var result = new Solution().PermuteUnique(nums);
        Assert.AreEqual(expectedResultString, JsonConvert.SerializeObject(result));
    }
}