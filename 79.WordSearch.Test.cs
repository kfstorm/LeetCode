using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TextClass
{
    [TestCase("[\"ABCE\", \"SFCS\", \"ADEE\"]", "ABCCED", true)]
    [TestCase("[\"ABCE\", \"SFCS\", \"ADEE\"]", "SEE", true)]
    [TestCase("[\"ABCE\", \"SFCS\", \"ADEE\"]", "ABCB", false)]
    public void TestMethod(string boardString, string word, bool expectedResult)
    {
        var boardStrings = JsonConvert.DeserializeObject<string[]>(boardString);
        var board = new char[boardStrings.Length, boardStrings[0].Length];
        for (var i = 0; i < boardStrings.Length; ++i)
        {
            for (var j = 0; j < boardStrings[i].Length; ++j)
            {
                board[i, j] = boardStrings[i][j];
            }
        }
        var answer = new Solution().Exist(board, word);
        Assert.AreEqual(expectedResult, answer);
    }
}
