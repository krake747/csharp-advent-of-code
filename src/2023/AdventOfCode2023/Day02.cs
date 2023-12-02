using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 2, "Cube Conundrum")]
public sealed partial class Day02 : IAocDay<int>
{
    private static readonly char[] Separators = [':', ';'];

    public static int Part1(AocInput input) => input.Lines
        .Select(l => l.Split(Separators, StringSplitOptions.TrimEntries))
        .Sum(game =>
        {
            var id = int.Parse(game[0].Split(' ')[^1]);
            var cubes = game[1..];
            var shown = cubes.Aggregate(new List<bool>(), (rounds, reveal) =>
            {
                var bag = CubeSetRegex().Matches(reveal)
                    .Select(m => (Count: m.Groups[1].Value, Color: m.Groups[2].Value))
                    .Aggregate(new Dictionary<string, int> { { "red", 0 }, { "blue", 0 }, { "green", 0 } }, 
                        (b, x) =>
                        {
                            b[x.Color] += int.Parse(x.Count);
                            return b;
                        });

                var possible = bag["red"] <= 12 && bag["green"] <= 13 && bag["blue"] <= 14;
                rounds.Add(possible);
                return rounds;
            });

            return shown.All(possible => possible) ? id : 0;
        });

    public static int Part2(AocInput input) => input.Lines
        .Select(l => l.Split(Separators, StringSplitOptions.TrimEntries))
        .Sum(game =>
        {
            var cubes = game[1..];
            var shown = cubes.Aggregate(new Dictionary<string, int> { { "red", 0 }, { "blue", 0 }, { "green", 0 } },
                (bag, reveal) => CubeSetRegex().Matches(reveal)
                    .Select(m => (Count: m.Groups[1].Value, Color: m.Groups[2].Value))
                    .Aggregate(bag, (b, x) =>
                    {
                        b[x.Color] = Math.Max(int.Parse(x.Count), b[x.Color]);
                        return b;
                    }));

            return shown["red"] * shown["green"] * shown["blue"];
        });


    [GeneratedRegex(@"(\d+) (\w+)", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex CubeSetRegex();
}