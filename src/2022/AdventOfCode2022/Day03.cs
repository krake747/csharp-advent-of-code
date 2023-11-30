using System.Collections.Immutable;
using AdventOfCodeLib;

namespace AdventOfCode2022;

public sealed class Day03 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Lines
        .ChunkBackpackBy(2)
        .Select(DistinctItemFromGroupOfBackpacks)
        .Sum(ParseItemPriorityValue);

    public static int Part2(AocInput input) => input.Lines
        .Chunk(3)
        .Select(DistinctItemFromGroupOfBackpacks)
        .Sum(ParseItemPriorityValue);

    private static char DistinctItemFromGroupOfBackpacks(IEnumerable<string> backpacks) =>
        backpacks.ToArray()
            .Pipe(input => input
                .Skip(1)
                .Aggregate(ImmutableHashSet.Create(input[0].ToCharArray()), (h, e) => h.Intersect(e))
                .Single());

    private static int ParseItemPriorityValue(char c) => c < 'a' ? c - 'A' + 27 : c - 'a' + 1;
}

internal static class Day03Extensions
{
    internal static IEnumerable<IEnumerable<string>> ChunkBackpackBy(this IEnumerable<string> backpacks, int count) =>
        backpacks
            .Select(backpack => backpack.Chunk(backpack.Length / count)
            .Select(compartment => string.Concat(compartment)));

    internal static IEnumerable<IEnumerable<string>> GroupBackpacksBy(this IEnumerable<string> backpacks,
        int count)
    {
        var input = backpacks.ToArray();
        for (var backpack = 0; backpack < input.Length; backpack += count)
        {
            yield return input.Skip(backpack).Take(count);
        }
    }
}