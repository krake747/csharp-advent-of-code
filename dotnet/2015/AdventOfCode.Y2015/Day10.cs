using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2015;

[AocPuzzle(2015, 10, "Elves Look, Elves Say")]
public sealed partial class Day10 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var sequence = input.Text;
        for (var i = 0; i < 40; i++)
        {
            sequence = LookAndSay(sequence);
        }

        return sequence.Length;
    }

    public static int Part2(AocInput input)
    {
        var sequence = input.Text;
        for (var i = 0; i < 50; i++)
        {
            sequence = LookAndSay(sequence);
        }

        return sequence.Length;
    }

    private static string LookAndSay(string input)
    {
        return DigitMatcher().Matches(input)
            .Aggregate(new StringBuilder(), (seed, c) => seed.Append($"{c.Length}{c.Value[0]}"))
            .ToString();
    }

    [GeneratedRegex(@"(\d)\1*")]
    private static partial Regex DigitMatcher();
}