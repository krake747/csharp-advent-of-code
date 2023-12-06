using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 6, "Wait For It")]
public sealed partial class Day06 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var races = ParseRaces(input.Lines);
        var distances = races.Select(race =>
        {
            List<bool> distances = [];
            foreach (var hold in Enumerable.Range(0, race.Time + 1))
            {
                var boatSpeed = hold;
                var travelTime = race.Time - hold;
                var travel = boatSpeed * travelTime;
                distances.Add(travel > race.RecordDistance);
            }
            
            return distances.Count(x => x is true);
        });
        
        
        return distances.Aggregate(1, (seed, acc) => seed * acc);
    }

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