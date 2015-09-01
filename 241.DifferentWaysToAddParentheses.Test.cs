using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase("2-1-1", "[0, 2]")]
    [TestCase("2*3-4*5", "[-34, -14, -10, -10, 10]")]
    public void TestMethod(string input, string expectedResultString)
    {
        var expectedResult = JsonConvert.DeserializeObject<List<int>>(expectedResultString);
        expectedResult.Sort();
        var result = new Solution().DiffWaysToCompute(input).OrderBy(x => x);
        Assert.AreEqual(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));
    }
}
