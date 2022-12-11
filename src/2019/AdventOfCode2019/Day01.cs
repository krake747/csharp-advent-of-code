using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2019;

public class Day01 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        return input.Select(int.Parse)
            .Sum(Fuel);
    }

    public int Part2(IEnumerable<string> input)
    {
        return input.Select(int.Parse)
            .Sum(TotalFuel);
    }

    private static int Fuel(int mass)
    {
        // return (int)(Math.Floor(mass / 3.0) - 2);
        return mass / 3 - 2;
    }

    private static IEnumerable<int> FuelRequirements(int mass)
    {
        var fuel = Fuel(mass);
        while (true)
        {
            if (fuel < 0)
                yield break;
            
            yield return fuel;
            fuel = Fuel(fuel);
        }
    }
    
    private static int TotalFuel(int mass)
    {
        var fuel = Fuel(mass);
        return fuel switch
        {
            < 0 => 0,
            _ => fuel + TotalFuel(fuel)
        };
    }
}