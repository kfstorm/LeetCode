using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT", "[\"AAAAACCCCC\", \"CCCCCAAAAA\"]")]
    public void TestMethod(string s, string expectedResultString)
    {
        expectedResultString = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<IList<string>>(expectedResultString).OrderBy(dna => dna));
        var answer = new Solution().FindRepeatedDnaSequences(s);
        Assert.AreEqual(expectedResultString, JsonConvert.SerializeObject(answer.OrderBy(dna => dna)));
    }
}
