using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(1, "1")]
    [TestCase(2, "11")]
    [TestCase(3, "21")]
    [TestCase(4, "1211")]
    [TestCase(5, "111221")]
    [TestCase(6, "312211")]
    [TestCase(7, "13112221")]
    [TestCase(8, "1113213211")]
    [TestCase(9, "31131211131221")]
    [TestCase(10, "13211311123113112211")]
    [TestCase(11, "11131221133112132113212221")]
    public void TestMethod(int n, string expectedResult)
    {
        Assert.AreEqual(expectedResult, new Solution().CountAndSay(n));
    }
}