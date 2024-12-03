namespace AdventOfCode.Lib;

public interface IAocSolver
{
    object PartOne(AocInput input);
    object PartTwo(AocInput input);
}

public static class AocSolverExtensions 
{
    public static string WorkingDir(int year) => Path.Combine($"Y{year}");

    public static string WorkingDir(int year, int day) => Path.Combine(WorkingDir(year), $"Day{day:00}");
}