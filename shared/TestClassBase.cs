using System;
using System.Collections.Generic;
using System.Diagnostics;

public abstract class TestClassBase
{
    private static readonly Random _random = new Random();

    protected static Random Random { get { return _random; } }

    protected static int[] GenerateIntegerArray(int maxLength, int maxValue)
    {
        return GenerateIntegerArray(0, maxLength, 0, maxValue);
    }

    protected static int[] GenerateIntegerArray(int minLength, int maxLength, int minValue, int maxValue)
    {
        return GenerateArray<int>(minLength, maxLength, () => Random.Next(minValue, maxValue == int.MaxValue ? int.MaxValue : maxValue + 1));
    }

    protected static string GenerateString(int maxLength)
    {
        return GenerateString(0, maxLength, 'a', 'z');
    }

    protected static string GenerateString(int minLength, int maxLength, char minValue, char maxValue)
    {
        return new string(GenerateArray<char>(minLength, maxLength, () => (char)Random.Next(minValue, maxValue)));
    }

    protected static T[] GenerateArray<T>(int minLength, int maxLength, Func<T> elementGenerator)
    {
        var length = Random.Next(minLength, maxLength + 1);
        var array = new T[length];
        for (var i = 0; i < length; ++i)
        {
            array[i] = elementGenerator();
        }
        return array;
    }

    protected static T[,] GenerateMatrix<T>(int minHeight, int maxHeight, int minWidth, int maxWidth, Func<T> elementGenerator)
    {
        var height = Random.Next(minHeight, maxHeight + 1);
        var width = Random.Next(minWidth, maxWidth + 1);
        var matrix = new T[height, width];
        for (var i = 0; i < height; ++i)
        {
            for (var j = 0; j < width; ++j)
            {
                matrix[i, j] = elementGenerator();
            }
        }
        return matrix;
    }

    protected void Repeat(int repeatTimes, Action action)
    {
        for (var i = 0; i < repeatTimes; ++i)
        {
            action();
        }
    }

    protected void Shuffle<T>(IList<T> list)
    {
        for (var i = 0; i < list.Count; ++i)
        {
            var j = Random.Next(i, list.Count);
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    protected T LogPerf<T>(Func<T> func, string name)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = func();
        stopwatch.Stop();
        Console.WriteLine("Performance of {0}: {1}ms", name, stopwatch.ElapsedMilliseconds);
        return result;
    }
}