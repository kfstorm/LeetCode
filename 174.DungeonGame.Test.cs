using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;

[TestFixture]
public class TestClass
{
    [TestCase("-2 -3 3, -5 -10 1, 10 30 -5", 7)]
    [TestCase("100", 1)]
    [TestCase("-5", 6)]
    [TestCase("-1", 2)]
    [TestCase("0", 1)]
    [TestCase("1", 1)]
    public void TestMethod(string dungeonString, int expectedResult)
    {
        var temp = dungeonString.Split(',').Select(line => Array.ConvertAll(line.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse)).ToArray();
        var dungeon = new int[temp.Length, temp[0].Length];
        for (var i = 0; i < temp.Length; ++i)
        {
            for (var j = 0; j < temp[0].Length; ++j)
            {
                dungeon[i, j] = temp[i][j];
            }
        }
        var answer = new Solution().CalculateMinimumHP(dungeon);
        Assert.AreEqual(expectedResult, answer);
    }
}
