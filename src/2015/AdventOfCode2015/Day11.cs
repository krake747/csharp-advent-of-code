using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 11, "Corporate Policy")]
public sealed partial class Day11 : IAocDay<string>
{
    public static string Part1(AocInput input) => CreateNewPassword(input.Text);

    public static string Part2(AocInput input) => CreateNewPassword(CreateNewPassword(input.Text));

    private static string CreateNewPassword(string input)
    {
        var alphabet = string.Join("", Enumerable.Range('a', 26).Select(x => (char)x));
        var chunks = alphabet.Zip(alphabet.Skip(1), alphabet.Skip(2))
            .Select(x => $"{x.First}{x.Second}{x.Third}")
            .ToArray();

        var password = input.ToCharArray();
        var endPassword = new string('z', password.Length);
        var i = password.Length - 1;
        var newPasswordFound = false;
        while (newPasswordFound is false && password.Equals(endPassword) is false)
        {
            if (password[i] < 'z')
            {
                password[i]++;
            }
            else
            {
                while (i > 0 && password[i - 1] is 'z')
                {
                    password[i] = 'a';
                    i--;
                }

                if (i is 0 && password[i] is 'z')
                {
                    break;
                }

                password[i] = 'a';
                password[i - 1]++;
                i = password.Length - 1;
            }

            if (AllValid(password, NoUnreadableLetters, IncreasingCondition(chunks), TwoLetterPairs))
            {
                newPasswordFound = true;
            }
        }

        return new string(password);
    }

    private static bool NoUnreadableLetters(char[] password) =>
        UnreadableLetters().IsMatch(new string(password)) is false;

    private static Func<char[], bool> IncreasingCondition(IEnumerable<string> chunks) =>
        password => chunks.Any(new string(password).Contains);

    private static bool TwoLetterPairs(char[] password) =>
        AppearsTwice().Matches(new string(password)).Count > 1;

    private static bool AllValid(char[] source, params Func<char[], bool>[] predicates) =>
        predicates.All(f => f(source));

    [GeneratedRegex(@"[iol]")]
    private static partial Regex UnreadableLetters();

    [GeneratedRegex(@"(.)\1")]
    private static partial Regex AppearsTwice();
}