using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("0.1", "1.1", -1)]
    [TestCase("0.1", "1.2", -1)]
    [TestCase("0.1", "13.37", -1)]
    [TestCase("1.1", "1.2", -1)]
    [TestCase("1.1", "13.37", -1)]
    [TestCase("1.2", "13.37", -1)]
    [TestCase("1.1", "0.1", 1)]
    [TestCase("1.2", "0.1", 1)]
    [TestCase("13.37", "0.1", 1)]
    [TestCase("1.2", "1.1", 1)]
    [TestCase("13.37", "1.1", 1)]
    [TestCase("13.37", "1.2", 1)]
    [TestCase("0.1", "0.1", 0)]
    [TestCase("1.1", "1.1", 0)]
    [TestCase("1.2", "1.2", 0)]
    [TestCase("13.37", "13.37", 0)]
    [TestCase("13.37.0", "13.37", 0)]
    [TestCase("13.37.0.1", "13.37", 1)]
    [TestCase("13.37.0.1.0", "13.37", 1)]
    [TestCase("13.37", "13.37.0", 0)]
    [TestCase("13.37", "13.37.0.1", -1)]
    [TestCase("13.37", "13.37.0.1.0", -1)]
    public void TestMethod(string version1, string version2, int expectedResult)
    {
        var answer = new Solution().CompareVersion(version1, version2);
        Assert.AreEqual(expectedResult, answer);
    }
}
