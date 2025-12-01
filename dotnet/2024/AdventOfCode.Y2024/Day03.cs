using System.Text.RegularExpressions;
using AdventOfCode.Lib;
using State = (bool Enabled, long Total);

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 3, "Mull It Over", "C#")]
public sealed partial class Day03 : IAocDay<long>
{
    public static long Part1(AocInput input) =>
        input.Text
        | (text => ComputerMemory().Matches(text).Sum(Instructions));

    public static long Part2(AocInput input) => 
        input.Text
        | (text => ComputerMemoryWithConditionals().Matches(text)
            .Aggregate(
                new State(true, 0),
                (state, m) => m.Value switch
                {
                    "do()" => state with { Enabled = true },
                    "don't()" => state with { Enabled = false },
                    _ when state.Enabled => state with
                    {
                        Total = state.Total + Instructions(m)
                    },
                    _ => state
                }
            )
        )
        | (state => state.Total);

    private static int Instructions(Match m) =>
        int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value);

    [GeneratedRegex(@"mul\((\d+),(\d+)\)", RegexOptions.Compiled)]
    private static partial Regex ComputerMemory();

    [GeneratedRegex(@"do\(\)|don't\(\)|mul\((\d+),(\d+)\)", RegexOptions.Compiled)]
    private static partial Regex ComputerMemoryWithConditionals();
}