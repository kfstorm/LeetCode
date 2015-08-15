using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class MaximalSquareTest
{
    [TestCase("[]", 0)]
    [TestCase("[['0']]", 0)]
    [TestCase("[['1']]", 1)]
    [TestCase(@"[['0','1'],
                ['0','0']]", 1)]
    [TestCase(@"[['0','1'],
                ['0','1']]", 1)]
    [TestCase(@"[['0','1'],
                ['1','0']]", 1)]
    [TestCase(@"[['0','1'],
                ['1','1']]", 1)]
    [TestCase(@"[['1','0'],
                ['1','1']]", 1)]
    [TestCase(@"[['1','1'],
                ['1','1']]", 4)]
    [TestCase(@"[['1','0','1','0','0'],
                ['1','0','1','1','1'],
                ['1','1','1','1','1'],
                ['1','0','0','1','0']]", 4)]
    [TestCase(@"[['1','0','1','0','0'],
                ['1','0','1','1','1'],
                ['1','1','1','1','1'],
                ['1','1','1','1','1'],
                ['1','0','0','1','0']]", 9)]
    [TestCase(@"[['1','1','0','0','0'],
                ['1','1','1','0','0'],
                ['0','1','1','1','0'],
                ['0','0','1','1','1'],
                ['0','0','0','1','1']]", 4)]
    [TestCase(@"[['1','1','1','1','1','1','1','1'],
                ['1','1','1','1','1','1','1','0'],
                ['1','1','1','1','1','1','1','0'],
                ['1','1','1','1','1','0','0','0'],
                ['0','1','1','1','1','0','0','0']]", 16)]
    public void Test(string matrixString, int expectedArea)
    {
        var matrix = JsonConvert.DeserializeObject<char[,]>(matrixString);
        var result = new Solution().MaximalSquare(matrix);
        Assert.AreEqual(expectedArea, result);
    }
}