using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(1, 1, "1")]
    [TestCase(2, 1, "12")]
    [TestCase(2, 2, "21")]
    [TestCase(3, 1, "123")]
    [TestCase(3, 2, "132")]
    [TestCase(3, 3, "213")]
    [TestCase(3, 4, "231")]
    [TestCase(3, 5, "312")]
    [TestCase(3, 6, "321")]
    public void TestMethod(int n, int k, string expectedResult)
    {
        var result = new Solution().GetPermutation(n, k);
        Assert.AreEqual(expectedResult, result);
    }
}