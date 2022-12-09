using System.Diagnostics;
using AdventOfCodeLib;
using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

[AocPuzzle(2022, 9, "Rope Bridge")]
public class Day09 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        var points = SeriesOfMotions(input).SelectMany(p => p).ToArray();
        return points.Select(point => point.Tail)
            .ToHashSet()
            .Count;
    }

    public int Part2(IEnumerable<string> input)
    {
        return 1;
    }

    private static IEnumerable<(Point Head, Point Tail)[]> SeriesOfMotions(IEnumerable<string> input)
    {
        var motions = input.ToArray();
        var head = new Point(0, 0);
        var tail = new Point(0, 0);
        yield return new[] { (head, tail) };
        foreach (var motion in motions)
        {
            var newPoints = ParseMotions(motion, head, tail).ToArray();
            head = newPoints.Last().Head;
            tail = newPoints.Last().Tail;
            yield return newPoints;
        }
    }

    private static IEnumerable<(Point Head, Point Tail)> ParseMotions(string motion, Point head, Point tail)
    {
        var parts = motion.Split(' ');
        var direction = char.Parse(parts[0]);
        var move = int.Parse(parts[^1]);
        var startHead = head;
        var startTail = tail;
        for (var i = 0; i < move; i++)
        {
            var newHeadPoint = MoveHeadToPoint(startHead, direction);
            var newTailPoint = MoveTailToPoint(newHeadPoint, startTail, direction);
            startHead = newHeadPoint;
            startTail = newTailPoint;
            yield return (newHeadPoint, newTailPoint);
        }
    }

    private static Point MoveHeadToPoint(Point head, char direction)
    {
        return direction switch
        {
            'U' => head with { Y = head.Y + 1 },
            'R' => head with { X = head.X + 1 },
            'D' => head with { Y = head.Y - 1 },
            'L' => head with { X = head.X - 1 },
            _ => throw new UnreachableException("Direction is not defined.")
        };
    }

    private static Point MoveTailToPoint(Point head, Point tail, char direction)
    {
        return Point.AreTouching(head, tail)
            ? tail
            : direction switch
            {
                'U' => head with { Y = head.Y - 1 },
                'R' => head with { X = head.X - 1 },
                'D' => head with { Y = head.Y + 1 },
                'L' => head with { X = head.X + 1 },
                _ => throw new UnreachableException("Direction is not defined.")
            };
    }

    private readonly record struct Point(int X, int Y)
    {
        internal static bool AreTouching(Point p1, Point p2)
        {
            return AreAdjacent(p1, p2) || AreDiagonal(p1, p2);
        }

        private static bool AreAdjacent(Point p1, Point p2)
        {
            var deltaX = p2.X - p1.X;
            var deltaY = p2.Y - p1.Y;
            return (Math.Abs(deltaX) <= 1 && deltaY == 0) || (Math.Abs(deltaY) <= 1 && deltaX == 0);
        }

        private static bool AreDiagonal(Point p1, Point p2)
        {
            var deltaX = p2.X - p1.X;
            var deltaY = p2.Y - p1.Y;
            return Math.Abs(deltaX) == Math.Abs(deltaY);
        }
    }
}

