using System.Collections.Immutable;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2020;

public class Day06 : IDay<string, int>
{
    public int Part1(string input)
    {
        return input.Split("\n\n")
            .Select(groups => groups.Split("\n").Select(answers => answers))
            .Sum(answers => answers.ToWhichYesWasAnsweredBy(Anyone).Count);
    }

    public int Part2(string input)
    {
        return input.Split("\n\n")
            .Select(groups => groups.Split("\n").Select(answers => answers))
            .Sum(answers => answers.ToWhichYesWasAnsweredBy(Everyone).Count);
    }

    private static ImmutableHashSet<char> Anyone(ImmutableHashSet<char> hashSet, string s) => hashSet.Union(s);

    private static ImmutableHashSet<char> Everyone(ImmutableHashSet<char> hashSet, string s) => hashSet.Intersect(s);
}

internal static class Day04Extensions
{
    internal static ImmutableHashSet<char> ToWhichYesWasAnsweredBy(this IEnumerable<string> source,
        Func<ImmutableHashSet<char>, string, ImmutableHashSet<char>> func)
    {
        var answers = source as string[] ?? source.ToArray();
        return answers.Skip(1).Aggregate(ImmutableHashSet.Create(answers.First().ToCharArray()), func);
    }
}