using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase("2", "['a', 'b', 'c']")]
    [TestCase("23", "['ad', 'ae', 'af', 'bd', 'be', 'bf', 'cd', 'ce', 'cf']")]
    public void TestMethod(string digits, string expectedResultString)
    {
        var expectedResult = JsonConvert.DeserializeObject<IList<string>>(expectedResultString);
        var result = new Solution().LetterCombinations(digits);
        Assert.AreEqual(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));
    }
}
