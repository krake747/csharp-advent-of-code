namespace AdventOfCode2021;

public static class Day1
{
    /// <summary>
    /// Count the number of times a depth measurement increases the previous measurement.
    /// </summary>
    public static int Function(IEnumerable<int> input) =>
        input.Skip(1)
             .Zip(input, (curr, prev) => curr > prev ? 1 : 0)
             .Sum();
    
}
