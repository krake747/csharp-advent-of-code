using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 1, "Historian Hysteria")]
public sealed partial class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.AllLines
        .Pipe(ParseInstructionIds)
        .Pipe(ids => ids.Select(i => i.Left).Order()
            .Zip(ids.Select(i => i.Right).Order(), (l, r) => Math.Abs(l - r))
            .Sum()
        );

    public static int Part2(AocInput input) => 0;

    private static (int Left, int Right)[] ParseInstructionIds(string[] lines) =>
    [
        ..lines
            .Select(l => NumbersRegex().Match(l))
            .Select(m => (Left: int.Parse(m.Groups[1].Value), Right: int.Parse(m.Groups[2].Value)))
    ];
    
    [GeneratedRegex(@"(\d+)\s*(\d+)", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex NumbersRegex();
}