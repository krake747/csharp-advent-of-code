using AdventOfCodeLib;

namespace AdventOfCode2016;

[AocPuzzle(2016, 1, "No Time for a Taxicab")]
public sealed class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Text
        .Split(',', StringSplitOptions.TrimEntries)
        .Select(ParseInstructions)
        .ToArray()
        .Aggregate((new Coordinate(0, 0), Direction.North), (seed, move) =>
        {
            var (coordinate, direction) = seed;
            var intDirection = ((move.Turn == 'R' ? 1 : -1) + (int)direction + 4) % 4;
            var newDirection = (Direction)intDirection;
            return newDirection switch
            {
                Direction.North => (coordinate with { X = coordinate.X + move.Blocks }, newDirection),
                Direction.East => (coordinate with { Y = coordinate.Y - move.Blocks }, newDirection),
                Direction.South => (coordinate with { X = coordinate.X - move.Blocks }, newDirection),
                Direction.West => (coordinate with { Y = coordinate.Y + move.Blocks }, newDirection),
                _ => throw new InvalidOperationException()
            };
        })
        .Pipe(final => final.Item1)
        .Pipe(coordinate => Math.Abs(coordinate.X) + Math.Abs(coordinate.Y));

    public static int Part2(AocInput input) => input.Text
        .Split(',', StringSplitOptions.TrimEntries)
        .Select(ParseInstructions)
        .ToArray()
        .Aggregate((new Coordinate(0, 0), Direction.North), (seed, move) =>
        {
            var (coordinate, direction) = seed;
            var intDirection = ((move.Turn == 'R' ? 1 : -1) + (int)direction + 4) % 4;
            var newDirection = (Direction)intDirection;
            return newDirection switch
            {
                Direction.North => (coordinate with { X = coordinate.X + move.Blocks }, newDirection),
                Direction.East => (coordinate with { Y = coordinate.Y - move.Blocks }, newDirection),
                Direction.South => (coordinate with { X = coordinate.X - move.Blocks }, newDirection),
                Direction.West => (coordinate with { Y = coordinate.Y + move.Blocks }, newDirection),
                _ => throw new InvalidOperationException()
            };
        })
        .Pipe(final => final.Item1)
        .Pipe(coordinate => Math.Abs(coordinate.X) + Math.Abs(coordinate.Y));

    private static Move ParseInstructions(string instruction) =>
        new(instruction[0], int.Parse(instruction[1..]));

    private readonly record struct Move(char Turn, int Blocks);

    private readonly record struct Coordinate(int X, int Y);

    private enum Direction
    {
        North,
        East,
        South,
        West
    }
}