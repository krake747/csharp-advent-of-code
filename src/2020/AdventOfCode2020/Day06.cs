using System.Collections.Immutable;
using AdventOfCode.Lib;

namespace AdventOfCode2020;

public sealed class Day06 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Text
        .Split("\n\n")
        .Select(groups => groups.Split("\n").Select(answers => answers))
        .Sum(answers => answers.ToWhichYesWasAnsweredBy(Anyone).Count);

    public static int Part2(AocInput input) => input.Text
        .Split("\n\n")
        .Select(groups => groups.Split("\n").Select(answers => answers))
        .Sum(answers => answers.ToWhichYesWasAnsweredBy(Everyone).Count);

    private static ImmutableHashSet<char> Anyone(ImmutableHashSet<char> hashSet, string s) => hashSet.Union(s);

    private static ImmutableHashSet<char> Everyone(ImmutableHashSet<char> hashSet, string s) => hashSet.Intersect(s);
}

internal static class Day04Extensions
{
    internal static ImmutableHashSet<char> ToWhichYesWasAnsweredBy(this IEnumerable<string> source,
        Func<ImmutableHashSet<char>, string, ImmutableHashSet<char>> func) => 
        source.ToArray()
            .Pipe(answers => answers.Skip(1)
                .Aggregate(ImmutableHashSet.Create(answers[0].ToCharArray()), func));
}