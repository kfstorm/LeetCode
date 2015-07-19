using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [TestCase("/home/", "/home")]
    [TestCase("/home/.", "/home")]
    [TestCase("/home/./", "/home")]
    [TestCase("/a/./b/../../c/", "/c")]
    [TestCase("/a/./b/../c/", "/a/c")]
    [TestCase("/a//b/../c/", "/a/c")]
    [TestCase("/../a/b/", "/a/b")]
    public void TestMethod(string path, string expectedResult)
    {
        var answer = new Solution().SimplifyPath(path);
        Assert.AreEqual(expectedResult, answer);
    }
}
