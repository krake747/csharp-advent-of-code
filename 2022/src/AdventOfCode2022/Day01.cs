using System.Collections.Immutable;
using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day01 : IDay
{
    public int Part1(IEnumerable<string> input)
    {
        var values = input.ToArray();
        return values.WithIndex()
            .Aggregate(ImmutableList<int>.Empty, (elves, value) => 
                elves.AddRange(SumUpCalories(values, value)))
            .Max();
    } 

    public int Part2(IEnumerable<string> input)
    {
        return 1;
    }

    private static ImmutableList<int> SumUpCalories(string[] values, (string item, int index) value)
    {
        return value.item == ""
            ? ImmutableList.Create(values[..value.index].Reverse()
                .TakeWhile(v => !string.IsNullOrWhiteSpace(v))
                .Sum(int.Parse))
            : ImmutableList<int>.Empty;
    }
}