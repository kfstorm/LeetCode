using System;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private static Random _random = new Random();

    [TestCase(5, 5, 1000)]
    public void TestMethod(int maxLength, int maxCharKinds, int repeatTimes)
    {
        for (var r = 0; r < repeatTimes; ++r)
        {
            var s1 = GenerateString(maxLength, maxCharKinds);
            var s2 = GenerateString(maxLength, maxCharKinds);
            var expectedResult = IsScramble(s1, s2);
            var result = new Solution().IsScramble(s1, s2);
            Assert.AreEqual(expectedResult, result, string.Format("s1: {0}. s2: {1}.", s1, s2));
        }
    }

    private string GenerateString(int maxLength, int maxCharKinds)
    {
        var length = _random.Next(maxLength + 1);
        var chars = new char[length];
        for (var i = 0; i < length; ++i)
        {
            chars[i] = (char) (_random.Next(maxCharKinds) + 'a');
        }
        return new string(chars);
    }

    private bool IsScramble(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        if (s1 == s2) return true;
        for (var i = 1; i < s1.Length; ++i)
        {
            var l1 = s1.Substring(0, i);
            var l2 = s1.Substring(i);
            var r1 = s2.Substring(0, i);
            var r2 = s2.Substring(i);
            if (IsScramble(l1, r1) && IsScramble(l2, r2)) return true;
            r1 = s2.Substring(s2.Length - i);
            r2 = s2.Substring(0, s2.Length - i);
            if (IsScramble(l1, r1) && IsScramble(l2, r2)) return true;
        }
        //System.Console.WriteLine("s1: {0}. s2: {1}", s1, s2);
        return false;
    }
}
