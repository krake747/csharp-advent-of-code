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
        var symbols = Symbols(lines);
        return Numbers(lines)
            .Where(number => symbols.Any(symbol => Adjacent(number, symbol)))
            .Sum(number => int.Parse(number.Text));
    }

    public static int Part2(AocInput input)
    {
        var lines = input.Lines.ToArray();
        var numbers = Numbers(lines);
        return Gears(lines)
            .Select(gear => numbers.Where(number => Adjacent(number, gear)).ToList())
            .Where(neighbors => neighbors.Count is 2)
            .Sum(gears => int.Parse(gears[0].Text) * int.Parse(gears[^1].Text));
    }

    private static Part[] Numbers(IReadOnlyList<string> lines) =>
        Enumerable.Range(0, lines.Count)
            .SelectMany(row => NumbersRegex().Matches(lines[row]), FindPotentialEnginePart)
            .ToArray();

    private static Part[] Symbols(IReadOnlyList<string> lines) =>
        Enumerable.Range(0, lines.Count)
            .SelectMany(row => SymbolsRegex().Matches(lines[row]), FindPotentialEnginePart)
            .ToArray();
    
    private static Part[] Gears(IReadOnlyList<string> lines) =>
        Enumerable.Range(0, lines.Count)
            .SelectMany(row => GearsRegex().Matches(lines[row]), FindPotentialEnginePart)
            .ToArray();

    private static Part FindPotentialEnginePart(int rowIndex, Match m) => 
        new((rowIndex, m.Index), m.Value, m.Value.Length);

    private static bool Adjacent(Part p1, Part p2) => 
        VerticalAdjacent(p1, p2) && HorizontalAdjacent(p1, p2) && HorizontalAdjacent(p2, p1);

    private static bool HorizontalAdjacent(Part p1, Part p2) => 
        p2.Coordinates.Col + p2.Offset >= p1.Coordinates.Col;

    private static bool VerticalAdjacent(Part p1, Part p2) => 
        Math.Abs(p2.Coordinates.Row - p1.Coordinates.Row) <= 1;
    
    // Row / Col Numbers or Gear (Offset is characters length -> string length for numbers else 1 for symbols)
    // (0, 0) 4 | (0, 1) 6 | (0, 2) 7 | (0, 3) . | (0, 4) . | (0, 5) 1 | (0, 6) 2 | (0, 7) 1 | (0, 8) 4 | (0, 9) . |
    // (1, 0) . | (1, 1) . | (1, 2) . | (1, 3) * | (0, 4) . | (0, 5) . | (0, 6) . | (0, 7) . | (0, 8) . | (0, 9) . |
    // (2, 0) . | (2, 1) . | (2, 2) 3 | (2, 3) 5 | (0, 4) . | (0, 5) . | (0, 6) 6 | (0, 7) 3 | (0, 8) 3 | (0, 9) . |
    // Picture every Number has a box around itself and needs to touch a symbol within a range of 1
    // Vertical Adjacent   -> Number cannot be more than 1 row apart from a symbol
    // Horizontal Adjacent -> Number cannot be more than 1 col apart from a symbol
    // The offset gives us the length of a symbol or numbers.
    // E.g. 467 length is 3 which is same column as the * which inside the box around a number
    
    private sealed record Part(Coordinates Coordinates, string Text, int Offset);
    
    [GeneratedRegex(@"\d+", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex NumbersRegex();
    
    [GeneratedRegex(@"[^.\d]", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex SymbolsRegex();

    [GeneratedRegex(@"\*", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex GearsRegex();
}