using AdventOfCode.Lib;

namespace AdventOfCode.Y2015;

[AocPuzzle(2015, 3, "Perfectly Spherical Houses in a Vacuum")]
public sealed class Day03 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Text
        .Aggregate(new List<Points> { new(0, 0) }, (visited, x) =>
        {
            var currentHouse = visited[^1];
            var nextHouse = Points.MoveToNextHouse(x, currentHouse);
            visited.Add(nextHouse);
            return visited;
        })
        .ToHashSet()
        .Count;

    public static int Part2(AocInput input) => input.Text
        .Select((x, i) => (Direction: x, Index: i))
        .Aggregate((List<List<Points>>)[[new Points(0, 0)], [new Points(0, 0)]], (visited, x) =>
        {
            var isSanta = x.Index % 2 == 0 ? 0 : 1;
            var currentHouse = visited[isSanta][^1];
            var nextHouse = Points.MoveToNextHouse(x.Direction, currentHouse);
            visited[isSanta].Add(nextHouse);

            return visited;
        })
        .SelectMany(x => x)
        .ToHashSet()
        .Count;

    private readonly record struct Points(int X, int Y)
    {
        internal static Points MoveToNextHouse(char x, Points current) => x switch
        {
            '^' => current with { Y = current.Y + 1 },
            '>' => current with { X = current.X + 1 },
            'v' => current with { Y = current.Y - 1 },
            '<' => current with { X = current.X - 1 },
            _ => current
        };
    }
}