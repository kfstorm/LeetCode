using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("aab", "[[\"aa\",\"b\"],[\"a\",\"a\",\"b\"]]")]
    public void TestMethod(string s, string expectedResultString)
    {
        var expectedResult = JsonConvert.DeserializeObject<IList<IList<string>>>(expectedResultString);
        var result = new Solution().Partition(s);
        Assert.AreEqual(ResultToString(expectedResult), ResultToString(result));
    }
    
    private string ResultToString(IList<IList<string>> result)
    {
        return JsonConvert.SerializeObject(result.OrderBy(p => JsonConvert.SerializeObject(p)));
    }
}
