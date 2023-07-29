using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 5, "Doesn't He Have Intern-Elves For This?")]
public sealed partial class Day05 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        input.Lines.Count(_ => AllValid(_, ContainsAtLeastThreeVowels, AppearsTwiceSubsequently,
            NotContainForbiddenPairs));

    public static int Part2(AocInput input) =>
        input.Lines.Count(_ => AllValid(_, PairOfAnyTwoSubsequentLetters,
            OneLetterBetweenPairSameTwoLetters));

    [GeneratedRegex("[aeiou]")]
    private static partial Regex Vowels();

    private static bool ContainsAtLeastThreeVowels(string s) => Vowels().Matches(s).Count > 2;


    [GeneratedRegex("(.)\\1")]
    private static partial Regex AnySubsequentLetter();

    private static bool AppearsTwiceSubsequently(string s) => AnySubsequentLetter().IsMatch(s);


    [GeneratedRegex("ab|cd|pq|xy")]
    private static partial Regex ForbiddenPairs();

    private static bool NotContainForbiddenPairs(string s) => ForbiddenPairs().IsMatch(s) is false;


    [GeneratedRegex("([a-z][a-z]).*\\1")]
    private static partial Regex PairOfAnySubsequentLetters();

    private static bool PairOfAnyTwoSubsequentLetters(string s) => PairOfAnySubsequentLetters().IsMatch(s);


    [GeneratedRegex("([a-z])[a-z]\\1")]
    private static partial Regex LetterBetweenPairAnyTwoSubsequentLetters();

    private static bool OneLetterBetweenPairSameTwoLetters(string s) =>
        LetterBetweenPairAnyTwoSubsequentLetters().IsMatch(s);

    private static bool AllValid(string source, params Func<string, bool>[] predicates) =>
        predicates.All(func => func(source));
}