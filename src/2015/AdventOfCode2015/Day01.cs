using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 1, "Not Quite Lisp")]
public sealed class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        input.Text.Select(x => x is '(' ? 1 : -1).Sum();

    public static int Part2(AocInput input) => 2;
}