namespace AdventOfCodeLib.Models;

public readonly record struct Coordinates(int X, int Y)
{
    public static bool AreTouching(Coordinates c1, Coordinates c2)
    {
        var (deltaX, deltaY) = Delta(c1, c2);
        return Math.Abs(deltaX) <= 1 && Math.Abs(deltaY) <= 1;
    }
    
    public static bool AreOverlapping(Coordinates c1, Coordinates c2)
    {
        return c1 == c2;
    }
    
    public static bool AreAdjacent(Coordinates c1, Coordinates c2)
    {
        var (deltaX, deltaY) = Delta(c1, c2);
        return (Math.Abs(deltaX) <= 1 && deltaY == 0) || (Math.Abs(deltaY) <= 1 && deltaX == 0);
    }

    public static bool AreDiagonal(Coordinates c1, Coordinates c2)
    {
        var (deltaX, deltaY) = Delta(c1, c2);
        return Math.Abs(deltaX) == Math.Abs(deltaY);
    }
    
    private static (int DeltaX, int DeltaY) Delta(Coordinates c1, Coordinates c2)
    {
        var deltaX = c2.X - c1.X;
        var deltaY = c2.Y - c1.Y;
        return (deltaX, deltaY);
    }
}
