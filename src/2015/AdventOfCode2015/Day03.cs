using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 3, "Perfectly Spherical Houses in a Vacuum")]
public sealed class Day03 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Text
        .Aggregate(new List<Points> { new(0, 0) }, (visited, x) =>
        {
            var currentHouse = visited[^1];
            var nextHouse = x switch
            {
                '^' => currentHouse with { Y = currentHouse.Y + 1 },
                '>' => currentHouse with { X = currentHouse.X + 1 },
                'v' => currentHouse with { Y = currentHouse.Y - 1 },
                '<' => currentHouse with { X = currentHouse.X - 1 },
                _ => currentHouse
            };
            visited.Add(nextHouse);
            return visited;
        })
        .ToHashSet()
        .Count;

    public static int Part2(AocInput input) => input.Text
        .Select((x, i) => (Direction: x, Index: i))
        .Aggregate(new List<List<Points>> { new() { new Points(0, 0) }, new() { new Points(0, 0) } }, (visited, x) =>
        {
            var santa = x.Index % 2 == 0 ? 0 : 1;
            var currentHouse = visited[santa][^1];
            var nextHouse = x.Direction switch
            {
                '^' => currentHouse with { Y = currentHouse.Y + 1 },
                '>' => currentHouse with { X = currentHouse.X + 1 },
                'v' => currentHouse with { Y = currentHouse.Y - 1 },
                '<' => currentHouse with { X = currentHouse.X - 1 },
                _ => currentHouse
            };
            visited[santa].Add(nextHouse);
            return visited;
        })
        .SelectMany(x => x)
        .ToHashSet()
        .Count;

    private readonly record struct Points(int X, int Y);
}