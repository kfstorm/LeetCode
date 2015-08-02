using System;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(@"
        53..7....
        6..195...
        .98....6.
        8...6...3
        4..8.3..1
        7...2...6
        .6....28.
        ...419..5
        ....8..79
    ", @"
        534678912
        672195348
        198342567
        859761423
        426853791
        713924856
        961537284
        287419635
        345286179
    ")]
    public void TestMethod1(string boardString, string expectedBoardString)
    {
        var board = DeserializeBoard(boardString);
        new Solution().SolveSudoku(board);
        Assert.AreEqual(SerializeBoard(DeserializeBoard(expectedBoardString)), SerializeBoard(board));
    }

    private char[,] DeserializeBoard(string boardString)
    {
        var board = new char[9,9];
        var i = 0;
        var j = 0;
        foreach (var ch in boardString)
        {
            if (ch == '.' || char.IsDigit(ch))
            {
                board[i, j] = ch;
                ++j;
                if (j == 9)
                {
                    ++i;
                    j = 0;
                }
            }
        }
        return board;
    }

    private string SerializeBoard(char[,] board)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < 9; ++i)
        {
            for (var j = 0; j < 9; ++j)
            {
                sb.Append(board[i, j]);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}