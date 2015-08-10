using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("[0]", 0)]
    [TestCase("[2,3,1,1,4]", 2)]
    [TestCase("[3,2,1,0,4]", -1)]
    public void TestMethod(string numsString, int expectedResultString)
    {
        var nums = JsonConvert.DeserializeObject<int[]>(numsString);
        var result = new Solution().Jump(nums);
        Assert.AreEqual(expectedResultString, result);
    }
}