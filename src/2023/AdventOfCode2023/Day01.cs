using System.Diagnostics;
using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 1, "Trebuchet?!")]
public sealed class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Lines
        .Select(x => Regex.Matches(x, @"\d"))
        .Select(m => m switch
        {
            [var first, .., var last] => $"{first}{last}",
            [var single] => $"{single}{single}",
            _ => throw new UnreachableException()
        })
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
        .Select(x => Regex.Matches(x, @"\d"))
        .Select(m => m switch
        {
            [var first, .., var last] => $"{first.Value}{last.Value}",
            [var single] => $"{single.Value}{single.Value}",
            _ => throw new UnreachableException()
        })
        .Sum(int.Parse);
}