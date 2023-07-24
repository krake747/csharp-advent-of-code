namespace AdventOfCodeLib;

internal readonly record struct Coordinates(int X, int Y)
{
    internal static bool AreTouching(Coordinates c1, Coordinates c2)
    {
        var (deltaX, deltaY) = Delta(c1, c2);
        return Math.Abs(deltaX) <= 1 && Math.Abs(deltaY) <= 1;
    }

    internal static bool AreOverlapping(Coordinates c1, Coordinates c2) => c1 == c2;

    internal static bool AreAdjacent(Coordinates c1, Coordinates c2)
    {
        var (deltaX, deltaY) = Delta(c1, c2);
        return (Math.Abs(deltaX) <= 1 && deltaY == 0) || (Math.Abs(deltaY) <= 1 && deltaX == 0);
    }

    internal static bool AreDiagonal(Coordinates c1, Coordinates c2)
    {
        var (deltaX, deltaY) = Delta(c1, c2);
        return Math.Abs(deltaX) == Math.Abs(deltaY);
    }

    internal static Coordinates Neighbor(Coordinates c, Direction direction)
    {
        return direction switch
        {
            Direction.Up => c with { Y = c.Y + 1 },
            Direction.Down => c with { Y = c.Y - 1 },
            Direction.Right => c with { X = c.X + 1 },
            Direction.Left => c with { X = c.X - 1 },
            _ => c
        };
    }

    internal static bool IsOnGrid<T>(T[,] grid, Coordinates c) =>
        c.Y >= 0 && c.Y < grid.GetLength(0) && c.X >= 0 && c.X < grid.GetLength(1);

    private static (int DeltaX, int DeltaY) Delta(Coordinates c1, Coordinates c2)
    {
        var deltaX = c2.X - c1.X;
        var deltaY = c2.Y - c1.Y;
        return (deltaX, deltaY);
    }
    
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
}