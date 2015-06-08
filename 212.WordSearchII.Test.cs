using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
", "oath,pea,eat,rain", "eat,oath")]
    [TestCase(@"
[
  ['o','a','a','n'],
  ['e','t','a','e'],
  ['i','h','e','r'],
  ['i','f','l','v']
]
", "oath,pea,eat,rain", "eat,oath")]
    [TestCase(@"
[
]
", "oath,pea,eat,rain", "")]
    [TestCase(@"
[
  ['o'],
]
", "o", "o")]
    public void Test(string boardString, string wordsString, string expectedFoundWordsString)
    {
        var sb = new StringBuilder();
        foreach (var ch in boardString)
        {
            if (char.IsLetter(ch) || ch == ']')
            {
                sb.Append(ch);
            }
        }
        var lines = sb.ToString().Split(new[] { ']' }, StringSplitOptions.RemoveEmptyEntries);
        var board = new char[lines.Length, lines.Length == 0 ? 0 : lines[0].Length];
        for (var i = 0; i < lines.Length; ++i)
        {
            for (var j = 0; j < lines[i].Length; ++j)
            {
                board[i, j] = lines[i][j];
            }
        }

        var words = SplitWords(wordsString);
        var expectedFoundWords = SplitWords(expectedFoundWordsString);

        var answer = new Solution().FindWords(board, words);
        Assert.AreEqual(WordsToString(expectedFoundWords), WordsToString(answer));
    }

    private string[] SplitWords(string wordsString)
    {
        return wordsString.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
    }

    private string WordsToString(IEnumerable<string> words)
    {
        return string.Join(",", words.OrderBy(w => w));
    }
}
