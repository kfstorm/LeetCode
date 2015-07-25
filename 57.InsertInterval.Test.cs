using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

public class Interval {
    public int start;
    public int end;
    public Interval() { start = 0; end = 0; }
    public Interval(int s, int e) { start = s; end = e; }
}

[TestFixture]
public class TestClass
{
    [TestCase("[[1,3],[6,9]]", "[2,5]", "[[1,5],[6,9]]")]
    [TestCase("[[1,3],[6,9]]", "[0,0]", "[[0,0],[1,3],[6,9]]")]
    [TestCase("[[1,3],[6,9]]", "[0,1]", "[[0,3],[6,9]]")]
    [TestCase("[[1,3],[6,9]]", "[1,1]", "[[1,3],[6,9]]")]
    [TestCase("[[1,3],[6,9]]", "[6,10]", "[[1,3],[6,10]]")]
    [TestCase("[[1,3],[6,9]]", "[7,10]", "[[1,3],[6,10]]")]
    [TestCase("[[1,3],[6,9]]", "[9,10]", "[[1,3],[6,10]]")]
    [TestCase("[[1,3],[6,9]]", "[10,10]", "[[1,3],[6,9],[10,10]]")]
    [TestCase("[[1,3],[6,9]]", "[10,11]", "[[1,3],[6,9],[10,11]]")]
    [TestCase("[[1,2],[3,5],[6,7],[8,10],[12,16]]", "[4,9]", "[[1,2],[3,10],[12,16]]")]
    public void TestMethod(string intervalsString, string newIntervalString, string expectedResultString)
    {
        var intervals = Array.ConvertAll(JsonConvert.DeserializeObject<int[][]>(intervalsString), pair => new Interval(pair[0], pair[1]));
        var newIntervalIntegers = JsonConvert.DeserializeObject<int[]>(newIntervalString);
        var newInterval = new Interval(newIntervalIntegers[0], newIntervalIntegers[1]);
        var result = new Solution().Insert(intervals, newInterval);
        Assert.AreEqual(expectedResultString, JsonConvert.SerializeObject(result.Select(i => new [] { i.start, i.end })));
    }
}