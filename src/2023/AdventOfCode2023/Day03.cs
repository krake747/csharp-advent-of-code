using System.Text.RegularExpressions;
using AdventOfCodeLib;

using Coordinates = (int Row, int Col);

namespace AdventOfCode2023;

[AocPuzzle(2023, 3, "Gear Ratios")]
public sealed partial class Day03 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var lines = input.Lines.ToArray();
        var numbers = Numbers(lines);
        var symbols = Symbols(lines);
        return numbers
            .Where(number => symbols.Any(symbol => IsEnginePart(number, symbol)))
            .Sum(number => int.Parse(number.Text));
    }

    public static int Part2(AocInput input) => 0;
    
    private static Part[] Numbers(IReadOnlyList<string> lines) =>
        Enumerable.Range(0, lines.Count)
            .SelectMany(row => NumbersRegex().Matches(lines[row]), FindPotentialEnginePart)
            .ToArray();

    private static Part[] Symbols(IReadOnlyList<string> lines) =>
        Enumerable.Range(0, lines.Count)
            .SelectMany(row => SymbolsRegex().Matches(lines[row]), FindPotentialEnginePart)
            .ToArray();

    private static Part FindPotentialEnginePart(int rowIndex, Match m) => 
        new((rowIndex, m.Index), m.Value);

    private static bool IsEnginePart(Part p1, Part p2) => 
        VerticalAdjacent(p1, p2) && HorizontalAdjacent(p1, p2) && HorizontalAdjacent(p2, p1);

    private static bool HorizontalAdjacent(Part p1, Part p2) => 
        p2.Coordinates.Col + p2.Text.Length - p1.Coordinates.Col >= 0;

    private static bool VerticalAdjacent(Part p1, Part p2) => 
        Math.Abs(p2.Coordinates.Row - p1.Coordinates.Row) <= 1;
    
    private sealed record Part(Coordinates Coordinates, string Text);
    
    
    [GeneratedRegex(@"\d+", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex NumbersRegex();
    
    [GeneratedRegex(@"[^.\d]", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex SymbolsRegex();
}