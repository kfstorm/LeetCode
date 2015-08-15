using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("['11110', '11010', '11000', '00000']", 1)]
    [TestCase("['11000', '11000', '00100', '00011']", 3)]
    public void TestMethod(string gridString, int expectedResult)
    {
        var temp = JsonConvert.DeserializeObject<string[]>(gridString);
        var grid = new char[temp.Length, temp.Length == 0 ? 0 : temp[0].Length];
        for (var i = 0; i < grid.GetLength(0); ++i)
        {
            for (var j = 0; j < grid.GetLength(1); ++j)
            {
                grid[i, j] = temp[i][j];
            }
        }
        var result = new Solution().NumIslands(grid);
        Assert.AreEqual(expectedResult, result);
    }
}
