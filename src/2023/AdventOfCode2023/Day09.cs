using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 9, "Mirage Maintenance")]
public sealed partial class Day09 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var sequences = ParseOasisReport(input.Lines);
        var differences = sequences.Select(s =>
            {
                var curr = s;
                var diffs = new List<int> { curr.Last() };
                while (curr.All(x => x is 0) is false)
                {
                    curr = curr.Zip(curr[1..], (x1, x2) => x2 - x1).ToArray();
                    diffs.Add(curr.Last());
                }

                return diffs;
            })
            .ToArray();


        return differences.SelectMany(x => x).Sum();
    }

    public static int Part2(AocInput input)
    {
        var sequences = ParseOasisReport(input.Lines);
        var differences = sequences.Select(s =>
            {
                var curr = s;
                var diffs = new List<int> { curr.First() };
                while (curr.All(x => x is 0) is false)
                {
                    curr = curr.Zip(curr[1..], (x1, x2) => x1 - x2).ToArray();
                    diffs.Add(curr.First());
                }

                return diffs;
            })
            .ToArray();


        return differences.SelectMany(x => x).Sum();
    }

    private static IEnumerable<int[]> ParseOasisReport(IEnumerable<string> lines) =>
        lines.Select(l => NumbersRegex().Matches(l).Select(m => int.Parse(m.Value)).ToArray());

    [GeneratedRegex(@"-?\d+")]
    private static partial Regex NumbersRegex();
}