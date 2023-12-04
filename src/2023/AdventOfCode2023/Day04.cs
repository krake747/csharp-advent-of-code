using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 4, "Scratchcards")]
public sealed partial class Day04 : IAocDay<int>
{
    private static readonly char[] Separators = [':', '|'];
    public static int Part1(AocInput input) =>
        input.Lines
            .Select(line => line.Split(Separators)[1..]
                .Select(x => DigitRegex().Matches(x).Select(mc => int.Parse(mc.Value)))
                .ToArray())
            .Select(pile => pile[0].Intersect(pile[^1]).Count())
            .Sum(n => (int)Math.Pow(2, n - 1));

    public static int Part2(AocInput input) => 0;
    
    [GeneratedRegex(@"\d+")]
    private static partial Regex DigitRegex();
}