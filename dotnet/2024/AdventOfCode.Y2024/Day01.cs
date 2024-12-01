using System.Text.RegularExpressions;
using AdventOfCode.Lib;
using Instructions = ( 
    System.Collections.Generic.IEnumerable<int> Left, 
    System.Collections.Generic.IEnumerable<int> Right
);

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 1, "Historian Hysteria")]
public sealed partial class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.AllLines
        .Pipe(ParseInstructions)
        .Pipe(instructions =>
            instructions.Left.Order().Zip(instructions.Right.Order(), (l, r) => Math.Abs(l - r)).Sum());

    public static int Part2(AocInput input) => input.AllLines
        .Pipe(ParseInstructions)
        .Pipe(SimilarityScore);

    private static int SimilarityScore(Instructions instructions)
    {
        var counts = instructions.Right.CountBy(i => i).ToDictionary();
        return instructions.Left.Sum(id => counts.GetValueOrDefault(id) * id);
    }

    private static Instructions ParseInstructions(string[] lines)
    {
        (int Left, int Right)[] matches =
        [
            ..lines
                .Select(l => NumbersRegex().Match(l))
                .Select(m => (Left: int.Parse(m.Groups[1].Value), Right: int.Parse(m.Groups[2].Value)))
        ];

        return (
            Left: matches.Select(m => m.Left),
            Right: matches.Select(m => m.Right)
        );
    }

    [GeneratedRegex(@"(\d+)\s*(\d+)", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex NumbersRegex();
}