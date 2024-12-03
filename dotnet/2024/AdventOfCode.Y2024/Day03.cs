using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 3, "Mull It Over", "C#")]
public sealed class Day03 : IAocDay<long>
{
    public static long Part1(AocInput input) => input.Text.Pipe(text => 
        Regex.Matches(text, @"mul\((\d+),(\d+)\)")
        .Sum(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)));

    public static long Part2(AocInput input) => 0;
}