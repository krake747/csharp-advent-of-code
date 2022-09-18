namespace AdventOfCode2021;

public static class Day7
{
    /// <summary>
    /// How much fuel must they spend to align to that position? (using least possible fuel)
    /// </summary>
    public static int Part1(IEnumerable<string> input)
    {
        return LeastFuelConstantRate(input);
    }

    public static int Part2(IEnumerable<string> input)
    {
        return LeastFuelVariableRate(input);
    }

    public static int LeastFuelConstantRate(IEnumerable<string> input)
    {
        var positions = input.SelectMany(i => i.Split(','))
            .Select(int.Parse);

        var leastFuelConsumption = Enumerable.Range(0, positions.Max())
            .Min(pos => positions.Sum(p => Math.Abs(p - pos)));

        return leastFuelConsumption;
    }

    public static int LeastFuelVariableRate(IEnumerable<string> input)
    {
        var positions = input.SelectMany(i => i.Split(','))
            .Select(int.Parse);

        var leastFuelConsumption = Enumerable.Range(0, positions.Max())
            .Min(pos => positions.Select(p => Math.Abs(p - pos)).Sum(n => n * (n + 1) / 2));

        return leastFuelConsumption;
    }
}
