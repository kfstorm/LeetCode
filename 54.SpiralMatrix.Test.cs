using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("[]", "[]")]
    [TestCase("[ [ 1 ] ]", "[1]")]
    [TestCase("[ [ 1 ], [ 4 ] ]", "[1,4]")]
    [TestCase("[ [ 1 ], [ 4 ], [ 7 ] ]", "[1,4,7]")]
    [TestCase("[ [ 1, 2] ]", "[1,2]")]
    [TestCase("[ [ 1, 2 ], [ 4, 5 ] ]", "[1,2,5,4]")]
    [TestCase("[ [ 1, 2 ], [ 4, 5 ], [ 7, 8 ] ]", "[1,2,5,8,7,4]")]
    [TestCase("[ [ 1, 2, 3 ] ]", "[1,2,3]")]
    [TestCase("[ [ 1, 2, 3 ], [ 4, 5, 6 ]]", "[1,2,3,6,5,4]")]
    [TestCase("[ [ 1, 2, 3 ], [ 4, 5, 6 ], [ 7, 8, 9 ]]", "[1,2,3,6,9,8,7,4,5]")]
    public void TestMethod(string matrixString, string expectedResultString)
    {
        var matrix = JsonConvert.DeserializeObject<int[,]>(matrixString);
        var result = new Solution().SpiralOrder(matrix);
        Assert.AreEqual(expectedResultString, JsonConvert.SerializeObject(result));
    }
}