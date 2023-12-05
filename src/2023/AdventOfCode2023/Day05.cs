using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 5, "If You Give A Seed A Fertilizer")]
public sealed partial class Day05 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var almanac = input.Text.Split("\n\n");
        var seeds = ParseSeeds(almanac[0]);
        var maps = almanac[1..].Select(ParseMap);
        return 35;
    }
    
    public static int Part2(AocInput input) => 0;

    private static IEnumerable<int> ParseSeeds(string almanac) => 
        NumbersRegex().Matches(almanac).Select(m => int.Parse(m.Value));

    private static Map ParseMap(string map) =>
        map.Split('\n')
            .Pipe(lines =>
            {
                var name = MapNameRegex().Match(lines[0]).Pipe(x => new MapName(x.Groups[1].Value, x.Groups[2].Value));
                var destination = RangeParts(lines[1]).Pipe(x => new Range(x[0], x[0] + x[2] - 1));
                var source = RangeParts(lines[2]).Pipe(x => new Range(x[1], x[1] + x[2] - 1));
                return new Map(name, source, destination);
            });

    private static int[] RangeParts(string line) => 
        NumbersRegex()
            .Matches(line)
            .Select(m => int.Parse(m.Value))
            .ToArray();

    private sealed record MapName(string From, string To);
    
    private sealed record Map(MapName Name, Range Source, Range Destination);
    
    private readonly record struct Range(int From, int To);
    
    [GeneratedRegex(@"(\w+)-to-(\w+)")]
    private static partial Regex MapNameRegex();
    
    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersRegex();
}