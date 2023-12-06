using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 6, "Wait For It")]
public sealed partial class Day06 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        ParseRaces(input.Lines)
            .Select(BeatingTheRecord)
            .Aggregate(1, (wins, ways) => wins * ways);

    private static int BeatingTheRecord(Race race) =>
        Enumerable.Range(0, race.Time + 1)
            .Select(hold => (BoatSpeed: hold, TravelTime: race.Time - hold))
            .Select(x => x.BoatSpeed * x.TravelTime)
            .Select(travel => travel > race.RecordDistance)
            .Count(x => x);

    private static IEnumerable<Race> ParseRaces(IEnumerable<string> lines) => lines
        .Select(line => NumbersRegex().Matches(line).Select(m => int.Parse(m.Value)))
        .ToArray()
        .Pipe(document =>
        {
            var times = document[0];
            var distances = document[^1];
            return times.Zip(distances, (t, d) => new Race(t, d));
        });

    public static int Part2(AocInput input) => 0;
    
    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersRegex();

    private readonly record struct Race(int Time, int RecordDistance);
}