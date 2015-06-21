using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class SurroundedRegionsTest
{
    [TestCase(@"
X X X X
X O O X
X X O X
X O X X
", @"
X X X X
X X X X
X X X X
X O X X
")]
    [TestCase(@"
X O X X
X O O X
X X O X
X O X X
", @"
X O X X
X O O X
X X O X
X O X X
")]
    [TestCase("O", "O")]
    public void Test(string boardString, string expectedResult)
    {
        var board = ParseBoard(boardString);
        new Solution().Solve(board);
        Assert.AreEqual(SerializeBoard(ParseBoard(expectedResult)), SerializeBoard(board));
    }

    private char[,] ParseBoard(string boardString)
    {
        var newBoard = boardString.Split(new []{ '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Replace(" ", "")).ToList();
        var board = new char[newBoard.Count, newBoard[0].Length];
        for (var i = 0; i < newBoard.Count; ++i)
        {
            for (var j = 0; j < newBoard[0].Length; ++j)
            {
                board[i, j] = newBoard[i][j];
            }
        }
        return board;
    }
    
    private string SerializeBoard(char [,] board)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < board.GetLength(0); ++i)
        {
            if (i != 0)
            {
                sb.Append('\n');
            }
            for (var j = 0; j < board.GetLength(1); ++j)
            {
                if (j != 0)
                {
                    sb.Append(' ');
                }
                sb.Append(board[i, j]);
            }
        }
        
        return sb.ToString();
    }
}
