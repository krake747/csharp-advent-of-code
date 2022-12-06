using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day06 : IDay<string, int>
{
    public int Part1(string input)
    {
        const int window = 4;
        return Enumerable.Range(0, input.Length - window + 1)
            .First(n => input.IsStartOfMarker(n, window)) + window;
    }

    public int Part2(string input)
    {
        return 1;
    }
}

internal static class Day06Extensions
{
    internal static bool IsStartOfMarker(this string source, int index ,int window)
    {
        return source.Skip(index).Take(window).Distinct().ToArray().Length == window;
    }
}