using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class SurroundedRegionsTest
{
    [TestCase("[['X','X','X','X'],['X','O','O','X'],['X','X','O','X'],['X','O','X','X']]", "[['X','X','X','X'],['X','X','X','X'],['X','X','X','X'],['X','O','X','X']]")]
    [TestCase("[['X','O','X','X'],['X','O','O','X'],['X','X','O','X'],['X','O','X','X']]", "[['X','O','X','X'],['X','O','O','X'],['X','X','O','X'],['X','O','X','X']]")]
    [TestCase("[['O']]", "[['O']]")]
    public void Test(string boardString, string expectedResult)
    {
        var board = JsonConvert.DeserializeObject<char[,]>(boardString);
        new Solution().Solve(board);
        Assert.AreEqual(JsonConvert.SerializeObject(JsonConvert.DeserializeObject<char[,]>(expectedResult)), JsonConvert.SerializeObject(board));
    }
}
