namespace AdventOfCode.Y2021;

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
        var rollingSums = RollingSum(input, 3);
        return Part1(rollingSums);
    }

    private static List<int> RollingSum(IEnumerable<int> source, int window)
    {
        var numbers = source.ToList();
        var rollingSums = new List<int>();

        if (numbers.Count < window)
        {
            return [];
        }

        Enumerable.Range(0, numbers.Count - window + 1)
            .ToList()
            .ForEach(n => rollingSums.Add(numbers.Skip(n).Take(window).Sum()));

        return rollingSums;
    }
}