using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("1 + 1", 2)]
    [TestCase("1+1", 2)]
    [TestCase("1", 1)]
    [TestCase(" 2-1 + 2 ", 3)]
    [TestCase("1+(4+5+2)", 12)]
    [TestCase("1+(1+1)", 3)]
    [TestCase("(1+(4+5+2)-3)+(6+8)", 23)]
    [TestCase("123 + 456", 579)]
    public void TestMethod(string s, int expectedResult)
    {
        var result = new Solution().Calculate(s);
        Assert.AreEqual(expectedResult, result);
    }
}
