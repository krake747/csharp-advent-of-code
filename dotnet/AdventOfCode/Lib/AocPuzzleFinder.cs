using System.Collections.Frozen;
using System.Reflection;

namespace AdventOfCode.Lib;

public static class AocDayFinder
{
    public static FrozenDictionary<string, Type> FindAocSolvers() =>
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => 
                typeof(IAocSolver).IsAssignableFrom(type) && 
                type.Namespace is not null && 
                type.Namespace.StartsWith("AdventOfCode.Y")
            )
            .ToFrozenDictionary(t => t.FullName!, t => t);
}