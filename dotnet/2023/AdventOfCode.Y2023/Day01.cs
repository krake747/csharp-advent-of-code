using System.Diagnostics;
using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2023;

[AocPuzzle(2023, 1, "Trebuchet?!")]
public sealed partial class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Lines
        .Select(x => DigitRegex().Matches(x))
        .Select(Calibration)
        .Sum(int.Parse);

    public static int Part2(AocInput input) => input.Lines
        .Select(x => x
            .Replace("one", "one1one")
            .Replace("two", "two2two")
            .Replace("three", "three3three")
            .Replace("four", "four4four")
            .Replace("five", "five5five")
            .Replace("six", "six6six")
            .Replace("seven", "seven7seven")
            .Replace("eight", "eight8eight")
            .Replace("nine", "nine9nine"))
        .Select(x => DigitRegex().Matches(x))
        .Select(Calibration)
        .Sum(int.Parse);

    public static int Part2A(AocInput input) => input.Lines
        .Select(x =>
        {
            var start = ParseWrittenDigit(LeftToRightDigitRegex().Match(x));
            var end = ParseWrittenDigit(RightToLeftDigitRegex().Match(x));
            return $"{start}{end}";
        })
        .Sum(int.Parse);

    private static string Calibration(MatchCollection m) => m switch
    {
        [var first, .., var last] => $"{first}{last}",
        [var single] => $"{single}{single}",
        _ => throw new UnreachableException()
    };

    private static string ParseWrittenDigit(Capture m) => m.Value switch
    {
        "one" => "1",
        "two" => "2",
        "three" => "3",
        "four" => "4",
        "five" => "5",
        "six" => "6",
        "seven" => "7",
        "eight" => "8",
        "nine" => "9",
        _ => m.Value
    };

    [GeneratedRegex(@"\d", RegexOptions.Compiled)]
    private static partial Regex DigitRegex();

    [GeneratedRegex(@"\d|one|two|three|four|five|six|seven|eight|nine",
        RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex LeftToRightDigitRegex();

    [GeneratedRegex(@"\d|one|two|three|four|five|six|seven|eight|nine",
        RegexOptions.Compiled | RegexOptions.RightToLeft)]
    private static partial Regex RightToLeftDigitRegex();
}