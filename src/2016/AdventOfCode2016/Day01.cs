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
        .Pipe(endCoordinate => ManhattanDistance(new Coordinate(0, 0), endCoordinate));

    public static int Part2(AocInput input) => input.Text
        .Split(',', StringSplitOptions.TrimEntries)
        .Select(ParseInstructions)
        .ToArray()
        .Pipe(instructions =>
        {
            var coordinate = new Coordinate(0, 0);
            var direction = Direction.North;
            var visited = new HashSet<Coordinate> { coordinate };
            foreach (var move in instructions)
            {
                var intDirection = ((move.Turn == 'R' ? 1 : -1) + (int)direction + 4) % 4;
                direction = (Direction)intDirection;

                var (x, y) = coordinate;
                var path = Enumerable.Range(1, move.Blocks)
                    .Select(b => direction switch
                    {
                        Direction.North => new Coordinate(x + b, y),
                        Direction.East => new Coordinate(x, y - b),
                        Direction.South => new Coordinate(x - b, y),
                        Direction.West => new Coordinate(x, y + b),
                        _ => throw new InvalidOperationException()
                    })
                    .ToArray();

                foreach (var coord in path)
                {
                    if (visited.Add(coord) is false)
                    {
                        return coord;
                    }
                }

                coordinate = path[^1];
            }

            return coordinate;
        })
        .Pipe(endCoordinate => ManhattanDistance(new Coordinate(0, 0), endCoordinate));

    private static int ManhattanDistance(Coordinate startCoordinate, Coordinate endCoordinate) =>
        Math.Abs(startCoordinate.X - endCoordinate.X) + Math.Abs(startCoordinate.Y - endCoordinate.Y);

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