using AdventOfCode.Lib;

namespace AdventOfCode.Y2019;

[AocPuzzle(2019, 2, "1202 Program Alarm")]
public sealed class Day02 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Text
        .Pipe(IntCodeMachine.Init)
        .Pipe(icm => IntCodeMachine.Run(icm, noun: 12, verb: 2));

    public static int Part2(AocInput input) => input.Text
        .Pipe(IntCodeMachine.Init)
        .Pipe(icm => IntCodeMachine.GravityAssist(icm, nouns: 100, verbs: 100));
}