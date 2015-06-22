using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("the sky is blue", "blue is sky the")]
    [TestCase("", "")]
    [TestCase(" ", "")]
    [TestCase("   the sky is blue", "blue is sky the")]
    [TestCase("the sky is blue   ", "blue is sky the")]
    [TestCase("the    sky is blue   ", "blue is sky the")]
    [TestCase("the", "the")]
    [TestCase("the. sky+ i!s blue", "blue i!s sky+ the.")]
    public void TestMethod(string s, string expectedResult)
    {
        var answer = new Solution().ReverseWords(s);
        Assert.AreEqual(expectedResult, answer);
    }
}
