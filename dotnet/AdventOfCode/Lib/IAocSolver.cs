namespace AdventOfCode.Lib;

public interface IAocSolver
{
    object PartOne(AocInput input);
    object PartTwo(AocInput input);
}

public static class AocSolverExtensions 
{
    public static int Year(this IAocSolver solver) => Year(solver.GetType());

    public static int Year(Type t) => int.Parse(t.FullName!.Split('.')[1][1..]);

    public static int Day(this IAocSolver solver) => Day(solver.GetType());

    public static int Day(Type t) => int.Parse(t.FullName!.Split('.')[2][3..]);

    public static string WorkingDir(int year, int day) => Path.Combine($"Y{year}", $"Day{day:00}");
}