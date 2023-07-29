using AdventOfCodeLib;

namespace AdventOfCode2022;

[AocPuzzle(2022, 8, "Treetop Tree House")]
public sealed class Day08 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var treeCoverGrid = DetermineForest(input.Lines, TreeCoverScore);
        return treeCoverGrid.Cast<int>().Sum();
    }

    public static int Part2(AocInput input)
    {
        var treeScenicGrid = DetermineForest(input.Lines, TreeScenicScore);
        return treeScenicGrid.Cast<int>().Max();
    }

    private static int[,] DetermineForest(IEnumerable<string> input, Func<int[,], int, int, int> func)
    {
        var map = input.Select(trees => trees.Select(t => int.Parse(t.ToString())).ToArray())
            .ToArray();

        var rows = map.Length;
        var cols = map[0].Length;
        var forest = new int[rows, cols];
        for (var row = 0; row < forest.GetLength(0); row++)
        for (var col = 0; col < forest.GetLength(1); col++)
        {
            forest[row, col] = map[row][col];
        }

        var treeGrid = new int[rows, cols];
        for (var row = 0; row < treeGrid.GetLength(0); row++)
        for (var col = 0; col < treeGrid.GetLength(1); col++)
        {
            treeGrid[row, col] = func(forest, row, col);
        }

        return treeGrid;
    }

    private static int TreeCoverScore(int[,] forest, int row, int col) =>
        TreeOnBorder(forest, row, col) || TreeVisibleFromAnyDirection(forest, row, col)
            ? 1
            : 0;

    private static bool TreeOnBorder(int[,] forest, int row, int col)
    {
        bool OnBorder(int value, int limit) => value == Math.Min(value, 0) || value + 1 >= Math.Max(value + 1, limit);

        var rows = forest.GetLength(0);
        var cols = forest.GetLength(1);
        return OnBorder(row, rows) || OnBorder(col, cols);
    }

    private static bool TreeVisibleFromAnyDirection(int[,] forest, int row, int col)
    {
        var tree = forest[row, col];
        var treesOnColum = forest.GetColumn(col).ToArray();
        var treesOnRow = forest.GetRow(row).ToArray();

        if (treesOnColum.All(height => height < tree) && treesOnRow.All(height => height < tree))
        {
            return true;
        }

        var treesToNorth = treesOnColum.Where((_, idx) => idx < row)
            .All(height => height < tree);

        var treesToSouth = treesOnColum.Where((_, idx) => idx > row)
            .All(height => height < tree);

        var treesToWest = treesOnRow.Where((_, idx) => idx < col)
            .All(height => height < tree);

        var treesToEast = treesOnRow.Where((_, idx) => idx > col)
            .All(height => height < tree);

        return treesToNorth || treesToSouth || treesToWest || treesToEast;
    }

    private static int TreeScenicScore(int[,] forest, int row, int col)
    {
        var tree = forest[row, col];
        var treesOnColum = forest.GetColumn(col).ToArray();
        var treesOnRow = forest.GetRow(row).ToArray();

        var treesToNorth = treesOnColum.Where((_, idx) => idx < row)
            .Reverse()
            .TakeUntil(height => height >= tree)
            .Count();

        var treesToSouth = treesOnColum.Where((_, idx) => idx > row)
            .TakeUntil(height => height >= tree)
            .Count();

        var treesToWest = treesOnRow.Where((_, idx) => idx < col)
            .Reverse()
            .TakeUntil(height => height >= tree)
            .Count();

        var treesToEast = treesOnRow.Where((_, idx) => idx > col)
            .TakeUntil(height => height >= tree)
            .Count();

        return treesToNorth * treesToSouth * treesToWest * treesToEast;
    }
}