using AdventOfCode.Lib;

namespace AdventOfCode.Y2022;

[AocPuzzle(2022, 1, "The Tyranny of the Rocket Equation")]
public sealed class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        TotalCaloriesPerElf(input.Text)
            .Max();

    public static int Part2(AocInput input) =>
        TotalCaloriesPerElf(input.Text)
            .OrderDescending()
            .Take(3)
            .Sum();

    private static IEnumerable<int> TotalCaloriesPerElf(string calories)
    {
        return calories.Split("\n\n")
            .Select(inventory => inventory.Split("\n")
                .Select(int.Parse)
                .Sum());
    }
}