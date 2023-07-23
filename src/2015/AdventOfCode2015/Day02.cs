using AdventOfCodeLib;

namespace AdventOfCode2015;

[AocPuzzle(2015, 2, "I Was Told There Would Be No Math")]
public sealed class Day02 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Lines
        .Select(x => x.Split('x').Select(int.Parse).ToArray())
        .Sum(x => OrderWrappingPaper(x[0], x[1], x[2]));

    public static int Part2(AocInput input) => input.Lines
        .Select(x => x.Split('x').Select(int.Parse).ToArray())
        .Sum(x => OrderRibbon(x[0], x[1], x[2]));

    private static int OrderWrappingPaper(int length, int width, int height) =>
        CalculateSurface(length, width, height) + CalculateAreaOfSmallestSide(length, width, height);

    private static int OrderRibbon(int length, int width, int height) =>
        CalculateBow(length, width, height) + CalculatePerimeterOfSmallestSide(length, width, height);

    private static int CalculateSurface(int length, int width, int height) =>
        2 * length * width + 2 * width * height + 2 * height * length;

    private static int CalculateAreaOfSmallestSide(int length, int width, int height) =>
        new[] { length * width, width * height, height * length }.Min();

    private static int CalculateBow(int length, int width, int height) =>
        length * width * height;

    private static int CalculatePerimeterOfSmallestSide(int length, int width, int height) =>
        new[] { 2 * length + 2 * width, 2 * width + 2 * height, 2 * height + 2 * length }.Min();
}