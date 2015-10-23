using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    [Test]
    public void TestMethod()
    {
        for (var n = 1; n < 10; ++n)
        {
            var expectedResults = SolveNQueens(n);
            var results = new Solution().SolveNQueens(n);
            Assert.AreEqual(Normalize(expectedResults), Normalize(results));
        }
    }

    private string Normalize(IList<IList<string>> results)
    {
        return JsonConvert.SerializeObject(results.OrderBy(r => JsonConvert.SerializeObject(r)));
    }

    private IList<IList<string>> SolveNQueens(int n)
    {
        var results = new List<IList<string>>();
        var state = new List<int>();
        Search(results, state, n);
        return results;
    }

    private void Search(List<IList<string>> results, List<int> state, int n)
    {
        if (state.Count == n)
        {
            var result = new List<string>();
            foreach (var s in state)
            {
                var sb = new StringBuilder();
                for (var i = 0; i < s; ++i)
                {
                    sb.Append('.');
                }
                sb.Append('Q');
                for (var i = s + 1; i < n; ++i)
                {
                    sb.Append('.');
                }
                result.Add(sb.ToString());
            }
            results.Add(result);
            return;
        }
        for (var i = 0; i < n; ++i)
        {
            var valid = true;
            for (var j = 0; j < state.Count; ++j)
            {
                if (state[j] - (state.Count - j) == i || state[j] + (state.Count - j) == i || state[j] ==i)
                {
                    valid = false;
                    break;
                }
            }
            if (valid)
            {
                state.Add(i);
                Search(results, state, n);
                state.RemoveAt(state.Count - 1);
            }
        }
    }
}