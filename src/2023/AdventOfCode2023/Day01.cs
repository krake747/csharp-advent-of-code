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

    public static int Part2(AocInput input) => 0;
}