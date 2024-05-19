using System.Diagnostics;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2022;

[AocPuzzle(2022, 9, "Rope Bridge")]
public sealed class Day09 : IAocDay<int>
{
    public static int Part1(AocInput input) => TailPositions(input.Lines, 2).ToHashSet().Count;

    public static int Part2(AocInput input) => TailPositions(input.Lines, 10).ToHashSet().Count;

    private static IEnumerable<Knot> TailPositions(IEnumerable<string> input, int ropeLength)
    {
        var commands = input.ToArray();
        var rope = Enumerable.Repeat(new Knot(0, 0), ropeLength).ToArray();
        yield return rope.Last();
        foreach (var command in commands)
        {
            var parts = command.Split(' ');
            var direction = char.Parse(parts[0]);
            var move = int.Parse(parts[^1]);
            for (var i = 0; i < move; i++)
            {
                var newRope = MoveHeadOfTheRope(rope, direction).ToArray();
                yield return newRope.Last();
            }
        }
    }

    private static IEnumerable<Knot> MoveHeadOfTheRope(IList<Knot> rope, char direction)
    {
        // Updates the coordinates of the first knot in the rope to reflect the direction in which the head is moving.
        // It then yields this updated knot.
        rope[0] = direction switch
        {
            'U' => rope[0] with { Y = rope[0].Y + 1 },
            'R' => rope[0] with { X = rope[0].X + 1 },
            'D' => rope[0] with { Y = rope[0].Y - 1 },
            'L' => rope[0] with { X = rope[0].X - 1 },
            _ => throw new UnreachableException("Direction is not defined.")
        };
        yield return rope[0];

        // Next, the method loops through the remaining knots in the rope and calculates the change in the x and y
        // coordinates between the current knot and the previous one.
        // If the knots are not touching, the method updates the coordinates of the current knot to be one unit closer
        // to the previous knot in the x and y directions.
        for (var k = 1; k < rope.Count; k++)
        {
            var (deltaX, deltaY) = Knot.Delta(rope[k], rope[k - 1]);
            var moveX = Math.Sign(deltaX);
            var moveY = Math.Sign(deltaY);
            yield return Knot.AreTouching(rope[k - 1], rope[k])
                ? rope[k]
                : rope[k] = new Knot(rope[k].X + moveX, rope[k].Y + moveY);
        }
    }

    private readonly record struct Knot(int X, int Y)
    {
        internal static bool AreTouching(Knot k1, Knot k2)
        {
            var (deltaX, deltaY) = Delta(k1, k2);
            return Math.Abs(deltaX) <= 1 && Math.Abs(deltaY) <= 1;
        }

        internal static (int DeltaX, int DeltaY) Delta(Knot k1, Knot k2) => (k2.X - k1.X, k2.Y - k1.Y);
    }
}