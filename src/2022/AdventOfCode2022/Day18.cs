using System.Collections;
using AdventOfCodeLib;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

[AocPuzzle(2022, 18, "Boiling Boulders")]
public sealed class Day18 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        var lavaLocations = LavaLocations(input).ToHashSet();
        return lavaLocations.SelectMany(Neighbors)
            .Count(lavaLocation => !lavaLocations.Contains(lavaLocation));
    }

    public int Part2(IEnumerable<string> input)
    {
        return 1;
    }

    private static IEnumerable<Point> LavaLocations(IEnumerable<string> input)
    {
        return input.Select(line => line.Split(',').Select(int.Parse).ToArray())
            .Select(line =>new Point(line[0], line[1], line[2]));
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
            lavaLocation with { Z = lavaLocation.Z + 1 },
        };
    }
    
    private readonly record struct Point(int X, int Y, int Z);
}
