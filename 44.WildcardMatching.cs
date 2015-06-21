using System.Linq;

public class Solution {
    public bool IsMatch(string s, string p) {
        if (p.Count(ch => ch != '*') > s.Length)
        {
            return false;
        }
        
        bool[,] f = new bool[s.Length + 1, p.Length + 1];
        for (var i = 0; i <= s.Length; ++i)
        {
            for (var j = 0; j <= p.Length; ++j)
            {
                if (j == 0)
                {
                    f[i, j] = i == 0;
                    continue;
                }
                
                if (p[j - 1] == '*')
                {
                    for (var k = 0; k <= i; ++k)
                    {
                        if (f[k, j - 1])
                        {
                            f[i, j] = true;
                            break;
                        }
                    }
                }
                else if (p[j - 1] == '?')
                {
                    f[i, j] = i > 0 && f[i - 1, j - 1];
                }
                else
                {
                    f[i, j] = i > 0 && f[i - 1, j - 1] && s[i - 1] == p[j - 1];
                }
            }
        }
        return f[s.Length, p.Length];
    }
}