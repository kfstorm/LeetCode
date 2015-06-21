using NUnit.Framework;

[TestFixture]
public class TextJustificationTest
{
    [TestCase("This is an example of text justification.", 16, "This    is    an\nexample  of text\njustification.  ")]
    [TestCase("This is an example of text", 16, "This    is    an\nexample of text ")]
    [TestCase("This is", 4, "This\nis  ")]
    [TestCase("This is", 10, "This is   ")]
    [TestCase("This", 5, "This ")]
    public void Test(string wordsString, int maxWidth, string expectedResult)
    {
        var answer = new Solution().FullJustify(wordsString.Split(' '), maxWidth);
        Assert.AreEqual(expectedResult, string.Join("\n", answer), wordsString);
    }
}
