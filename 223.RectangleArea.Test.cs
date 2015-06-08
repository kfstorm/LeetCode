using NUnit.Framework;

[TestFixture]
public class RectangleAreaTest
{
    [TestCase(-3, 0, 3, 4, 0, -1, 9, 2, 45)]
    public void Test(int a, int b, int c, int d, int e, int f, int g, int h, int expectedArea)
    {
        var result = new Solution().ComputeArea(a, b, c, d, e, f, g, h);
        Assert.AreEqual(expectedArea, result);
    }
}
