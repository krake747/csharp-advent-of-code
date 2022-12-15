using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2020;

public class Day03 : IDay<IEnumerable<string>, long>
{
    public long Part1(IEnumerable<string> input)
    {
        var treeMap = CreateTreeMap(input);
        return CountTreesOnSlope(treeMap, new Slope(1, 3));
    }

    public long Part2(IEnumerable<string> input)
    {
        var treeMap = CreateTreeMap(input);
        return new[]
            {
                new Slope(1, 1),
                new Slope(1, 3),
                new Slope(1, 5),
                new Slope(1, 7),
                new Slope(2, 1)
            }
            .Aggregate(1L, (prod, slope) => prod * CountTreesOnSlope(treeMap, slope));
    }

    private static bool[][] CreateTreeMap(IEnumerable<string> input)
    {
        return input.Select(s => s.Select(c => c == '#').ToArray())
            .ToArray();
    }

    private static long CountTreesOnSlope(IReadOnlyList<bool[]> treemap, Slope slope)
    {
        var count = 0;
        for (int x = 0, y = 0; x < treemap.Count; x += slope.DeltaX, y += slope.DeltaY)
            if (treemap[x][y % treemap[x].Length])
                count++;

        return count;
    }

    private readonly record struct Slope(int DeltaX, int DeltaY);
}