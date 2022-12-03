using System.Collections.Immutable;
using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day03 : IDay<IEnumerable<string>>
{
    public int Part1(IEnumerable<string> input)
    {
        return input.Select(CreateTwoCompartments)
            .Select(DistinctItemFromBothCompartments)
            .Sum(ParseItemPriorityValue);
    }

    public int Part2(IEnumerable<string> input)
    {
        return input.GroupBackpacksBy(3)
            .Select(DistinctItemFromGroupOfBackpacks)
            .Sum(ParseItemPriorityValue);
    }

    private static Dictionary<char, int> CreatePriorities(string alphabet)
    {
        return Enumerable.Range(0, alphabet.Length)
            .Select((c, i) => (Priority: i + 1, Item: alphabet[c]))
            .ToDictionary(k => k.Item, v => v.Priority);
    }

    private static Compartment CreateTwoCompartments(string backpack)
    {
        return new Compartment(backpack[..(backpack.Length / 2)], backpack[(backpack.Length / 2)..]);
    }

    private static char DistinctItemFromBothCompartments(Compartment compartment)
    {
        return compartment.First.Intersect(compartment.Second).First();
    }

    private static char DistinctItemFromGroupOfBackpacks(IEnumerable<string> backpacks)
    {
        var input = backpacks.ToArray();
        return input.Skip(1).Aggregate(ImmutableHashSet.Create(input.First().ToCharArray()), (h, e) => h.Intersect(e))
            .First();
    }

    private static int ParseItemPriorityValue(char c)
    {
        return c < 'a' ? c - 'A' + 27 : c - 'a' + 1;
    }

    private record Compartment(string First, string Second);
}

internal static class Day03Extensions
{
    internal static IEnumerable<IEnumerable<string>> GroupBackpacksBy(this IEnumerable<string> backpacks,
        int count)
    {
        var input = backpacks.ToArray();
        for (var backpack = 0; backpack < input.Length; backpack += count)
            yield return input.Skip(backpack).Take(count);
    }
}