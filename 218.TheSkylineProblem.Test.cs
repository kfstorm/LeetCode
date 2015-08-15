using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TheSkylineProblemTest
{
    [TestCase("[[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]","[[2,10],[3,15],[7,12],[12,0],[15,10],[20,8],[24,0]]")]
    [TestCase("[[2,9,10],[3,7,15],[5,15,12],[15,20,10],[19,24,8]]","[[2,10],[3,15],[7,12],[15,10],[20,8],[24,0]]")]
    [TestCase("[[2,9,10],[3,7,15],[5,15,12],[15,20,10],[15,20,12],[19,24,8]]","[[2,10],[3,15],[7,12],[20,8],[24,0]]")]
    [TestCase("[[2,9,10],[3,7,15],[5,15,12],[15,20,10],[15,20,8],[19,24,8]]","[[2,10],[3,15],[7,12],[15,10],[20,8],[24,0]]")]
    [TestCase("[[2,9,10],[3,7,15],[5,15,12],[15,20,10],[15,20,12],[15,20,8],[19,24,8]]","[[2,10],[3,15],[7,12],[20,8],[24,0]]")]
    [TestCase("[[2,9,10],[3,7,15],[5,15,12],[15,20,20],[19,24,8]]","[[2,10],[3,15],[7,12],[15,20],[20,8],[24,0]]")]
    [TestCase("[]","[]")]
    [TestCase("[[2,9,10]]","[[2,10],[9,0]]")]
    [TestCase("[[2,9,10],[2,9,10]]","[[2,10],[9,0]]")]
    [TestCase("[[2,9,10],[2,9,10],[2,9,10]]","[[2,10],[9,0]]")]
    [TestCase("[[2,9,10],[3,9,10]]","[[2,10],[9,0]]")]
    [TestCase("[[2,9,10],[3,9,10],[4,9,10]]","[[2,10],[9,0]]")]
    [TestCase("[[2,9,10],[9,18,10]]","[[2,10],[18,0]]")]
    [TestCase("[[2,9,10],[3,8,10]]","[[2,10],[9,0]]")]
    [TestCase("[[2,9,10],[3,9,10]]","[[2,10],[9,0]]")]
    [TestCase("[[2,9,10],[3,10,10]]","[[2,10],[10,0]]")]
    [TestCase("[[2,9,10],[3,8,9]]","[[2,10],[9,0]]")]
    [TestCase("[[2,9,10],[3,8,11]]","[[2,10],[3,11],[8,10],[9,0]]")]
    [TestCase("[[2,9,10],[3,9,11]]","[[2,10],[3,11],[9,0]]")]
    public void Test(string buildingsString, string expectedOutputString)
    {
        var array = JsonConvert.DeserializeObject<int[][]>(buildingsString);
        var buildings = new int[array.Length, 3];
        for (var i = 0; i < array.Length; ++i)
        {
            buildings[i, 0] = array[i][0];
            buildings[i, 1] = array[i][1];
            buildings[i, 2] = array[i][2];
        }
        var answer = new Solution().GetSkyline(buildings);
        Assert.AreEqual(expectedOutputString, JsonConvert.SerializeObject(answer));
    }

    [TestCase(1)]
    [TestCase(10)]
    [TestCase(100)]
    [TestCase(1000)]
    [TestCase(10000)]
    public void TestOneLargeBuilding(int count)
    {
        var buildings = new int[count, 3];
        for (var i = 0; i < count; ++i)
        {
            buildings[i, 0] = i + 1;
            buildings[i, 1] = count + 1;
            buildings[i, 2] = count - i;
        }
        var expectedOutput = new[] { new[] { 1, count }, new[] { count + 1, 0 } };
        var answer = new Solution().GetSkyline(buildings);
        Assert.AreEqual(JsonConvert.SerializeObject(expectedOutput), JsonConvert.SerializeObject(answer));
    }
}
