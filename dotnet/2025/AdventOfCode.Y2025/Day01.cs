using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2025;

[AocPuzzle(2025, 1, "Secret Entrance", "C#")]
public sealed partial class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) => 
        input.Lines
            .Select(x => RotationsRegex().Match(x))
            .Select(Instruction)
            .Aggregate(new State(0, 50), (acc, instruction) =>
            {
                var newState = instruction.Turn switch
                {
                    "L" => acc with { Value = (acc.Value - instruction.Amount + 100) % 100 },
                    "R" => acc with { Value = (acc.Value + instruction.Amount + 100) % 100 },
                    _ => acc
                };

                return newState.Value switch
                {
                    0 => newState with { Count = newState.Count + 1 },
                    _ => newState
                };
            })
            .Count;

    public static int Part2(AocInput input) => 0;

    private static (string Turn, int Amount) Instruction(Match m) =>
        (
            Turn: m.Groups[1].Value, 
            Amount: int.Parse(m.Groups[2].Value)
        );

    private record struct State(int Count, int Value);
    
    [GeneratedRegex(@"(L|R)(\d*)", RegexOptions.Compiled)]
    private static partial Regex RotationsRegex();
}