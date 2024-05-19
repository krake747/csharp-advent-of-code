using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 4, "Scratchcards")]
public sealed partial class Day04 : IAocDay<int>
{
    private static readonly char[] Separators = [':', '|'];

    public static int Part1(AocInput input) =>
        Scratchcards(input.Lines)
            .Select(card => card.WinningNumbers.Intersect(card.Numbers).Count())
            .Sum(n => (int)Math.Pow(2, n - 1));

    public static int Part2(AocInput input) =>
        Scratchcards(input.Lines)
            .ToArray()
            .Pipe(scratchcards =>
            {
                var store = scratchcards.ToDictionary(kvp => kvp.Id, kvp => (Card: kvp, Original: 1, Copies: 0));
                var counted = store.Aggregate(store, (pile, scratchcard) =>
                {
                    var ((id, winningNumbers, numbers), original, copies) = scratchcard.Value;
                    var total = original + copies;
                    for (var i = 0; i < total; i++)
                    {
                        var matchingNumbers = winningNumbers.Intersect(numbers).Count();
                        for (var nextId = id + 1; nextId <= id + matchingNumbers; nextId++)
                        {
                            var current = pile[nextId];
                            current.Copies += 1;
                            pile[nextId] = current;
                        }
                    }

                    return pile;
                });

                return counted.Values.Sum(x => x.Original + x.Copies);
            });

    private static IEnumerable<Scratchcard> Scratchcards(IEnumerable<string> lines) => lines
        .Select(line => line.Split(Separators))
        .Select(ParseScratchcard);

    private static Scratchcard ParseScratchcard(string[] pile)
    {
        var id = GetNumbers(pile[0]).Single();
        var winningNumbers = GetNumbers(pile[1]);
        var numbers = GetNumbers(pile[2]);
        return new Scratchcard(id, winningNumbers, numbers);
    }

    private static int[] GetNumbers(string cards) =>
        DigitRegex().Matches(cards).Select(mc => int.Parse(mc.Value)).ToArray();

    [GeneratedRegex(@"\d+")]
    private static partial Regex DigitRegex();

    private sealed record Scratchcard(int Id, int[] WinningNumbers, int[] Numbers);
}