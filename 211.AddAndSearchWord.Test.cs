using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase(100, 10)]
    [TestCase(1000, 100)]
    public void TestMethod(int opCount, int maxWordLength)
    {
        var random = new Random();
        var dict = new WordDictionary();
        var list = new List<string>();
        while (opCount-- > 0)
        {
            var word = GenerateWord(random, maxWordLength);
            switch (random.Next(2))
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
    
    private string GenerateWord(Random random, int maxLength)
    {
        var length = random.Next(1, maxLength + 1);
        var sb = new StringBuilder();
        for (var i = 0; i < length; ++i)
        {
            sb.Append((char)(random.Next(26) + 'a'));
        }
        return sb.ToString();
    }
}
