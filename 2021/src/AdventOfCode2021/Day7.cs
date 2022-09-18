namespace AdventOfCode2021;

public static class Day7
{
    /// <summary>
    /// How much fuel must they spend to align to that position? (using least possible fuel)
    /// </summary>
    public static int Part1(IEnumerable<string> input)
    {
        return LeastFuel(input);
    }

    public static int Part2(IEnumerable<string> input)
    {
        return 1;
    }

    public static int LeastFuel(IEnumerable<string> input)
    {
        var positions = input.SelectMany(i => i.Split(','))
            .Select(int.Parse);

        var leastFuelConsumption = Enumerable.Range(0, positions.Max())
            .Select(pos => positions.Select(p => Math.Abs(p - pos)).Sum())
            .Min();

        return leastFuelConsumption;
    }
}
