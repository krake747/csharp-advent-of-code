using System.Text.RegularExpressions;
using AdventOfCodeLib;

namespace AdventOfCode2016;

[AocPuzzle(2016, 1, "No Time for a Taxicab")]
public sealed partial class Day01 : IAocDay<int>
{
    public static int Part1(AocInput input) => input.Text
        .Split(",", StringSplitOptions.TrimEntries)
        .Select(ParseInstructions)
        .ToArray()
        .Aggregate(new Coordinate(0, 0, Direction.North), (coordinate, move) => (move, coordinate) switch
        {
            ({ Turn: 'R', Blocks: var blocks }, { Face: Direction.North } ) => coordinate with { Face = Direction.East, X = coordinate.X + blocks },
            ({ Turn: 'R', Blocks: var blocks }, { Face: Direction.East } ) => coordinate with { Face = Direction.South, Y = coordinate.Y - blocks },
            ({ Turn: 'R', Blocks: var blocks }, { Face: Direction.South } ) => coordinate with { Face = Direction.West, X = coordinate.X - blocks },
            ({ Turn: 'R', Blocks: var blocks }, { Face: Direction.West } ) => coordinate with { Face = Direction.North, Y = coordinate.Y + blocks },
            ({ Turn: 'L', Blocks: var blocks }, { Face: Direction.North } ) => coordinate with { Face = Direction.West, X = coordinate.X - blocks },
            ({ Turn: 'L', Blocks: var blocks }, { Face: Direction.West } ) => coordinate with { Face = Direction.South, Y = coordinate.Y - blocks },
            ({ Turn: 'L', Blocks: var blocks }, { Face: Direction.South } ) => coordinate with { Face = Direction.East, X = coordinate.X + blocks },
            ({ Turn: 'L', Blocks: var blocks }, { Face: Direction.East } ) => coordinate with { Face = Direction.North, Y = coordinate.Y + blocks },
            _ => throw new InvalidOperationException()
        })
        .Pipe(coordinate => Math.Abs(coordinate.X) + Math.Abs(coordinate.Y));

    public static int Part2(AocInput input) => 0;

    private static Move ParseInstructions(string instruction)
    {
        var span = instruction.AsSpan();
        return new Move(char.Parse(span[..1].ToString()), int.Parse(span[1..].ToString()));
    }

    private readonly record struct Move(char Turn, int Blocks);
    
    private readonly record struct Coordinate(int X, int Y, Direction Face);
    
    private enum Direction
    {
        North,
        East,
        South,
        West
    }
}

