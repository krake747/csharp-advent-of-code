using AdventOfCode.Lib;
using Pages = string[];
using PageUpdates = string[][];
using PagePrecedenceRules = System.Collections.Generic.Comparer<string>;

namespace AdventOfCode.Y2024;

[AocPuzzle(2024, 5, "Print Queue", "C#")]
public sealed class Day05 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        input.Text
            .Pipe(SleighLaunchSafetyManual)
            .Pipe(manual => manual.Updates
                .Where(pages => ElfPageSorting(manual.PrecedenceRules, pages))
                .Sum(ExtractMiddlePage)
            );

    public static int Part2(AocInput input) =>
        input.Text
            .Pipe(SleighLaunchSafetyManual)
            .Pipe(manual => manual.Updates
                .Where(pages => ElfPageSorting(manual.PrecedenceRules, pages) is false)
                .Select(pages => pages.OrderBy(p => p, manual.PrecedenceRules).ToArray())
                .Sum(ExtractMiddlePage)
            );

    private static SafetyManual SleighLaunchSafetyManual(string text)
    {
        var parts = text.Split("\n\n");
        var ordering = parts[0].Split('\n').ToHashSet();
        var updates = parts[1].Split('\n').Select(u => u.Split(',')).ToArray();
        return new SafetyManual(
            updates,
            PagePrecedenceRules.Create((p1, p2) => ordering.Contains($"{p1}|{p2}") ? -1 : 1)
        );
    }

    private static bool ElfPageSorting(PagePrecedenceRules precedenceRules, Pages pages) =>
        pages.SequenceEqual(pages.OrderBy(p => p, precedenceRules));

    private static int ExtractMiddlePage(Pages pages) =>
        int.Parse(pages[pages.Length / 2]);

    private readonly record struct SafetyManual(PageUpdates Updates, PagePrecedenceRules PrecedenceRules);
}