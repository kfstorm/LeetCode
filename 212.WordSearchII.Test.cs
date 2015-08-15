using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class WordSearchIITest
{
    [TestCase(@"
[
  ['o','a','a','n'],
  ['e','t','a','e'],
  ['i','h','k','r'],
  ['i','f','l','v']
]
", "['oath','pea','eat','rain']", "['eat','oath']")]
    [TestCase(@"
[
  ['o','a','a','n'],
  ['e','t','a','e'],
  ['i','h','e','r'],
  ['i','f','l','v']
]
", "['oath','pea','eat','rain']", "['eat','oath']")]
    [TestCase(@"
[
]
", "['oath','pea','eat','rain']", "[]")]
    [TestCase(@"
[
  ['o'],
]
", "['o']", "['o']")]
    public void Test(string boardString, string wordsString, string expectedFoundWordsString)
    {
        var board = JsonConvert.DeserializeObject<char[,]>(boardString);

        var words = JsonConvert.DeserializeObject<string[]>(wordsString);
        var expectedFoundWords = JsonConvert.DeserializeObject<string[]>(expectedFoundWordsString);

        var answer = new Solution().FindWords(board, words);
        Assert.AreEqual(JsonConvert.SerializeObject(expectedFoundWords.OrderBy(w => w)), JsonConvert.SerializeObject(answer.OrderBy(w => w)));
    }
}
