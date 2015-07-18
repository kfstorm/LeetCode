using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("barfoothefoobarman", "[\"foo\", \"bar\"]", "[0,9]")]
    [TestCase("wordgoodgoodgoodbestword", "[\"word\",\"good\",\"best\",\"good\"]", "[8]")]
    public void TestMethod(string s, string wordsString, string expectedResultString)
    {
        var words = JsonConvert.DeserializeObject<string[]>(wordsString);
        Assert.AreEqual(expectedResultString, JsonConvert.SerializeObject(new Solution().FindSubstring(s, words)));
    }
}