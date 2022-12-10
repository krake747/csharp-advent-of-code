using System.Diagnostics;
using AdventOfCodeLib;
using AdventOfCodeLib.Interfaces;
// ReSharper disable StringLiteralTypo

namespace AdventOfCode2022;

[AocPuzzle(2022, 10, "Cathode-Ray Tube")]
public class Day10 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        var cycles = ArithmeticSequence(20, 40, 6).ToArray();
        return ProcessSignals(input).Where(signal => cycles.Contains(signal.Cycle))
            .Sum(signal => signal.Cycle * signal.X);
    }

    private static IEnumerable<(int Cycle, int X)> ProcessSignals(IEnumerable<string> input)
    {
        var (cycle, x) = (1, 1);
        foreach (var line in input)
        {
            var instruction = line.Split(' ');
            switch (instruction)
            {
                case ["noop"]:
                    yield return (cycle++, x);
                    break;
                case ["addx", var value]:
                    yield return (cycle++, x);
                    yield return (cycle++, x);
                    x += int.Parse(value);
                    break;
                default:
                    throw new UnreachableException($"Instruction is not defined: {line}");
            }
        }
    }

    public int Part2(IEnumerable<string> input)
    {
        return 1;
    }
    
    private static IEnumerable<int> ArithmeticSequence(int n1, int f, int n)
    {
        for (var i = 0; i < n; i++) yield return n1 + f * i;
    }
}