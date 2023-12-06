using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 6, "Wait For It")]
public sealed partial class Day06 : IAocDay<long>
{
    public static long Part1(AocInput input) =>
        ParseRaceDocument(input.Lines)
            .Pipe(ReadBadWriting)
            .Select(BreakRecord)
            .Aggregate(1L, (wins, ways) => wins * ways);

    public static long Part2(AocInput input) =>
        ParseRaceDocument(input.Lines)
            .Pipe(ReadGoodWriting)
            .Select(BreakRecord)
            .Aggregate(1L, (wins, ways) => wins * ways);
    
    private static long BreakRecord(Race race)
    {
        var count = 0L;
        for (var charge = 0; charge < race.Time + 1L; charge++)
        {
            count += charge * (race.Time - charge) > race.RecordDistance ? 1 : 0;
        }

        return count;
    }
    
    private static IEnumerable<string>[] ParseRaceDocument(IEnumerable<string> lines) => 
        lines.Select(line => NumbersRegex().Matches(line).Select(m => m.Value)).ToArray();

    private static IEnumerable<Race> ReadBadWriting(IEnumerable<string>[] document)
    {
        var times = document[0].Select(long.Parse);
        var distances = document[^1].Select(long.Parse);
        return times.Zip(distances, (t, d) => new Race(t, d));
    }

    private static IEnumerable<Race> ReadGoodWriting(IEnumerable<string>[] document)
    {
        var time = string.Join("", document[0]).Pipe(long.Parse);
        var distance = string.Join("", document[^1]).Pipe(long.Parse);
        return [new Race(time, distance)];
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersRegex();

    private readonly record struct Race(long Time, long RecordDistance);
}