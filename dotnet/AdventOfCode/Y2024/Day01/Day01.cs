using AdventOfCode.Lib;

namespace AdventOfCode.Y2024.Day01;

[AocPuzzle(2024, 1, "Historian Hysteria", "C#")]
public sealed class Solution : IAocSolver
{
    public object PartOne(AocInput input) => input.AllLines
        .Pipe(lines =>
        {
            var left = Instructions(lines, 0);
            var right = Instructions(lines, 1);
            return left.Zip(right, (l, r) => Math.Abs(l - r)).Sum();
        });

    public object PartTwo(AocInput input)  => input.AllLines
        .Pipe(lines =>
        {
            var left = Instructions(lines, 0);
            var counts = Instructions(lines, 1).CountBy(i => i).ToDictionary();
            return left.Sum(id => counts.GetValueOrDefault(id) * id);
        });
    
    private static IEnumerable<int> Instructions(IEnumerable<string> lines, int col) =>
        from line in lines
        let nums = line.Split("   ").Select(int.Parse).ToArray()
        orderby nums[col]
        select nums[col];
}