using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2023;

[AocPuzzle(2023, 2, "Cube Conundrum")]
public sealed partial class Day02 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Lines.Sum(PlayGame1);

    public static int Part2(AocInput input) => input.Lines.Sum(PlayGame2);

    private static int PlayGame1(string game) =>
        CountCubesInBag(game).Pipe(bag => bag is { Red: <= 12, Green: <= 13, Blue: <= 14 } ? bag.Id : 0);

    private static int PlayGame2(string game) =>
        CountCubesInBag(game).Pipe(bag => bag.Red * bag.Green * bag.Blue);

    private static Bag CountCubesInBag(string game)
    {
        var id = GameId(game);
        var red = CountCubes(game, RedCubesRegex());
        var green = CountCubes(game, GreenCubesRegex());
        var blue = CountCubes(game, BlueCubesRegex());
        return new Bag(id, red, green, blue);
    }

    private static int GameId(string game) =>
        int.Parse(GameIdRegex().Match(game).Groups[1].Value);

    private static int CountCubes(string game, Regex regex) =>
        regex.Matches(game).Max(m => int.Parse(m.Groups[1].Value));

    [GeneratedRegex(@"Game (\d+)", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex GameIdRegex();

    [GeneratedRegex(@"(\d+) red", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex RedCubesRegex();

    [GeneratedRegex(@"(\d+) green", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex GreenCubesRegex();

    [GeneratedRegex(@"(\d+) blue", RegexOptions.Compiled | RegexOptions.NonBacktracking)]
    private static partial Regex BlueCubesRegex();

    private readonly record struct Bag(int Id, int Red, int Green, int Blue);
}