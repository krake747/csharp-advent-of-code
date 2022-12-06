using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day06 : IDay<string, int>
{
    public int Part1(string input)
    {
        const int signalWindow = 4;
        return Enumerable.Range(0, input.Length - signalWindow + 1)
            .First(index => input.IsStartOfSignalMarker(index, signalWindow)) + signalWindow;
    }

    public int Part2(string input)
    {
        const int signalWindow = 14;
        return Enumerable.Range(0, input.Length - signalWindow + 1)
            .First(index => input.IsStartOfSignalMarker(index, signalWindow)) + signalWindow;
    }
}

internal static class Day06Extensions
{
    internal static bool IsStartOfSignalMarker(this string source, int index, int signalWindow)
    {
        return source.Skip(index).Take(signalWindow).Distinct().ToArray().Length == signalWindow;
    }
}