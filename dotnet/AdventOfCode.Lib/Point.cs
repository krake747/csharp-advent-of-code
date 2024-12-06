using System.Numerics;

namespace AdventOfCode.Lib;

public readonly record struct Point(int X, int Y)
    : IAdditionOperators<Point, Point, Point>, IMultiplyOperators<Point, Point, Point>,
        IMultiplyOperators<Point, int, Point>
{
    public static readonly Point North = new(0, -1); // Move up
    public static readonly Point NorthEast = new(1, -1); // Move diagonally up-right
    public static readonly Point East = new(1, 0); // Move right
    public static readonly Point SouthEast = new(1, 1); // Move diagonally down-right
    public static readonly Point South = new(0, 1); // Move down
    public static readonly Point SouthWest = new(-1, 1); // Move diagonally down-left
    public static readonly Point West = new(-1, 0); // Move left
    public static readonly Point NorthWest = new(-1, -1); // Move diagonally up-left

    private static readonly Point RotationClockwise90 = new(0, 1);
    
    public static Point operator +(Point p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);
    public static Point operator *(Point p1, Point p2) => new(p1.X * p2.X - p1.Y * p2.Y, p1.X * p2.Y + p1.Y * p2.X);
    public static Point operator *(Point p, int factor) => new(p.X * factor, p.Y * factor);
    
    public static Point RotateRight(Point p) => p * RotationClockwise90; // new(-Y, X)
}