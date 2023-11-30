using AdventOfCodeLib;

namespace AdventOfCode2020;

public sealed class Day02 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Lines
        .Select(ParseLine)
        .Select(CreatePasswordPolicy)
        .Count(IsPasswordPolicyValid);

    public static int Part2(AocInput input) => input.Lines
        .Select(ParseLine)
        .Select(CreatePasswordPolicy)
        .Count(IsNewPasswordPolicyValid);
    
    private static IEnumerable<string> ParseLine(string line) => 
        line.Split(Separators, StringSplitOptions.TrimEntries);

    private static PasswordPolicy CreatePasswordPolicy(IEnumerable<string> segments)
    {
        var parts = segments.ToArray();
        return new PasswordPolicy(int.Parse(parts[0]), int.Parse(parts[1]), char.Parse(parts[2]), parts[3]);
    }

    private static bool IsPasswordPolicyValid(PasswordPolicy passwordPolicy)
    {
        var countLetter = passwordPolicy.Password.Count(c => c == passwordPolicy.Letter);
        return passwordPolicy.Min <= countLetter && countLetter <= passwordPolicy.Max;
    }

    private static bool IsNewPasswordPolicyValid(PasswordPolicy passwordPolicy)
    {
        var firstElement = passwordPolicy.Password[passwordPolicy.Min - 1];
        var secondElement = passwordPolicy.Password[passwordPolicy.Max - 1];
        return new[] { firstElement, secondElement }
            .Count(m => m == passwordPolicy.Letter) is 1;
    }

    private static readonly string[] Separators = ["-", " ", ": "];

    private sealed record PasswordPolicy(int Min, int Max, char Letter, string Password);
}