using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day01 : IDay<IEnumerable<string>>
{
    public int Part1(IEnumerable<string> input)
    {
        return TotalCaloriesPerElf(input)
            .Max();
    }
    
    public int Part1(string input)
    {
        return TotalCaloriesPerElf(input)
            .Max();
    }

    public int Part2(IEnumerable<string> input)
    {
        return TotalCaloriesPerElf(input)
            .OrderDescending()
            .Take(3)
            .Sum();
    }

    private static IEnumerable<int> TotalCaloriesPerElf(IEnumerable<string> calories)
    {
        return string.Join("|", calories)
            .Split("||")
            .Select(inventory => inventory.Split("|")
                .Select(int.Parse)
                .Sum());
    }
    
    private static IEnumerable<int> TotalCaloriesPerElf(string calories)
    {
        return calories
            .Split("\n\n")
            .Select(inventory => inventory.Split("\n")
                .Select(int.Parse)
                .Sum());
    }
}