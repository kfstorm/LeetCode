using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("1 + 1", 2)]
    [TestCase("1+1", 2)]
    [TestCase("1", 1)]
    [TestCase(" 2-1 + 2 ", 3)]
    [TestCase("3+2*2", 7)]
    [TestCase(" 3/2 ", 1)]
    [TestCase(" 3+5 / 2 ", 5)]
    [TestCase("123 + 456", 579)]
    public void TestMethod(string s, int expectedResult)
    {
        var result = new Solution().Calculate(s);
        Assert.AreEqual(expectedResult, result);
    }
}
