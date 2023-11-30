using AdventOfCodeLib;

namespace AdventOfCode2022;

public sealed class Day06 : IAocDay<int>
{
    public static int Part1(AocInput input) => SignalMarker(input.Text, 4);

    public static int Part2(AocInput input) => SignalMarker(input.Text, 14);

    private static int SignalMarker(string input, int window) =>
        Enumerable.Range(window, input.Length)
            .First(index => input.Substring(index - window, window).ToHashSet().Count == window);
}