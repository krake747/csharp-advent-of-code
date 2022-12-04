using AdventOfCodeLib;

namespace AdventOfCode2020;

public class Day01 : IDay<IEnumerable<string>>
{
    public int Part1(IEnumerable<string> input)
    {
        var integers = input.Select(int.Parse).ToArray();
        return (from i in integers
                from j in integers
                select new[] { i, j })
            .First(n => n.Sum() == 2020)
            .Aggregate((i, j) => i * j);
    }

    public int Part2(IEnumerable<string> input)
    {
        var integers = input.Select(int.Parse).ToArray();
        return (from i in integers
                from j in integers
                from k in integers
                select new[] { i, j, k })
            .First(n => n.Sum() == 2020)
            .Aggregate((i, j) => i * j);
    }
}