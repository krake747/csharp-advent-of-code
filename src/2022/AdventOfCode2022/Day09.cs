using System.Diagnostics;
using AdventOfCodeLib;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

[AocPuzzle(2022, 9, "Rope Bridge")]
public class Day09 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        return TailCoordinates(input, 2).ToHashSet().Count;
    }

    public int Part2(IEnumerable<string> input)
    {
        ;
        return 1;
    }

    private static IEnumerable<Knot> TailCoordinates(IEnumerable<string> input, int ropeLength)
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
                var newRope = MoveHead(rope, direction).ToArray();
                yield return newRope.Last();
            }
        }
    }

    private static IEnumerable<Knot> MoveHead(IList<Knot> rope, char direction)
    {
        rope[0] = direction switch
        {
            'U' => rope[0] with { Y = rope[0].Y + 1 },
            'R' => rope[0] with { X = rope[0].X + 1 },
            'D' => rope[0] with { Y = rope[0].Y - 1 },
            'L' => rope[0] with { X = rope[0].X - 1 },
            _ => throw new UnreachableException("Direction is not defined.")
        };
        yield return rope[0];
        
        for (var k = 1; k < rope.Count; k++)
        {
            rope[k] = Knot.AreTouching(rope[k - 1], rope[k])
                ? rope[k]
                : direction switch
                {
                    'U' => rope[k - 1] with { Y = rope[k - 1].Y - 1 },
                    'R' => rope[k - 1] with { X = rope[k - 1].X - 1 },
                    'D' => rope[k - 1] with { Y = rope[k - 1].Y + 1 },
                    'L' => rope[k - 1] with { X = rope[k - 1].X + 1 },
                    _ => throw new UnreachableException("Direction is not defined.")
                };
            yield return rope[k];
        }

    }

    private readonly record struct Knot(int X, int Y)
    {
        internal static bool AreTouching(Knot k1, Knot k2)
        {
            return AreAdjacent(k1, k2) || AreDiagonal(k1, k2);
        }

        private static bool AreAdjacent(Knot k1, Knot k2)
        {
            var deltaX = k2.X - k1.X;
            var deltaY = k2.Y - k1.Y;
            return (Math.Abs(deltaX) <= 1 && deltaY == 0) || (Math.Abs(deltaY) <= 1 && deltaX == 0);
        }

        private static bool AreDiagonal(Knot k1, Knot k2)
        {
            var deltaX = k2.X - k1.X;
            var deltaY = k2.Y - k1.Y;
            return Math.Abs(deltaX) == Math.Abs(deltaY);
        }
    }
}

