using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 6, "Wait For It")]
public sealed partial class Day06 : IAocDay<long>
{
    public static long Part1(AocInput input) =>
        ParseRaceDocument(input.Lines)
            .Pipe(ReadDocument)
            .Select(WaysToWinRace)
            .Aggregate(1L, (wins, ways) => wins * ways);

    public static long Part2(AocInput input) =>
        ParseRaceDocument(input.Lines.Select(l => l.Replace(" ", "")))
            .Pipe(ReadDocument)
            .Select(WaysToWinRace)
            .Aggregate(1L, (wins, ways) => wins * ways);

    private static long WaysToWinRace(Race race)
    {
        var count = 0L;
        for (var charge = 0; charge < race.Time + 1L; charge++)
        {
            count += charge * (race.Time - charge) > race.RecordDistance ? 1 : 0;
        }

        return count;
    }

    private static IEnumerable<long>[] ParseRaceDocument(IEnumerable<string> lines) =>
        lines.Select(line => NumbersRegex().Matches(line).Select(m => long.Parse(m.Value)))
            .ToArray();

    private static IEnumerable<Race> ReadDocument(IEnumerable<long>[] document) =>
        document[0].Zip(document[^1], (t, d) => new Race(t, d));

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersRegex();

    private readonly record struct Race(long Time, long RecordDistance);
}