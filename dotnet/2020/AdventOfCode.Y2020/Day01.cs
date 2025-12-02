using AdventOfCode.Lib;

namespace AdventOfCode.Y2020;

public sealed class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        input.Lines.Select(int.Parse).ToArray()
        | (numbers => (
                from i in numbers
                from j in numbers
                select new[] { i, j }
            )
            .First(n => n.Sum() is 2020)
            .Aggregate((i, j) => i * j)
        );

    public static int Part2(AocInput input) =>
        input.Lines.Select(int.Parse).ToArray()
        | (numbers => (
                from i in numbers
                from j in numbers
                from k in numbers
                select new[] { i, j, k }
            )
            .First(n => n.Sum() is 2020)
            .Aggregate((i, j) => i * j)
        );
}