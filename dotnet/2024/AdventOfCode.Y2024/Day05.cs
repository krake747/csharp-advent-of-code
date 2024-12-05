using AdventOfCode.Lib;

using PageOrderingRules = System.Collections.Generic.HashSet<string>;
using PageProductionUpdates = string[][];

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 5, "Print Queue", "C#")]
public sealed class Day05 : IAocDay<int>
{
    public static int Part1(AocInput input) => 
        input.Text
            .Pipe(Instructions)
            .Pipe(instructions =>
            {
                var (pageOrderingRules, pageProductionUpdates) = instructions;
                var comparer = Comparer<string>.Create((p1, p2) => pageOrderingRules.Contains($"{p1}|{p2}") ? -1 : 1);
                return pageProductionUpdates
                    .Where(pages => pages.SequenceEqual(pages.OrderBy(p => p, comparer)))
                    .Sum(pages => int.Parse(pages[pages.Length / 2]));
            });

    public static int Part2(AocInput input) => 
        input.Text
            .Pipe(Instructions)
            .Pipe(instructions =>
            {
                var (pageOrderingRules, pageProductionUpdates) = instructions;
                var comparer = Comparer<string>.Create((p1, p2) => pageOrderingRules.Contains($"{p1}|{p2}") ? -1 : 1);
                return pageProductionUpdates
                    .Where(pages => pages.SequenceEqual(pages.OrderBy(p => p, comparer)) is false)
                    .Select(pages => pages.OrderBy(p => p, comparer).ToArray())
                    .Sum(pages => int.Parse(pages[pages.Length / 2]));
            });

    private static (PageOrderingRules, PageProductionUpdates) Instructions(string text)
    {
        var parts = text.Split("\n\n");
        var pageOrderingRules = parts[0].Split('\n').ToHashSet();
        var pageProductionUpdates = parts[1].Split('\n').Select(u => u.Split(',')).ToArray();
        return (pageOrderingRules, pageProductionUpdates);
    }
}