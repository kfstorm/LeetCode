using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("[]", "[]")]
    [TestCase("[1]", "[1]")]
    [TestCase("[2]", "[2]")]
    [TestCase("[1,2]", "[2,1]")]
    [TestCase("[2,1]", "[1,2]")]
    [TestCase("[1,1,5]", "[1,5,1]")]
    [TestCase("[1,2,3]", "[1,3,2]")]
    [TestCase("[3,2,1]", "[1,2,3]")]
    [TestCase("[1,2,4,3]", "[1,3,2,4]")]
    public void TestMethod(string numsString, string expectedResultString)
    {
        var nums = JsonConvert.DeserializeObject<int[]>(numsString);
        new Solution().NextPermutation(nums);
        Assert.AreEqual(expectedResultString, JsonConvert.SerializeObject(nums));
    }
}
