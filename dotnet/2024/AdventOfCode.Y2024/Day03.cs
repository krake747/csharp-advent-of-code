using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 3, "Mull It Over", "C#")]
public sealed class Day03 : IAocDay<long>
{
    public static long Part1(AocInput input) => input.Text
        .Pipe(
            text => Regex.Matches(text, @"mul\((\d+),(\d+)\)")
                .Sum(m => int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value))
        );

    public static long Part2(AocInput input) => input.Text
        .Pipe(
            text => Regex.Matches(text, @"do\(\)|don't\(\)|mul\((\d+),(\d+)\)")
                .Aggregate(new State(true, 0), (state, m) => m.Value switch
                {
                    "do()" => state with { Enabled = true },
                    "don't()" => state with { Enabled = false },
                    _ => state.Enabled
                        ? state with
                        {
                            Result = state.Result + int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value)
                        }
                        : state
                }).Result
        );

    private readonly record struct State(bool Enabled, long Result);
}