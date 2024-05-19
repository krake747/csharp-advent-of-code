using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 8, "Matchsticks")]
public sealed class Day08 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Lines
        .Select(x => (Literal: x, Memory: Regex.Unescape(x.AsSpan(1, x.Length - 2).ToString())))
        .Sum(x => x.Literal.Length - x.Memory.Length);

    public static int Part2(AocInput input) => input.Lines
        .Select(x => (Encoded: $"\"{x.Replace("\\", "\\\\").Replace("\"", "\\\"")}\"".ToString(), Original: x))
        .Sum(x => x.Encoded.Length - x.Original.Length);
}