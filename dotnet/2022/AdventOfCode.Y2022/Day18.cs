using AdventOfCode.Lib;

namespace AdventOfCode.Y2022;

[AocPuzzle(2022, 18, "Boiling Boulders")]
public sealed class Day18 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var lavaLocations = LavaLocations(input.Lines).ToHashSet();
        return lavaLocations.SelectMany(Neighbors)
            .Count(lavaLocation => !lavaLocations.Contains(lavaLocation));
    }

    public static int Part2(AocInput input) => 1;

    private static IEnumerable<Point> LavaLocations(IEnumerable<string> input)
    {
        return input.Select(line => line.Split(',').Select(int.Parse).ToArray())
            .Select(line => new Point(line[0], line[1], line[2]));
    }

    private static IEnumerable<Point> Neighbors(Point lavaLocation)
    {
        return new[]
        {
            lavaLocation with { X = lavaLocation.X - 1 },
            lavaLocation with { X = lavaLocation.X + 1 },
            lavaLocation with { Y = lavaLocation.Y - 1 },
            lavaLocation with { Y = lavaLocation.Y + 1 },
            lavaLocation with { Z = lavaLocation.Z - 1 },
            lavaLocation with { Z = lavaLocation.Z + 1 }
        };
    }

    private readonly record struct Point(int X, int Y, int Z);
}