using AdventOfCode.Lib;

namespace AdventOfCode.Y2019;

[AocPuzzle(2019, 4, "Secure Container")]
public sealed class Day04 : IAocDay<int>
{
    public static int Part1(AocInput input)
    {
        var parts = input.Text.Split('-', 2);
        var (lower, upper) = (int.Parse(parts[0]), int.Parse(parts[1]));
        return Enumerable
            .Range(lower, upper - lower + 1)
            .Count(pw => AllValid($"{pw}", SixDigits, Increasing, PotentialDouble));
    }

    public static int Part2(AocInput input)
    {
        var parts = input.Text.Split('-', 2);
        var (lower, upper) = (int.Parse(parts[0]), int.Parse(parts[1]));
        return Enumerable
            .Range(lower, upper - lower + 1)
            .Count(pw => AllValid($"{pw}", SixDigits, Increasing, ExactDouble));
    }

    private static bool SixDigits(string password) =>
        password.Length is 6;

    private static bool Increasing(string password) =>
        password.Zip(password[1..]).Any(x => x.First > x.Second) is false;

    private static bool PotentialDouble(string password) =>
        password.GroupBy(g => g).ToDictionary(k => k.Key, v => v.Count()).Values.Any(c => c >= 2);

    private static bool ExactDouble(string password) =>
        password.GroupBy(g => g).ToDictionary(k => k.Key, v => v.Count()).Values.Any(c => c is 2);

    private static bool AllValid(string password, params Func<string, bool>[] funcs) =>
        funcs.All(f => f(password));
}