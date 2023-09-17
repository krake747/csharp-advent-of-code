using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 13, "Knights of the Dinner Table")]
public sealed class Day13 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var instructions = ParseInstructions(input.Lines).ToArray();
        var people = instructions.Select(x => x.Person).Distinct().ToArray();


        var paired = instructions.Select(x =>
            {
                var nextTo = instructions.First(y => x.Person == y.NextTo && x.NextTo == y.Person);
                return new SeatingArrangement(x.Person, nextTo.Person, x.Happiness + nextTo.Happiness);
            })
            .ToArray();

        var d = paired.SelectMany(x => new[] { (x.Person, x.NextTo) }).Distinct().ToArray();


        return 2;
    }

    public static int Part2(AocInput input) => 0;

    private static IEnumerable<SeatingArrangement> ParseInstructions(IEnumerable<string> input)
    {
        return input.Select(x => x.Split(' ') switch
        {
            [var p, _, "gain", var h, .., var next] => new SeatingArrangement(p, next.TrimEnd('.'), +int.Parse(h)),
            [var p, _, "lose", var h, .., var next] => new SeatingArrangement(p, next.TrimEnd('.'), -int.Parse(h)),
            _ => throw new ArgumentException("Undefined case")
        });
    }

    private sealed record SeatingArrangement(string Person, string NextTo, int Happiness);
}