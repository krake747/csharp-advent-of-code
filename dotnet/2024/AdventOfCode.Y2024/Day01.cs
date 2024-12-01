using AdventOfCode.Lib;

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 1, "Historian Hysteria", "C#")]
public sealed class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.AllLines
        .Pipe(lines =>
        {
            var left = ParseInstructions(lines, 0);
            var right = ParseInstructions(lines, 1);
            return left.Order().Zip(right.Order(), (l, r) => Math.Abs(l - r)).Sum();
        });

    public static int Part2(AocInput input) => input.AllLines
        .Pipe(lines =>
        {
            var left = ParseInstructions(lines, 0);
            var counts = ParseInstructions(lines, 1).CountBy(i => i).ToDictionary();
            return left.Sum(id => counts.GetValueOrDefault(id) * id);
        });
    
    private static IEnumerable<int> ParseInstructions(IEnumerable<string> lines, int col) =>
        from line in lines
        let nums = line.Split("   ").Select(int.Parse).ToArray()
        orderby nums[col]
        select nums[col];
}