using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TextClass
{
    [TestCase("[['A','B','C','E'], ['S','F','C','S'], ['A','D','E','E']]", "ABCCED", true)]
    [TestCase("[['A','B','C','E'], ['S','F','C','S'], ['A','D','E','E']]", "SEE", true)]
    [TestCase("[['A','B','C','E'], ['S','F','C','S'], ['A','D','E','E']]", "ABCB", false)]

    public void TestMethod(string boardString, string word, bool expectedResult)
    {
        var board = JsonConvert.DeserializeObject<char[,]>(boardString);
        var answer = new Solution().Exist(board, word);
        Assert.AreEqual(expectedResult, answer);
    }
}
