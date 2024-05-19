namespace AdventOfCode.Lib;

[AttributeUsage(AttributeTargets.Class)]
public sealed class AocPuzzleAttribute(int year, int day, string name, string lang = "C#") : Attribute
{
    public int Year { get; } = year;
    public int Day { get; } = day;
    public string Name { get; } = name;
    public string Lang { get; } = lang;
}