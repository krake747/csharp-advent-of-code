using AdventOfCode2021.Shared;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode2021;

public static class Day5
{

    public static int Part1(IEnumerable<string> input)
    {
        var lines = ParseLines(input);
        var count = CountOverlappingHydrothermalVents(lines, diagonals: false);

        return count;
    }

    /// <summary>
    /// Consider all of the lines. At how many points do at least two lines overlap?
    /// </summary>
    public static int Part2(IEnumerable<string> input)
    {
        var lines = ParseLines(input);
        var count = CountOverlappingHydrothermalVents(lines, diagonals: true);

        return count;
    }

    /// <summary>
    /// Alternative: Consider only horizontal and vertical lines. At how many points do at least two lines overlap? (with grid)
    /// </summary>
    public static int Part1a(IEnumerable<string> input)
    {
        var lines = ParseLines(input);
        var grid = CreateHydrothermalVents(lines, diagonals: false);
        var count = CountOverlappingVents(grid);

        return count;
    }

    /// <summary>
    /// Alternative: Consider all of the lines. At how many points do at least two lines overlap? (with grid)
    /// </summary>
    public static int Part2a(IEnumerable<string> input)
    {
        var lines = ParseLines(input);
        var grid = CreateHydrothermalVents(lines, diagonals: true);
        var count = CountOverlappingVents(grid);

        return count;
    }

    private static IEnumerable<Line> ParseLines(IEnumerable<string> input)
    {
        return input.Select(r => Regex.Matches(r, @"(\d+)"))
            .Select(v => new Line()
            {
                X1 = int.Parse(v[0].Value),
                Y1 = int.Parse(v[1].Value),
                X2 = int.Parse(v[2].Value),
                Y2 = int.Parse(v[3].Value)
            });
    }

    private static int CountOverlappingHydrothermalVents(IEnumerable<Line> lines, int minOverlap = 1, bool diagonals = false)
    {
        var vents = new List<List<Coordinate>>();
        foreach (var line in lines.ToList())
        {
            // Place Vertical vents
            var coords = new List<Coordinate>();
            if (line.X1 == line.X2)
            {
                coords = EnumerableRange.Integer(line.Y1, line.Y2, 1)
                    .Select(i => new Coordinate(line.X1, i))
                    .ToList();
            }

            // Place Horizontal vents
            if (line.Y1 == line.Y2)
            {
                coords = EnumerableRange.Integer(line.X1, line.X2, 1)
                    .Select(i => new Coordinate(i, line.Y1))
                    .ToList();
            }

            // Place Diagonal vents
            if ((line.X2 - line.X1 == line.Y2 - line.Y1) && diagonals)
            {
                coords = EnumerableRange.Integer(line.X1, line.X2, 1)
                    .Zip(EnumerableRange.Integer(line.Y1, line.Y2, 1))
                    .Select(i => new Coordinate(i.First, i.Second))
                    .ToList();
            }

            // Place Antidiagonal vents
            if ((line.X2 - line.X1 == line.Y1 - line.Y2) && diagonals)
            {
                coords = EnumerableRange.Integer(line.X1, line.X2, 1)
                    .Zip(EnumerableRange.Integer(line.Y1, line.Y2, 1))
                    .Select(i => new Coordinate(i.First, i.Second))
                    .ToList();
            }

            vents.Add(coords);
        }

        return vents.SelectMany(c => c)
            .GroupBy(g => g)
            .Count(g => g.Count() > minOverlap);
    }

    private static int[,] CreateHydrothermalVents(IEnumerable<Line> lines, bool diagonals = false)
    {
        var grid = CreateEmptyGrid(lines);

        foreach (var line in lines.ToList())
        {
            // Place Vertical vents
            if (line.X1 == line.X2)
            {
                EnumerableRange.Integer(line.Y1, line.Y2, 1)
                    .Select(i => new Coordinate(line.X1, i))
                    .ToList()
                    .ForEach(v => grid[v.Y, v.X] += 1);
            }

            // Place Horizontal vents
            if (line.Y1 == line.Y2)
            {
                EnumerableRange.Integer(line.X1, line.X2, 1)
                    .Select(i => new Coordinate(i, line.Y1))
                    .ToList()
                    .ForEach(v => grid[v.Y, v.X] += 1);
            }

            // Place Diagonal vents
            if ((line.X2 - line.X1 == line.Y2 - line.Y1) && diagonals)
            {
                EnumerableRange.Integer(line.X1, line.X2, 1)
                    .Zip(EnumerableRange.Integer(line.Y1, line.Y2, 1))
                    .Select(i => new Coordinate(i.First, i.Second))
                    .ToList()
                    .ForEach(v => grid[v.Y, v.X] += 1);
            }

            // Place Antidiagonal vents
            if ((line.X2 - line.X1 == line.Y1 - line.Y2) && diagonals)
            {
                EnumerableRange.Integer(line.X1, line.X2, 1)
                    .Zip(EnumerableRange.Integer(line.Y1, line.Y2, 1))
                    .Select(i => new Coordinate(i.First, i.Second))
                    .ToList()
                    .ForEach(v => grid[v.Y, v.X] += 1);
            }
        }

        return grid;
    }

    private static int[,] CreateEmptyGrid(IEnumerable<Line> lines)
    {
        var X1 = lines.Max(l => l.X1);
        var X2 = lines.Max(l => l.X2);
        var Y1 = lines.Max(l => l.Y1);
        var Y2 = lines.Max(l => l.Y2);

        var maxX = Math.Max(X1, X2);
        var maxY = Math.Max(Y1, Y2);

        return new int[maxY + 1, maxX + 1];
    }

    private static int CountOverlappingVents(int[,] grid, int minOverlap = 1)
    {
        int countMaxOverlap = 0;
        foreach (var cell in grid)
        {
            if (cell > minOverlap)
            {
                countMaxOverlap++;
            }
        }

        return countMaxOverlap;
    }

    private static void TraceGrid(int[,] grid)
    {
        int rowLength = grid.GetLength(0);
        int colLength = grid.GetLength(1);

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                var value = grid[i, j] != 0 ? grid[i, j].ToString() : ".";
                Trace.Write($"{value}");
            }
            Trace.Write(Environment.NewLine);
        }
    }

    internal record struct Line(int X1, int Y1, int X2, int Y2);
    internal record struct Coordinate(int X, int Y);
}
