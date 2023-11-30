using AdventOfCodeLib;

namespace AdventOfCode2019;

public sealed class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        input.Lines
            .Select(int.Parse)
            .Sum(Fuel);

    public static int Part2(AocInput input) =>
        input.Lines
            .Select(int.Parse)
            .Sum(TotalFuel);

    private static int Fuel(int mass) => mass / 3 - 2; // => (int)(Math.Floor(mass / 3.0) - 2);

    private static IEnumerable<int> FuelRequirements(int mass)
    {
        var fuel = Fuel(mass);
        while (true)
        {
            if (fuel < 0)
            {
                yield break;
            }

            yield return fuel;
            fuel = Fuel(fuel);
        }
    }

    private static int TotalFuel(int mass)
    {
        var fuel = Fuel(mass);
        return fuel < 0 ? 0 : fuel + TotalFuel(fuel);
    }
}