using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

public class Day06 : IDay<string, int>
{
    public int Part1(string input) => SignalMarker(input, 4);

    public int Part2(string input) => SignalMarker(input, 14);

    private static int SignalMarker(string input, int window)
    {
        return Enumerable.Range(window, input.Length)
            .First(index => input.Substring(index - window, window).ToHashSet().Count == window);
    }
}