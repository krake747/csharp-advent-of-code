using AdventOfCodeLib;

namespace AdventOfCode2020;

public class Day01 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        var numbers = input.Select(int.Parse).ToArray();
        return (from i in numbers
                from j in numbers
                select new[] { i, j })
            .First(n => n.Sum() == 2020)
            .Aggregate((i, j) => i * j);
    }

    public int Part2(IEnumerable<string> input)
    {
        var numbers = input.Select(int.Parse).ToArray();
        return (from i in numbers
                from j in numbers
                from k in numbers
                select new[] { i, j, k })
            .First(n => n.Sum() == 2020)
            .Aggregate((i, j) => i * j);
    }
}