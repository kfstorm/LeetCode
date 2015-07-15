using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(1000)]
    public void TestMethod(int maxN)
    {
        for (var n = -100; n <= maxN; ++n)
        {
            var result = new Solution().CountDigitOne(n);
            var expectedResult = CountDigitOne(n);
            Assert.AreEqual(expectedResult, result, "n = " + n);
        }
    }
    
    private int CountDigitOne(int n)
    {
        var count = 0;
        for (var i = 0; i <= n; ++i)
        {
            var x = i;
            while (x > 0)
            {
                if (x % 10 == 1)
                {
                    ++count;
                }
                x /= 10;
            }
        }
        return count;
    }
}
