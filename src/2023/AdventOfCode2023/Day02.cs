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
                var bag = new Dictionary<string, int> { { "red", 0 }, { "blue", 0 }, { "green", 0 } };
                var mc = CubeSetRegex().Matches(reveal).ToArray();
                foreach (var m in mc)
                {
                    var count = m.Groups[1].Value;
                    var color = m.Groups[2].Value;
                    bag[color] += int.Parse(count);
                }

                var possible = bag["red"] <= 12 && bag["green"] <= 13 && bag["blue"] <= 14;
                rounds.Add(possible);
                return rounds;
            });

            return shown.All(possible => possible) ? id : 0;
        });

    public static int Part2(AocInput input) => 0;


    [GeneratedRegex(@"(\d+)\s(red|blue|green)", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex CubeSetRegex();
}