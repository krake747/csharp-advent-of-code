using AdventOfCode.Lib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 12, "Hot Springs")]
public sealed class Day12 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var hotSprings = ParseHotSprings(input.Lines).ToArray();
        var ctn = PossibleArrangements(hotSprings[0]);
        return 0;
    }

    private static int PossibleArrangements(Spring spring)
    {
        var valid = new Dictionary<string, int>();
        return valid.Count;
    }

    private static IEnumerable<Spring> ParseHotSprings(IEnumerable<string> input) =>
        input.Select(line =>
        {
            var data = line.Split(' ');
            var row = data[0];
            var brokenSprings = data[^1].Split(',').Select(int.Parse).ToArray();
            return new Spring(row, brokenSprings);
        });

    public static int Part2(AocInput input) => 0;

    private sealed record Spring(string Row, int[] BrokenSprings);
}