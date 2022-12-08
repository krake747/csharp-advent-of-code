﻿using AdventOfCodeLib;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

[AocPuzzle(2022, 8, "Treetop Tree House")]
public class Day08 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        var forest = CreateForest(input);
        var treeCoverGrid = DetermineForest(forest, TreeCoverScore);
        return treeCoverGrid.Cast<int>().Sum();
    }

    public int Part2(IEnumerable<string> input)
    {
        var forest = CreateForest(input);
        var treeScenicGrid = DetermineForest(forest, TreeScenicScore);
        return treeScenicGrid.Cast<int>().Max();
    }

    private static int[,] CreateForest(IEnumerable<string> input)
    {
        var map = input.Select(trees => trees.Select(t => int.Parse(t.ToString())).ToArray())
            .ToArray();

        var rows = map.Length;
        var cols = map[0].Length;
        var forest = new int[rows, cols];
        for (var row = 0; row < forest.GetLength(0); row++)
        for (var col = 0; col < forest.GetLength(1); col++) 
            forest[row, col] = map[row][col];
        
        return forest;
    }
    
    private static int[,] DetermineForest(int[,] forest, Func<int[,], int, int, int> func)
    {
        var rows = forest.GetLength(0);
        var cols = forest.GetLength(1);
        var treeGrid = new int[rows, cols];
        for (var row = 0; row < treeGrid.GetLength(0); row++)
        for (var col = 0; col < treeGrid.GetLength(1); col++)
        {
            treeGrid[row, col] = func(forest, row, col);
        }

        return treeGrid;
    }

    private static int TreeCoverScore(int[,] forest, int row, int col)
    {
        return TreeOnBorder(forest, row, col) || TreeVisibleFromAnyDirection(forest, row, col)
            ? 1
            : 0;
    }

    private static bool TreeOnBorder(int[,] forest, int row, int col)
    {
        bool OnNorthOrWestBorder(int value)
        {
            return value == 0;
        }

        bool OnSouthOrEastBorder(int value, int limit)
        {
            return value + 1 >= limit;
        }
        
        var rows = forest.GetLength(0);
        var cols = forest.GetLength(1);
        return OnNorthOrWestBorder(row) ||
               OnSouthOrEastBorder(col, cols) ||
               OnSouthOrEastBorder(row, rows) ||
               OnNorthOrWestBorder(col);
    }

    private static bool TreeVisibleFromAnyDirection(int[,] forest, int row, int col)
    {
        var tree = forest[row, col];
        var treesToNorth = forest.GetColumn(col)
            .Where((_, idx) => idx < row)
            .All(height => height < tree);

        var treesToSouth = forest.GetColumn(col)
            .Where((_, idx) => idx > row)
            .All(height => height < tree);

        var treesToWest = forest.GetRow(row)
            .Where((_, idx) => idx < col)
            .All(height => height < tree);

        var treesToEast = forest.GetRow(row)
            .Where((_, idx) => idx > col)
            .All(height => height < tree);

        return treesToNorth || treesToSouth || treesToWest || treesToEast;
    }

    private static int TreeScenicScore(int[,] forest, int row, int col)
    {
        var tree = forest[row, col];
        var treesToNorth = forest.GetColumn(col)
            .Where((_, idx) => idx < row)
            .Reverse()
            .TakeUntil(height => height >= tree)
            .Count();

        var treesToSouth = forest.GetColumn(col)
            .Where((_, idx) => idx > row)
            .TakeUntil(height => height >= tree)
            .Count();

        var treesToWest = forest.GetRow(row)
            .Where((_, idx) => idx < col)
            .Reverse()
            .TakeUntil(height => height >= tree)
            .Count();

        var treesToEast = forest.GetRow(row)
            .Where((_, idx) => idx > col)
            .TakeUntil(height => height >= tree)
            .Count();

        return treesToNorth * treesToSouth * treesToWest * treesToEast;
    }
}