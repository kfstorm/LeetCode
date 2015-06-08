using NUnit.Framework;

[TestFixture]
public class FractionToRecurringDecimalTest
{
    [TestCase(1, 2, "0.5")]
    [TestCase(2, 1, "2")]
    [TestCase(0, 1, "0")]
    [TestCase(2, 3, "0.(6)")]
    [TestCase(1, 3, "0.(3)")]
    [TestCase(15, 7, "2.(142857)")]
    [TestCase(-1, 2, "-0.5")]
    [TestCase(-2, 1, "-2")]
    [TestCase(0, 1, "0")]
    [TestCase(0, -1, "0")]
    [TestCase(-2, 3, "-0.(6)")]
    [TestCase(1, -3, "-0.(3)")]
    [TestCase(15, -7, "-2.(142857)")]
    [TestCase(-15, -7, "2.(142857)")]
    [TestCase(8865, 1865, "4.(753351206434316353887399463806970509383378016085790884718498659517426273458445040214477211796246648793565683646112600536193029490616621983914209115281501340482573726541554959785522788203)")]
    [TestCase(-2147483648, -1, "2147483648")]
    public void Test(int numerator, int denominator, string expectedResult)
    {
        var answer = new Solution().FractionToDecimal(numerator, denominator);
        Assert.AreEqual(expectedResult, answer);
    }
}
