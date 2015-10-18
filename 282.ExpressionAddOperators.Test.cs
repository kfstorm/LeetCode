using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase("123", 6, "[\"1+2+3\", \"1*2*3\"]")]
    [TestCase("232", 8, "[\"2*3+2\", \"2+3*2\"]")]
    [TestCase("105", 5, "[\"1*0+5\",\"10-5\"]")]
    [TestCase("105", 6, "[\"1-0+5\",\"1+0+5\"]")]
    [TestCase("00", 0, "[\"0+0\", \"0-0\", \"0*0\"]")]
    [TestCase("2147483648", -2147483648 , "[]")]
    [TestCase("3456237490", 9191 , "[]")]
    public void TestMethod1(string num, int target, string expectedResultString)
    {
        expectedResultString = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<IList<string>>(expectedResultString).OrderBy(x => x));
        var results = new Solution().AddOperators(num, target);
        Assert.AreEqual(expectedResultString, JsonConvert.SerializeObject(results.OrderBy(x => x)));
    }
}