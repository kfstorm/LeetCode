using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("['2', '1', '+', '3', '*']", 9)]
    [TestCase("['4', '13', '5', '/', '+']", 6)]
    public void TestMethod(string tokensString, int expectedResult)
    {
        var tokens = JsonConvert.DeserializeObject<string[]>(tokensString);
        var answer = new Solution().EvalRPN(tokens);
        Assert.AreEqual(expectedResult, answer);
    }
}
