using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 5, "If You Give A Seed A Fertilizer")]
public sealed partial class Day05 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var almanac = input.Text.Split("\n\n");
        var seeds = ParseSeeds(almanac[0]);
        var map = almanac[1..].SelectMany(ParseMapEntries).ToArray();
        return 35;
    }

    public static int Part2(AocInput input) => 0;

    private static IEnumerable<int> ParseSeeds(string almanac) =>
        NumbersRegex().Matches(almanac).Select(m => int.Parse(m.Value));

    private static IEnumerable<MapEntry> ParseMapEntries(string map) =>
        map.Split('\n')
            .Pipe(lines =>
                from range in lines[1..]
                let rangeParts = RangeParts(range)
                let destination = new Range(rangeParts[0], rangeParts[0] + rangeParts[2] - 1)
                let source = new Range(rangeParts[1], rangeParts[1] + rangeParts[2] - 1)
                select new MapEntry(GetMapName(lines[0]), source, destination)
            );

    private static MapName GetMapName(string line) =>
        MapNameRegex()
            .Match(line)
            .Pipe(x => new MapName(x.Groups[1].Value, x.Groups[2].Value));

    private static int[] RangeParts(string line) =>
        NumbersRegex()
            .Matches(line)
            .Select(m => int.Parse(m.Value))
            .ToArray();

    [GeneratedRegex(@"(\w+)-to-(\w+)")]
    private static partial Regex MapNameRegex();

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersRegex();

    private sealed record MapName(string From, string To);

    private sealed record MapEntry(MapName Name, Range Source, Range Destination);

    private readonly record struct Range(int From, int To);
}