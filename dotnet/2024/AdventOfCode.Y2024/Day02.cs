using AdventOfCode.Lib;

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 2, "Red-Nosed Reports", "C#")]
public sealed class Day02 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.AllLines
        .Pipe(lines =>
        {
            var instructions = lines.Select(l => l.Split(' ').Select(int.Parse).ToArray());
            var sum = 0;
            foreach (var instruction in instructions)
            {
                var pairs = instruction.Zip(instruction[1..], (l, r) => (l, r)).ToArray();
                var allDecreasing = pairs.All(t => t.l > t.r && Math.Abs(t.l - t.r) is 1 or 2 or 3);
                var allIncreasing = pairs.All(t => t.l < t.r && Math.Abs(t.l - t.r) is 1 or 2 or 3);

                if (allDecreasing || allIncreasing) sum += 1;
            }
            
            return sum;
        });

    public static int Part2(AocInput input) => 0;
}