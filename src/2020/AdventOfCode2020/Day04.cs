using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode2020;

public sealed partial class Day04 : IAocDay<int>
{
    public static int Part1(AocInput input) =>
        CreatePassports(input.Text)
            .Count(passport => AreAllKeysPresent(passport) || OptionalCountryId(passport));

    public static int Part2(AocInput input) =>
        CreatePassports(input.Text)
            .Count(AreAllPassportValuesValid);

    private static bool AreAllPassportValuesValid(Dictionary<string, string> passport) =>
        IsValidBirthYear(passport) &&
        IsValidIssueYear(passport) &&
        IsValidExpirationYear(passport) &&
        IsValidHeight(passport) &&
        IsValidHairColor(passport) &&
        IsValidEyeColor(passport) &&
        IsValidPassportId(passport);
    
    private static IEnumerable<Dictionary<string, string>> CreatePassports(string input) =>
        input.Split("\n\n")
            .Select(str => str
                .Split(Separators)
                .Select(s => s.Split(':'))
                .ToDictionary(k => k[0], v => v[^1]));

    private static bool AreAllKeysPresent(IDictionary<string, string> passport) => 
        passport.Keys.Count >= 8;

    private static bool OptionalCountryId(IDictionary<string, string> passport) =>
        passport.Keys.Count >= 7 && !passport.ContainsKey("cid");

    private static bool IsValidBirthYear(IReadOnlyDictionary<string, string> passport) =>
        passport.TryGetValue("byr", out var result) && int.Parse(result) is >= 1920 and <= 2002;

    private static bool IsValidIssueYear(IReadOnlyDictionary<string, string> passport) =>
        passport.TryGetValue("iyr", out var result) && int.Parse(result) is >= 2010 and <= 2020;

    private static bool IsValidExpirationYear(IReadOnlyDictionary<string, string> passport) =>
        passport.TryGetValue("eyr", out var result) && int.Parse(result) is >= 2020 and <= 2030;

    private static bool IsValidHeight(IReadOnlyDictionary<string, string> passport)
    {
        var yes = passport.TryGetValue("hgt", out var result) && HeightRegex().IsMatch(result);
        return yes && (int.Parse(result![..^2]), result[^2..]) switch
        {
            (var height, "cm") => height is >= 150 and <= 193,
            (var height, "in") => height is >= 59 and <= 76,
            (_, _) => false
        };
    }

    private static bool IsValidHairColor(IReadOnlyDictionary<string, string> passport) =>
        passport.TryGetValue("hcl", out var result) && HairColorRegex().IsMatch(result);

    private static bool IsValidEyeColor(IReadOnlyDictionary<string, string> passport) => 
        passport.TryGetValue("ecl", out var result) && SourceArray.Contains(result);

    private static bool IsValidPassportId(IReadOnlyDictionary<string, string> passport) =>
        passport.TryGetValue("pid", out var result) && PassportIdRegex().IsMatch(result);
    
    private static readonly char[] Separators = [' ', '\n'];
    
    private static readonly string[] SourceArray = ["amb", "blu", "brn", "gry", "grn", "hzl", "oth"];
    
    [GeneratedRegex(@"(\d*)(cm|in)")]
    private static partial Regex HeightRegex();
    
    [GeneratedRegex(@"^[0-9]{9}$")]
    private static partial Regex PassportIdRegex();
    
    [GeneratedRegex(@"#([0-9a-f]){6}$")]
    private static partial Regex HairColorRegex();
}