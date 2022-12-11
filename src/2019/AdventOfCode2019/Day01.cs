﻿using AdventOfCodeLib.Interfaces;

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
            .SelectMany(FuelRequirements)
            .Sum();
    }

    private static int Fuel(int mass)
    {
        return (int)(Math.Floor(mass / 3.0) - 2);
    }

    private static IEnumerable<int> FuelRequirements(int mass)
    {
        var totalFuel = Fuel(mass);
        while (true)
        {
            if (totalFuel <= 0)
                yield break;
            
            yield return totalFuel;
            totalFuel = Fuel(totalFuel);
        }
    }
}