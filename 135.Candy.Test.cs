using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("[1, 3, 3, 4, 7, 2, 1, 1, -1, -2]", "[1, 2, 1, 2, 3, 2, 1, 3, 2, 1]")]
    [TestCase("[1, 3, 3, 4, 7, 3, 2, 1, -1, -2]", "[1, 2, 1, 2, 6, 5, 4, 3, 2, 1]")]
    [TestCase("[7, 3, 2, 1, -1, -2]", "[6, 5, 4, 3, 2, 1]")]
    [TestCase("[1, 2, 3, 4, 5]", "[1, 2, 3, 4, 5]")]
    public void TestMethod(string ratingsString, string candyString)
    {
        var ratings = JsonConvert.DeserializeObject<int[]>(ratingsString);
        var expectedResult = JsonConvert.DeserializeObject<int[]>(candyString).Sum();
        var result = new Solution().Candy(ratings);
        Assert.AreEqual(expectedResult, result);
    }
}
