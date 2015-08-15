using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase(100, 10)]
    [TestCase(1000, 100)]
    public void TestMethod(int opCount, int maxWordLength)
    {
        var dict = new WordDictionary();
        var list = new List<string>();
        while (opCount-- > 0)
        {
            var word = GenerateString(1, maxWordLength, 'a', 'z');
            switch (Random.Next(2))
            {
                case 0:
                    dict.AddWord(word);
                    list.Add(word);
                    break;
                case 1:
                    Assert.AreEqual(list.Contains(word), dict.Search(word));
                    break;
            }
        }
    }
}
