using System.Collections.Immutable;
using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day01 : IDay
{
    public int Part1(IEnumerable<string> input)
    {
        var values = input.ToArray();
        return CreateElves(values)
            .Max();
    }
    
    public int Part2(IEnumerable<string> input)
    {
        var values = input.ToArray();
        return CreateElves(values)
            .OrderDescending()
            .Take(3)
            .Sum();
    }
    
    private static ImmutableList<int> CreateElves(string[] values)
    {
        return MakeElvesFromCalories(CumulativeCalories(values));
    }
    
    private static ImmutableList<int> CumulativeCalories(string[] values)
    {
        return values.WithIndex()
            .Aggregate(ImmutableList<int>.Empty, (elves, value) => elves.AddRange(SumCalories(values, value)));
    }
    
    private static ImmutableList<int> MakeElvesFromCalories(ImmutableList<int> calories)
    {
        return calories.Skip(1).Zip(calories, (curr, prev) => (curr, prev) switch
            {
                (0, _) => prev,
                (_, 0) => curr == calories.Last() ? curr : 0,
                _ => 0
            })
            .Where(n => n != 0)
            .ToImmutableList();
    }
    
    private static ImmutableList<int> SumCalories(string[] values, (string item, int index) value)
    {
        return ImmutableList.Create(values[..(value.index + 1)].Reverse()
                .TakeWhile(v => !string.IsNullOrWhiteSpace(v))
                .Sum(int.Parse));
    }
}

internal static class Day01Extensions
{

}