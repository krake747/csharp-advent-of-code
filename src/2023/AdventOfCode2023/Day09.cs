using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 9, "Mirage Maintenance")]
public sealed partial class Day09 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        ParseOasisReport(input.Lines)
            .Select(s => Extrapolate(Forward, s, ^1))
            .SelectMany(x => x)
            .Sum();

    public static int Part2(AocInput input) =>
        ParseOasisReport(input.Lines)
            .Select(s => Extrapolate(Backward, s, 0))
            .SelectMany(x => x)
            .Sum();

    private static List<int> Extrapolate(Func<int, int, int> func, int[] sequence, Index i)
    {
        var curr = sequence;
        List<int> diffs = [curr[i]];
        while (curr.All(x => x is 0) is false)
        {
            curr = curr.Zip(curr[1..], func).ToArray();
            diffs.Add(curr[i]);
        }

        return diffs;
    }

    private static IEnumerable<int[]> ParseOasisReport(IEnumerable<string> lines) =>
        lines.Select(l => NumbersRegex().Matches(l).Select(m => int.Parse(m.Value)).ToArray());

    private static int Forward(int x1, int x2) => x2 - x1;

    private static int Backward(int x1, int x2) => x1 - x2;

    [GeneratedRegex(@"-?\d+")]
    private static partial Regex NumbersRegex();
}