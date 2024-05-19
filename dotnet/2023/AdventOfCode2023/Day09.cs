using AdventOfCode.Lib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 9, "Mirage Maintenance")]
public sealed class Day09 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        ParseOasisReport(input.Lines)
            .Sum(Extrapolate);

    public static int Part2(AocInput input) =>
        ParseOasisReport(input.Lines)
            .Sum(seq => Extrapolate(seq.Reverse().ToArray()));

    public static int Part1A(AocInput input) =>
        ParseOasisReport(input.Lines)
            .Sum(seq => Extrapolate(Forward, seq, ^1));

    public static int Part2A(AocInput input) =>
        ParseOasisReport(input.Lines)
            .Sum(seq => Extrapolate(Backward, seq, 0));

    // Recursive approach
    private static int Extrapolate(int[] sequence) =>
        sequence.Length is 0 ? 0 : Extrapolate(sequence.Zip(sequence[1..], Forward).ToArray()) + sequence.Last();

    // Original approach
    private static int Extrapolate(Func<int, int, int> func, int[] sequence, Index i)
    {
        var curr = sequence;
        var sum = curr[i];
        while (curr.All(x => x is 0) is false)
        {
            curr = curr.Zip(curr[1..], func).ToArray();
            sum += curr[i];
        }

        return sum;
    }

    private static IEnumerable<int[]> ParseOasisReport(IEnumerable<string> lines) =>
        lines.Select(l => l.Split(' ').Select(int.Parse).ToArray());

    private static int Forward(int x1, int x2) => x2 - x1;

    private static int Backward(int x1, int x2) => x1 - x2;
}