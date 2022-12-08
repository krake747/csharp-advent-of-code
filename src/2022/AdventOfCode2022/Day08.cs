using System.Text.RegularExpressions;
using AdventOfCodeLib;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

[AocPuzzle(2022, 8, "Treetop Tree House")]
public class Day08 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        var treeGrid = GenerateTreeGrid(input);
        return treeGrid.Cast<bool>().ToArray().Count(t => t);
    }

    public int Part2(IEnumerable<string> input)
    {
        return 1;
    }

    private static bool[,] GenerateTreeGrid(IEnumerable<string> input)
    {
        var map = input.Select(trees => trees.Select(t => int.Parse(t.ToString())).ToArray())
            .ToArray();

        var rows = map.Length;
        var cols = map[0].Length;
        var treeGrid = new bool[rows, cols];
        for (var row = 0; row < treeGrid.GetLength(0); row++)
        for (var col = 0; col < treeGrid.GetLength(1); col++)
        {
            var tree = map[row][col];
            treeGrid[row, col] = IsTreeOnBorder(row, col, rows, cols) || 
                                 IsTreeVisibleFromAnyDirection(map, row, col, tree);
        }

        return treeGrid;
    }

    private static bool IsTreeVisibleFromAnyDirection(int[][] map, int row, int col, int tree)
    {
        var treesToNorth = map.GetColumn(col)
            .Where((_, idx) => idx < row)
            .All(height => height < tree);

        var treesToSouth = map.GetColumn(col)
            .Where((_, idx) => idx > row)
            .All(height => height < tree);

        var treesToWest = map.GetRow(row)
            .Where((_, idx) => idx < col)
            .All(height => height < tree);
        
        var treesToEast = map.GetRow(row)
            .Where((_, idx) => idx > col)
            .All(height => height < tree);

        return treesToNorth || treesToSouth || treesToWest || treesToEast;
    }

    private static bool IsTreeOnBorder(int row, int col, int rows, int cols)
    {
        bool OnNorthOrWestBorder(int value) => value == 0;
        bool OnSouthOrEastBorder(int value, int limit) => value + 1 >= limit;
        return OnNorthOrWestBorder(row) || 
               OnSouthOrEastBorder(col, cols) || 
               OnSouthOrEastBorder(row, rows) ||
               OnNorthOrWestBorder(col);
    }

    private readonly record struct Tree(int Row, int Col, int Height);
}