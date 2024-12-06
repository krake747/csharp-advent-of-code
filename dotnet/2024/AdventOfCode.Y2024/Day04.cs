using System.Collections.Frozen;
using AdventOfCode.Lib;
using Map = System.Collections.Frozen.FrozenDictionary<AdventOfCode.Lib.Point, char>;

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 4, "Ceres Search", "C#")]
public sealed class Day04 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        input.AllLines
            .Pipe(ParseMap)
            .Pipe(
                map =>
                    from point in map.Keys
                    from direction in new[] { Point.East, Point.SouthEast, Point.South, Point.SouthWest }
                    select SearchWord(map, "XMAS", point, direction)
            )
            .Pipe(matches => matches.Count(m => m));

    public static int Part2(AocInput input) =>
        input.AllLines
            .Pipe(ParseMap)
            .Pipe(
                map =>
                    from point in map.Keys
                    select SearchWord(map, "MAS", point + Point.NorthWest, Point.SouthEast) &&
                           SearchWord(map, "MAS", point + Point.SouthWest, Point.NorthEast)
            )
            .Pipe(matches => matches.Count(m => m));

    private static bool SearchWord(Map map, string pattern, Point point, Point direction)
    {
        var len = pattern.Length;
        char[] chars = [..Enumerable.Range(0, len).Select(i => map.GetValueOrDefault(point + direction * i))];
        return chars.SequenceEqual(pattern) || chars.SequenceEqual(pattern.Reverse());
    }

    private static Map ParseMap(string[] lines) => (
        from y in Enumerable.Range(0, lines.Length)
        from x in Enumerable.Range(0, lines[0].Length)
        select KeyValuePair.Create(new Point(x, y), lines[y][x])
    ).ToFrozenDictionary();
}