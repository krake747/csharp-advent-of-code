using AdventOfCode.Lib;

namespace AdventOfCode.Y2019;

[AocPuzzle(2019, 5, "Sunny with a Chance of Asteroids")]
public sealed class Day05 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Text
        .Pipe(IntCodeMachine.Init)
        .Pipe(icm => IntCodeMachine.ThermalEnvironmentSupervisionTerminal(icm, 1));

    public static int Part2(AocInput input) => input.Text
        .Pipe(IntCodeMachine.Init)
        .Pipe(icm => IntCodeMachine.ThermalEnvironmentSupervisionTerminal(icm, 5));
}