using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 5, "Doesn't He Have Intern-Elves For This?")]
public sealed class Day05 : IAocDay<int>
{
    private const string Vowels = "aeiou";
    private static readonly string[] Pairs = { "ab", "cd", "pq", "xy" };

    public static int Part1(AocInput input) =>
        input.Lines.Count(_ => AllValid(_, ContainsAtLeastThreeVowels, AppearsTwiceSubsequently,
            NotContainForbiddenPairs));

    public static int Part2(AocInput input) => 0;

    private static bool ContainsAtLeastThreeVowels(string s) => s.Count(x => Vowels.Contains(x)) > 2;

    private static bool AppearsTwiceSubsequently(string s) => s.Any(x => s.Contains($"{x}{x}"));

    private static bool NotContainForbiddenPairs(string s) => !Pairs.Any(s.Contains);

    private static bool AllValid(string source, params Func<string, bool>[] predicates) => 
        predicates.All(func => func(source));
}