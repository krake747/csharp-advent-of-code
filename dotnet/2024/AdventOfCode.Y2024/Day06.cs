using AdventOfCode.Lib;
using PatrolMap = System.Collections.Generic.Dictionary<AdventOfCode.Lib.Point, char>;

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 6, "Guard Gallivant", "C#")]
public sealed class Day06 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        input.AllLines
            .Pipe(lines =>
            {
                var map = ParsePatrolMap(lines);
                var start = LocateGuardStart(map, '^');
                return TrackGuardRoute(map, start);
            })
            .Pipe(route => route.Positions.Count);

    public static int Part2(AocInput input) =>
        input.AllLines
            .Pipe(lines =>
            {
                var map = ParsePatrolMap(lines);
                var start = LocateGuardStart(map, '^');
                return TrackGuardRoute(map, start).Positions.Where(p => map[p] is '.')
                    .Sum(obstacle =>
                    {
                        var updatedMap = UpdateMap(map, '#', obstacle);
                        var (_, loop) = TrackGuardRoute(updatedMap, start);
                        return loop ? 1 : 0;
                    });
            });

    private static PatrolMap UpdateMap(PatrolMap map, char obstacle, Point position) =>
        map.ToDictionary(kvp => kvp.Key, kvp => kvp.Key == position ? obstacle : kvp.Value);

    private static GuardRoute TrackGuardRoute(PatrolMap map, Point start)
    {
        var position = start;
        var patrol = new PatrolState(start, Point.North);
        var visited = new HashSet<PatrolState>();
        while (map.ContainsKey(patrol.Position) && visited.Add(patrol))
        {
            patrol = map.GetValueOrDefault(patrol.Position + patrol.Direction) switch
            {
                '#' => patrol with { Direction = Point.RotateRight(patrol.Direction) },
                _ => patrol with { Position = position += patrol.Direction }
            };
        }

        return new GuardRoute(visited.Select(s => s.Position).ToHashSet(), visited.Contains(patrol));
    }

    private static Point LocateGuardStart(PatrolMap map, char c) =>
        map.Single(p => p.Value == c).Key;

    private static PatrolMap ParsePatrolMap(string[] lines) => (
        from y in Enumerable.Range(0, lines.Length)
        from x in Enumerable.Range(0, lines[0].Length)
        select KeyValuePair.Create(new Point(x, y), lines[y][x])
    ).ToDictionary();

    private readonly record struct PatrolState(Point Position, Point Direction);

    private readonly record struct GuardRoute(HashSet<Point> Positions, bool Loop);
}