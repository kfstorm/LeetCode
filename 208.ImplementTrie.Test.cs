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
        var trie = new Trie();
        var list = new List<string>();
        while (opCount-- > 0)
        {
            var word = GenerateString(1, maxWordLength, 'a', 'z');
            switch (Random.Next(3))
            {
                case 0:
                    trie.Insert(word);
                    list.Add(word);
                    break;
                case 1:
                    Assert.AreEqual(list.Contains(word), trie.Search(word));
                    break;
                case 2:
                    Assert.AreEqual(list.Any(w => w.StartsWith(word)), trie.StartsWith(word));
                    break;
            }
        }
    }
}
