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
        return 0;
    }
    
    public static int Part2(AocInput input) => 0;

    private static IEnumerable<int> ParseSeeds(string almanac) => 
        NumbersRegex().Matches(almanac).Select(m => int.Parse(m.Value));

    private static Map ParseMap(string map) =>
        map.Split('\n')
            .Pipe(lines =>
            {
                var name = NameRegex().Match(lines[0]);
                var from = name.Groups[1].Value;
                var to = name.Groups[2].Value;
                var destination = ParseRange(lines[1]);
                var source = ParseRange(lines[2]);
                return new Map(from, to, destination, source);
            });

    private static Range ParseRange(string line) => 
        NumbersRegex()
            .Matches(line)
            .Select(m => int.Parse(m.Value))
            .ToArray()
            .Pipe(x => new Range(x[0], x[1], x[2]));

    
    private sealed record Map(string From, string To, Range Destination, Range Source);

    private readonly record struct Range(int DestinationStart, int SourceStart, int Length);
    
    [GeneratedRegex(@"(\w+)-to-(\w+)")]
    private static partial Regex NameRegex();
    
    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersRegex();
}