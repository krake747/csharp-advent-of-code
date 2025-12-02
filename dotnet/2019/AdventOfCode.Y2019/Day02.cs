using AdventOfCode.Lib;

namespace AdventOfCode.Y2019;

[AocPuzzle(2019, 2, "1202 Program Alarm")]
public sealed class Day02 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        input.Text
        | IntCodeMachine.Init
        | (icm => IntCodeMachine.Run(icm, 12, 2));

    public static int Part2(AocInput input) =>
        input.Text
        | IntCodeMachine.Init
        | (icm => IntCodeMachine.GravityAssist(icm, 100, 100));
}