using AdventOfCode.Lib;

namespace AdventOfCode.Y2023;

[AocPuzzle(2023, 11, "Cosmic Expansion")]
public sealed class Day11 : IAocDay<long>
{
    public static long Part1(AocInput input)
    {
        var galaxies = ParseGalaxies(input.AllLines).ToArray();
        var emptyRows = EmptySpaceRows(input.AllLines);
        var emptyCols = EmptySpaceCols(input.AllLines);
        return galaxies
            .SelectMany(_ => galaxies, (g1, g2) => (G1: g1, G2: g2))
            .Sum(galaxyPair =>
            {
                var ((row1, col1), (row2, col2)) = galaxyPair;
                var distRow = SpaceDistance(emptyRows, 1, row1, row2);
                var distCol = SpaceDistance(emptyCols, 1, col1, col2);
                return distRow + distCol;
            })
            .Pipe(sum => sum / 2L);
    }

    public static long Part2(AocInput input)
    {
        var galaxies = ParseGalaxies(input.AllLines).ToArray();
        var emptyRows = EmptySpaceRows(input.AllLines);
        var emptyCols = EmptySpaceCols(input.AllLines);
        return galaxies
            .SelectMany(_ => galaxies, (g1, g2) => (G1: g1, G2: g2))
            .Sum(galaxyPair =>
            {
                var ((row1, col1), (row2, col2)) = galaxyPair;
                var distRow = SpaceDistance(emptyRows, 999999, row1, row2);
                var distCol = SpaceDistance(emptyCols, 999999, col1, col2);
                return distRow + distCol;
            })
            .Pipe(sum => sum / 2L);
    }
    
    private static long SpaceDistance(IEnumerable<int> emptySpaces, int expansion, int p1, int p2)
    {
        var start = Math.Min(p1, p2);
        var distance = Math.Abs(p1 - p2);
        var expanded = expansion * Enumerable.Range(start, distance).Count(emptySpaces.Contains);
        return distance + expanded;
    }

    private static IEnumerable<Galaxy> ParseGalaxies(IReadOnlyList<string> universe)
    {
        var rows = universe.Count;
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
    
    private static int[] EmptySpaceRows(IReadOnlyList<string> universe) =>
        Enumerable.Range(0, universe.Count)
            .Where(row => universe[row].All(x => x is '.'))
            .Select(row => row)
            .ToArray();

    private static int[] EmptySpaceCols(IReadOnlyList<string> universe) =>
        Enumerable.Range(0, universe[0].Length)
            .Where(col => universe.All(x => x[col] is '.'))
            .Select(col => col)
            .ToArray();

    private readonly record struct Galaxy(int Row, int Col);
}