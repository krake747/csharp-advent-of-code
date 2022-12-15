using System.Collections.Immutable;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

public class Day03 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        return input.ChunkBackpackBy(2)
            .Select(DistinctItemFromGroupOfBackpacks)
            .Sum(ParseItemPriorityValue);
    }

    public int Part2(IEnumerable<string> input)
    {
        return input.Chunk(3)
            .Select(DistinctItemFromGroupOfBackpacks)
            .Sum(ParseItemPriorityValue);
    }

    private static char DistinctItemFromGroupOfBackpacks(IEnumerable<string> backpacks)
    {
        var input = backpacks.ToArray();
        return input.Skip(1).Aggregate(ImmutableHashSet.Create(input.First().ToCharArray()), (h, e) => h.Intersect(e))
            .Single();
    }

    private static int ParseItemPriorityValue(char c)
    {
        return c < 'a' ? c - 'A' + 27 : c - 'a' + 1;
    }
}

internal static class Day03Extensions
{
    internal static IEnumerable<IEnumerable<string>> ChunkBackpackBy(this IEnumerable<string> backpacks,
        int count)
    {
        return backpacks.Select(backpack =>
            backpack.Chunk(backpack.Length / count).Select(compartment => string.Concat(compartment)));
    }

    internal static IEnumerable<IEnumerable<string>> GroupBackpacksBy(this IEnumerable<string> backpacks,
        int count)
    {
        var input = backpacks.ToArray();
        for (var backpack = 0; backpack < input.Length; backpack += count)
            yield return input.Skip(backpack).Take(count);
    }
}