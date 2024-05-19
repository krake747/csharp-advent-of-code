using System.Diagnostics;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2022;

[AocPuzzle(2022, 10, "Cathode-Ray Tube")]
public sealed class Day10 : IAocDay<int, string>
{
    public static int Part1(AocInput input)
    {
        var cycles = ArithmeticSequence(20, 40, 6).ToArray();
        return ProcessSignals(input.Lines)
            .Where(signal => cycles.Contains(signal.Cycle))
            .Sum(s => s.Cycle * s.X);
    }

    public static string Part2(AocInput input)
    {
        var signals = ProcessSignals(input.Lines).Chunk(40).ToArray();
        var screenRows = new List<string>();
        foreach (var signal in signals)
        {
            var row = "";
            for (var pixel = 0; pixel < signal.Length; pixel++)
            {
                var (_, sprite) = signal[pixel];
                var isSpriteVisible = Math.Abs(sprite - pixel) <= 1;
                row += isSpriteVisible ? '#' : '.';
            }

            screenRows.Add(row);
        }

        var screen = string.Join("\n", screenRows);
        return screen;
    }


    private static IEnumerable<(int Cycle, int X)> ProcessSignals(IEnumerable<string> input)
    {
        var (cycle, x) = (1, 1);
        foreach (var line in input)
        {
            switch (line.Split(' '))
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

    private static IEnumerable<int> ArithmeticSequence(int n1, int f, int n)
    {
        for (var i = 0; i < n; i++)
        {
            yield return n1 + f * i;
        }
    }
}