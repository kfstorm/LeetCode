using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("25525511135", "[\"255.255.11.135\", \"255.255.111.35\"]")]
    [TestCase("0000", "[\"0.0.0.0\"]")]
    [TestCase("00000000000000000000000", "[]")]
    [TestCase("1111", "[\"1.1.1.1\"]")]
    [TestCase("11111", "[\"11.1.1.1\",\"1.11.1.1\",\"1.1.11.1\",\"1.1.1.11\"]")]
    [TestCase("555555555555", "[]")]
    [TestCase("55555555555", "[]")]
    [TestCase("5555555555", "[]")]
    [TestCase("555555555", "[]")]
    [TestCase("55555555", "[\"55.55.55.55\"]")]
    [TestCase("010010", "[\"0.10.0.10\",\"0.100.1.0\"]")]
    [TestCase("1000", "[\"1.0.0.0\"]")]
    [TestCase("10000", "[\"10.0.0.0\"]")]
    [TestCase("100000", "[\"100.0.0.0\"]")]
    [TestCase("1000000", "[]")]
    [TestCase("11111111111111111", "[]")]
    [TestCase("00000000000000000", "[]")]
    public void TestMethod(string s, string expectedResultString)
    {
        expectedResultString = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<string[]>(expectedResultString).OrderBy(ip => ip));
        var answer = new Solution().RestoreIpAddresses(s);
        var answerString = JsonConvert.SerializeObject(answer.OrderBy(ip => ip));
        Assert.AreEqual(expectedResultString, answerString);
    }
}
