using System;
using System.Globalization;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class LRUCacheTest
{
    [TestCase(5, "g4;s3,2;s1,5;g3", "-1;2")]
    [TestCase(1, "g4;s3,2;s1,5;g3", "-1;-1")]
    [TestCase(2, "g4;s3,2;s1,5;s3,1;s2,1;g1;g3", "-1;-1;1")]
    [TestCase(0, "s3,2;g3", "-1")]
    public void Test(int capacity, string operationsString, string expectedOutputString)
    {
        var cache = new LRUCache(capacity);
        var output = new StringBuilder();
        foreach (var operationString in operationsString.Split(';'))
        {
            int key;
            int value;
            switch (operationString[0])
            {
                case 'g':
                    key = int.Parse(operationString.Substring(1));
                    if (output.Length > 0)
                    {
                        output.Append(";");
                    }
                    output.Append(cache.Get(key).ToString(CultureInfo.InvariantCulture));
                    break;
                case 's':
                    var indexOfComma = operationString.IndexOf(',');
                    key = int.Parse(operationString.Substring(1, indexOfComma - 1));
                    value = int.Parse(operationString.Substring(indexOfComma + 1));
                    cache.Set(key, value);
                    break;
                default:
                    throw new Exception(string.Format("Unkown operation: {0}", operationString));
            }
        }
        
        Assert.AreEqual(expectedOutputString, output.ToString());
    }
}
