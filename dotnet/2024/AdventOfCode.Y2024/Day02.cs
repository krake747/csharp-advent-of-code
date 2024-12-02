using AdventOfCode.Lib;
using Pair = (int Left, int Right);

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 2, "Red-Nosed Reports", "C#")]
public sealed class Day02 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        input.Lines
            .Pipe(lines => Instructions(lines).Count(Monotonic));

    public static int Part2(AocInput input) =>
        input.Lines
            .Pipe(lines => Instructions(lines).Count(instructions => ProblemDampener(instructions).Any(Monotonic)));

    private static bool Monotonic(int[] instructions) =>
        instructions.Zip(instructions.Skip(1), (l, r) => new Pair(l, r))
            .ToArray()
            .Pipe(pairs => MonotonicIncreasing(pairs) || MonotonicDecreasing(pairs));

    private static bool MonotonicIncreasing(Pair[] pairs) =>
        pairs.All(p => p.Right - p.Left is >= 1 and <= 3);

    private static bool MonotonicDecreasing(Pair[] pairs) =>
        pairs.All(p => p.Left - p.Right is >= 1 and <= 3);

    private static IEnumerable<int[]> ProblemDampener(int[] instructions) =>
        from i in Enumerable.Range(0, instructions.Length + 1)
        let take = instructions[..Math.Max(0, i - 1)]
        let skip = instructions[i..]
        select (int[]) [..take, ..skip];

    private static IEnumerable<int[]> Instructions(IEnumerable<string> lines) =>
        lines.Select(l => l.Split(' ').Select(int.Parse).ToArray());
}