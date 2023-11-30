using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 9, "All in a Single Night")]
public sealed partial class Day09 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var flights = ParseInstructions(input.Lines).ToArray();
        var locations = flights.SelectMany(x => new[] { x.From, x.To }).Distinct().ToArray();
        return GetPermutations(locations, locations.Length)
            .Select(layovers => layovers.Zip(layovers.Skip(1), (from, to) => (from, to)))
            .Select(route => route.Sum(r => CalculateDistance(flights, r.from, r.to)))
            .Min();
    }

    public static int Part2(AocInput input)
    {
        var flights = ParseInstructions(input.Lines).ToArray();
        var locations = flights.SelectMany(x => new[] { x.From, x.To }).Distinct().ToArray();
        return GetPermutations(locations, locations.Length)
            .Select(layovers => layovers.Zip(layovers.Skip(1), (from, to) => (from, to)))
            .Select(route => route.Sum(r => CalculateDistance(flights, r.from, r.to)))
            .Max();
    }

    private static IEnumerable<Flight> ParseInstructions(IEnumerable<string> instructions) =>
        instructions.Select(x => FlightPattern().Match(x))
            .Select(x => new Flight(x.Groups[1].Value, x.Groups[2].Value, int.Parse(x.Groups[3].Value)));

    private static int CalculateDistance(IEnumerable<Flight> flights, string from, string to) =>
        flights.First(x => (x.From == from && x.To == to) || (x.To == from && x.From == to)).Distance;

    private static IEnumerable<T[]> GetPermutations<T>(IReadOnlyList<T> list, int length) =>
        length is 1
            ? list.Select(x => new[] { x })
            : GetPermutations(list, length - 1)
                .SelectMany(x => list.Where(o => x.Contains(o) is false),
                    (x1, x2) => x1.Concat([x2]).ToArray());

    [GeneratedRegex("(.*) to (.*) = (.*)")]
    private static partial Regex FlightPattern();

    private sealed record Flight(string From, string To, int Distance);
}