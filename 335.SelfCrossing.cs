using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public bool IsSelfCrossing(int[] x) {
        var points = new Queue<Tuple<int, int>>();
        points.Enqueue(Tuple.Create(0, 0));
        var direction = 0;
        foreach (var len in x)
        {
            if (points.Count == 7)
            {
                points.Dequeue();
            }
            var original = points.Last();
            Tuple<int, int> current;
            switch (direction)
            {
                case 0:
                    current = Tuple.Create(original.Item1, original.Item2 + len);
                    break;
                case 1:
                    current = Tuple.Create(original.Item1 - len, original.Item2);
                    break;
                case 2:
                    current = Tuple.Create(original.Item1, original.Item2 - len);
                    break;
                default:
                    current = Tuple.Create(original.Item1 + len, original.Item2);
                    break;
            }
            direction++;
            if (direction > 3) direction = 0;
            Tuple<int, int> point1 = null;
            Tuple<int, int> point2 = null;
            var step = 0;
            foreach (var point in points)
            {
                point1 = point1 == null ? point : point2;
                point2 = point;
                if (point1 != point2)
                {
                    if (++step > points.Count - 2)
                    {
                        break;
                    }
                    if (IsCrossing(point1.Item1, point1.Item2, point2.Item1, point2.Item2, original.Item1, original.Item2, current.Item1, current.Item2))
                    {
                        return true;
                    }
                }
            }
            points.Enqueue(current);
        }
        return false;
    }

    private bool IsCrossing(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
    {
        if (x1 != x2)
        {
            int temp;
            temp = x1; x1 = y1; y1 = temp;
            temp = x2; x2 = y2; y2 = temp;
            temp = x3; x3 = y3; y3 = temp;
            temp = x4; x4 = y4; y4 = temp;
        }
        if (x3 == x4)
        {
            if (x1 != x3) return false;
            return Math.Max(Math.Min(y1, y2), Math.Min(y3, y4)) <= Math.Min(Math.Max(y1, y2), Math.Max(y3, y4));
        }
        else
        {
            if (x1 < Math.Min(x3, x4) || x1 > Math.Max(x3, x4)) return false;
            if (y3 < Math.Min(y1, y2) || y3 > Math.Max(y1, y2)) return false;
            return true;
        }
    }
}