using System.Diagnostics;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 7, "Camel Cards")]
public sealed class Day07 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        ParseHands(input.Lines)
            .OrderBy(hand => HandStrength(hand.Cards))
            .ThenBy(hand => hand, new LabelComparer(LabelStrength))
            .Select((h, i) => h.Bid * (i + 1))
            .Sum();

    public static int Part2(AocInput input) =>
        ParseHands(input.Lines)
            .OrderBy(hand => HandStrength(Jokerize(hand.Cards)))
            .ThenBy(hand => hand, new LabelComparer(LabelStrengthWithJoker))
            .Select((h, i) => h.Bid * (i + 1))
            .Sum();

    private static IEnumerable<Hand> ParseHands(IEnumerable<string> lines) =>
        lines.Select(l => l.Split(' '))
            .Select(x => new Hand(x[0], int.Parse(x[^1])));

    private static string Jokerize(string cards) =>
        cards.Contains('J') && cards is not "JJJJJ"
            ? cards.GroupBy(c => c).Select(g => cards.Replace('J', g.Key)).MaxBy(HandStrength)!
            : cards;

    private static int HandStrength(string cards) => cards switch
    {
        _ when FiveOfAKind(cards) => 6,
        _ when FourOfAKind(cards) => 5,
        _ when FullHouse(cards) => 4,
        _ when ThreeOfAKind(cards) => 3,
        _ when TwoPair(cards) => 2,
        _ when OnePair(cards) => 1,
        _ when HighCard(cards) => 0,
        _ => throw new UnreachableException("Expressions should have been exhaustive")
    };

    private static bool FiveOfAKind(string cards) => cards.Distinct().Count() is 1;
    private static bool FourOfAKind(string cards) => cards.GroupBy(x => x).Any(x => x.Count() is 4);
    private static bool FullHouse(string cards) => cards.GroupBy(x => x).All(x => x.Count() is 3 or 2);
    private static bool ThreeOfAKind(string cards) => cards.GroupBy(x => x).Any(x => x.Count() is 3);
    private static bool TwoPair(string cards) => cards.GroupBy(x => x).Count(x => x.Count() is 2) is 2;
    private static bool OnePair(string cards) => cards.GroupBy(x => x).Any(x => x.Count() is 2);
    private static bool HighCard(string cards) => cards.Distinct().Count() is 5;

    private static int LabelStrength(char c) => c switch
    {
        'A' => 14,
        'K' => 13,
        'Q' => 12,
        'J' => 11,
        'T' => 10,
        _ => int.Parse(c.ToString())
    };

    private static int LabelStrengthWithJoker(char c) => LabelStrength(c is 'J' ? '1' : c);

    private sealed class LabelComparer(Func<char, int> labelStrength) : IComparer<Hand>
    {
        public int Compare(Hand? h1, Hand? h2) =>
            h1 == h2
                ? 0
                : h1!.Cards
                    .Zip(h2!.Cards, (fst, snd) => (L: labelStrength(fst), R: labelStrength(snd)))
                    .FirstOrDefault(x => x.L > x.R || x.R > x.L)
                    .Pipe(x => x.L.CompareTo(x.R));
    }

    private sealed record Hand(string Cards, int Bid);
}