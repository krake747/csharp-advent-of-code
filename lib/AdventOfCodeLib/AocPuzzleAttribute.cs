﻿namespace AdventOfCodeLib;

[AttributeUsage(AttributeTargets.Class)]
public class AocPuzzleAttribute : Attribute
{
    public int Year { get; }
    public int Day { get; }
    public string Name { get; }
    
    public AocPuzzleAttribute(int year, int day, string name)
    {
        Year = year;
        Day = day;
        Name = name;
    }
}