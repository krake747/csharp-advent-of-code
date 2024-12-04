using System.Collections.Frozen;
using System.Numerics;
using AdventOfCode.Lib;
using Map = System.Collections.Frozen.FrozenDictionary<AdventOfCode.Y2024.Point, char>;

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 4, "Ceres Search", "C#")]
public sealed class Day04 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        input.AllLines
            .Pipe(ParseMap)
            .Pipe(
                static map =>
                    from point in map.Keys
                    from direction in new[] { Point.East, Point.SouthEast, Point.South, Point.SouthWest }
                    select WordSearch(map, point, direction, "XMAS")
            )
            .Pipe(matches => matches.Count(m => m));

    public static int Part2(AocInput input) =>
        input.AllLines
            .Pipe(ParseMap)
            .Pipe(
                map =>
                    from point in map.Keys
                    select WordSearch(map, point + Point.NorthWest, Point.SouthEast, "MAS") &&
                           WordSearch(map, point + Point.SouthWest, Point.NorthEast, "MAS")
            )
            .Pipe(matches => matches.Count(m => m));

    private static bool WordSearch(Map map, Point point, Point direction, string pattern)
    {
        var len = pattern.Length;
        char[] chars = [..Enumerable.Range(0, len).Select(i => map.GetValueOrDefault(point + direction * i))];
        return chars.SequenceEqual(pattern) || chars.SequenceEqual(pattern.Reverse());
    }

    private static Map ParseMap(string[] lines) =>
    (
        from y in Enumerable.Range(0, lines.Length)
        from x in Enumerable.Range(0, lines[0].Length)
        select KeyValuePair.Create(new Point(x, y), lines[y][x])
    ).ToFrozenDictionary();
}

internal readonly record struct Point(int X, int Y)
    : IAdditionOperators<Point, Point, Point>,
        IMultiplyOperators<Point, int, Point>
{
    public static readonly Point North = new(0, -1);      // Move up
    public static readonly Point NorthEast = new(1, -1);  // Move diagonally up-right
    public static readonly Point East = new(1, 0);        // Move right
    public static readonly Point SouthEast = new(1, 1);   // Move diagonally down-right
    public static readonly Point South = new(0, 1);       // Move down
    public static readonly Point SouthWest = new(-1, 1);  // Move diagonally down-left
    public static readonly Point West = new(-1, 0);       // Move left
    public static readonly Point NorthWest = new(-1, -1); // Move diagonally up-left

    public static Point operator +(Point p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);
    public static Point operator *(Point p, int factor) => new(p.X * factor, p.Y * factor);
}