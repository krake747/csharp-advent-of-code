using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 11, "Cosmic Expansion")]
public sealed class Day11 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var galaxies = ParseGalaxies(input.AllLines).ToArray();
        var emptyRows = EmptySpaceRows(input.AllLines).ToArray();
        var emptyCols = EmptySpaceCols(input.AllLines).ToArray();
        var galaxyParis = galaxies.SelectMany(_ => galaxies, (g1, g2) => (g1, g2));

        var sum = galaxyParis.Sum(p =>
        {
            var distRow = Distance(p.g1.Row, p.g2.Row) + ExpansionRow(p.g1, p.g2, emptyRows);
            var distCol = Distance(p.g1.Col, p.g2.Col) + ExpansionCol(p.g1, p.g2, emptyCols);
            return distRow + distCol;
        }) / 2; // take half from cartesian input
        
        return sum;
    }

    private static int Distance(int p1, int p2) => Math.Abs(p1 - p2);
    
    private static int ExpansionRow(Galaxy g1, Galaxy g2, IEnumerable<int> emptySpaces)
    {
        var ((r1, _), (r2, _)) = (g1, g2);
        var start = Math.Min(r1, r2);
        var dist = Distance(r1, r2);
        return 1 * Enumerable.Range(start, dist).Count(x => emptySpaces.Contains(x));
    }
    
    private static int ExpansionCol(Galaxy g1, Galaxy g2, IEnumerable<int> emptySpaces)
    {
        var ((_, c1), (_, c2)) = (g1, g2);
        var start = Math.Min(c1, c2);
        var dist = Distance(c1, c2);
        return 1 * Enumerable.Range(start, dist).Count(x => emptySpaces.Contains(x));
    }
    
    public static int Part2(AocInput input) => 0;
    
    private static IEnumerable<Galaxy> ParseGalaxies(string[] universe)
    {
        var rows = universe.Length;
        var cols = universe[0].Length;
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (universe[row][col] is '#')
                {
                    yield return new Galaxy(row, col);
                }
            }
        }
    }
    
    private static IEnumerable<int> EmptySpaceRows(string[] universe) =>
        Enumerable.Range(0, universe.Length)
            .Where(row => universe[row].All(x => x is '.'))
            .Select(row => row);

    private static IEnumerable<int> EmptySpaceCols(string[] universe) =>
        Enumerable.Range(0, universe[0].Length)
            .Where(col => universe.All(x => x[col] is '.'))
            .Select(col => col);
    private readonly record struct Galaxy(int Row, int Col);
}