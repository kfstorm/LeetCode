using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("", 0)]
    [TestCase("0", 0)]
    [TestCase("01", 0)]
    [TestCase("90", 0)]
    [TestCase("1", 1)]
    [TestCase("2", 1)]
    [TestCase("3", 1)]
    [TestCase("4", 1)]
    [TestCase("5", 1)]
    [TestCase("6", 1)]
    [TestCase("7", 1)]
    [TestCase("8", 1)]
    [TestCase("9", 1)]
    [TestCase("10", 1)]
    [TestCase("11", 2)]
    [TestCase("12", 2)]
    [TestCase("12345", 3)]
    public void TestMethod(string s, int expectedResult)
    {
        var answer = new Solution().NumDecodings(s);
        Assert.AreEqual(expectedResult, answer);
    }
}
