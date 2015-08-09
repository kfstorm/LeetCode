using System;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(2147395599)]
    public void TestMethod1(int x)
    {
        var expectedResult = (int)Math.Sqrt(x);
        var result = new Solution().MySqrt(x);
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase(100000)]
    public void TestMethod2(int maxX)
    {
        for (var x = 0; x <= maxX; ++x)
        {
            TestMethod1(x);
        }
    }
}
