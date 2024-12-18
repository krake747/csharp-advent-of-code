﻿namespace AdventOfCode.Lib;

public static class LinqExtensions
{
    public static T[] GetColumn<T>(this T[][] source, int columnNumber)
    {
        return Enumerable.Range(0, source.GetLength(0))
            .Select(x => source[x][columnNumber])
            .ToArray();
    }


    public static T[] GetRow<T>(this T[][] source, int rowNumber)
    {
        return Enumerable.Range(0, source.GetLength(0))
            .Select(x => source[rowNumber][x])
            .ToArray();
    }

    public static T[] GetColumn<T>(this T[,] source, int columnNumber)
    {
        return Enumerable.Range(0, source.GetLength(0))
            .Select(x => source[x, columnNumber])
            .ToArray();
    }

    public static T[] GetRow<T>(this T[,] source, int rowNumber)
    {
        return Enumerable.Range(0, source.GetLength(0))
            .Select(x => source[rowNumber, x])
            .ToArray();
    }

    public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            yield return item;
            if (predicate(item))
            {
                yield break;
            }
        }
    }
}