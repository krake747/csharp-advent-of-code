using AdventOfCode.Lib;

namespace AdventOfCode2020;

public sealed class Day03 : IAocDay<long>
{
    public static long Part1(AocInput input) => input.Lines
        .Pipe(CreateTreeMap)
        .Pipe(treeMap => CountTreesOnSlope(treeMap, new Slope(1, 3)));


    public static long Part2(AocInput input) => input.Lines
        .Pipe(CreateTreeMap)
        .Pipe(treeMap => new[]
            {
                new Slope(1, 1),
                new Slope(1, 3),
                new Slope(1, 5),
                new Slope(1, 7),
                new Slope(2, 1)
            }
            .Aggregate(1L, (prod, slope) => prod * CountTreesOnSlope(treeMap, slope)));


    private static bool[][] CreateTreeMap(IEnumerable<string> input) =>
        input.Select(s => s.Select(c => c == '#').ToArray())
            .ToArray();

    private static long CountTreesOnSlope(IReadOnlyList<bool[]> treemap, Slope slope)
    {
        var count = 0;
        for (int x = 0, y = 0; x < treemap.Count; x += slope.DeltaX, y += slope.DeltaY)
        {
            if (treemap[x][y % treemap[x].Length])
            {
                count++;
            }
        }

        return count;
    }

    private readonly record struct Slope(int DeltaX, int DeltaY);
}