using AdventOfCodeLib;

namespace AdventOfCode2021;

public static class Day1
{
    /// <summary>
    ///     Count the number of times a depth measurement increases the previous measurement.
    /// </summary>
    public static int Part1(IEnumerable<int> input)
    {
        var values = input.ToArray();
        return values.Skip(1)
            .Zip(values, (curr, prev) => curr > prev ? 1 : 0)
            .Sum();
    }

    /// <summary>
    ///     Count the number of times the sum of measurements in this sliding window increases from the previous sum.
    /// </summary>
    public static int Part2(IEnumerable<int> input)
    {
        var rollingSums = input.RollingSum(3);

        return Part1(rollingSums);
    }
}