using NUnit.Framework;

[TestFixture]
public class TextClass
{
    [TestCase("ADOBECODEBANC", "ABC", "BANC")]
    [TestCase("ABC", "ABC", "ABC")]
    [TestCase("BANC", "ABC", "BANC")]
    [TestCase("ABBANC", "ABC", "BANC")]
    [TestCase("ABBANC", "A", "A")]
    [TestCase("ABBANC", "AC", "ANC")]
    [TestCase("ABBBNC", "AC", "ABBBNC")]
    [TestCase("ABBANC", "AD", "")]
    [TestCase("a", "aa", "")]
    public void TestMethod(string s, string t, string expectedResult)
    {
        var answer = new Solution().MinWindow(s, t);
        Assert.AreEqual(expectedResult, answer);
    }
}
