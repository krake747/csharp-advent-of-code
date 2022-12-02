using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day01 : IDay<string>
{
    public int Part1(string input)
    {
        return TotalCaloriesPerElf(input)
            .Max();
    }

    public int Part2(string input)
    {
        return TotalCaloriesPerElf(input)
            .OrderDescending()
            .Take(3)
            .Sum();
    }

    private static IEnumerable<int> TotalCaloriesPerElf(string calories)
    {
        return calories.Split("\n\n")
            .Select(inventory => inventory.Split("\n")
                .Select(int.Parse)
                .Sum());
    }
}