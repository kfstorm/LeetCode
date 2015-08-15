using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public class Interval
{
    public int start;
    public int end;
    public Interval() { start = 0; end = 0; }
    public Interval(int s, int e) { start = s; end = e; }

    public static string Serialize(Interval interval)
    {
        return JsonConvert.SerializeObject(interval == null ? null : new [] { interval.start, interval.end });
    }

    public static Interval Deserialize(string intervalString)
    {
        var array = JsonConvert.DeserializeObject<int[]>(intervalString);
        if (array == null) return null;
        if (array.Length != 2) throw new FormatException(intervalString);
        return new Interval(array[0], array[1]);
    }

    public static string SerializeArray(IEnumerable<Interval> intervals)
    {
        return JsonConvert.SerializeObject(intervals.Select(i => new [] { i.start, i.end }));
    }

    public static Interval[] DeserializeArray(string intervalsString)
    {
        return Array.ConvertAll(JsonConvert.DeserializeObject<int[][]>(intervalsString), pair => new Interval(pair[0], pair[1]));
    }

    public static IList<Interval> Merge(IList<Interval> intervals)
    {
        var result = new HashSet<Interval>();
        foreach (var interval in intervals)
        {
            var temp = interval;
            while (true)
            {
                var found = result.FirstOrDefault(i => i.start <= temp.end && i.end >= temp.start);
                if (found == null)
                {
                    break;
                }
                result.Remove(found);
                temp = new Interval(Math.Min(found.start, temp.start), Math.Max(found.end, temp.end));
            }
            result.Add(temp);
        }
        return result.ToList();
    }
}