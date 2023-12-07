using System.Diagnostics;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 7, "Camel Cards")]
public sealed class Day07 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        ParseHands(input.Lines)
            .OrderBy(HandStrength)
            .ThenBy(hand => hand, new LabelComparer())
            .Select((h, i) => h.Bid * (i + 1)).Sum();

    public static int Part2(AocInput input) => 0;
    
    private static IEnumerable<Hand> ParseHands(IEnumerable<string> lines) =>
        lines.Select(l => l.Split(' '))
            .Select(x => new Hand(x[0], int.Parse(x[^1])));

    private static int HandStrength(Hand hand) => hand.Cards switch
    {
        _ when FiveOfAKind(hand.Cards) => 6,
        _ when FourOfAKind(hand.Cards) => 5,
        _ when FullHouse(hand.Cards) => 4,
        _ when ThreeOfAKind(hand.Cards) => 3,
        _ when TwoPair(hand.Cards) => 2,
        _ when OnePair(hand.Cards) => 1,
        _ when HighCard(hand.Cards) => 0,
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

    private sealed class LabelComparer : IComparer<Hand>
    {
        public int Compare(Hand? h1, Hand? h2) => h1!.Cards
            .Zip(h2!.Cards, (fst, snd) => (L: LabelStrength(fst), R: LabelStrength(snd)))
            .First(x => x.L > x.R || x.R > x.L)
            .Pipe(x => x.L.CompareTo(x.R));
    } 
    
    private sealed record Hand(string Cards, int Bid);
}
