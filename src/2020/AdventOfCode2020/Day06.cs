using System.Collections.Immutable;
using AdventOfCodeLib;

namespace AdventOfCode2020;

public class Day06 : IDay<string, int>
{
    public int Part1(string input)
    {
        return input.Split("\n\n")
            .Sum(groups => groups.Split("\n").SelectMany(answers => answers).Distinct().Count());
    }

    public int Part2(string input)
    {
        return input.Split("\n\n")
            .Select(groups => groups.Split("\n").Select(answers => answers).ToArray())
            .Sum(CountQuestionsWhereEveryoneAnsweredYes);
    }

    private static int CountQuestionsWhereEveryoneAnsweredYes(string[] answers)
    {
        return answers.Skip(1).Aggregate(ImmutableHashSet.Create(answers.First().ToCharArray()),
            (h, e) => h.Intersect(e)).Count;
    }
}