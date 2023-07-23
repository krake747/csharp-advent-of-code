using System.Text.RegularExpressions;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2020;

public class Day04 : IDay<string, int>
{
    public int Part1(string input)
    {
        return CreatePassports(input)
            .Count(passport => AreAllKeysPresent(passport) || OptionalCountryId(passport));
    }

    public int Part2(string input) =>
        CreatePassports(input)
            .Count(AreAllPassportValuesValid);

    private static bool AreAllPassportValuesValid(IDictionary<string, string> passport) =>
        IsValidBirthYear(passport) &&
        IsValidIssueYear(passport) &&
        IsValidExpirationYear(passport) &&
        IsValidHeight(passport) &&
        IsValidHairColor(passport) &&
        IsValidEyeColor(passport) &&
        IsValidPassportId(passport);

    private static IEnumerable<Dictionary<string, string>> CreatePassports(string input)
    {
        return input.Split("\n\n")
            .Select(str => str.Split(' ', '\n').Select(s => s.Split(':')).ToDictionary(k => k.First(), v => v.Last()));
    }

    private static bool AreAllKeysPresent(IDictionary<string, string> passport) => passport.Keys.Count >= 8;

    private static bool OptionalCountryId(IDictionary<string, string> passport) =>
        passport.Keys.Count >= 7 && !passport.Keys.Contains("cid");

    private static bool IsValidBirthYear(IDictionary<string, string> passport) =>
        passport.TryGetValue("byr", out var result) && int.Parse(result) is >= 1920 and <= 2002;

    private static bool IsValidIssueYear(IDictionary<string, string> passport) =>
        passport.TryGetValue("iyr", out var result) && int.Parse(result) is >= 2010 and <= 2020;

    private static bool IsValidExpirationYear(IDictionary<string, string> passport) =>
        passport.TryGetValue("eyr", out var result) && int.Parse(result) is >= 2020 and <= 2030;

    private static bool IsValidHeight(IDictionary<string, string> passport)
    {
        var yes = passport.TryGetValue("hgt", out var result) && Regex.Match(result, @"(\d*)(cm|in)").Success;
        return yes && (int.Parse(result![..^2]), result[^2..]) switch
        {
            (var height, "cm") => height is >= 150 and <= 193,
            (var height, "in") => height is >= 59 and <= 76,
            (_, _) => false
        };
    }

    private static bool IsValidHairColor(IDictionary<string, string> passport) =>
        passport.TryGetValue("hcl", out var result) && Regex.Match(result, @"#([0-9a-f]){6}$").Success;

    private static bool IsValidEyeColor(IDictionary<string, string> passport)
    {
        return passport.TryGetValue("ecl", out var result) &&
               new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(result);
    }

    private static bool IsValidPassportId(IDictionary<string, string> passport) =>
        passport.TryGetValue("pid", out var result) && Regex.Match(result, @"^[0-9]{9}$").Success;
}