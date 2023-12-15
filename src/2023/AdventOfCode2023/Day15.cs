using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 15, "Lens Library")]
public sealed class Day15 : IAocDay<int>
{
    public static int Part1(AocInput input) => 
        input.Text.Split(',').Sum(Hash);

    public static int Part2(AocInput input) => 0;

    private static int Hash(string input) => input.Aggregate(0, (seed, c) => (seed + c) * 17 % 256);
}