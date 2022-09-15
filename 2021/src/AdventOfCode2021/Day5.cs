using AdventOfCode2021.Shared;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
namespace AdventOfCode2021;

public static class Day5
{
    /// <summary>
    /// Consider only horizontal and vertical lines. At how many points do at least two lines overlap?
    /// </summary>
    public static int Part1(IEnumerable<string> input)
    {
        var lines = input.Select(r => Regex.Replace(r, "[^0-9]", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries))
                         .Select(v => new Line(int.Parse(v[0]), int.Parse(v[1]), int.Parse(v[2]), int.Parse(v[3])));

        var grid = PlaceHydrothermalVents(lines, CreateGrid(lines));
        var count = CountOverlappingLines(grid);
        return count;
    }

    /// <summary>
    /// Consider all of the lines. At how many points do at least two lines overlap?
    /// </summary>
    public static int Part2(IEnumerable<string> input)
    {
        return 1;
    }

    private static int[,] CreateGrid(IEnumerable<Line> lines)
    {
        var X1 = lines.Max(l => l.X1);
        var X2 = lines.Max(l => l.X2);
        var Y1 = lines.Max(l => l.Y1);
        var Y2 = lines.Max(l => l.Y2);

        var maxX = Math.Max(X1, X2);
        var maxY = Math.Max(Y1, Y2);

        return new int[maxY + 1, maxX + 1];
    }

    private static int CountOverlappingLines(int[,] grid, int timesOverlapping = 2)
    {
        int countMaxOverlap = 0;
        foreach (var cell in grid)
        {
            if (cell < timesOverlapping)
            {
                continue;
            }
            countMaxOverlap++;
        }

        return countMaxOverlap;
    }

    private static int[,] PlaceHydrothermalVents(IEnumerable<Line> lines, int[,] grid)
    {
        var horizontal = lines.Where(l => l.X1 == l.X2);
        var vertical = lines.Where(l => l.Y1 == l.Y2);

        var vents = horizontal.Concat(vertical);

        foreach (var line in vents.ToList())
        {
            // Place Horizontal vents
            if (line.X1 == line.X2)
            {
                EnumerableRange.Integer(line.Y1, line.Y2, 1)
                               .Select(i => new Coordinate(line.X1, i))
                               .ToList()
                               .ForEach(v => grid[v.Y, v.X] += 1);
            }

            // Place Vertical vents
            if (line.Y1 == line.Y2)
            {
                EnumerableRange.Integer(line.X1, line.X2, 1)
                               .Select(i => new Coordinate(i, line.Y1))
                               .ToList()
                               .ForEach(v => grid[v.Y, v.X] += 1);
            }
        }

        return grid;
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
