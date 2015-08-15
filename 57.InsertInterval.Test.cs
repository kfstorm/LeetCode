using NUnit.Framework;

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
        var intervals = Interval.DeserializeArray(intervalsString);
        var newInterval = Interval.Deserialize(newIntervalString);
        var result = new Solution().Insert(intervals, newInterval);
        Assert.AreEqual(expectedResultString, Interval.SerializeArray(result));
    }
}