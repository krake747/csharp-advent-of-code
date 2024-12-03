namespace AdventOfCode.Lib;

[AttributeUsage(AttributeTargets.Class)]
public sealed class AocPuzzleAttribute(int year, int day, string name, params string[] langs) : Attribute
{
    public int Year { get; } = year;
    public int Day { get; } = day;
    public string Name { get; } = name;
    public string[] Langs { get; } = langs;
}