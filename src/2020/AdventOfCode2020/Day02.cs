using AdventOfCodeLib;

namespace AdventOfCode2020;

public class Day02 : IDay<IEnumerable<string>>
{
    public int Part1(IEnumerable<string> input)
    {
        return input.Select(ParseLine)
            .Select(CreatePasswordPolicy)
            .Count(IsPasswordPolicyValid);
    }

    public int Part2(IEnumerable<string> input)
    {
        return input.Select(ParseLine)
            .Select(CreatePasswordPolicy)
            .Count(IsNewPasswordPolicyValid);
    }

    private static IEnumerable<string> ParseLine(string line)
    {
        return line.Split(new[] { "-", " ", ": " }, StringSplitOptions.TrimEntries);
    }

    private static PasswordPolicy CreatePasswordPolicy(IEnumerable<string> segments)
    {
        var parts = segments as string[] ?? segments.ToArray();
        return new PasswordPolicy(int.Parse(parts[0]), int.Parse(parts[1]), char.Parse(parts[2]), parts[3]);
    }

    private static bool IsPasswordPolicyValid(PasswordPolicy passwordPolicy)
    {
        var countLetter = passwordPolicy.Password.Count(c => c == passwordPolicy.Letter);
        return passwordPolicy.Min <= countLetter && countLetter <= passwordPolicy.Max;
    }

    private static bool IsNewPasswordPolicyValid(PasswordPolicy passwordPolicy)
    {
        var firstElement = passwordPolicy.Password.ElementAt(passwordPolicy.Min - 1);
        var secondElement = passwordPolicy.Password.ElementAt(passwordPolicy.Max - 1);
        return new[] { firstElement, secondElement }
            .Count(m => m == passwordPolicy.Letter) == 1;
    }

    private record PasswordPolicy(int Min, int Max, char Letter, string Password);
}