using System.Collections.Generic;
using System.Linq;

public struct State
{
    public long InitialHP; // how much health needed at start point
    public long CurrentHP; // how much health left at this point
    public State(long initialHP, long currentHP)
    {
        InitialHP = initialHP;
        CurrentHP = currentHP;
    }
}

public class Solution {
    public int CalculateMinimumHP(int[,] dungeon) {
        var len1 = dungeon.GetLength(0);
        var len2 = dungeon.GetLength(1);
        var f = new List<State>[len1, len2]; 
        for (var i = 0; i < len1; ++i)
        {
            for (var j = 0; j < len2; ++j)
            {
                var previousStates = new List<State>();
                if (i == 0 && j == 0)
                {
                    previousStates.Add(new State(1, 1));
                }
                else
                {
                    if (i > 0)
                    {
                        previousStates.AddRange(f[i - 1, j]);
                    }
                    if (j > 0)
                    {
                        previousStates.AddRange(f[i, j - 1]);
                    }
                }
                var newStates = new List<State>();
                foreach (var prev in previousStates)
                {
                    var newState = new State(prev.InitialHP, prev.CurrentHP + dungeon[i, j]);
                    if (newState.CurrentHP < 1)
                    {
                        newState.InitialHP -= newState.CurrentHP - 1;
                        newState.CurrentHP = 1;
                    }
                    newStates.Add(newState);
                }
                
                var minCurrentHP = long.MinValue;
                var tempStates = newStates.GroupBy(s => s.InitialHP).Select(g => new State(g.Key, g.Max(s => s.CurrentHP))).OrderBy(s => s.InitialHP);
                f[i, j] = new List<State>();
                foreach (var state in tempStates)
                {
                    if (state.CurrentHP > minCurrentHP)
                    {
                        f[i, j].Add(state);
                        minCurrentHP = state.CurrentHP;
                    }
                }
            }
        }
        return (int) f[len1 - 1, len2 - 1][0].InitialHP;
    }
}