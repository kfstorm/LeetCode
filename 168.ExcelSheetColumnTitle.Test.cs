using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(1, "A")]
    [TestCase(2, "B")]
    [TestCase(25, "Y")]
    [TestCase(26, "Z")]
    [TestCase(27, "AA")]
    [TestCase(28, "AB")]
    [TestCase(51, "AY")]
    [TestCase(52, "AZ")]
    [TestCase(53, "BA")]
    [TestCase(54, "BB")]
    [TestCase(701, "ZY")]
    [TestCase(702, "ZZ")]
    [TestCase(703, "AAA")]
    [TestCase(704, "AAB")]
    [TestCase(727, "AAY")]
    [TestCase(728, "AAZ")]
    [TestCase(729, "ABA")]
    [TestCase(730, "ABB")]
    public void TestMethod(int n, string expectedresult)
    {
        var result = new Solution().ConvertToTitle(n);
        Assert.AreEqual(expectedresult, result);
    }
}
