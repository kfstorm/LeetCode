using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("[0]", true)]
    [TestCase("[2,3,1,1,4]", true)]
    [TestCase("[3,2,1,0,4]", false)]
    public void TestMethod(string numsString, bool expectedResultString)
    {
        var nums = JsonConvert.DeserializeObject<int[]>(numsString);
        var result = new Solution().CanJump(nums);
        Assert.AreEqual(expectedResultString, result);
    }
}