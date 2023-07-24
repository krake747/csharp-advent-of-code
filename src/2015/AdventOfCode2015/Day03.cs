using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 3, "Perfectly Spherical Houses in a Vacuum")]
public sealed class Day03 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Text
        .Aggregate(new List<Coordinates> { new(0, 0) }, (visited, c) =>
        {
            var currentHouse = visited[^1];
            var nextHouse = c switch
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

    public static int Part2(AocInput input) => 1;

    private readonly record struct Coordinates(int X, int Y);
}