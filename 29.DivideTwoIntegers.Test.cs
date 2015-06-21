using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(0, 1, 0)]
    [TestCase(1, 1, 1)]
    [TestCase(2, 1, 2)]
    [TestCase(3, 1, 3)]
    [TestCase(4, 1, 4)]
    [TestCase(5, 1, 5)]
    [TestCase(0, 2, 0)]
    [TestCase(1, 2, 0)]
    [TestCase(2, 2, 1)]
    [TestCase(3, 2, 1)]
    [TestCase(4, 2, 2)]
    [TestCase(5, 2, 2)]
    [TestCase(1231415, 435, 2830)]
    [TestCase(-1231415, 435, -2830)]
    [TestCase(1231415, -435, -2830)]
    [TestCase(-1231415, -435, 2830)]
    [TestCase(0, -1, 0)]
    [TestCase(0, 112321412, 0)]
    [TestCase(0, -112321412, 0)]
    [TestCase(0x7FFFFFFF, 1, 0x7FFFFFFF)]
    [TestCase(-0x7FFFFFFF, 1, -0x7FFFFFFF)]
    [TestCase(0x7FFFFFFF, -1, -0x7FFFFFFF)]
    [TestCase(-0x7FFFFFFF, -1, 0x7FFFFFFF)]
    [TestCase((int)-0x80000000, 1, (int)-0x80000000)]
    [TestCase((int)-0x80000000, -1, 0x7FFFFFFF)]
    public void TestMethod(int dividend, int divisor, int expectedResult)
    {
        Assert.AreEqual(expectedResult, new Solution().Divide(dividend, divisor));
    }
}