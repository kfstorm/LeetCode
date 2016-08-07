using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass : TestClassBase
{
    [TestCase("[\"bat\", \"tab\", \"cat\"]", "[[0, 1], [1, 0]]")]
    [TestCase("[\"abcd\", \"dcba\", \"lls\", \"s\", \"sssll\"]", "[[0, 1], [1, 0], [3, 2], [2, 4]]")]
    public void TestMethod1(string wordsString, string expectedResultsString)
    {
        var words = JsonConvert.DeserializeObject<string[]>(wordsString);
        var results = new Solution().PalindromePairs(words);
        var expectedResults = JsonConvert.DeserializeObject<int[][]>(expectedResultsString);
        Assert.AreEqual(JsonConvert.SerializeObject(expectedResults.OrderBy(r => JsonConvert.SerializeObject(r))),
            JsonConvert.SerializeObject(results.OrderBy(r => JsonConvert.SerializeObject(r))), wordsString);
    }

    [TestCase(5, 10, 100)]
    [TestCase(10, 100, 100)]
    public void TestMethod2(int maxWordLength, int maxLength, int repeatCount)
    {
        Repeat(repeatCount, () =>
        {
            var words = GenerateArray(0, maxLength, () => GenerateString(1, maxWordLength, 'a', 'z')).Distinct().ToArray();
            TestMethod1(JsonConvert.SerializeObject(words), JsonConvert.SerializeObject(PalindromePairs(words)));
        });
    }

    //[TestCase(100, 1000)]
    public void TestMethodPerf(int maxWordLength, int maxLength)
    {
        var words = GenerateArray(maxLength, maxLength, () => GenerateString(maxWordLength, maxWordLength, 'a', 'z')).Distinct().ToArray();
        var expectedResult = LogPerf(() => PalindromePairs(words), "dummy algo");
        var actualResult = LogPerf(() => new Solution().PalindromePairs(words), "real algo");
    }

    private IList<IList<int>> PalindromePairs(string[] words) {
        var results =new List<IList<int>>();

        for (var i = 0; i < words.Length; ++i)
        {
            for (var j = 0; j < words.Length; ++j)
            {
                if (i != j)
                {
                    var array = new char[words[i].Length + words[j].Length];
                    for (var k = 0; k < words[i].Length; ++k)
                    {
                        array[k] = words[i][k];
                    }
                    for (var k = 0; k < words[j].Length; ++k)
                    {
                        array[words[i].Length + k] = words[j][k];
                    }
                    {
                        var match = true;
                        var k = 0;
                        var l = array.Length - 1;
                        while (k < l)
                        {
                            if (array[k] != array[l])
                            {
                                match =false;
                                break;
                            }
                            ++k;
                            --l;
                        }
                        if (match)
                        {
                            results.Add(new [] { i, j});
                        }
                    }
                }
            }
        }

        return results;
    }
}