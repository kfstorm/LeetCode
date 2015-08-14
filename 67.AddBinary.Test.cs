using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("11", "1", "100")]
    public void TestMethod(string a, string b, string expectedResult)
    {
        var result = new Solution().AddBinary(a, b);
        Assert.AreEqual(expectedResult, result);
    }
}
